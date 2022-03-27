using System.IO;
using System.Text.Json;

namespace SynthLipN
{
    public class SLip
    {
        public PrjInfo? info { get; set; }
        public Skins? Sks { get; set; }
        public bool GenInfo(string jsontxt)
        {
            if (!jsontxt.Contains("#SYNTHLIP INFO"))
                return false;
            else
                jsontxt = jsontxt[jsontxt.IndexOf("{")..];
            try
            {
                info = JsonSerializer.Deserialize<PrjInfo>(jsontxt);
                if (info != null)
                {
                    System.Diagnostics.Debug.Print(string.Format("{0}", info.NoteCount));
                    jsontxt = jsontxt[(jsontxt.IndexOf("}") + 1)..];
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return true;
        }

        public bool InitializeNotes()
        {
            if (info == null)
                return false;
            Note init = new();
            init.Phn = new List<string>();
            init.Phn.Add("sil");
            init.Scl = new List<float>();
            init.Scl.Add(1);
            init.Pit = 0;
            init.Num = 1;
            init.Lrc = "(init)";
            init.Dur = info.Notes[0].Ons;
            init.Ons = 0;
            info.Notes.Insert(0, init);
            for (int i = 1; i < info.Notes.Count; i++)
            {
                if (Math.Abs(info.Notes[i].Ons - info.Notes[i - 1].Ons - info.Notes[i - 1].Dur) > 1/25)
                {
                    Note sil = new();
                    sil.Phn = new List<string>();
                    sil.Phn.Add("sil");
                    sil.Scl = new List<float>();
                    sil.Scl.Add(1);
                    sil.Pit = 0;
                    sil.Num = 1;
                    sil.Lrc = "(sil)";
                    sil.Dur = (float)Math.Round(info.Notes[i].Ons - info.Notes[i - 1].Ons - info.Notes[i - 1].Dur, 4, MidpointRounding.AwayFromZero);
                    sil.Ons = info.Notes[i - 1].Ons + info.Notes[i - 1].Dur;
                    info.Notes.Insert(i, sil);
                    i++;
                }
                continue;
            }
            return true;
        }

        public bool ReadSkin(string skinjson, string filename)
        {
            Sks = JsonSerializer.Deserialize<Skins>(skinjson);

            if (Sks == null)
                return false;

            Sks.BasePath = Path.GetDirectoryName(filename) + "\\";

            foreach (var key in Sks.Dics)
            {
                Sks.Additem(key.Phn, key.Type, key.Src);
            }
            return true;
        }

        public bool GenPhones()
        {
            try
            {
                if (info == null)
                    return false;
                info.metas = new List<MetaPhn>();

                MetaPhn? meta0 = new();
                meta0.PhnName = "sil|(Init)";
                meta0.PhnOnset = 0;
                meta0.PhnSource = Sks.GetSrc("sil");
                meta0.PhnType = Sks.GetType("sil");
                meta0.PhnPath = Sks.BasePath + meta0.PhnSource + ".png";
                info.metas.Insert(0, meta0);
                meta0 = null;
                for (int i = 1; i < info.Notes.Count; i++)
                {
                    var item = info.Notes[i];
                    var idx = 0;
                    foreach (var phn in item.Phn)
                    {
                        idx++;
                        MetaPhn tmpmeta = new();
                        tmpmeta.PhnName = string.Format("{0}|{1}", item.Phn[idx - 1], item.Lrc);
                        tmpmeta.PhnOnset = item.Ons + (idx - 1) * item.Dur / item.Num;
                        tmpmeta.PhnDuration = -tmpmeta.PhnOnset;

                        // tmpmeta.PhnDuration = item.Dur / item.Num;
                        tmpmeta.PhnSource = Convert.ToString(Sks.GetSrc(phn)[0]);
                        if (tmpmeta.PhnType == "continue" || tmpmeta.PhnSource == "-")
                        {
                            tmpmeta.PhnSource = info.metas[info.metas.Count - 1].PhnSource;
                        }
                        tmpmeta.PhnType = Sks.GetType(phn);
                        tmpmeta.PhnPath = Sks.BasePath + tmpmeta.PhnSource + ".png";

                        info.metas[info.metas.Count - 1].PhnDuration += tmpmeta.PhnOnset;
                        var tmpphn = info.metas[info.metas.Count - 1].PhnName.Split("|")[0];
                        if (Sks.GetType(tmpphn) != "vowel" && Sks.GetType(tmpphn) != "diphthong" && Sks.GetType(tmpphn) != "silence" && Sks.GetType(tmpphn) != "continue")
                        {
                            info.metas[info.metas.Count - 1].PhnDuration /= 2;
                            tmpmeta.PhnOnset = info.metas[info.metas.Count - 1].PhnOnset + info.metas[info.metas.Count - 1].PhnDuration;
                            tmpmeta.PhnDuration += info.metas[info.metas.Count - 1].PhnDuration;
                        }
                        info.metas.Add(tmpmeta);
                    }
                }

                info.metas[info.metas.Count - 1].PhnDuration = 1;

                /*foreach (var item in info.metas)
                {
                    if (item.PhnSource.Length == 1)
                        continue ;
                    var idx = item.PhnSource.Length;
                    List<MetaPhn> tmpcol = new List<MetaPhn>();
                    item.PhnDuration /= idx;
                    tmpcol.Add(item);
                    foreach (char ch in item.PhnSource)
                    {
                        MetaPhn tmpmeta = new();
                        tmpmeta = item;
                        tmpmeta.PhnDuration /= idx;
                        tmpmeta.PhnSource = Convert.ToString(ch);
                        tmpmeta.PhnPath = Sks.BasePath + tmpmeta.PhnSource + ".png";
                        tmpmeta.PhnOnset = tmpcol[tmpcol.Count - 2].PhnOnset + tmpcol[tmpcol.Count - 2].PhnDuration;
                        tmpcol.Add(tmpmeta);
                    }
                }*/

                return true;
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                return false;
            }
        }
    }
}

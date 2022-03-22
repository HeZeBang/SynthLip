using System.Text.Json;

namespace SynthLipN
{
    public class PrjInfo
    {
        public string? PrjName { get; set; }
        public string? PrjPath { get; set; }
        public ulong EditTime { get; set; }
        public int NoteCount { get; set; }
        public int ScriptVersion { get; set; }
        public int Track { get; set; }
        public string? TrackName { get; set; }

        public List<Note>? Notes { get; set; }

        public List<MetaPhn>? metas { get; set; }

    }

    public class MetaPhn
    {
        public string? PhnName { get; set; }
        public string? PhnPath { get; set; }
        public float PhnOnset { get; set; }
        public float PhnDuration { get; set; }
        public string? PhnType { get; set; }
        public string? PhnSource { get; set; }
    }

    public class SLip
    {
        public PrjInfo? info { get; set; }
        public Boolean GenInfo(string jsontxt)
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

        public Boolean Initialize()
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
                if (Math.Abs(info.Notes[i].Ons - info.Notes[i - 1].Ons - info.Notes[i - 1].Dur) > 0.25)
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
    }
}

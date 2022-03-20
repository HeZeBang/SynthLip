using System.Text.Json;

namespace SynthLipN
{
    public partial class Form1 : Form
    {
        #region 欢迎辞
        /*
         * 明知山有虎，偏向虎山行
         * 感谢dalao光临寒舍！
         * 这个代码写的狗屁不通，但是它运行起来了！
         * WinForm将会被遗弃
         * 希望有大佬能够整个WPF或者跨平台GTK#也行啊哭www（
         * ——ZAMBAR
         */
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        PrjInfo? info;
        Skins? Sks;
        private void Button1_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (!clip.Contains("#SYNTHLIP INFO"))
                return;
            else
                clip = clip[clip.IndexOf("{")..];
            try
            {
                info = JsonSerializer.Deserialize<PrjInfo>(clip);
                if (info != null)
                {
                    System.Diagnostics.Debug.Print(string.Format("{0}", info.NoteCount));
                    this.Text = string.Format("Loaded Project: {0}", info.PrjName);
                    clip = clip[(clip.IndexOf("}") + 1)..];
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                    System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (info == null)
                return;

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

            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Notes", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Phoneme", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Onset", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Duration", 120, HorizontalAlignment.Left);
            this.listView1.BeginUpdate();
            foreach (var item in info.Notes)
            {
                ListViewItem i = new();
                i.Text = item.Lrc;
                string otp = "";
                foreach (string p in item.Phn)
                    otp += p + " ";
                i.SubItems.Add(otp);
                i.SubItems.Add(string.Format("{0}", item.Ons));
                i.SubItems.Add(string.Format("{0}", item.Dur));
                this.listView1.Items.Add(i);
                //System.Diagnostics.Debug.WriteLine(otp);

            }
            this.listView1.EndUpdate();
        }




        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (info == null)
                    return;
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


                this.listView2.Clear();
                this.listView2.Columns.Add("Phoneme", 120, HorizontalAlignment.Left);
                this.listView2.Columns.Add("Onset", 120, HorizontalAlignment.Left);
                this.listView2.Columns.Add("Duration", 120, HorizontalAlignment.Left);
                this.listView2.Columns.Add("Source", 120, HorizontalAlignment.Left);
                this.listView2.Columns.Add("Type", 120, HorizontalAlignment.Left);
                this.listView2.Columns.Add("Path", 500, HorizontalAlignment.Left);
                this.listView2.BeginUpdate();
                foreach (var item in info.metas)
                {
                    ListViewItem i = new();
                    i.Text = item.PhnName;
                    i.SubItems.Add(Convert.ToString(/*item.PhnOnset*/Math.Round(item.PhnOnset * 1, 2, MidpointRounding.AwayFromZero)));
                    i.SubItems.Add(Convert.ToString(/*item.PhnDuration*/Math.Round(item.PhnDuration * 1, 2, MidpointRounding.AwayFromZero)));
                    i.SubItems.Add(item.PhnSource);
                    i.SubItems.Add(item.PhnType);
                    i.SubItems.Add(item.PhnPath);
                    this.listView2.Items.Add(i);
                }
                this.listView2.EndUpdate();
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    this.toolStripStatusLabel1.Text = ex.Message;
                    
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            System.Diagnostics.Debug.WriteLine(clip);
            DicPhone dictmp = new();
            string nclip = "[";
            for (int i = 0; ; i++, nclip += ",\n")
            {
                if (clip.Contains(','))
                {
                    string[] str = clip.Split(',');
                    str[2] = str[2][..str[2].IndexOf('\n')];
                    dictmp.Phn = str[0];
                    dictmp.Type = str[1];
                    dictmp.Src = str[2];
                    nclip += JsonSerializer.Serialize<DicPhone>(dictmp);
                    clip = clip[(clip.IndexOf('\n') + 1)..];
                }
                else
                    break;
            }

            try
            {
                nclip = nclip[..nclip.LastIndexOf(',')];
                nclip += "]";
                Clipboard.SetText(nclip);

                string test = string.Format("\"SkinName\":\"template\",\n\"Dics\":{0}", nclip);
                test = "{" + test + "}";
                System.Diagnostics.Debug.WriteLine(test);

                Sks = JsonSerializer.Deserialize<Skins>(test);
                this.Text = Sks.Dics[0].Phn;

                this.textBox1.Text = test;
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    this.toolStripStatusLabel1.Text = ex.Message;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var ret = this.saveFileDialog1 = new();
                ret.CheckPathExists = true;
                ret.Filter = "FCP5 XML文件|.xml";
                ret.FileName = info.TrackName;
                ret.Title = "保存时间线/序列";
                var result = this.saveFileDialog1.ShowDialog();

                Output otp = new();

                this.textBox2.Text = otp.OutputFile("test", info, Sks);

                if (result == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, this.textBox2.Text);
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    this.toolStripStatusLabel1.Text = ex.Message;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ofd = this.openFileDialog1 = new();
            ofd.InitialDirectory = System.Environment.CurrentDirectory + "\\Skin";
            var result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.textBox1.Text = File.ReadAllText(ofd.FileName);

                Sks = JsonSerializer.Deserialize<Skins>(this.textBox1.Text);

                Sks.BasePath = Path.GetDirectoryName(ofd.FileName) + "\\";

                foreach (var key in Sks.Dics)
                {
                    Sks.Additem(key.Phn, key.Type, key.Src);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string msg = "作者自述——————————————\n" +
                "欢迎使用SynthLip\n" +
                "这个程序不基于任何神经网络，而是基于口型表直接通过音素生成口型（摊手）\n" +
                "本着既然我调教不好，就帮别人调教好的精神，开发了这一款小工具┑(￣Д ￣)┍\n" +
                "使用愉快~\n" +
                "——ZAMBAR\n";
            msg += "主程序信息————————————\n" +
                String.Format("程序集版本：{0}\n", 
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            msg += "皮肤信息——————————————\n";
            if (Sks != null)
                msg += string.Format("皮肤名称：{0}\n作者：{1}\n画师：{2}\n更新信息：{3}\n路径：{4}\n适用语言：{5}\n",
                    Sks.SkinName, Sks.Author, Sks.Illustrator, Sks.Update, Sks.BasePath, Sks.Lang);
            else
                msg += "未加载\n";
            msg += "工程信息——————————————\n";
            if (info != null)
                msg += string.Format("工程名称：{0}\n工程路径：{1}\n生成时间：{2}\n音符数：{3}\n口型轨道：#{4} - {5}\n脚本版本：{6}\n",
                    info.PrjName, info.PrjPath, info.EditTime, info.NoteCount, info.Track, info.TrackName, info.ScriptVersion);
            else
                msg += "未加载\n";
            MessageBox.Show(msg);
        }



        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
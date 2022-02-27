using System.Text.Json;

namespace SynthLipN
{
    public partial class Form1 : Form
    {
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

            this.listView1.Columns.Clear();
            this.listView1.Columns.Add("Notes", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Phoneme", 120, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Onset", 120, HorizontalAlignment.Left);
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
                this.listView1.Items.Add(i);
                //System.Diagnostics.Debug.WriteLine(otp);

            }
            this.listView1.EndUpdate();
        }



        Dictionary<string, string> phokey = new();
        private void Button3_Click(object sender, EventArgs e)
        {
            Sks = JsonSerializer.Deserialize<Skins>(this.textBox1.Text);
            foreach (var key in Sks.Dics)
            {
                if (!phokey.ContainsKey(key.Phn))
                {
                    phokey.Add(key.Phn, key.Src);
                }
            }

            this.listView2.Columns.Add("Phoneme", 120, HorizontalAlignment.Left);
            this.listView2.Columns.Add("Onset", 120, HorizontalAlignment.Left);
            this.listView2.Columns.Add("Source", 120, HorizontalAlignment.Left);
            this.listView2.BeginUpdate();
            foreach (var item in info.Notes)
            {
                var idx = 0;
                foreach (var phones in item.Phn)
                {
                    idx++;
                    ListViewItem i = new();
                    i.Text = phones;
                    i.SubItems.Add(Convert.ToString(item.Ons + idx * item.Dur / item.Num));
                    i.SubItems.Add(phokey[phones]);
                    this.listView2.Items.Add(i);
                }
            }
            this.listView2.EndUpdate();
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
                this.Text = ex.Message;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ret = this.saveFileDialog1 = new();
            ret.CheckPathExists = true;
            ret.Filter = "FCP5 XM (.xml)|.xml";
            ret.FileName = info.TrackName;
            ret.Title = "保存时间线/序列";
            var result = this.saveFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                var filepath = ret.FileName.ToString();
                System.IO.FileStream fs = (System.IO.FileStream)ret.OpenFile();
                //fs.wr;
                fs.Close();
            }
            Output otp = new();

            MessageBox.Show(otp.OutputFile("test",info));

        }
    }
}
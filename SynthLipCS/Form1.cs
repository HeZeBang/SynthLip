using System.Text.Json;

namespace SynthLipCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PrjInfo? info;
        Skins? Sks;
        private void button1_Click(object sender, EventArgs e)
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
                if(ex != null)
                    System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if(info == null)
                return ;

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
                i.SubItems.Add(string.Format("{0}",item.Ons));
                this.listView1.Items.Add(i);
                //System.Diagnostics.Debug.WriteLine(otp);
                
            }
            this.listView1.EndUpdate();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            System.Diagnostics.Debug.WriteLine(clip);
            DicPhone dictmp = new();
            string nclip = "[";
            for (int i = 0; ; i ++, nclip += ",\n")
            {
                if (clip.Contains(','))
                {
                    string[] str = clip.Split(',');
                    str[2]=str[2].Substring(0, str[2].IndexOf('\n'));
                    dictmp.Phn = str[0];
                    dictmp.Type = str[1];
                    dictmp.Src = str[2] + ".jpg";
                    nclip += JsonSerializer.Serialize<DicPhone>(dictmp);
                    clip = clip[(clip.IndexOf('\n') + 1)..];

                }
                else
                    break;
            }

            nclip = nclip.Substring(0, nclip.LastIndexOf(','));
            nclip += "]";
            Clipboard.SetText(nclip);

            string test = string.Format("\"SkinName\":\"template\",\n\"Dics\":{0}",nclip);
            test = "{" + test + "}";
            System.Diagnostics.Debug.WriteLine(test);

            try
            {
                Sks = JsonSerializer.Deserialize<Skins>(test);
                this.Text = Sks.Dics[0].Phn;
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }

    }
}
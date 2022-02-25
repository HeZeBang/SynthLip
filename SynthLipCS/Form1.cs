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
        private int timeaxis = 0, head = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            timeaxis = 0;
            _ = Program.Beep(Convert.ToInt32(440 * Math.Pow(2, (info.Notes[head].Pit - 69) / 2)), Convert.ToInt32(Math.Floor(info.Notes[head].Dur)));
        }

    }
}
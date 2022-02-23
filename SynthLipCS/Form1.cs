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
            string clip = Clipboard.GetText(), meta;
            if (!clip.Contains("#SYNTHLIP INFO"))
                return;
            else
                clip = clip.Substring(clip.IndexOf("{"));
            /*try*/
            {
                info = JsonSerializer.Deserialize<PrjInfo>(clip);
                if (info != null)
                {
                    System.Diagnostics.Debug.Print(string.Format("{0}",info.NoteCount));
                    this.Text = string.Format("Loaded Project: {0}", info.PrjName);
                    clip = clip.Substring(clip.IndexOf("}") + 1);
                }
            }
            /*catch (Exception ex)
            {
                if(ex != null)
                    System.Diagnostics.Debug.WriteLine(ex.Message);
            }*/
            
        }
    }
}
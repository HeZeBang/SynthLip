using System.Text.Json;

namespace SynthLipCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clip = Clipboard.GetText();
            if (!clip.Contains("#SYNTHLIP INFO"))
                return;
            else
                clip = clip.Substring(clip.IndexOf("{"), clip.IndexOf("}") - clip.IndexOf("{") + 1);

            try
            {
                PrjInfo? info = JsonSerializer.Deserialize<PrjInfo>(clip);

                if (info != null)
                    System.Diagnostics.Debug.Print(info.PrjName);
            }
            catch (Exception ex)
            {
                if(ex != null)
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
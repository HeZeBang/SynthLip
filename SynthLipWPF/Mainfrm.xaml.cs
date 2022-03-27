using System.Windows;

namespace SynthLipWPF
{
    /// <summary>
    /// Mainfrm.xaml 的交互逻辑
    /// </summary>
    public partial class Mainfrm : Window
    {
        public Mainfrm()
        {
            InitializeComponent();
        }
        SLip? program = new();
        private void FrmInit(object sender, RoutedEventArgs e)
        {
            About(this, e);
        }
        private void Climport(object sender, RoutedEventArgs e)
        {
            program = null;
            program = new();

            if (!program.GenInfo(System.Windows.Clipboard.GetText()))
                return;
            program.InitializeNotes();

            this.noteView.Items.Clear();
            foreach (var item in program.info.Notes)
            {
                string otp = "";
                foreach (string p in item.Phn)
                    otp += p + " ";
                this.noteView.Items.Add(new { item, otp });
            }
        }

        private void Skimport(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new();
            ofd.Filter = "Slip Json文件|*.json|所有文件|*.*";
            ofd.InitialDirectory = System.Environment.CurrentDirectory + "\\Skin";
            var result = ofd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                program.ReadSkin(File.ReadAllText(ofd.FileName), ofd.FileName);
            }
        }

        private void Phogen(object sender, RoutedEventArgs e)
        {
            try
            {
                program.GenPhones();
                metaView.Items.Clear();
                foreach (var item in program.info.metas)
                    metaView.Items.Add(item);
                //metaView.Effect.BeginAnimation(RenderTransformProperty, DoubleAnimation());


            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        private void OutputSeq(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog ret = new();
            ret.CheckPathExists = true;
            ret.Filter = "FCP5 XML文件|.xml";
            ret.Title = "保存时间线/序列";
            try
            {
                ret.FileName = program.info.TrackName;
                var result = ret.ShowDialog();

                Output otp = new();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    File.WriteAllText(ret.FileName, otp.OutputFile("test", program.info, program.Sks));
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }
        private void About(object sender, RoutedEventArgs e)
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
            if (program.Sks != null)
                msg += string.Format("皮肤名称：{0}\n作者：{1}\n画师：{2}\n更新信息：{3}\n路径：{4}\n适用语言：{5}\n",
                    program.Sks.SkinName, program.Sks.Author, program.Sks.Illustrator, program.Sks.Update, program.Sks.BasePath, program.Sks.Lang);
            else
                msg += "未加载\n";
            msg += "工程信息——————————————\n";
            if (program.info != null)
                msg += string.Format("工程名称：{0}\n工程路径：{1}\n生成时间：{2}\n音符数：{3}\n口型轨道：#{4} - {5}\n脚本版本：{6}\n",
                    program.info.PrjName, program.info.PrjPath, program.info.EditTime, program.info.NoteCount, program.info.Track, program.info.TrackName, program.info.ScriptVersion);
            else
                msg += "未加载\n";
            this.aboutlabel.Content = msg;
        }

        private void Refreshbut_Click(object sender, RoutedEventArgs e)
        {
            About(sender, e);
        }

        private async void Chkupdbut_Click(object sender, RoutedEventArgs e)
        {
            Version cur = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string[] upd = new string[2] { "https://gitee.com/api/v5/repos/ZAMBAR/SynthLip/releases/latest?access_token=482349e28844f06020d44ff4cf83d579", "https://api.github.com/repos/HeZeBang/SynthLip/releases/latest" };

            System.Net.WebClient wc = new();
            wc.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wc.Encoding = System.Text.Encoding.UTF8;
            wc.Headers.Add("User-Agent: Other");
            try
            {
                string ret = wc.DownloadString(upd[this.UrlSrccomb.SelectedIndex]);
                System.Text.Json.JsonDocument jdoc = System.Text.Json.JsonDocument.Parse(ret);
                string lver = jdoc.RootElement.GetProperty("tag_name").ToString().Replace("v", "");
                Version latest = new Version(lver);
                if (latest > cur)
                    Updlabel.Content = string.Format("发现新版本 - {0}\n更新标题：{1}\n创建时间：{2}\n更新内容：\n{3}", lver, jdoc.RootElement.GetProperty("created_at"), jdoc.RootElement.GetProperty("name"),  jdoc.RootElement.GetProperty("body"));
                else
                    Updlabel.Content = string.Format("SynthLip 已是最新版本\n更新标题 - {0}", jdoc.RootElement.GetProperty("name"));

            }
            catch (Exception ex)
            {
                Updlabel.Content = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void deval(string json)
        {

        }
    }
}

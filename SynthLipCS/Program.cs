using System.Runtime.InteropServices;

namespace SynthLipCS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        [DllImport("kernel32.dll", EntryPoint = "Beep")]
        public static extern int Beep(
            int dwFreq,
            int dwDuration
            );

    }
}
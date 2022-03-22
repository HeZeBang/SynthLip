using System;

namespace SynthLipConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SynthLipCore");
            
            SLip program = new SLip();

            do
            {
                Console.Write("Slip>");
                string s = Console.ReadLine();
                args = s.Split(' ');
                
            } while (args[0] != "exit");
        }
    }

}

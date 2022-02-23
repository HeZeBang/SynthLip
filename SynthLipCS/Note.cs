using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLipCS
{
    public class Note
    {
        public string? Lrc { get; set; }
        public double Ons { get; set; }
        public double Dur { get; set; }
        public int Num { get; set; }
        public string[]? Phn { get; set; }
        public double[]? Scl { get; set; }
        public int Pit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLipCS
{
    public class Note
    {
        public string? lrc { get; set; }
        public double ons { get; set; }
        public double dur { get; set; }
        public int num { get; set; }
        public string[]? phn { get; set; }
        public double[]? scl { get; set; }
        public int pit { get; set; }
    }
}

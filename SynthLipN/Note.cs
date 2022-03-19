namespace SynthLipN
{
    public class Note
    {
        public string? Lrc { get; set; }
        public float Ons { get; set; }
        public float Dur { get; set; }
        public int Num { get; set; }
        public List<string>? Phn { get; set; }
        public List<float>? Scl { get; set; }
        public int Pit { get; set; }
    }
}

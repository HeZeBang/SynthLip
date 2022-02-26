namespace SynthLipN
{
    public class PrjInfo
    {
        public string? PrjName { get; set; }
        public string? PrjPath { get; set; }
        public ulong EditTime { get; set; }
        public int NoteCount { get; set; }
        public int ScriptVersion { get; set; }
        public int Track { get; set; }
        public string? TrackName { get; set; }

        public Note[]? Notes { get; set; }

    }
}

namespace SynthLipWPF
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

        public List<Note>? Notes { get; set; }

        public List<MetaPhn>? metas { get; set; }

    }

    public class MetaPhn
    {
        public string? PhnName { get; set; }
        public string? PhnPath { get; set; }
        public float PhnOnset { get; set; }
        public float PhnDuration { get; set; }
        public string? PhnType { get; set; }
        public string? PhnSource { get; set; }
    }

}

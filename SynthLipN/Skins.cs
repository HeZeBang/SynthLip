namespace SynthLipN
{
    public class Skins
    {
        Dictionary<string, string>? phokey = new();
        Dictionary<string, string>? photype = new();
        public string? SkinName { get; set; }
        public string? Author { get; set; }
        public string? Illustrator { get; set; }
        public string? Update { get; set; }
        public string? BasePath { get; set; }
        public string? Lang { get; set; }

        public Boolean Additem(string item, string type, string source)
        {
            if (!phokey.ContainsKey(item) && !photype.ContainsKey(item))
            {
                phokey.Add(item, source);
                photype.Add(item, type);
            }
            return true;
        }

        public string GetSrc(string item)
        {
            return phokey[item];
        }
        public string GetType(string item)
        {
            return photype[item];
        }
        public DicPhone[]? Dics { get; set; }

    }
    public class DicPhone
    {

        public string? Phn { get; set; }
        public string? Type { get; set; }
        public string? Src { get; set; }

    }
}

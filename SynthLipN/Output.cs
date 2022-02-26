using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLipN
{
    internal class Output
    {
public string OutputFile(string Title, PrjInfo info)
        {
            xmlformat.Root xmlstr = new();
            
            xmlstr.@version = "5";
            xmlstr.sequence.@id = Title;
            xmlstr.sequence.name = Title + "_Timeline";
            xmlstr.sequence.duration = "250";
            xmlstr.sequence.rate.ntsc = "FALSE";
            xmlstr.sequence.rate.timebase = "25";
            xmlstr.sequence.timecode.rate = xmlstr.sequence.rate;
            xmlstr.sequence.timecode.string_ = "01:00:00:00";
            xmlstr.sequence.timecode.frame = "90000";
            xmlstr.sequence.timecode.source = "source";
            xmlstr.sequence.timecode.displayformat = "displayformat";
            xmlstr.sequence.in_ = "0";
            xmlstr.sequence.out_ = "250";
            xmlstr.sequence.width = "1920";
            xmlstr.sequence.height = "1080";

            xmlformat.MediaItem item = new();
            xmlstr.sequence.media.Add(item);

            return "";
        }
    }
}

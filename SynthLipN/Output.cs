using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace SynthLipN
{
    public class Output
    {
public string OutputFile(string Title, PrjInfo info)
        {
            xmlformat.Root xmlstr = new();
            List<xmlformat.MediaItem> mdit = new();
            string templatestring = "{\"@version\":\"5\",\"sequence\":{\"@id\":\"序列\",\"updatebehavior\":\"add\",\"name\":\"序列\",\"duration\":\"250\",\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"timecode\":{\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"string_\":\"01:00:00:00\",\"frame\":\"90000\",\"source\":\"source\",\"displayformat\":\"NDF\"},\"in_\":\"0\",\"out_\":\"250\",\"width\":\"1920\",\"height\":\"1080\",\"media\":[{\"format\":[{\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"width\":\"1920\",\"height\":\"1080\",\"pixelaspectratio\":\"Square\",\"anamorphic\":\"FALSE\"}],\"track\":[{\"enabled\":\"TRUE\",\"locked\":\"FALSE\"},{\"clipitem\":[{\"@id\":\"Subtitle_IMG_0000.png\",\"name\":\"Subtitle_IMG_0000.png\",\"duration\":\"3251\",\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"in_\":\"1500\",\"out_\":\"1500\",\"start\":\"0\",\"end\":\"0\",\"pixelaspectratio\":\"Square\",\"stillframe\":\"TRUE\",\"anamorphic\":\"FALSE\",\"alphatype\":\"straight\",\"masterclipid\":\"Subtitle_IMG_0000.png1\",\"file\":{\"@id\":\"Subtitle_IMG_0000\",\"name\":\"Subtitle_IMG_0000.png\",\"pathurl\":\"D:/Users/ZAMBAR/Desktop/subtitle/Subtitle_IMG_0000.png\",\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"duration\":\"2\",\"width\":\"1920\",\"height\":\"1080\",\"media\":[{\"duration\":\"2\",\"stillframe\":\"TRUE\",\"samplecharacteristics\":{\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"width\":\"1920\",\"height\":\"1080\",\"pixelaspectratio\":\"Square\",\"anamorphic\":\"FALSE\"}}]},\"sourcetrack\":[\"video\"],\"fielddominance\":\"none\"}],\"enabled\":\"TRUE\",\"locked\":\"FALSE\"}]}],\"ismasterclip\":\"FALSE\"}}";
            xmlstr = JsonSerializer.Deserialize<xmlformat.Root>(templatestring);
            templatestring = "[{\"format\":[{\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"width\":\"1920\",\"height\":\"1080\",\"pixelaspectratio\":\"Square\",\"anamorphic\":\"FALSE\"}],\"track\":[{\"enabled\":\"TRUE\",\"locked\":\"FALSE\"},{\"clipitem\":[{\"@id\":\"Subtitle_IMG_0000.png\",\"name\":\"Subtitle_IMG_0000.png\",\"duration\":\"3251\",\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"in_\":\"1500\",\"out_\":\"1500\",\"start\":\"0\",\"end\":\"0\",\"pixelaspectratio\":\"Square\",\"stillframe\":\"TRUE\",\"anamorphic\":\"FALSE\",\"alphatype\":\"straight\",\"masterclipid\":\"Subtitle_IMG_0000.png1\",\"file\":{\"@id\":\"Subtitle_IMG_0000\",\"name\":\"Subtitle_IMG_0000.png\",\"pathurl\":\"D:/Users/ZAMBAR/Desktop/subtitle/Subtitle_IMG_0000.png\",\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"duration\":\"2\",\"width\":\"1920\",\"height\":\"1080\",\"media\":[{\"duration\":\"2\",\"stillframe\":\"TRUE\",\"samplecharacteristics\":{\"rate\":{\"ntsc\":\"FALSE\",\"timebase\":\"25\"},\"width\":\"1920\",\"height\":\"1080\",\"pixelaspectratio\":\"Square\",\"anamorphic\":\"FALSE\"}}]},\"sourcetrack\":[\"video\"],\"fielddominance\":\"none\"}]";
            //mdit = JsonSerializer.Deserialize<List<xmlformat.MediaItem>>(templatestring);
            //xmlstr.sequence.media = mdit;
            /*xmlstr.@version = "5";
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
            xmlstr.sequence.height = "1080";*/

            //xmlformat.MediaItem item = new();
            //item = 
            //xmlstr.sequence.media.Add(item);

            var str2 = "";

            StringWriter stringWriter = new();
            System.Xml.Serialization.XmlSerializerNamespaces ns = new();
            ns.Add("", "");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(xmlformat.Root));
            serializer.Serialize(stringWriter, xmlstr, ns);
            string otp = Convert.ToString(stringWriter).Replace("_", "");
            return otp;
        }
    }
}

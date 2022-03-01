using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;

namespace SynthLipN
{
    public class Output
    {
public string OutputFile(string Title, PrjInfo info)
        {
            /* The classs2xml-output mode have been abandoned */

            xmlformat.Root xmlstr = new();
            string templatestring = ""
 + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n"
 + "<!DOCTYPE xmeml>\n"
 + "\n"
 + "<xmeml version=\"5\">\n"
 + "  <sequence id=\"序列\">\n"
 + "    <updatebehavior>add</updatebehavior>\n"
 + "    <name>序列</name>\n"
 + "    <duration>125</duration>\n"
 + "    <rate>\n"
 + "      <ntsc>FALSE</ntsc>\n"
 + "      <timebase>25</timebase>\n"
 + "    </rate>\n"
 + "    <timecode>\n"
 + "      <rate>\n"
 + "        <ntsc>FALSE</ntsc>\n"
 + "        <timebase>25</timebase>\n"
 + "      </rate>\n"
 + "      <string>01:00:00:00</string>\n"
 + "      <frame>90000</frame>\n"
 + "      <source>source</source>\n"
 + "      <displayformat>NDF</displayformat>\n"
 + "    </timecode>\n"
 + "    <in>0</in>\n"
 + "    <out>125</out>\n"
 + "    <width>1920</width>\n"
 + "    <height>1080</height>\n"
 + "    <media>\n"
 + "      <video>\n"
 + "        <format>\n"
 + "          <samplecharacteristics>\n"
 + "            <rate>\n"
 + "              <ntsc>FALSE</ntsc>\n"
 + "              <timebase>25</timebase>\n"
 + "            </rate>\n"
 + "            <width>1920</width>\n"
 + "            <height>1080</height>\n"
 + "            <pixelaspectratio>Square</pixelaspectratio>\n"
 + "            <anamorphic>FALSE</anamorphic>\n"
 + "          </samplecharacteristics>\n"
 + "        </format>\n"
 + "        <track>\n"
 + "          <enabled>TRUE</enabled>\n"
 + "          <locked>FALSE</locked>\n"
 + "        </track>\n"
 + "        <track>\n"
 + "          <clipitem id=\"Subtitle_IMG_0001.png\">\n"
 + "            <!--loop-->\n"
 + "            <name>Subtitle_IMG_0001.png</name>\n"
 + "            <duration>3251</duration>\n"
 + "            <rate>\n"
 + "              <ntsc>FALSE</ntsc>\n"
 + "              <timebase>25</timebase>\n"
 + "            </rate>\n"
 + "            <in>1500</in>\n"
 + "            <out>1538</out>\n"
 + "            <start>8</start>\n"
 + "            <end>46</end>\n"
 + "            <pixelaspectratio>Square</pixelaspectratio>\n"
 + "            <stillframe>TRUE</stillframe>\n"
 + "            <anamorphic>FALSE</anamorphic>\n"
 + "            <alphatype>straight</alphatype>\n"
 + "            <masterclipid>Subtitle_IMG_0001.png1</masterclipid>\n"
 + "            <file id=\"Subtitle_IMG_0001\">\n"
 + "              <name>Subtitle_IMG_0001.png</name>\n"
 + "              <pathurl>C:/Users/NYTV/Documents/Arctime%20Documents/Subtitle_IMG_0001.png</pathurl>\n"
 + "              <rate>\n"
 + "                <ntsc>FALSE</ntsc>\n"
 + "                <timebase>25</timebase>\n"
 + "              </rate>\n"
 + "              <duration>2</duration>\n"
 + "              <width>1920</width>\n"
 + "              <height>1080</height>\n"
 + "              <media>\n"
 + "                <video>\n"
 + "                  <duration>2</duration>\n"
 + "                  <stillframe>TRUE</stillframe>\n"
 + "                  <samplecharacteristics>\n"
 + "                    <rate>\n"
 + "                      <ntsc>FALSE</ntsc>\n"
 + "                      <timebase>25</timebase>\n"
 + "                    </rate>\n"
 + "                    <width>1920</width>\n"
 + "                    <height>1080</height>\n"
 + "                    <pixelaspectratio>Square</pixelaspectratio>\n"
 + "                    <anamorphic>FALSE</anamorphic>\n"
 + "                  </samplecharacteristics>\n"
 + "                </video>\n"
 + "              </media>\n"
 + "            </file>\n"
 + "            <sourcetrack>\n"
 + "              <mediatype>video</mediatype>\n"
 + "            </sourcetrack>\n"
 + "            <fielddominance>none</fielddominance>\n"
 + "          </clipitem>\n"
 + "          <enabled>TRUE</enabled>\n"
 + "          <locked>FALSE</locked>\n"
 + "        </track>\n"
 + "      </video>\n"
 + "    </media>\n"
 + "    <ismasterclip>FALSE</ismasterclip>\n"
 + "  </sequence>\n"
 + "</xmeml>\n";

            byte[] vs = Encoding.UTF8.GetBytes(templatestring);
            MemoryStream ms = new MemoryStream(vs);
            XElement ele =  XElement.Load(ms);
            ele.Element("sequence")
                .Add(new XElement("assest", new XAttribute("id", "r7"), new XAttribute("name", "Subtitle")));
            //xmlstr = 
            //xmlstr = JsonSerializer.Deserialize<xmlformat.Root>(templatestring);
            //xmlstr.sequence.media = mdit;
            /*xmlstr.fcpxml.
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
            xmlstr.sequence.height = "1080";*/

            //xmlformat.MediaItem item = new();
            //item = 
            //xmlstr.sequence.media.Add(item);

            /*var str2 = "";

            StringWriter stringWriter = new();
            System.Xml.Serialization.XmlSerializerNamespaces ns = new();
            ns.Add("", "");
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(xmlformat.Root));
            serializer.Serialize(stringWriter, xmlstr, ns);
            //string otpjson = JsonSerializer.Serialize<xmlformat.Root>(xmlstr);
            string otp = Convert.ToString(stringWriter).Replace("_", "");*/

            //string head = "";
            var reader = ele.CreateWriter();
            reader.Close();
            return reader;
        }
    }
}

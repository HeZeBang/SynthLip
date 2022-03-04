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

            #region init_test_str
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
                 /*+ "          <clipitem id=\"Subtitle_IMG_0001.png\">\n"
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
                 + "          </clipitem>\n"*/
                 + "          <enabled>TRUE</enabled>\n"
                 + "          <locked>FALSE</locked>\n"
                 + "        </track>\n"
                 + "      </video>\n"
                 + "    </media>\n"
                 + "    <ismasterclip>FALSE</ismasterclip>\n"
                 + "  </sequence>\n"
                 + "</xmeml>\n";
            #endregion

            byte[] vs = Encoding.UTF8.GetBytes(templatestring);
            MemoryStream ms = new MemoryStream(vs);
            XElement ele =  XElement.Load(ms);
            
            


            string id = "Subtitle_IMG_0001", ftype = ".png";
            int timebase = 25, start = 0, dur = 48;
            #region addelement
            ele.Element("sequence")
                .Element("media")
                .Element("video")
                .Elements("track").ElementAt(1)
                .AddFirst(new XElement("clipitem", new XAttribute("id", id + ftype),
                    new XElement("name", id + ftype),
                    new XElement("duration", dur),    //一个整数，以帧数为单位指定持续时间。
                    new XElement("rate",    //对时间刻度进行编码，以解释剪辑、序列、时间码或其他组件的时间值。
                        new XElement("ntsc", "FALSE"),  //指定 NTSC 速率降低的布尔值。
                        new XElement("timebase", timebase)),    //一个整数，指定帧速率的时间基。
                    new XElement("in", 1500 + start),   //一个整数，指定开始时间。
                    new XElement("out", 1500 + start + dur - 1),  //指定结束时间的整数。
                    new XElement("start", start),   //一个整数，指定轨道中剪辑的相对起点。
                    new XElement("end", start + dur - 1),    //一个整数，指定轨道中剪辑的相对终点。
                    /*
                     * 注意：在 Final Cut Pro 中，elements的 out 与 end 和 in / start 的计时值的计算方式不同。
                     * 要计算或解释 start 和 in 的值，Final Cut 会将第一帧编号为帧 0。另一方面，要计算或解释 out 和 end 的值，Final Cut 会将第一帧编号为第 1 帧。换句话说，Final Cut 在计算或解释这些元素的值时使用两种不同的序号编号方案。
                     */
                    new XElement("pixelaspectratio", "Square"),
                    new XElement("stillframe", "TRUE"),
                    new XElement("anamorphic", "FALSE"),
                    new XElement("alphatype", "straight"),
                    new XElement("masterclipid", id + ".png1"),
                    new XElement("file", new XAttribute("id", id),
                        new XElement("name", id + ftype),
                        new XElement("pathurl", "C:/Users/NYTV/Documents/" + id + ftype),
                        new XElement("rate",
                            new XElement("ntsc", "FALSE"),
                            new XElement("timebase", timebase)
                            ),
                        new XElement("duration", 2),
                        new XElement("width", 1920),
                        new XElement("height", 1080),
                        new XElement("media",
                            new XElement("video",
                                new XElement("duration", 2),
                                new XElement("stillframe", "TRUE"),
                                new XElement("samplecharacteristics",
                                    new XElement("rate",
                                        new XElement("ntsc", "FALSE"),
                                        new XElement("timebase", timebase)),
                                    new XElement("width", 1920),
                                    new XElement("height", 1080),
                                    new XElement("pixelaspectratio", "Square"),
                                    new XElement("anamorphic", "FALSE")
                                    )
                               )
                            )
                        ),
                    new XElement("sourcetrack",
                        new XElement("mediatype", "video")
                        ),
                    new XElement("fielddominance", "none")
                    ));
            #endregion
            
            return "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>\n"
                    + "<!DOCTYPE xmeml>\n\n"
                    + ele.ToString();
        }
    }
}

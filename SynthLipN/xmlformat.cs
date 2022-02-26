using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLipN
{
    internal class xmlformat
    {
        public class Rate
        {
            /// <summary>
            /// 
            /// </summary>
            public string ntsc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string timebase { get; set; }
        }

        public class Timecode
        {
            /// <summary>
            /// 
            /// </summary>
            public Rate rate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string string_ { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string frame { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string source { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string displayformat { get; set; }
        }

        public class Rate_
        {
            /// <summary>
            /// 
            /// </summary>
            public string ntsc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string timebase { get; set; }
        }

        public class FormatItem
        {
            /// <summary>
            /// 
            /// </summary>
            public Rate rate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string width { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string height { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pixelaspectratio { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string anamorphic { get; set; }
        }

        public class TrackItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string enabled { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string locked { get; set; }
        }

        public class MediaItem
        {
            /// <summary>
            /// 
            /// </summary>
            public List<FormatItem> format { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<TrackItem> track { get; set; }
        }

        public class Sequence
        {
            /// <summary>
            /// XML字幕序列
            /// </summary>
            public string @id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string updatebehavior { get; set; }
            /// <summary>
            /// XML字幕序列_25.0p_Subtitle
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Rate rate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Timecode timecode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string in_ { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string out_ { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string width { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string height { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<MediaItem> media { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string ismasterclip { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string @version { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Sequence sequence { get; set; }
        }
    }
}

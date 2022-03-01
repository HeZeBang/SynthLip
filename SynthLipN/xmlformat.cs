using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthLipN
{
    public class xmlformat
    {
        /* This Class will no longer in support due to its bad behave in xml performing.*/
        public class FormatItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string _id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _frameDuration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _width { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _height { get; set; }
        }

        public class AssetItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string _id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _src { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _start { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _hasVideo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _format { get; set; }
        }

        public class Resources
        {
            /// <summary>
            /// 
            /// </summary>
            public List<FormatItem> format { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<AssetItem> asset { get; set; }
        }

        public class VideoItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string _name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _lane { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _offset { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _ref { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _start { get; set; }
        }

        public class Gap
        {
            /// <summary>
            /// 
            /// </summary>
            public string _offset { get; set; }
            /// <summary>
            /// 空隙
            /// </summary>
            public string _name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _start { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<VideoItem> video { get; set; }
        }

        public class Spine
        {
            /// <summary>
            /// 
            /// </summary>
            public Gap gap { get; set; }
        }

        public class Sequence
        {
            /// <summary>
            /// 
            /// </summary>
            public string _duration { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _format { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _tcStart { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _tcFormat { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _audioLayout { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _audioRate { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Spine spine { get; set; }
        }

        public class Project
        {
            /// <summary>
            /// XML字幕序列
            /// </summary>
            public string _name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Sequence sequence { get; set; }
        }

        public class @event
        {
            /// <summary>
            /// 
            /// </summary>
            public string _name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string _uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Project project { get; set; }
        }

        public class Library
        {
            /// <summary>
            /// 
            /// </summary>
            public string _location { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public @event @event { get; set; }
        }

        public class Fcpxml
        {
            /// <summary>
            /// 
            /// </summary>
            public string _version { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Resources resources { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Library library { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public Fcpxml fcpxml { get; set; }
        }
    }
}

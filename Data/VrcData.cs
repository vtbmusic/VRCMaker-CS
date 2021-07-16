using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VRCMaker.Controllers;

namespace VRCMaker
{
    /**
     * Vrc数据
     */
    public class VrcData
    {
        /**
         * 歌词数据
         */
        public class Lyric
        {
            public int Version { get; }
            public string Text { get; set; }

            public Lyric()
            {
                Text = "";
                Version = Configs.GetVrcVersion();
            }
        }
        

        public bool Karaoke { get; set; }
        public bool ScrollDisabled { get; set; }
        public bool Translated { get; set; }
        public Lyric Origin { get; }
        public Lyric Translate { get; }

        public VrcData()
        {
            Karaoke = false;
            ScrollDisabled = false;
            Translated = false;
            Origin = new Lyric();
            Translate = new Lyric();
        }

        public JObject ToJsonObject()
        {
            return new JObject
            {
                ["karaoke"] = Karaoke,
                ["scrollDisabled"] = ScrollDisabled,
                ["translated"] = Translated,
                ["origin"] = new JObject
                {
                    ["version"] = Origin.Version,
                    ["text"] = Origin.Text
                },
                ["translate"] = new JObject
                {
                    ["version"] = Translate.Version,
                    ["text"] = Translate.Text
                }
            };
        }

        public override string ToString()
        {
            return ToJsonObject().ToString();
        }

        public string ToString(Formatting fmt, params JsonConverter[] converters)
        {
            return ToJsonObject().ToString(fmt, converters);
        }

        public bool Save(string path)
        {
            try
            {
                var sw = new StreamWriter(path);
                sw.Write(ToString());
                sw.Flush();
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Save failed!");
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
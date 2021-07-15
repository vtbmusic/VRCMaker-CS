using System;
using System.IO;
using Newtonsoft.Json;

namespace VRCMaker
{
    /**
     * Vrc数据
     */
    public class Vrc
    {
        /**
         * 歌词数据
         */
        public class Kashi
        {
            public Kashi()
            {
                text = "";
                version = Config.Version;
            }

            public int version { get; set; }
            public string text { get; set; }
        }

        public bool karaoke { get; set; }
        public bool scrollDisabled { get; set; }
        public bool translated { get; set; }
        public Kashi origin { get; }
        public Kashi translate { get; }

        public Vrc()
        {
            karaoke = false;
            scrollDisabled = false;
            translated = false;
            origin = new Kashi();
            translate = new Kashi();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
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
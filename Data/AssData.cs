using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VRCMaker
{
    /// <summary>
    /// Ass字幕文件数据
    /// </summary>
    public class AssData
    {
        private string[] _fmt;

        private readonly List<Dictionary<string, string>> _vrcMapList;

        private bool _translated;

        /// <summary>
        /// Vrc数据
        /// </summary>
        public readonly VrcData VrcData;

        private AssData()
        {
            _vrcMapList = new List<Dictionary<string, string>>();
            VrcData = new VrcData();
        }


        /// <summary>
        /// 读取.ass文件并返回AssData
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>生成的AssData</returns>
        /// <exception cref="ArgumentException">文件名不以.ass结尾</exception>
        public static AssData ParseAssFile(string path)
        {
            var data = new AssData();
            if (!path.EndsWith(".ass")) throw new ArgumentException("File name must end with .ass");
            try
            {
                var sr = new StreamReader(path);
                while (sr.ReadLine() != "[Events]") ;
                var tmp = sr.ReadLine()?.Replace(" ", "").Replace("Format:", "") ?? "";
                data._fmt = tmp.Split(',');
                while ((tmp = sr.ReadLine()) != null)
                {
                    if (tmp.Contains(@"\N")) data._translated = true;
                    if (tmp.StartsWith("[")) break;
                    if (!tmp.StartsWith("Dialogue: ")) continue;
                    var values = tmp.Replace("Dialogue: ", "").Split(',');
                    var map = new Dictionary<string, string>();
                    for (var i = 0; i < data._fmt.Length; i++)
                    {
                        map.Add(data._fmt[i], values[i]);
                    }

                    data._vrcMapList.Add(map);
                }

                data.VrcData.karaoke = false;
                data.VrcData.scrollDisabled = false;
                data.VrcData.translated = data._translated;

                var sb1 = new StringBuilder();
                var sb2 = new StringBuilder();
                foreach (var map in data._vrcMapList)
                {
                    var kashi = map["Text"];
                    var time = "[" + map["Start"] + "]";
                    if (data._translated)
                    {
                        var tranStr = kashi.Split(new[] {@"\N"}, StringSplitOptions.None);
                        sb1.Append(time).Append(tranStr[0]).Append("\n");
                        sb2.Append(time).Append(tranStr[1].Replace(@"\N", "")).Append("\n");
                    }
                    else
                    {
                        sb1.Append(time).Append(kashi).Append("\n");
                    }
                }

                data.VrcData.origin.text = sb1.ToString();
                data.VrcData.translate.text = data._translated ? sb2.ToString() : "";
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
                throw;
            }

            return data;
        }
    }
}
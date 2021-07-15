using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCMaker
{
    class Configs
    {

        private static string GetConfig(string key) 
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetConfig(string key, string value)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings[key].Value = value;
            cfa.Save();
        }

        public static bool GetLyricScrollBarBind()
        {
            return Convert.ToBoolean(value: GetConfig("LyricScrollBarBind"));
        }

        public static int GetVrcVersion()
        {
            return Convert.ToInt32(value: GetConfig("VrcVersion"));
        }

        public static void SetLyricScrollBarBind(bool v)
        {
            SetConfig("LyricScrollBarBind", Convert.ToString(v));
        }

        public static void SetVrcVersion(bool v)
        {
            SetConfig("VrcVersion", Convert.ToString(v));
        }

    }
}

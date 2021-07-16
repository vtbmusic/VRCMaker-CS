using System;
using System.Configuration;

namespace VRCMaker.Controllers
{
    public static class Configs
    {
        private static readonly Lazy<Configuration> LazyCfg =
            new Lazy<Configuration>(() => ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));

        private static Configuration Cfg => LazyCfg.Value;

        private static string GetConfig(string key)
        {
            lock (Cfg)
            {
                return Cfg.AppSettings.Settings[key].Value;
            }
        }

        private static void SetConfig(string key, string value)
        {
            lock (Cfg)
            {
                Cfg.AppSettings.Settings[key].Value = value;
                Cfg.Save();
            }
        }

        public static bool GetLyricScrollBarBind(bool defValue = false)
        {
            try
            {
                return Convert.ToBoolean(GetConfig("LyricScrollBarBind"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return defValue;
            }
        }

        public static int GetVrcVersion(int defValue = 2)
        {
            try
            {
                return Convert.ToInt32(GetConfig("VrcVersion"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return defValue;
            }
        }

        public static void SetLyricScrollBarBind(bool v)
        {
            SetConfig("LyricScrollBarBind", Convert.ToString(v));
        }

        public static void SetVrcVersion(int v)
        {
            SetConfig("VrcVersion", Convert.ToString(v));
        }
    }
}
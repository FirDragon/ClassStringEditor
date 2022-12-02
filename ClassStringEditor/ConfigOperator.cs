using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStringEditor
{
    internal static class ConfigOperator
    {
        public static string KEY_JDK_PATH = "JdkPath";
        public static string KEY_NONE = "None";
        private static Configuration? _config = null;
        public static Configuration Config
        {
            get
            {
                if (_config == null)
                    _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                return _config;
            }
        }
        public static string GetValue(string key)
        {
            return Config.AppSettings.Settings[key]?.Value ?? string.Empty;
        }
        public static void SetValue(string key, string value)
        {
            if (Config.AppSettings.Settings[key] != null)
                Config.AppSettings.Settings[key].Value = value;
            else
                Config.AppSettings.Settings.Add(key, value);
        }
        public static void Save(ConfigurationSaveMode mode = ConfigurationSaveMode.Modified)
        {
            Config.Save(mode);
        }
    }
}

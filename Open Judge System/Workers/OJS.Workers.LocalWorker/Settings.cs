﻿namespace OJS.Workers.LocalWorker
{
    using System;
    using System.Configuration;

    using log4net;

    public static class Settings
    {
        private static readonly ILog Logger;

        static Settings()
        {
            Logger = LogManager.GetLogger("Settings");
        }

        public static string CSharpCompilerPath
        {
            get
            {
                return GetSetting("CSharpCompilerPath");
            }
        }

        public static string CPlusPlusGccCompilerPath
        {
            get
            {
                return GetSetting("CPlusPlusGccCompilerPath");
            }
        }

        public static string MsBuildExecutablePath
        {
            get
            {
                return GetSetting("MsBuildExecutablePath");
            }
        }

        public static string NodeJsExecutablePath
        {
            get
            {
                return GetSetting("NodeJsExecutablePath");
            }
        }

        public static string JavaCompilerPath
        {
            get
            {
                return GetSetting("JavaCompilerPath");
            }
        }

        public static string JavaExecutablePath
        {
            get
            {
                return GetSetting("JavaExecutablePath");
            }
        }

        public static int ThreadsCount
        {
            get
            {
                return GetSettingOrDefault("ThreadsCount", 2);
            }
        }

        private static string GetSetting(string settingName)
        {
            if (ConfigurationManager.AppSettings[settingName] == null)
            {
                Logger.FatalFormat("{0} setting not found in App.config file!", settingName);
                throw new Exception(string.Format("{0} setting not found in App.config file!", settingName));
            }

            return ConfigurationManager.AppSettings[settingName];
        }

        private static T GetSettingOrDefault<T>(string settingName, T defaultValue)
        {
            if (ConfigurationManager.AppSettings[settingName] == null)
            {
                return defaultValue;
            }

            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[settingName], typeof(T));
        }
    }
}

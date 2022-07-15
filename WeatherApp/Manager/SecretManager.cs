using System;
using System.IO;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Manager
{
    public class SecretManager
    {
        #region private Variables
        private static SecretManager _settingManager;
        private readonly string AppName = "WeatherApp";
        private readonly string FileName = "secret.json";

        #endregion

        #region Properties
        public static SecretManager Setting
        {
            get 
            { 
                if(_settingManager is null)
                    _settingManager = new SecretManager();
                return _settingManager; 
            }
        }
        public Secret Secret { get; set; }
        #endregion

        #region Constructor
        private SecretManager() 
        {
            Secret = LoadSecret(GetSecretFilePath());
        }
        #endregion

        private string GetSecretFilePath()
        {
            string targetPath = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppName, FileName);
            if(!File.Exists(targetPath))
                File.Create(targetPath);
            return targetPath;
        }

        private static Secret LoadSecret(string secretFilePath)
        {
            string secretjsonfile;
            secretjsonfile = File.ReadAllText(secretFilePath);
            var secret = JsonConvert.DeserializeObject<Secret>(secretjsonfile);
            return secret;
        }
    }
}

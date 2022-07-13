using System.IO;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Helper
{
    public class SecretHelper
    {
        public static Secret LoadSecret(string secretFilePath)
        {
            string secretjsonfile;
            secretjsonfile = File.ReadAllText(secretFilePath);
            var secret = JsonConvert.DeserializeObject<Secret>(secretjsonfile);
            return secret;

        }
    }
}

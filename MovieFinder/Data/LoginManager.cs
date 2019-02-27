using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MovieFinder.Data
{
    public class LoginManager
    {
        public static string GetAuthToken(string loginFilePath)
        {
            string apiKey = GetApiKey(loginFilePath);
            return Login(apiKey, loginFilePath);
        }

        private static string GetApiKey(string loginFilePath)
        {
            if (!File.Exists(loginFilePath))
            {
                throw new InvalidOperationException("The API key has not been set.");
            }

            using (var reader = new StreamReader(loginFilePath))
            {
                return reader.ReadToEnd();
            }
        }


        private static string Login(string apiKey, string loginPath)
        {
            var client = new HttpClient();
            var jsonObject = new
            {
                apikey = GetApiKey(loginPath),
                userkey = "216914200274590C",
                username = "b270552@mvrht.net"
            };

            var content = new StringContent(JsonConvert.SerializeObject(jsonObject), Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = client.PostAsync("https://api.thetvdb.com/login", content).Result;
            var response = result.Content.ReadAsStringAsync().Result;
            var resultJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(response)["token"];
            return resultJson;
        }
    }
}
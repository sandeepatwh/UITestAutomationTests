using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace UiAutomationFramework.Helper
{
   
        public class AppSettings : IAppSetting
        {
            public string Email => InitConfiguration()["email"];
            public string BaseUrl => InitConfiguration()["url"];
            public string Password => InitConfiguration()["password"];

            public IConfiguration InitConfiguration()
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                return config;
            }


        }

        public interface IAppSetting
        {
            string Email { get; }
            string BaseUrl { get; }
            string Password { get; }
        }
}


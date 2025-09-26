using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBankingExercise.Configurations
{
   
    //   https://localhost:7055/api/GameStuff
    public class ApplicationSettings
    {
        public string ServerName { get; set; }
        public int Port { get; set; }
        public string BaseRoute { get; set; }

        public string ServiceUrl { get; set; }

        public ApplicationSettings()
        {
            ServerName = "localhost";

#if DEBUG

            if (DeviceInfo.Platform == DevicePlatform.Android)
                ServerName = "10.0.2.2";
#endif

            Port = 7258;
            BaseRoute = "api";
            ServiceUrl = $"https://{ServerName}:{Port}/{BaseRoute}";
        }

    }
}


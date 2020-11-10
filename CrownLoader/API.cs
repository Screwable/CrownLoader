using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CrownLoader
{
    public class API
    {
        private const string URL = "https://sebrandt1.github.io/";

        public static async Task<string> RequestVersion()
        {
            using (WebClient client = new WebClient())
            {
                return await client.DownloadStringTaskAsync(URL + "Client.txt");
            }
        }

        public static async void DownloadClient()
        {
            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(new Uri("https://github.com/sebrandt1/sebrandt1.github.io/raw/master/CrownClient.dll"), @"CrownClient\CrownClient.dll");
                Log.Message(LogType.Success, "Successfully downloaded CrownClient.dll from web!");
            }
        }
    }
}

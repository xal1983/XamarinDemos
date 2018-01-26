using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public static class ServerLink
    {
        static HttpClient cli;
        static HttpClient GetClient()
        {
            if (cli == null)
            {
                //cli = new HttpClient(new NativeMessageHandler());
                cli = new HttpClient();
                cli.BaseAddress = new Uri("http://surfacexal/SICAP.WebEndpoint/api/");
            }
            return cli;
        }

        public static async Task<T> GetDataAsync<T>(string url)
        {

            var result =  await GetClient().GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<T>(result);
            return data;
        }


    
    }
}

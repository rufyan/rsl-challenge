using Newtonsoft.Json;
using rsl_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class theLott
    {
        //Async tasks that hit theLott api endpoints

        static HttpClient client = new HttpClient();
        static LotteryResultsList lottery = new LotteryResultsList();
        static DrawsList draw = new DrawsList();

        public static LotteryResultsList GetLotteryResultsList()
        {
            RunAsync("lotteryresults").GetAwaiter().GetResult();
            return lottery;
        }

        public static DrawsList GetOpenDrawList()
        {
            RunAsync("opendraw").GetAwaiter().GetResult();
            return draw;
        }

        static async Task RunAsync(string datatype)
        {
            //TODO: use config keys for endpoints
            switch (datatype) {
                case "lotteryresults":
                    // Get latest results results
                    lottery = await GetLatestResultsAsync("https://data.api.thelott.com/sales/vmax/web/data/lotto/latestresults");
                    break;
                case "opendraw":
                    //Get open draws
                    draw = await GetOpenDrawsAsync("https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws");
                    break;
            }
        }

        static async Task<LotteryResultsList> GetLatestResultsAsync(string path)
        {
            LotteryResultsList results = null;
            //TODO: Change to variable/dynamic format
            var values = new Dictionary<string, string>
                {
                    { "CompanyId", "Tattersalls" },
                    { "MaxDrawCountPerProduct", "2" }
                    //,{ "OptionalProductFilter", "[\"Pools\"]" }
                };
            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\": [\"Tattslotto\"]}";
            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<LotteryResultsList>();
            }
            //TODO: Handle error
            return results;
        }

        static async Task<DrawsList> GetOpenDrawsAsync(string path)
        {
            DrawsList results = null;
            //TODO: Change to variable/dynamic format
            var values = new Dictionary<string, string>
                {
                    { "CompanyId", "Tattersalls" },
                    { "MaxDrawCountPerProduct", "2" }
                    //,{ "OptionalProductFilter", "[\"Pools\"]" }
                };
            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            //Hit the api with Post method
            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                //Convert results to object
                results = await response.Content.ReadAsAsync<DrawsList>();
            }
            return results;
        }
    }
}

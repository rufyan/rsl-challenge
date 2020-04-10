using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using rsl_challenge.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class LotteryService
    {
        private const string Url = "https://data.api.thelott.com/sales/vmax/web/data/lotto";

        static readonly HttpClient client = new HttpClient();
        static LotteryResultsList _lottery = new LotteryResultsList();
        static DrawsList _draw = new DrawsList();
        static HttpResponseMessage _response = new HttpResponseMessage();

        //public static LotteryResultsList GetLotteryResultsList()
        //{
        //    RunAsync("lotteryresults").GetAwaiter().GetResult();

        //    return lottery;
        //}

        //public static DrawsList GetOpenDrawList()
        //{
        //    DrawsList results = null;
        //    GetApiResponse("opendraw").GetAwaiter().GetResult();
        //    if (_response.IsSuccessStatusCode)
        //    {
        //        results = _response.Content.ReadAsAsync<DrawsList>();
        //    }
        //    return results;
        //}

        //async static Task<T> GetApiResponse(string endpointtype)
        //{
        //    string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\": [\"Tattslotto\"]}";
        //    var content = new StringContent(str, Encoding.UTF8, "application/json");

        //    _response = await client.PostAsync($"{Url}/{endpointtype}", content);


        //}

        public static LotteryResultsList GetLotteryResultsList() =>
            GetApiResultsAsync<LotteryResultsList>($"{Url}/latestresults").GetAwaiter().GetResult();

        public static DrawsList GetOpenDrawList() =>
            GetApiResultsAsync<DrawsList>($"{Url}/opendraws").GetAwaiter().GetResult();

        private static async Task<T> GetApiResultsAsync<T>(string path) where T : class, IDrawsList, ILotteryResultsList
        {
            T results = null;
            //TODO: Change to variable/dynamic format
            var values = new Dictionary<string, string>
                {
                    { "CompanyId", "Tattersalls" },
                    { "MaxDrawCountPerProduct", "2" }
                    //,{ "OptionalProductFilter", "[\"Pools\"]" }
                };
            var str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\": [\"Tattslotto\"]}";
            var jsonString = JsonConvert.SerializeObject(values);
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var response = await client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<T>();
            }
            return results;
        }

        //Async tasks that hit theLott api endpoints
        //async static Task RunAsync(string endpointtype)
        //{
        //    //Get path from appsettings.json
        //    switch (endpointtype)
        //    {
        //        case "lotteryresults":
        //            // Get latest results results
        //            lottery = await GetLatestResultsAsync(Url + "/latestresults");
        //            break;
        //        case "opendraw":
        //            //Get open draws
        //            draw = await GetOpenDrawsAsync(Url + "/opendraws");
        //            break;
        //    }
        //}

        //async static Task<LotteryResultsList> GetLatestResultsAsync(string path)
        //{
        //    LotteryResultsList results = null;
        //    string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\": [\"Tattslotto\"]}";
        //    var content = new StringContent(str, Encoding.UTF8, "application/json");

        //    HttpResponseMessage response = await client.PostAsync(path, content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        results = await response.Content.ReadAsAsync<LotteryResultsList>();
        //    }
        //    return results;
        //}

        //async static Task<DrawsList> GetOpenDrawsAsync(string path)
        //{
        //    DrawsList results = null;
        //    //TODO - add a MemoryCache or similar to store response data
        //    //TODO - pass CompanyId and OptionalProductFilters through as json object
        //    string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
        //    //Attempting to get GoldLotto using GoldenCasket 
        //    //string str = "{ \"CompanyId\": \"GoldenCasket\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"GoldLotto\", \"Powerball\"]}";

        //    var content = new StringContent(str, Encoding.UTF8, "application/json");

        //    //Hit the api with Post method
        //    HttpResponseMessage response = await client.PostAsync(path, content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //Convert results to object
        //        results = await response.Content.ReadAsAsync<DrawsList>();
        //    }
        //    return results;
        //}
    }
}

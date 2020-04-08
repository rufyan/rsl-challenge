using Microsoft.Extensions.Configuration;
using rsl_challenge.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class theLott : ItheLott
    {
        private readonly IConfiguration _config;
        public theLott(IConfiguration config)
        {
            _config = config;
        }

        HttpClient client = new HttpClient();
        LotteryResultsList lottery = new LotteryResultsList();
        DrawsList draw = new DrawsList();

        public LotteryResultsList GetLotteryResultsList()
        {
            RunAsync("lotteryresults").GetAwaiter().GetResult();
            return lottery;
        }

        public DrawsList GetOpenDrawList()
        {
            RunAsync("opendraw").GetAwaiter().GetResult();
            return draw;
        }

        //Async tasks that hit theLott api endpoints
        async Task RunAsync(string endpointtype)
        {
            var path = _config.GetValue<string>("Endpoint:Root");
            switch (endpointtype) {
                case "lotteryresults":
                    // Get latest results results
                    lottery = await GetLatestResultsAsync(string.Concat(path + _config.GetValue<string>("Endpoint:LatestResults")));
                break;
                case "opendraw":
                    //Get open draws
                    draw = await GetOpenDrawsAsync(string.Concat(path + _config.GetValue<string>("Endpoint:OpenDraws")));
                break;
            }
        }

         async Task<LotteryResultsList> GetLatestResultsAsync(string path)
        {
            LotteryResultsList results = null;
            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\": [\"Tattslotto\"]}";
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(path, content);
            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<LotteryResultsList>();
            }
            return results;
        }

         async Task<DrawsList> GetOpenDrawsAsync(string path)
        {
            DrawsList results = null;
            //TODO - pass CompanyId and OptionalProductFilters through as json object
            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
            //Attempting to get GoldLotto using GoldenCasket 
            //string str = "{ \"CompanyId\": \"GoldenCasket\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"GoldLotto\", \"Powerball\"]}";

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

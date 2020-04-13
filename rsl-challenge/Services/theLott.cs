using Newtonsoft.Json;
using rsl_challenge.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class ApiQuery {
        public string CompanyId { get; set; }
        public string MaxDrawCountPerProduct { get; set; }
        public List<string> OptionalProductFilter { get; set; }
    }
    public class LotteryService
    {
        private const string Url = "https://data.api.thelott.com/sales/vmax/web/data/lotto";
        private static List<string> defaultProducts = new List<string> {
            "OzLotto", "TattsLotto", "Powerball"
        };

        static readonly HttpClient client = new HttpClient();

        public static LotteryResultsList GetLotteryResultsList(string productId) =>
            GetApiResultsAsync<LotteryResultsList>($"{Url}/latestresults", productId).GetAwaiter().GetResult();

        public static DrawsList GetOpenDrawList() =>
            GetApiResultsAsync<DrawsList>($"{Url}/opendraws", string.Empty).GetAwaiter().GetResult();

        //Hit the Lott Api
        private static async Task<T> GetApiResultsAsync<T>(string path, string productId) where T : class, ILottery
        {
            var apiQuery = new ApiQuery
            {
                CompanyId = "Tattersalls",
                MaxDrawCountPerProduct = "2",
                OptionalProductFilter = defaultProducts
            };
            if (!string.IsNullOrEmpty(productId)){
                apiQuery.OptionalProductFilter = new List<string> { productId };
            }
            var jsonString = JsonConvert.SerializeObject(apiQuery);
            T results = null;
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var client = new HttpClient();
            var response = await client.PostAsync(path, content);

            if (response.IsSuccessStatusCode)
            {
                results = await response.Content.ReadAsAsync<T>();
            }
            return results;
        }
    }
}

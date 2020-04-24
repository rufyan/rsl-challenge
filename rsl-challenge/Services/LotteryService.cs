using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using rsl_challenge.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class LotteryService : ILotteryService
    {
        private readonly IConfiguration _config;
        private readonly string _url;
        private string[] _defaultProducts;
        private string _companyId;

        public LotteryService(IConfiguration config)
        {
            _config = config;
            _url = _config.GetValue<string>("Endpoint:Root");
            _defaultProducts = _config.GetSection("DefaultProducts").GetChildren().Select(c => c.Value).ToArray();
            _companyId = _config.GetValue<string>("CompanyId");
        }

        static readonly HttpClient client = new HttpClient();

        public  LotteryResultsList GetLotteryResultsList(string productId) =>
            GetApiResultsAsync<LotteryResultsList>($"{_url}/{_config.GetValue<string>("Endpoint:LatestResults")}", productId).GetAwaiter().GetResult();

        public  DrawsList GetOpenDrawList() =>
            GetApiResultsAsync<DrawsList>($"{_url}/{_config.GetValue<string>("Endpoint:OpenDraws")}", string.Empty).GetAwaiter().GetResult();

        //Hit the Lott Api
        public async Task<T> GetApiResultsAsync<T>(string path, string productId) where T : class, ILottery
        {

        var apiQuery = new ApiQuery
            {
                CompanyId = _companyId,
                MaxDrawCountPerProduct = "2",
                OptionalProductFilter = _defaultProducts
            };
            if (!string.IsNullOrEmpty(productId)){
                apiQuery.OptionalProductFilter = new string[] { productId };
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

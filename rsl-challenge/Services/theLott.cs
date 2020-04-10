using rsl_challenge.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace rsl_challenge.Services
{
    public class LotteryService
    {
        private const string Url = "https://data.api.thelott.com/sales/vmax/web/data/lotto";

        static readonly HttpClient client = new HttpClient();

        public static LotteryResultsList GetLotteryResultsList() =>
            GetApiResultsAsync<LotteryResultsList>($"{Url}/latestresults").GetAwaiter().GetResult();

        public static DrawsList GetOpenDrawList() =>
            GetApiResultsAsync<DrawsList>($"{Url}/opendraws").GetAwaiter().GetResult();

        private static async Task<T> GetApiResultsAsync<T>(string path) where T : class, ILottery
        {
            T results = null;
            //TODO: Change to variable/dynamic format
            var str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCountPerProduct\": 2, \"OptionalProductFilter\":  [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
            var content = new StringContent(str, Encoding.UTF8, "application/json");

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

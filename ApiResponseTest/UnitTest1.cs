using Microsoft.VisualStudio.TestTools.UnitTesting;
using rsl_challenge.Services;
using rsl_challenge.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using rsl_challenge.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ApiResponseTest
{
    [TestClass]
    public class UnitTest1 
    {
        ItheLott _theLott;
        IDrawsRepository _drawRepository;

        public UnitTest1()
        {
        }

        public UnitTest1(ItheLott theLott)
        {
            _theLott = theLott;
        }
        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            // Add services
            services.AddTransient<ItheLott, theLott>();
        }

        // Test not running due to _theLott being null
        //[TestMethod]
        //public void CheckOpenDrawsCount()
        //{
        //    var model = new DrawsList();
        //    model = _theLott.GetOpenDrawList();
        //    var openDrawCount = model.Draws.Count;
        //    Assert.IsTrue(openDrawCount > 0);
        //}

        [TestMethod]
        public void AsyncCheckOpenDrawsCount()
        {
            var model = new DrawsList();
            Task.Run(async () =>
            {
                model = await AsyncHitApiOpenDraws();
            }).GetAwaiter().GetResult();

            var openDrawCount = model.Draws.Count;

            Assert.IsTrue(openDrawCount > 0);
        }

        [TestMethod]
        public void AsyncCheckLatestResultsCount()
        {
            var model = new LotteryResultsList();
            Task.Run(async () =>
            {
                model = await AsyncHitApiLatestResults();
            }).GetAwaiter().GetResult();

            var openLatestResultsCount = model.DrawResults.Count;

            Assert.IsTrue(openLatestResultsCount > 0);
        }


        async Task<DrawsList> AsyncHitApiOpenDraws()
        {
            HttpClient client = new HttpClient();

            DrawsList results = null;

            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            //Hit the api with Post method
            HttpResponseMessage response = await client.PostAsync("https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws", content);
            if (response.IsSuccessStatusCode)
            {
                //Convert results to object
                results = await response.Content.ReadAsAsync<DrawsList>();
            }
            return results;
        }

        async Task<LotteryResultsList> AsyncHitApiLatestResults()
        {
            HttpClient client = new HttpClient();

            LotteryResultsList results = null;

            string str = "{ \"CompanyId\": \"Tattersalls\",  \"MaxDrawCount\": 3, \"OptionalProductFilter\": [\"Ozlotto\", \"TattsLotto\", \"Powerball\"]}";
            var content = new StringContent(str, Encoding.UTF8, "application/json");

            //Hit the api with Post method
            HttpResponseMessage response = await client.PostAsync("https://data.api.thelott.com/sales/vmax/web/data/lotto/latestresults", content);
            if (response.IsSuccessStatusCode)
            {
                //Convert results to object
                results = await response.Content.ReadAsAsync<LotteryResultsList>();
            }
            return results;
        }
    }
}

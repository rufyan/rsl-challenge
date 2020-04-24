using Microsoft.VisualStudio.TestTools.UnitTesting;
using rsl_challenge.Services;

namespace UnitTests
{
    [TestClass]
    public class ApiResponseTest 
    {
        private readonly ILotteryService _lotteryService;
        public ApiResponseTest(ILotteryService LotteryService)
        {
            _lotteryService = LotteryService;
        }


        [TestMethod]
        public void CheckOpenDrawsCount()
        {
            var openDrawCount = _lotteryService.GetOpenDrawList().Draws.Count;
            Assert.IsTrue(openDrawCount > 0);
        }

        [TestMethod]
        public void CheckLatestResultsCount()
        {
            var openLotteryResultsCount = _lotteryService.GetLotteryResultsList(string.Empty).DrawResults.Count;
            Assert.IsTrue(openLotteryResultsCount > 0);
        }
    }
}

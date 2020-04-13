using Microsoft.VisualStudio.TestTools.UnitTesting;
using rsl_challenge.Services;

namespace UnitTests
{
    [TestClass]
    public class ApiResponseTest 
    {

        [TestMethod]
        public void CheckOpenDrawsCount()
        {
            var openDrawCount = LotteryService.GetOpenDrawList().Draws.Count;
            Assert.IsTrue(openDrawCount > 0);
        }

        [TestMethod]
        public void CheckLatestResultsCount()
        {
            var openLotteryResultsCount = LotteryService.GetLotteryResultsList(string.Empty).DrawResults.Count;
            Assert.IsTrue(openLotteryResultsCount > 0);
        }
    }
}

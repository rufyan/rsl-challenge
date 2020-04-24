using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using rsl_challenge.Models;
using rsl_challenge.Services;

namespace UnitTests
{
    [TestClass]
    public class ApiResponseTest 
    {
        private readonly ILotteryService _lotteryService;
        public ApiResponseTest()
        {
        }
        public ApiResponseTest(ILotteryService LotteryService)
        {
            _lotteryService = LotteryService;
        }


        [TestMethod]
        public void CheckOpenDrawsCount()
        {
            var list = new DrawsList();
            var mockService = new Mock<ILotteryService>();
            mockService.Setup(x => x.GetOpenDrawList()).Returns(list);
        }

        [TestMethod]
        public void CheckLatestResultsCount()
        {
            var list = new LotteryResultsList();
            var mockService = new Mock<ILotteryService>();
            mockService.Setup(x => x.GetLotteryResultsList("")).Returns(list);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using rsl_challenge.Models;
using rsl_challenge.Repository;
using rsl_challenge.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class ApiResponseTest 
    {
        private readonly ILotteryService _lotteryService;
        private readonly IDrawRepository _drawRepository;
        private readonly IConfiguration _config;

        public ApiResponseTest()
        {
            _config = Substitute.For<IConfigurationRoot>();
            _config.GetValue<string>("CompanyId").Returns("Tattersalls");
            _lotteryService = new LotteryService(_config);
            _drawRepository = new DrawRepository();
        }

        [TestMethod]
        public async Task GetResultsApiAsync_ReturnsDrawsList()
        {
            var result = await _lotteryService.GetApiResultsAsync<DrawsList>($"https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws", string.Empty);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void HydrateDraws_ReturnsDifferentDrawsList()
        {
            //Arrange
            var testDrawsList = Substitute.For<DrawsList>();
            testDrawsList.Draws = new List<Draw>() {
                new Draw() {
                    DrawLogoUrl = "test",
                    ProductId = "OzLotto"
                }
            };

            //Act
            var result = _drawRepository.HydrateDraws(testDrawsList);

            //Assert
            Assert.AreNotEqual(result, testDrawsList);
        }
    }
}


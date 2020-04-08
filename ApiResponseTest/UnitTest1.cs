using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using rsl_challenge.Services;

namespace ApiResponseTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ItheLott _theLott;
        
        public UnitTest1(ItheLott theLott)  
        {
            _theLott = theLott;
        }

        [TestMethod]
        public void CheckOpenDrawsCount()
        {
            var openDrawCount = _theLott.GetOpenDrawList().Draws.Count;
            Assert.IsTrue(openDrawCount > 0);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearRegression;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTestLinearRegression
{
    [TestClass]
    public class UnitTest
    {
        // should put in a resource file then read in test case
        private const string sampleFromCurrency = "USD"; 
        private const string sampleToCurrency = "TRY";
        private const string sampleInvalidCurrency = "ABCD";
        private Controller controller;

        [TestInitialize]
        public void TestInitialize()
        {
            controller = new Controller();
        }

        [TestMethod]
        public void T1_GetExchangeRates_ValidFromCurrency()
        {
            Task.Run(async () =>
            {
                ExchangeRates rates = await controller.GetExchangeRates(sampleFromCurrency, DateTime.Now);
                Assert.IsNotNull(rates);
            }).GetAwaiter().GetResult();
        }

        // Can use data driven test here to test invalid values
        [TestMethod]
        public void T2_GetExchangeRates_InvalidFromCurrency()
        {
            Task.Run(async () =>
            {
                ExchangeRates rates = await controller.GetExchangeRates(sampleInvalidCurrency, DateTime.Now);
                Assert.IsNull(rates);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void T3_GetExchangeRate_ValidToCurrency()
        {
            Task.Run(async () =>
            {
                float rate = await controller.GetExchangeRate(sampleFromCurrency, sampleToCurrency, DateTime.Now);
                Assert.AreNotEqual(-1, rate);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void T4_GetExchangeRate_InvalidToCurrency()
        {
            Task.Run(async () =>
            {
                float rate = await controller.GetExchangeRate(sampleFromCurrency, sampleInvalidCurrency, DateTime.Now);
                Assert.AreEqual(-1, rate);
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void T5_CalculatePredictedRate_Sample_Data()
        {
            Dictionary<int, float> rates = new Dictionary<int, float>();
            rates.Add(1, 2.1f);
            rates.Add(2, 2.2f);
            rates.Add(3, 2.4f);
            double predictedRate = controller.CalculatePredictedRate(rates);
            Assert.IsTrue(predictedRate > 0);
        }

        [TestMethod]
        public void T6_CalculatePredictedRate_Not_Enough_Information()
        {
            Dictionary<int, float> rates = new Dictionary<int, float>();
            double predictedRate = controller.CalculatePredictedRate(rates);
            Assert.AreEqual(-1, predictedRate);
        }

        [TestMethod]
        public void T7_Integrated_Test()
        {
            Controller controller = new Controller();
            DateTime date = DateTime.Now;
            Dictionary<int, float> rates = null;
            Task.Run(async () =>
            {
                rates = await controller.GetExchangeRates(sampleFromCurrency, sampleToCurrency, date, 12);
            }).GetAwaiter().GetResult();
            double predictedRate = controller.CalculatePredictedRate(rates);
            Assert.IsTrue(predictedRate > 0);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            controller = null;
        }
    }
}

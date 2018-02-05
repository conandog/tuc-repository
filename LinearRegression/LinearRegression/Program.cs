using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression
{
    class Program
    {
        public const string apiLink = "https://api.fixer.io/";
        public const string defaultDataType = "application/json";
        public const string defaultFromCurrency = "USD";
        public const string sampleToCurrency = "AUD";
        public const int monthCount = 12;

        static void Main(string[] args)
        {
            Process();
        }

        private static async void Process()
        {
            // Assume that we will calculate the prediction of the exchange rate for tomorrow
            DateTime date = DateTime.Now.AddDays(2);
            Dictionary<int, float> rates = await GetExchangeRates(defaultFromCurrency, sampleToCurrency, date, monthCount);

            if (rates.Count >= 2)
            {
                double predictedRate = GetPredictedRate(rates);
                // Write the result with 4 decimal places
                Console.WriteLine(String.Format("The predicted currency exchange from {0} to {1} for {2} is {3:N4}",
                    defaultFromCurrency, sampleToCurrency, date.ToShortDateString(), predictedRate));
            }
            else
            {
                Console.WriteLine("Cannot get enough information to calculate the prediction");
            }
        }

        /// <summary>
        /// Get predicted rate following the below regression
        /// Regression Equation(y) = a + bx 
        /// Slope(b) = (NΣXY - (ΣX)(ΣY)) / (NΣX2 - (ΣX)2)
        /// Intercept(a) = (ΣY - b(ΣX)) / N
        /// </summary>
        /// <param name="rates">X will be the ordinal value of the month
        /// and Y will be the the exchange rate between the two currencies for the given month</param>
        /// <returns>Predicted rate</returns>
        private static double GetPredictedRate(Dictionary<int, float> rates)
        {
            double res = 0; // Regression equation
            int rateCount = rates.Count; // Number of rates
            List<float> listXX = new List<float>();
            List<float> listXY = new List<float>();
            double subSlope1 = 0; // (NΣXY - (ΣX)(ΣY))
            double subSlope2 = 0; // (NΣX2 - (ΣX)2)
            double sumX = 0, sumY = 0, sumXY = 0, sumXX = 0, sumX2 = 0, slope = 0, intercept = 0;

            // Find ΣX, ΣY, ΣXY, ΣX2
            foreach (KeyValuePair<int, float> rate in rates)
            {
                sumX += rate.Key;
                sumY += rate.Value;
                sumXY += rate.Key * rate.Value;
                sumXX += rate.Key * rate.Key;
            }

            subSlope1 = (rateCount * sumXY) - (sumX * sumY);
            sumX2 = sumX * sumX;
            subSlope2 = (rateCount * sumXX) - sumX2;
            slope = subSlope1 / subSlope2;
            intercept = (sumY - slope * sumX) / rateCount;
            res = intercept + (slope * (rateCount + 1));
            return res;
        }

        /// <summary>
        /// Get the points (rates) over months
        /// </summary>
        /// <returns>Points</returns>
        private static async Task<Dictionary<int, float>> GetExchangeRates(string fromCurrency, string toCurrency, DateTime date, int monthCount)
        {
            Dictionary<int, float> res = new Dictionary<int, float>();

            for (int previousMonth = -monthCount; previousMonth < 0; previousMonth++)
            {
                DateTime previousDate = date.AddMonths(previousMonth);
                float rate = await GetExchangeRate(fromCurrency, toCurrency, previousDate);

                if (rate != -1)
                {
                    res.Add(previousMonth + monthCount + 1, rate);
                }
            }

            return res;
        }

        /// <summary>
        /// Get the exchange rate between two specific FROM - TO currencies
        /// </summary>
        /// <returns>The exchange rate</returns>
        private static async Task<float> GetExchangeRate(string fromCurrency, string toCurrency, DateTime date)
        {
            float res = -1;

            try
            {
                ExchangeRates exchangeRates = await GetExchangeRates(defaultFromCurrency, date);
                res = exchangeRates.Rates[toCurrency];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }

        /// <summary>
        /// Get all exchange rates for a date
        /// </summary>
        /// <returns>All exchange rates information</returns>
        public static async Task<ExchangeRates> GetExchangeRates(string fromCurrency, DateTime date)
        {
            ExchangeRates res = new ExchangeRates();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(defaultDataType));
                    string request = String.Format("{0}/{1}?base={2}", apiLink, date.ToString("yyyy-MM-dd"), fromCurrency);

                    using (HttpResponseMessage response = client.GetAsync(request).Result)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        res.DeserializeFromJson(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }
    }
}

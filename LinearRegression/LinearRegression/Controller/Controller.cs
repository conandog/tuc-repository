using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LinearRegression
{
    public class Controller
    {
        /// <summary>
        /// Get all exchange rates for a date
        /// </summary>
        /// <returns>All exchange rates information</returns>
        public async Task<ExchangeRates> GetExchangeRates(string fromCurrency, DateTime date)
        {
            ExchangeRates res = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Constants.API_DEFAULT_DATA_TYPE));
                    string request = String.Format(Constants.API_REQUEST, Constants.API_ADDRESS, date.ToString(Constants.API_DATE_FORMAT), fromCurrency);

                    using (HttpResponseMessage response = client.GetAsync(request).Result)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            res = new ExchangeRates();
                            res.DeserializeFromJson(responseBody);
                        }
                        else
                        {
                            Console.WriteLine(String.Format(Constants.ERROR_MESSAGE_CANNOT_GET_EXCHANGE_RATE_FROM, date.ToShortDateString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }

        /// <summary>
        /// Get the exchange rate between two specific FROM - TO currencies
        /// </summary>
        /// <returns>The exchange rate</returns>
        public async Task<float> GetExchangeRate(string fromCurrency, string toCurrency, DateTime date)
        {
            float res = -1;

            try
            {
                ExchangeRates exchangeRates = await GetExchangeRates(fromCurrency, date);

                if (exchangeRates != null)
                {
                    if (exchangeRates.Rates.ContainsKey(toCurrency))
                    {
                        res = exchangeRates.Rates[toCurrency];
                    }
                    else
                    {
                        Console.WriteLine(String.Format(Constants.ERROR_MESSAGE_CANNOT_GET_EXCHANGE_RATE_TO, date.ToShortDateString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return res;
        }

        /// <summary>
        /// Get the points (rates) over months
        /// </summary>
        /// <returns>Points</returns>
        public async Task<Dictionary<int, float>> GetExchangeRates(string fromCurrency, string toCurrency, DateTime date, int monthCount)
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
        /// Get predicted rate following the below regression
        /// Regression Equation(y) = a + bx 
        /// Slope(b) = (NΣXY - (ΣX)(ΣY)) / (NΣX2 - (ΣX)2)
        /// Intercept(a) = (ΣY - b(ΣX)) / N
        /// </summary>
        /// <param name="rates">X will be the ordinal value of the month
        /// and Y will be the the exchange rate between the two currencies for the given month</param>
        /// <returns>Predicted rate</returns>
        public double CalculatePredictedRate(Dictionary<int, float> rates)
        {
            double res = -1;

            if (rates == null || rates.Count < 2)
            {
                Console.WriteLine(Constants.ERROR_MESSAGE_CANNOT_GET_ENOUGH_INFORMATION);
            }
            else
            {
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
            }

            return res;
        }

        /// <summary>
        /// Calculate predicted rate for tomorrow
        /// </summary>
        /// <param name="monthCount">Number of months will be used to calculate</param>
        public async void CalculatePredictedRateForTomorrow(string fromCurrency, string toCurrency)
        {
            // Assume that we will calculate the prediction of the exchange rate for tomorrow
            DateTime date = DateTime.Now.AddDays(1);
            Dictionary<int, float> rates = await GetExchangeRates(fromCurrency, toCurrency, date, Constants.MONTH_COUNT);
            double predictedRate = CalculatePredictedRate(rates);

            if (predictedRate != -1)
            {
                Console.WriteLine(String.Format(Constants.SUCCESS_MESSAGE, fromCurrency, toCurrency, date.ToShortDateString(), predictedRate));
            }
            else
            {
                Console.WriteLine(Constants.ERROR_MESSAGE);
            }
        }
    }
}

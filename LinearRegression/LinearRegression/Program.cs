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

        static void Main(string[] args)
        {
            Process();
        }

        private static async void Process()
        {
            DateTime date = new DateTime(2018, 6, 15);
            await GetExchangeRate(defaultFromCurrency, "TRY", date);
        }

        private static async Task<Dictionary<int, float>> GetExchangeRates(string fromCurrency, string toCurrency, DateTime date)
        {
            Dictionary<int, float> res = new Dictionary<int, float>();

            for (int previousMonth = -12; previousMonth < 0; previousMonth++)
            {
                DateTime previousDate = date.AddMonths(previousMonth);
                float rate = await GetExchangeRate(fromCurrency, toCurrency, previousDate);
            }

            return res;
        }

        private static async Task<float> GetExchangeRate(string fromCurrency, string toCurrency, DateTime date)
        {
            float res = -1;
            ExchangeRates exchangeRates = await GetExchangeRates(defaultFromCurrency, date);
            res = exchangeRates.Rates[toCurrency];
            return res;
        }

        public static async Task<ExchangeRates> GetExchangeRates(string fromCurrency, DateTime date)
        {
            ExchangeRates res = new ExchangeRates();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(defaultDataType));

                    using (HttpResponseMessage response = client.GetAsync(
                       apiLink + "/" + date.ToString("yyyy-MM-dd") + "?base=" + fromCurrency).Result)
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

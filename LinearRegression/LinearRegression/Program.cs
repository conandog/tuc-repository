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
            Test();
        }

        static async void Test()
        {
            DateTime date = new DateTime(2018, 1, 15);
            ExchangeRates exchangeRates = await GetExchangeRates(defaultFromCurrency, date);
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
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseBody);
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

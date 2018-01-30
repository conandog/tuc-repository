using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LinearRegression
{
    public class ExchangeRates
    {
        public string Base;
        public DateTime Date;
        public Dictionary<string, float> Rates;

        public void DeserializeFromJson(string input)
        {
            ExchangeRates data = JsonConvert.DeserializeObject<ExchangeRates>(input);
            this.Base = data.Base;
            this.Date = data.Date;
            this.Rates = data.Rates;
        }
    }
}
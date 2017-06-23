using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class OrderDetails
    {
        public string Name;
        public string Id;
        public int Quantity;
        public long Price;
        public long Total;

        public OrderDetails()
        {
            //Default constructor
        }

        public OrderDetails(string name, string id, int quantity, long price, long total)
        {
            this.Name = name;
            this.Id = id;
            this.Quantity = quantity;
            this.Price = price;
            this.Total = total;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            OrderDetails data = JsonConvert.DeserializeObject<OrderDetails>(input);
            this.Name = data.Name;
            this.Id = data.Id;
            this.Quantity = data.Quantity;
            this.Price = data.Price;
            this.Total = data.Total;
        }
    }
}

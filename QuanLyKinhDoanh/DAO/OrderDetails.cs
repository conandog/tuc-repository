using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DAO
{
    public class OrderDetails
    {
        public string name;
        public string id;
        public int quantity;
        public long price;

        public OrderDetails()
        {
            //Default constructor
        }

        public OrderDetails(string name, string id, int quantity, long price)
        {
            this.name = name;
            this.id = id;
            this.quantity = quantity;
            this.price = price;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            OrderDetails data = JsonConvert.DeserializeObject<OrderDetails>(input);
            this.name = data.name;
            this.id = data.id;
            this.quantity = data.quantity;
            this.price = data.price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DAO
{
    public class Order
    {
        public string name;
        public string phone;
        public string address;
        public int orderCount;
        public string notes;

        public long totalBill;
        public string status;
        public string codCode;
        public string codWeight;
        public string codBill;

        public DateTime createdDate;
        public string createdBy;
        public DateTime updatedDate;
        public string updatedBy;

        public Order()
        {
            //Default constructor
        }

        public Order(string name, string phone, string address, int orderCount, string notes,
            long totalBill, string status, string codCode, string codWeight, string codBill,
            DateTime createdDate, string createdBy, DateTime updatedDate, string updatedBy)
        {
            this.name = name;
            this.phone = phone;
            this.address = address;
            this.orderCount = orderCount;
            this.notes = notes;

            this.totalBill = totalBill;
            this.status = status;
            this.codCode = codCode;
            this.codWeight = codWeight;
            this.codBill = codBill;

            this.createdDate = createdDate;
            this.createdBy = createdBy;
            this.updatedDate = updatedDate;
            this.updatedBy = updatedBy;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            Order data = JsonConvert.DeserializeObject<Order>(input);
            this.name = data.name;
            this.phone = data.phone;
            this.address = data.address;
            this.orderCount = data.orderCount;
            this.notes = data.notes;

            this.totalBill = data.totalBill;
            this.status = data.status;
            this.codCode = data.codCode;
            this.codWeight = data.codWeight;
            this.codBill = data.codBill;

            this.createdDate = data.createdDate;
            this.createdBy = data.createdBy;
            this.updatedDate = data.updatedDate;
            this.updatedBy = data.updatedBy;
        }

        public static List<Order> GetList(string input,string text)
        {
            List<Order> res = new List<Order>();
            JToken outer = JToken.Parse(input);
            JObject inner = outer["order"].Value<JObject>();

            //List<string> keys = inner.Properties().Select(p => p.Name).ToList();

            //foreach (string k in keys)
            //{
            //    Console.WriteLine(k);
            //}

            return res;
        }
    }
}

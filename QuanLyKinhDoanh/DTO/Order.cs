using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int Id;
        public string Name;
        public string Phone;
        public string Address;

        public long TotalBill;
        public string Status;
        public string CodCode;
        public string CodType;
        public double CodWeight;
        public long CodBill;
        public string Notes;

        public DateTime CreatedDate;
        public string CreatedBy;
        public DateTime UpdatedDate;
        public string UpdatedBy;
        public bool DeleteFlag;

        public List<OrderDetails> ListDetail;

        public Order()
        {
            //Default constructor
        }

        public Order(int id, string name, string phone, string address, 
            long totalBill, string status, string codCode, string codType, double codWeight, long codBill, string notes,
            List<OrderDetails> listDetail, bool deleteFlag = false)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;

            this.TotalBill = totalBill;
            this.Status = status;
            this.CodCode = codCode;
            this.CodType = codType;
            this.CodWeight = codWeight;
            this.CodBill = codBill;
            this.Notes = notes;

            this.ListDetail = listDetail;
            this.DeleteFlag = deleteFlag;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            Order data = JsonConvert.DeserializeObject<Order>(input);
            this.Id = data.Id;
            this.Name = data.Name;
            this.Phone = data.Phone;
            this.Address = data.Address;

            this.TotalBill = data.TotalBill;
            this.Status = data.Status;
            this.CodCode = data.CodCode;
            this.CodType = data.CodType;
            this.CodWeight = data.CodWeight;
            this.CodBill = data.CodBill;
            this.Notes = data.Notes;

            this.ListDetail = data.ListDetail;
            this.DeleteFlag = data.DeleteFlag;
        }
    }
}

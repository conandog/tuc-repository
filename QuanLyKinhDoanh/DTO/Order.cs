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
        public int OrderCount;
        public string Notes;

        public long TotalBill;
        public string Status;
        public string CodCode;
        public string CodWeight;
        public string CodBill;

        public DateTime CreatedDate;
        public string CreatedBy;
        public DateTime UpdatedDate;
        public string UpdatedBy;
        public bool DeleteFlag;

        public List<OrderDetails> details;

        public Order()
        {
            //Default constructor
        }

        public Order(int id, string name, string phone, string address, int orderCount, string notes,
            long totalBill, string status, string codCode, string codWeight, string codBill,
            DateTime createdDate, string createdBy, DateTime updatedDate, string updatedBy,
            List<OrderDetails> details, bool deleteFlag = false)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.OrderCount = orderCount;
            this.Notes = notes;

            this.TotalBill = totalBill;
            this.Status = status;
            this.CodCode = codCode;
            this.CodWeight = codWeight;
            this.CodBill = codBill;

            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.UpdatedDate = updatedDate;
            this.UpdatedBy = updatedBy;
            this.DeleteFlag = deleteFlag;

            this.details = details;
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
            this.OrderCount = data.OrderCount;
            this.Notes = data.Notes;

            this.TotalBill = data.TotalBill;
            this.Status = data.Status;
            this.CodCode = data.CodCode;
            this.CodWeight = data.CodWeight;
            this.CodBill = data.CodBill;

            this.CreatedDate = data.CreatedDate;
            this.CreatedBy = data.CreatedBy;
            this.UpdatedDate = data.UpdatedDate;
            this.UpdatedBy = data.UpdatedBy;
            this.DeleteFlag = data.DeleteFlag;

            this.details = data.details;
        }
    }
}

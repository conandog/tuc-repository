using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Customer
    {
        public int Id;
        public string Name;
        public string Phone;
        public string Address;

        public DateTime CreatedDate;
        public string CreatedBy;
        public DateTime UpdatedDate;
        public string UpdatedBy;
        public bool DeleteFlag;

        public List<CustomerContact> ListContact;

        public Customer()
        {
            //Default constructor
        }

        public Customer(int id, string name, string phone, string address,
            List<CustomerContact> listContact, bool deleteFlag = false)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;

            this.ListContact = listContact;
            this.DeleteFlag = deleteFlag;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            Customer data = JsonConvert.DeserializeObject<Customer>(input);
            this.Id = data.Id;
            this.Name = data.Name;
            this.Phone = data.Phone;
            this.Address = data.Address;

            this.ListContact = data.ListContact;
            this.DeleteFlag = data.DeleteFlag;
        }
    }
}

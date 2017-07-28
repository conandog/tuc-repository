using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CustomerContact
    {
        public string Name;
        public string Contact;

        public CustomerContact()
        {
            //Default constructor
        }

        public CustomerContact(string name, string contact)
        {
            this.Name = name;
            this.Contact = contact;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            CustomerContact data = JsonConvert.DeserializeObject<CustomerContact>(input);
            this.Name = data.Name;
            this.Contact = data.Contact;
        }
    }
}

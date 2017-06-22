using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Information
    {
        public string Name;
        public string AppVersion;
        public string DataVersion;
        public DateTime CreatedDate;

        public Information()
        {
            //Default constructor
        }

        public Information(string name, string appVersion, string dataVersion, DateTime createdDate)
        {
            this.Name = name;
            this.AppVersion = appVersion;
            this.DataVersion = dataVersion;
            this.CreatedDate = createdDate;
        }

        public string SerializeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void DeserializeFromJson(string input)
        {
            Information data = JsonConvert.DeserializeObject<Information>(input);
            this.Name = data.Name;
            this.AppVersion = data.AppVersion;
            this.DataVersion = data.DataVersion;
            this.CreatedDate = data.CreatedDate;
        }
    }
}

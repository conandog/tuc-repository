using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DAO
{
    public class JsonConnection
    {
        private static readonly string datasourcePath = @"ngocdang.json";

        // Data Context
        private static JToken dbContext;

        public JsonConnection()
        {
            CreateJsonConnection();
        }

        protected static JToken DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    CreateJsonConnection();
                }

                return dbContext;
            }
        }

        public static void CreateJsonConnection()
        {
            try
            {
                if (dbContext == null)
                {
                    if (!File.Exists(datasourcePath))
                    {
                        FileStream file = File.Create(datasourcePath);
                        file.Close();

                        JObject content = new JObject();
                        Information infor = new Information("Ngọc Đăng", "5.0.0.0", "1.0.0.0", DateTime.Now);
                        string jInfor = Newtonsoft.Json.JsonConvert.SerializeObject(new { Information = infor });
                        //content.Add(jInfor);
                        //JObject order = new JObject();
                        //order["Order"] = String.Empty;
                        //content.Add(order);
                        File.WriteAllText(datasourcePath, jInfor);
                    }
                }

                dbContext = JToken.Parse(File.ReadAllText(datasourcePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

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
        public static string datasourcePath = @"ngocdang.json";

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
                        Information infor = new Information("Ngọc Đăng", "5.1.0.0", "1.1.0.0", DateTime.Now);
                        //string jInfor = Newtonsoft.Json.JsonConvert.SerializeObject(new { Information = infor });
                        string jInfor = Newtonsoft.Json.JsonConvert.SerializeObject(infor);
                        content.Add("Information", jInfor);
                        //JObject order = new JObject();
                        //order["Order"] = String.Empty;
                        content.Add("Order", new JArray());
                        File.WriteAllText(datasourcePath, content.ToString(Newtonsoft.Json.Formatting.Indented));
                    }
                }

                dbContext = JToken.Parse(File.ReadAllText(datasourcePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateData()
        {
            try
            {
                if (dbContext != null && File.Exists(datasourcePath))
                {
                    File.WriteAllText(datasourcePath, dbContext.ToString(Newtonsoft.Json.Formatting.Indented));
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

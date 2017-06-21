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

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
        protected static JToken dbContext = JToken.Parse(File.ReadAllText(datasourcePath));

        public JsonConnection()
        {
            dbContext = JToken.Parse(File.ReadAllText(datasourcePath));
        }

        public static void CreateSQlConnection()
        {
            try
            {
                dbContext = JToken.Parse(File.ReadAllText(datasourcePath));
            }
            catch
            {
                return;
            }
        }
    }
}

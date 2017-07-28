using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Library;
using DTO;

namespace DAO
{
    public class CustomerDao : JsonConnection
    {
        private static readonly string DATA_KEY = "Customer";
        private static readonly string DATA_ID_KEY = "Id";
        private static readonly string DATA_NAME_KEY = "Name";
        private static readonly string DATA_PHONE_KEY = "Phone";
        private static readonly string DATA_ADDRESS_KEY = "Address";

        private static readonly string DATA_LISTCONTACT_KEY = "ListContact";

        private static readonly string DATA_CREATED_DATE_KEY = "CreatedDate";
        private static readonly string DATA_CREATED_BY_KEY = "CreatedBy";
        private static readonly string DATA_UPDATED_DATE_KEY = "UpdatedDate";
        private static readonly string DATA_UPDATED_BY_KEY = "UpdatedBy";
        private static readonly string DATA_DELETE_FLAG_KEY = "DeleteFlag";

        public static IEnumerable<JToken> GetQuery(string text, bool deleteFlag = false)
        {
            var res = from p in DbContext[DATA_KEY]
                      select p;
            text = text.ToLower();

            if (!string.IsNullOrEmpty(text))
            {
                res = res.Where(p => ((string)p[DATA_NAME_KEY]).ToLower().Contains(text)
                    || ((string)p[DATA_PHONE_KEY]).ToLower().Contains(text));
            }

            res = res.Where(p => ((bool)p[DATA_DELETE_FLAG_KEY]).Equals(deleteFlag));

            return res;
        }

        public static int GetCount(string text, bool deleteFlag = false)
        {
            return GetQuery(text).Count();
        }

        public static List<Customer> GetList(string text,
            string sortColumn, string sortOrder, int skip, int take, bool deleteFlag = false)
        {
            List<Customer> res = new List<Customer>();
            var jData = GetQuery(text);
            JArray resSorted = null;
            string sortKey = DATA_NAME_KEY;

            switch (sortColumn)
            {
                case "Tên khách":
                    sortKey = DATA_NAME_KEY;
                    break;

                case "Điện thoại":
                    sortKey = DATA_PHONE_KEY;
                    break;

                case "Ngày cập nhật":
                    sortKey = DATA_UPDATED_DATE_KEY;
                    break;

                default:
                    sortKey = DATA_UPDATED_DATE_KEY;
                    break;
            }

            if (sortOrder == CommonDao.SORT_ASCENDING)
            {
                resSorted = new JArray(jData.OrderBy(obj => obj[sortKey]));
            }
            else
            {
                resSorted = new JArray(jData.OrderByDescending(obj => obj[sortKey]));
            }

            if ((skip <= 0 && take <= 0) || (skip < 0 && take > 0) || (skip > 0 && take < 0))
            {
                //keep current list
            }
            else
            {
                jData = resSorted.Skip(skip).Take(take);
            }

            foreach (var item in jData)
            {
                res.Add(item.ToObject<Customer>());
            }

            return res;
        }

        public static Customer GetById(int id)
        {
            var res = DbContext[DATA_KEY].Where(p => ((int)p[DATA_ID_KEY]).Equals(id)).FirstOrDefault();

            if (res != null)
            {
                return res.ToObject<Customer>();
            }

            return null;
        }

        public static Customer GetLastData()
        {
            var res = DbContext[DATA_KEY].LastOrDefault();

            if (res != null)
            {
                return res.ToObject<Customer>();
            }

            return null;
        }

        public static bool Insert(Customer data, User user)
        {
            try
            {
                data.CreatedBy = data.UpdatedBy = user.UserName;
                data.CreatedDate = data.UpdatedDate = DateTime.Now;

                JObject newData = JObject.FromObject(data);
                JArray parent = DbContext[DATA_KEY] as JArray;
                parent.Add(newData);

                return UpdateData();
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool Delete(int id, User user)
        {
            try
            {
                var res = DbContext[DATA_KEY].Where(p => ((int)p[DATA_ID_KEY]).Equals(id)).FirstOrDefault();
                res[DATA_UPDATED_BY_KEY] = user.UserName;
                res[DATA_UPDATED_DATE_KEY] = DateTime.Now;
                res[DATA_DELETE_FLAG_KEY] = true;
                return UpdateData();
            }
            catch
            {

            }

            return false;
        }

        public static bool DeleteList(string ids, User user)
        {
            bool isDone = true;

            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    string[] idArr = ids.Split(new string[] { CommonDao.SEPERATE_STRING }, StringSplitOptions.RemoveEmptyEntries);
                    int result = 0;

                    foreach (string id in idArr)
                    {
                        if (int.TryParse(id, out result))
                        {
                            if (!Delete(result, user))
                            {
                                isDone = false;
                                break;
                            }
                        }
                        else
                        {
                            isDone = false;
                            break;
                        }
                    }
                }
                else
                {
                    isDone = false;
                }
            }
            catch
            {
                isDone = false;
            }

            return isDone;
        }

        public static bool Update(Customer data, User user)
        {
            try
            {
                if (data != null)
                {
                    var res = DbContext[DATA_KEY].Where(p => ((int)p[DATA_ID_KEY]).Equals(data.Id)).FirstOrDefault();
                    res[DATA_NAME_KEY] = data.Name;
                    res[DATA_PHONE_KEY] = data.Phone;
                    res[DATA_ADDRESS_KEY] = data.Address;

                    JArray listData = res[DATA_LISTCONTACT_KEY] as JArray;
                    listData.Clear();

                    foreach (var item in data.ListContact)
                    {
                        listData.Add(JObject.FromObject(item));
                    }

                    res[DATA_UPDATED_BY_KEY] = user.UserName;
                    res[DATA_UPDATED_DATE_KEY] = DateTime.Now;
                    return UpdateData();
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}

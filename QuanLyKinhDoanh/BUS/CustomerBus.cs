using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class CustomerBus
    {
        public static int GetCount(string text)
        {
            return CustomerDao.GetCount(text);
        }

        public static List<Customer> GetList(string text,
            string sortColumn, string sortOrder, int skip, int take)
        {
            return CustomerDao.GetList(text, sortColumn, sortOrder, skip, take);
        }

        public static Customer GetById(int id)
        {
            return CustomerDao.GetById(id);
        }

        public static Customer GetLastData()
        {
            return CustomerDao.GetLastData();
        }

        public static bool Insert(Customer data, User user)
        {
            return CustomerDao.Insert(data, user);
        }

        public static bool Delete(int id, User user)
        {
            return CustomerDao.Delete(id, user);
        }

        public static bool DeleteList(string ids, User user)
        {
            return CustomerDao.DeleteList(ids, user);
        }

        public static bool Update(Customer data, User user)
        {
            return CustomerDao.Update(data, user);
        }
    }
}

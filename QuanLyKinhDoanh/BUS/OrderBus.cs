using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class OrderBus
    {
        public static int GetCount(string text)
        {
            return OrderDao.GetCount(text);
        }

        public static List<Order> GetList(string text,
            string sortColumn, string sortOrder, int skip, int take)
        {
            return OrderDao.GetList(text, sortColumn, sortOrder, skip, take);
        }

        public static Order GetById(int id)
        {
            return OrderDao.GetById(id);
        }

        public static Order GetLastData()
        {
            return OrderDao.GetLastData();
        }

        public static bool Insert(Order data, User user)
        {
            return OrderDao.Insert(data, user);
        }

        //public static bool Delete(UserGroup data)
        //{
        //    return OrderDao.Delete(data);
        //}

        //public static bool DeleteList(string ids)
        //{
        //    return OrderDao.DeleteList(ids);
        //}

        //public static bool Update(UserGroup data)
        //{
        //    return OrderDao.Update(data);
        //}
    }
}

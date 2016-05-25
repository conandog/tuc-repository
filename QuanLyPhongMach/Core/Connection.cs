using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Connection
    {
        protected static QuanLyPhongMachEntities dbContext;

        public Connection()
        {
            //Not implement
        }

        public static bool NewConnection()
        {
            try
            {
                dbContext = new QuanLyPhongMachEntities();
                var query = from data in dbContext.Users
                          select data;

                return query.Count() >= 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BeginTransaction()
        {
            try
            {
                if (dbContext.Database.Connection.State != System.Data.ConnectionState.Open)
                {
                    dbContext.Database.Connection.Open();
                }

                if (dbContext.Database.CurrentTransaction == null || dbContext.Database.CurrentTransaction.UnderlyingTransaction.Connection == null)
                {
                    dbContext.Database.Connection.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EndTransaction(bool isSuccess)
        {
            try
            {
                if (dbContext.Database.CurrentTransaction != null)
                {
                    if (isSuccess)
                    {
                        dbContext.Database.CurrentTransaction.Commit();
                    }
                    else
                    {
                        dbContext.Database.CurrentTransaction.Rollback();
                    }

                    dbContext.Database.CurrentTransaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbContext.Database.Connection.Close();
                NewConnection();
            }
        }
    }
}

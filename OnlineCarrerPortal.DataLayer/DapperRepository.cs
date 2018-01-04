using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.DataLayer
{
    public class DapperRepository<T> where T : class
    {
        #region GetAll
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll(string storedProcedure)
        {
            List<T> lstResult = null;

            using (IDbConnection connection =  OpenConnection())
            {
                lstResult = connection.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure).ToList();
            }

            return lstResult;
        }
        #endregion GetAll

        #region FindByID
        /// <summary>
        /// FindByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindByID(string sp, DynamicParameters param)
        {
            T resultObj = null;

            using (IDbConnection connection =  OpenConnection())
            {
                resultObj = connection.Query<T>(sp, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return resultObj;
        }
        #endregion FindByID

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Add(string sp, DynamicParameters param, bool transactionType = true)
        {
            bool status = false;

            using (IDbConnection connection =  OpenConnection())
            {
                if (transactionType)
                {
                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            status = connection.Execute(sp, param, tran, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                else
                {
                    status = connection.Execute(sp, param, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }

            return status;
        }
        #endregion Add

        #region Add
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddandReturnID(string sp, DynamicParameters param, bool transactionType = true)
        {
            bool status = false;
            int result = 0;
            T resultObj = null;

            using (IDbConnection connection =  OpenConnection())
            {
                if (transactionType)
                {
                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            resultObj = connection.Query<T>(sp, param, tran, commandType: CommandType.StoredProcedure).FirstOrDefault();
                            result = Convert.ToInt32(resultObj.ToString());
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                else
                {
                    status = connection.Execute(sp, param, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }

            return result;
        }
        #endregion Add

        #region Update
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(string sp, DynamicParameters param, bool trasactionType = true)
        {
            bool status = false;

            using (IDbConnection connection =  OpenConnection())
            {
                if (trasactionType)
                {
                    using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            status = connection.Execute(sp, param, tran, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                else
                {
                    status = connection.Execute(sp, param, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }

            return status;
        }
        #endregion Update

        #region Remove
        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(string sp, DynamicParameters param)
        {
            bool status = false;

            using (IDbConnection connection =  OpenConnection())
            {
                //const string sql = "dbo.tmpDapperUserDelete";
                status = connection.Execute(sp, param, commandType: CommandType.StoredProcedure) > 0 ? true : false;
            }

            return status;
        }
        #endregion Remove

        #region SelectQuery
        /// <summary>
        /// SelectQuery
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> SelectQuery(string sp, DynamicParameters param)
        {
            List<T> lstResult = null;

            using (IDbConnection connection =  OpenConnection())
            {
                lstResult = connection.Query<T>(sp, param, commandType: CommandType.StoredProcedure).ToList();
            }

            return lstResult;
        }
        #endregion SelectQuery

        #region SelectQueryWithOutClass
        /// <summary>
        /// SelectQueryWithOutClass
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataSet SelectQueryWithOutClass(string sp, List<SqlParameter> param)
        {
            DataSet lstResult = new DataSet();

            using (IDbConnection connection =  OpenConnection())
            {
                IDbDataAdapter dbAdapter = new SqlDataAdapter();
                IDbCommand dbCommand = connection.CreateCommand();
                dbCommand.CommandText = sp;
                dbCommand.CommandType = CommandType.StoredProcedure;
                dbAdapter.SelectCommand = dbCommand;

                foreach (var data in param)
                {

                    dbAdapter.SelectCommand.Parameters.Add(data);
                }

                dbAdapter.Fill(lstResult);
            }

            return lstResult;
        }
        #endregion SelectQueryWithOutClass

        #region ExecuteSp
        /// <summary>
        /// ExecuteSp
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="param"></param>
        /// <param name="transactionType"></param>
        /// <returns></returns>
        public bool ExecuteSp(string sp, DynamicParameters param, bool transactionType = false)
        {
            bool status = false;

            using (IDbConnection connection =  OpenConnection())
            {
                if (transactionType)
                {
                    using (var tran = connection.BeginTransaction())
                    {
                        status = connection.Execute(sp, param, tran, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                    }
                }
                else
                {
                    status = connection.Execute(sp, param, commandType: CommandType.StoredProcedure) > 0 ? true : false;
                }
            }

            return status;
        }
        #endregion ExecuteSp

        #region OpenConnection
        /// <summary>
        /// OpenConnection
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenConnection()
            {
                IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CPortal"].ConnectionString);
                connection.Open();
                return connection;
            }
            #endregion OpenConnection
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OnlineCarrerPortal.DataLayer
{
    public class DALHelper: IDisposable
    {
        readonly string _connectionString;
        IDbTransaction _transaction;
        IDbConnection _connection;

        public DALHelper()
        {
            _connectionString = (ConfigurationManager.ConnectionStrings["CPortal"]).ToString();
        }
        public void OpenConnectionWithTransaction()
        {
            try
            {
                _connection = new SqlConnection(_connectionString);
                // Open the connection, if needed
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                _transaction = _connection.BeginTransaction(System.Data.IsolationLevel.Serializable);
            }
            catch (Exception ex)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                }
                throw ex;
            }
        }
        public void EndConnectionAndCommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
                _transaction.Dispose();

            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        public void CommitTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Commit();
            }
        }
        public void EndConnectionAndRollBackTransaction()
        {
            if (_transaction != null)
            {
                try
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        public PropertyDetails GetDAL_PropertyDetails(bool withTransaction)
        {
            PropertyDetails objPropertyDetailsDAL = null;
            if (!withTransaction)
            {
                objPropertyDetailsDAL = new PropertyDetails(_connection);
            }
            else
            {
                objPropertyDetailsDAL = new PropertyDetails(_transaction);
            }
            return objPropertyDetailsDAL;
        }
    }
}

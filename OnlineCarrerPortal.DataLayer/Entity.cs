using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCarrerPortal.DataLayer
{
    public class Entity
    {
        #region Private Fields
        private IDbTransaction _transaction = null;
        private IDbConnection _connection = null;
        #endregion

        #region Constructor
        public Entity()
        {
        }

        public Entity(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        #endregion

        #region Public Properties
        public IDbTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }
        public IDbConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        #endregion
    }
}

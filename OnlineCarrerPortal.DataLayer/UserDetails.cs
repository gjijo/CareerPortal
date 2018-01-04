using IMSDataAccessLayer;
using OnlineCarrerPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TScribDataLayer
{
    public class UserDetails : Entity
    {
        #region PrivateFields
        private ISQLHelper _helper;
        #endregion

        #region Constructors
        public UserDetails(SqlTransaction Transaction)
        {
            base.Transaction = Transaction;
            _helper = new SqlHelper();
        }
        public UserDetails(string strConnectionString)
        {
            base.ConnectionString = strConnectionString;
            _helper = new SqlHelper();

        }
        #endregion

        public List<UserModel> GetUserLoginDetails(string userName, string password)
        {
            IDataReader datareader = null;
            List<UserModel> lsUser = new List<UserModel>();
            try
            {
                if (base.Transaction != null)
                {
                    datareader = _helper.ExecuteReader(base.Transaction, "SelectUserLogin", userName, password);
                }
                else
                {
                    datareader = _helper.ExecuteReader(base.ConnectionString, "SelectUserLogin", userName, password);
                }
                while (datareader.Read())
                {
                    UserModel objUser = new UserModel();
                    if (!datareader.IsDBNull(datareader.GetOrdinal("reference_no")))
                        objUser.UserID = datareader.GetInt16(datareader.GetOrdinal("UserID"));
                    /*if (!datareader.IsDBNull(datareader.GetOrdinal("customer_branchname")))
                        objquotation.strcustomerbranchname = datareader.GetString(datareader.GetOrdinal("customer_branchname"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("customer_number")))
                        objquotation.strcustomerno = datareader.GetString(datareader.GetOrdinal("customer_number"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("name")))
                        objquotation.strcustomername = datareader.GetString(datareader.GetOrdinal("name"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("salesman_name")))
                        objquotation.strSaleman_name = datareader.GetString(datareader.GetOrdinal("salesman_name"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("sales_quotation_date")))
                        objquotation.dateQuotationdate = datareader.GetDateTime(datareader.GetOrdinal("sales_quotation_date"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("sales_quotation_exp_date")))
                        objquotation.dateQuotationexpdate = datareader.GetDateTime(datareader.GetOrdinal("sales_quotation_exp_date"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("sales_quotation_refrance")))
                        objquotation.strReference = datareader.GetString(datareader.GetOrdinal("sales_quotation_refrance"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("remark")))
                        objquotation.strRemark = datareader.GetString(datareader.GetOrdinal("remark"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("active")))
                        objquotation.boolIsActive = datareader.GetBoolean(datareader.GetOrdinal("active"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("paymentmode")))
                        objquotation.strcashpaymentmode = datareader.GetString(datareader.GetOrdinal("paymentmode"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("sales_quotation_id")))
                        objquotation.intSalesquotationId = datareader.GetInt32(datareader.GetOrdinal("sales_quotation_id"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("IsOrder")))
                        objquotation.boolcleared = datareader.GetBoolean(datareader.GetOrdinal("IsOrder"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("sales_quotation_total")))
                        objquotation.decimalQuotationtotal = datareader.GetDecimal(datareader.GetOrdinal("sales_quotation_total"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("quotation_discount")))
                        objquotation.decimalDiscount = datareader.GetDecimal(datareader.GetOrdinal("quotation_discount"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("taxrate")))
                        objquotation.dectaxrate = datareader.GetDecimal(datareader.GetOrdinal("taxrate"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("Orderreference")))
                        objquotation.strType = datareader.GetString(datareader.GetOrdinal("Orderreference"));
                    if (!datareader.IsDBNull(datareader.GetOrdinal("OrderId")))
                        objquotation.intSalesorderId = datareader.GetInt32(datareader.GetOrdinal("OrderId"));
                    objquotation.decTotal = objquotation.decimalQuotationtotal + objquotation.dectaxrate - objquotation.decimalDiscount;*/
                    lsUser.Add(objUser);
                }
            }
            finally
            {
                if (datareader != null)
                    datareader.Close();
            }
            return lsUser;
        }
        public long InsertUserDetails(UserModel UserDetails)
        {            
            try
            {
                SqlParameter[] parms = new SqlParameter[11];
                parms[0] = new SqlParameter("@UserID", UserDetails.UserID);
                parms[1] = new SqlParameter("@FirstName", UserDetails.FirstName);
                parms[2] = new SqlParameter("@LastName", UserDetails.LastName);
                parms[3] = new SqlParameter("@Email", UserDetails.Email);
                parms[4] = new SqlParameter("@UserTypeID", UserDetails.UserTypeID);
                parms[5] = new SqlParameter("@Password", UserDetails.Password);
                parms[6] = new SqlParameter("@IsRegistrationApproved", UserDetails.IsRegistrationApproved);
                parms[7] = new SqlParameter("@IsDeleted", UserDetails.IsDeleted);
                parms[8] = new SqlParameter("@Qalification", UserDetails.Qalification);
                parms[9] = new SqlParameter("@Experience", UserDetails.Experience);
                parms[10] = new SqlParameter("@VPath", UserDetails.VPath);

                if (base.Transaction != null)
                {
                    return (int)_helper.ExecuteScalar(base.Transaction, CommandType.StoredProcedure, "InsertUserDetails", parms);
                }
                else
                {
                    return (int)_helper.ExecuteScalar(base.ConnectionString, CommandType.StoredProcedure, "InsertUserDetails", parms);

                }
            }
            finally { }
        }
    }
}

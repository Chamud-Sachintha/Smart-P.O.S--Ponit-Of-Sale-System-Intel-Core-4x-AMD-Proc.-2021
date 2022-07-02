using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class SupplierDetailsRegistration
    {
        public static SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        internal void RegisterSupllierGeneralDetails(string SupplierIDNumber, string CompanyName, string AddressLine01, string AddressLine02, string City, string EmailAddress, string ContactNumber, string FaxNumber, DateTime JoiningDate, byte[] SupplierProfileImage)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand RegisterSupplierGeneralDetails = new SqlCeCommand("insert into Supplier_GeneralDetails (SupplierId,CompanyName,Address_01,Address_02,City,Email,Contact,Fax,JoiningDate,SupplierProfileImage) values (@SupplierId,@CompanyName,@Address_01,@Address_02,@City,@Email,@Contact,@Fax,@JoiningDate,@SupplierProfileImage)",conn);
            RegisterSupplierGeneralDetails.Parameters.Add("@SupplierID", SupplierIDNumber);
            RegisterSupplierGeneralDetails.Parameters.Add("@CompanyName", CompanyName);
            RegisterSupplierGeneralDetails.Parameters.Add("@Address_01", AddressLine01);
            RegisterSupplierGeneralDetails.Parameters.Add("@Address_02", AddressLine02);
            RegisterSupplierGeneralDetails.Parameters.Add("@City", City);
            RegisterSupplierGeneralDetails.Parameters.Add("@Email", EmailAddress);
            RegisterSupplierGeneralDetails.Parameters.Add("@Contact", ContactNumber);
            RegisterSupplierGeneralDetails.Parameters.Add("@Fax", FaxNumber);
            RegisterSupplierGeneralDetails.Parameters.Add("@JoiningDate", JoiningDate);
            RegisterSupplierGeneralDetails.Parameters.Add(new SqlCeParameter("SupplierProfileImage", SupplierProfileImage));

            RegisterSupplierGeneralDetails.ExecuteNonQuery();
        }

        internal void RegisterSupplierSupplyDetails(string SupplierID, string InsuaranceStatus, string LicenseStatus, string LicensedNumber, string ProvidedCategoryType, string CategoryDescription, string Services, string ServiceDescription, string AdditionalComments)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand RegisterSupplierSupplyDetails = new SqlCeCommand("insert into Supplier_SupplyDetails (SupplierID,InsuaranceStatus,LicenseStatus,LicenseNumber,CategoryType,CategoryDescription,ServiceStatus,ServiceDescription,AdditionalComments) values (@SupplierID,@InsuaranceStatus,@LicenseStatus,@LicenseNumber,@CategoryType,@CategoryDescription,@ServiceStatus,@ServiceDescription,@AdditionalComments)", conn);
            RegisterSupplierSupplyDetails.Parameters.Add("@SupplierID",SupplierID);
            RegisterSupplierSupplyDetails.Parameters.Add("@InsuaranceStatus", InsuaranceStatus);
            RegisterSupplierSupplyDetails.Parameters.Add("@LicenseStatus", LicenseStatus);
            RegisterSupplierSupplyDetails.Parameters.Add("@LicenseNumber", LicensedNumber);
            RegisterSupplierSupplyDetails.Parameters.Add("@CategoryType", ProvidedCategoryType);
            RegisterSupplierSupplyDetails.Parameters.Add("@CategoryDescription", CategoryDescription);
            RegisterSupplierSupplyDetails.Parameters.Add("@ServiceStatus", Services);
            RegisterSupplierSupplyDetails.Parameters.Add("@ServiceDescription", ServiceDescription);
            RegisterSupplierSupplyDetails.Parameters.Add("@AdditionalComments", AdditionalComments);

            RegisterSupplierSupplyDetails.ExecuteNonQuery();
        }

        internal string[] GetSupplierGeneralDetails(string SupplierIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] SupplierGeneralDetails = new string[50];
            SqlCeCommand GetSelectedSupplierGeneralDetails = new SqlCeCommand("select * from Supplier_GeneralDetails where SupplierID = '" + SupplierIDNumber + "'",conn);
            SqlCeDataReader SelectedSupplierGeneralDetails = GetSelectedSupplierGeneralDetails.ExecuteReader();

            while (SelectedSupplierGeneralDetails.Read())
            {
                for (int each_col = 0; each_col < 10; each_col++)
                {
                    SupplierGeneralDetails[each_col] = SelectedSupplierGeneralDetails[each_col].ToString();
                }
            }

            return SupplierGeneralDetails;
        }

        internal string[] GetSupplierSupplyDetails(string SupplierIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] SupplierSupplydetails = new string[50];
            SqlCeCommand GetSupplierSupplyDetails = new SqlCeCommand("select * from Supplier_SupplyDetails where SupplierID = '" + SupplierIDNumber + "'", conn);
            SqlCeDataReader SelectedSupplierSupplyDetails = GetSupplierSupplyDetails.ExecuteReader();

            while (SelectedSupplierSupplyDetails.Read())
            {
                for (int each_col = 0; each_col < 10; each_col++)
                {
                    SupplierSupplydetails[each_col] = SelectedSupplierSupplyDetails[each_col].ToString();
                }
            }

            return SupplierSupplydetails;
        }

        internal void UpdateSupllierGeneralDetails(string SupplierIDNumber, string CompanyName, string AddressLine01, string AddressLine02, string City, string EmailAddress, string ContactNumber, string FaxNumber, DateTime JoiningDate, byte[] SupplierProfileImage)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateSupplierGeneralDetails = new SqlCeCommand("update Supplier_GeneralDetails set CompanyName = @Companyname,Address_01 = @Address_01,Address_02 = @Address_02,City = @City,Email = @Email,Contact = @Contact,Fax = @Fax,JoiningDate = @JoiningDate where SupplierID = @SupplierID", conn);
            UpdateSupplierGeneralDetails.Parameters.Add("@SupplierID", SupplierIDNumber);
            UpdateSupplierGeneralDetails.Parameters.Add("@Companyname",CompanyName);
            UpdateSupplierGeneralDetails.Parameters.Add("@Address_01", AddressLine01);
            UpdateSupplierGeneralDetails.Parameters.Add("@Address_02", AddressLine02);
            UpdateSupplierGeneralDetails.Parameters.Add("@City", City);
            UpdateSupplierGeneralDetails.Parameters.Add("@Email", EmailAddress);
            UpdateSupplierGeneralDetails.Parameters.Add("@Contact", ContactNumber);
            UpdateSupplierGeneralDetails.Parameters.Add("@Fax", FaxNumber);
            UpdateSupplierGeneralDetails.Parameters.Add("@JoiningDate", JoiningDate);

            if (SupplierProfileImage == null)
            {
                UpdateSupplierGeneralDetails.ExecuteNonQuery();
            }
            else
            {
                SqlCeCommand UpdateSupplierImage = new SqlCeCommand("update Supplier_GeneralDetails set SupplierProfileImage = @SupplierProfileImage where SupplierID = '" + SupplierIDNumber + "'",conn);
                UpdateSupplierImage.Parameters.Add("@SupplierID", SupplierIDNumber);
                UpdateSupplierImage.Parameters.Add(new SqlCeParameter("@SupplierProfileImage", SupplierProfileImage));
                UpdateSupplierImage.ExecuteNonQuery();
            }
        }

        internal void UpdateSupplierSupplyDetails(string SupplierIDNumber, string InsuaranceStatus, string LicenseStatus, string LicensedNumber, string ProvidedCategoryType, string CategoryDescription, string Services, string ServiceDescription, string AdditionalComments)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand UpdateSupplierSupplyDetails = new SqlCeCommand("update Supplier_SupplyDetails set InsuaranceStatus = @InsuaranceStatus,LicenseStatus = @LicenseStatus,LicenseNumber = @LicenseNumber,CategoryType = @CategoryType,CategoryDescription = @CategoryDescription,ServiceStatus = @ServiceStatus,ServiceDescription = @ServiceDescription,AdditionalComments = @AdditionalComments where SupplierID = '" + SupplierIDNumber + "'",conn);
            UpdateSupplierSupplyDetails.Parameters.Add("@SupplierID", SupplierIDNumber);
            UpdateSupplierSupplyDetails.Parameters.Add("@InsuaranceStatus", InsuaranceStatus);
            UpdateSupplierSupplyDetails.Parameters.Add("@LicenseStatus", LicenseStatus);
            UpdateSupplierSupplyDetails.Parameters.Add("@LicenseNumber", LicensedNumber);
            UpdateSupplierSupplyDetails.Parameters.Add("@CategoryType", ProvidedCategoryType);
            UpdateSupplierSupplyDetails.Parameters.Add("@CategoryDescription", CategoryDescription);
            UpdateSupplierSupplyDetails.Parameters.Add("@ServiceStatus", Services);
            UpdateSupplierSupplyDetails.Parameters.Add("@ServiceDescription", ServiceDescription);
            UpdateSupplierSupplyDetails.Parameters.Add("@AdditionalComments", AdditionalComments);

            UpdateSupplierSupplyDetails.ExecuteNonQuery();
        }

        internal void DeleteSupplierGeneralDetails(string SupplierIdNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand DeleteSupplierGeneralDetails = new SqlCeCommand("delete from Supplier_GeneralDetails where SupplierID = '" + SupplierIdNumber + "'");
            DeleteSupplierGeneralDetails.ExecuteNonQuery();
        }

        internal void DeleteSupplierSupplyDetails(string SupplierIdNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand DeleteSupplierSuppluDetails = new SqlCeCommand("delete from Supplier_Supply Details where SupplierID = '" + SupplierIdNumber + "'");
            DeleteSupplierSuppluDetails.ExecuteNonQuery();
        }
    }
}

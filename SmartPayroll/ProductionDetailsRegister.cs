using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class ProductionDetailsRegister
    {
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        internal string GettableRowCountForSerialNum()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int CurrentRowCount;

            SqlCeCommand GetTableRowCount = new SqlCeCommand("select count(*) from ProductDetails", conn);
            SqlCeDataReader SelectedCount = GetTableRowCount.ExecuteReader();

            SelectedCount.Read();

            CurrentRowCount = Convert.ToInt32(SelectedCount[0].ToString());

            return CurrentRowCount.ToString("D3");
        }

        internal string[] CheckCategoryNames(string ProductName)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableCategorynames = new string[100];

            SqlCeCommand GetCurrentCatNames = new SqlCeCommand("select category_name from ProductDetails",conn);
            SqlCeDataReader AvailableCategoryNames = GetCurrentCatNames.ExecuteReader();

            int x = 0;
            while (AvailableCategoryNames.Read())
            {
                AvailableCategorynames[x] = AvailableCategoryNames[0].ToString();
                x++;
            }

            string[] RespList = new string[5];

            for (int each_val = 0; each_val < AvailableCategorynames.Length; each_val++)
            {
                if (AvailableCategorynames[each_val] == null)
                {
                    break;
                }
                else if(ProductName == AvailableCategorynames[each_val])
                {
                    RespList[0] = AvailableCategorynames[each_val];
                    break;
                }
            }

            return RespList;
        }

        internal bool registerProductionDetails(DateTime AssigningDate, string ProductCategory, string ProductName, int ItemQuentity, int PricePerItem, string TotalAmount,string SellingPrice, string ProductSerialNumber, string SupplierIDNumber, DateTime ModifyDate, string Companyname, string SupplierName, string AdditionalComments, byte[] BarcodeChar)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterProductDetails = new SqlCeCommand("insert into ProductDetails (assign_date,category,category_name,quentity,price,tot,serial_num,sup_id,mod_date,company_name,supp_name,additional_comm,BarcodeGen,selling_price) values (@assign_date,@category,@category_name,@quentity,@price,@tot,@serial_num,@sup_id,@mod_date,@company_name,@supp_name,@additional_comments,@BarcodeGen,@selling_price)", conn);
                RegisterProductDetails.Parameters.Add("@assign_date", AssigningDate);
                RegisterProductDetails.Parameters.Add("@category", ProductCategory);
                RegisterProductDetails.Parameters.Add("@category_name", ProductName);
                RegisterProductDetails.Parameters.Add("@quentity", ItemQuentity);
                RegisterProductDetails.Parameters.Add("@price", PricePerItem);
                RegisterProductDetails.Parameters.Add("@tot", TotalAmount);
                RegisterProductDetails.Parameters.Add("@serial_num", ProductSerialNumber);
                RegisterProductDetails.Parameters.Add("@sup_id", SupplierIDNumber);
                RegisterProductDetails.Parameters.Add("@mod_date", ModifyDate);
                RegisterProductDetails.Parameters.Add("@company_name", Companyname);
                RegisterProductDetails.Parameters.Add("@supp_name", SupplierName);
                RegisterProductDetails.Parameters.Add("@additional_comments", AdditionalComments);
                RegisterProductDetails.Parameters.Add("@selling_price", SellingPrice);
                RegisterProductDetails.Parameters.Add(new SqlCeParameter("@BarcodeGen", BarcodeChar));

                RegisterProductDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string SelectedSupplierDetails(string SupplierIDNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string CompanyName;
            SqlCeCommand GetSupplierDetails = new SqlCeCommand("select CompanyName from Supplier_GeneralDetails where SupplierId = @SupplierIDNumber", conn);
            GetSupplierDetails.Parameters.Add("@SupplierIDNumber", SupplierIDNumber);

            SqlCeDataReader SelectedSupplierDetails = GetSupplierDetails.ExecuteReader();
            SelectedSupplierDetails.Read();

            try
            {
                CompanyName = SelectedSupplierDetails[0].ToString();
            }
            catch (InvalidOperationException)
            {
                CompanyName = "Invalid Supplier ID";
            }

            return CompanyName;
        }

        internal string[] GetSelectedProductionDetails(string ProductSerialNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] ProductDetails = new string[50];

            SqlCeCommand GetSelectedProductionDetails = new SqlCeCommand("select * from ProductDetails where serial_num = @serial_num", conn);
            GetSelectedProductionDetails.Parameters.Add("@serial_num", ProductSerialNumber);

            SqlCeDataReader SelectedProductDetails = GetSelectedProductionDetails.ExecuteReader();
            SelectedProductDetails.Read();

            try
            {
                for (int each_col = 0; each_col < 16; each_col++)
                {
                    ProductDetails[each_col] = SelectedProductDetails[each_col].ToString();
                }

                return ProductDetails;
            }
            catch (InvalidOperationException)
            {
                return ProductDetails;
            }

        }

        internal bool UpdateProductionDetails(DateTime AssigningDate, string ProductCategory, string ProductName, int ItemQuentity, int PricePerItem, string TotalAmount,string SellingPrice, string ProductSerialNumber, string SupplierIDNumber, DateTime ModifyDate, string Companyname, string SupplierName, string AdditionalComments, byte[] BarcodeChar)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateProductDetails = new SqlCeCommand("update ProductDetails set assign_date = @assign_date,category = @category,category_name = @category_name,quentity = @quentity,price = @price,tot = @tot,serial_num = @serial_num,sup_id = @sup_id,mod_date = @mod_date,company_name = @company_name,supp_name = @supp_name,additional_comm = @additional_comm,BarcodeGen = @BarcodeGen,selling_price = @selling_price where serial_num = @serial_num", conn);
                UpdateProductDetails.Parameters.Add("@assign_date", AssigningDate);
                UpdateProductDetails.Parameters.Add("@category", ProductCategory);
                UpdateProductDetails.Parameters.Add("@category_name", ProductName);
                UpdateProductDetails.Parameters.Add("@quentity", ItemQuentity);
                UpdateProductDetails.Parameters.Add("@price", PricePerItem);
                UpdateProductDetails.Parameters.Add("@tot", TotalAmount);
                UpdateProductDetails.Parameters.Add("@serial_num", ProductSerialNumber);
                UpdateProductDetails.Parameters.Add("@sup_id", SupplierIDNumber);
                UpdateProductDetails.Parameters.Add("@mod_date", ModifyDate);
                UpdateProductDetails.Parameters.Add("@company_name", Companyname);
                UpdateProductDetails.Parameters.Add("@supp_name", SupplierName);
                UpdateProductDetails.Parameters.Add("@additional_comm", AdditionalComments);
                UpdateProductDetails.Parameters.Add("@selling_price", SellingPrice);
                UpdateProductDetails.Parameters.Add(new SqlCeParameter("@BarcodeGen", BarcodeChar));

                UpdateProductDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteProductDetails(string ProductSerialNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteProductDetails = new SqlCeCommand("delete from ProductDetails where serial_num = @serial_num", conn);
                DeleteProductDetails.Parameters.Add("@serial_num", ProductSerialNumber);

                DeleteProductDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

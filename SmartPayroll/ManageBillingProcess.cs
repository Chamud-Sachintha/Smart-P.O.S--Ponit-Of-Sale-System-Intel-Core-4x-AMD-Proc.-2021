using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class ManageBillingProcess
    {
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");


        internal string[] GetSelectedProductDetails(string ProductSerialNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] ProductDetails = new string[10];
            SqlCeCommand GetSelectedProductDetails = new SqlCeCommand("select category,category_name,selling_price,sup_id,mod_date,company_name,supp_name,additional_comm from ProductDetails where serial_num = @serial_num", conn);
            GetSelectedProductDetails.Parameters.Add("@serial_num", ProductSerialNumber);

            SqlCeDataReader SelectedProductDetails = GetSelectedProductDetails.ExecuteReader();
            SelectedProductDetails.Read();

            for (int each_col = 0; each_col < 8; each_col++)
            {
                ProductDetails[each_col] = SelectedProductDetails[each_col].ToString();
            }

            return ProductDetails;
        }

        internal void InsertBillCache(int TotalAmount,DateTime BillingDate)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand InsertBillCache = new SqlCeCommand("insert into bill_chache (billing_date,total_selling) values (@billing_date,@total_selling)", conn);
            InsertBillCache.Parameters.Add("@billing_date", BillingDate);
            InsertBillCache.Parameters.Add("@total_selling", TotalAmount);

            InsertBillCache.ExecuteNonQuery();
        }
    }
}

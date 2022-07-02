using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class ManageAllVeiws
    {
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        internal string[] GetAllSections()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] SectionDetails = new string[10];
            SqlCeCommand GetSectionDetails = new SqlCeCommand("select sec_name from SectionTable", conn);
            SqlCeDataReader AvailableSections = GetSectionDetails.ExecuteReader();

            int x = 0;
            while (AvailableSections.Read())
            {
                SectionDetails[x] = AvailableSections[0].ToString();
                x++;
            }

            return SectionDetails;
        }

        internal string[] GetAllPositions()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailablePositions = new string[10];
            SqlCeCommand GetPositionDetails = new SqlCeCommand("select position_name from PositionTable", conn);
            SqlCeDataReader AvailablePositionDetails = GetPositionDetails.ExecuteReader();

            int x = 0;
            while (AvailablePositionDetails.Read())
            {
                AvailablePositions[x] = AvailablePositionDetails[0].ToString();
                x++;
            }

            return AvailablePositions;
        }

        internal string[] GetAvailableCompanyNames()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] Companynames = new string[50];
            SqlCeCommand GetCompanyNames = new SqlCeCommand("select distinct CompanyName from Supplier_GeneralDetails", conn);
            SqlCeDataReader AvailableCompanynames = GetCompanyNames.ExecuteReader();

            int x = 0;
            while (AvailableCompanynames.Read())
            {
                Companynames[x] = AvailableCompanynames[0].ToString();
                x++;
            }

            return Companynames;
        }

        internal string[] GetProvideProductTypes()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] ProductTypes = new string[50];
            SqlCeCommand GetProductTypes = new SqlCeCommand("select distinct category from ProductDetails", conn);
            SqlCeDataReader AvailableProductTypes = GetProductTypes.ExecuteReader();

            int x = 0 ;
            while (AvailableProductTypes.Read())
            {
                ProductTypes[x] = AvailableProductTypes[0].ToString();
                x++;
            }

            return ProductTypes;
        }
    }
}

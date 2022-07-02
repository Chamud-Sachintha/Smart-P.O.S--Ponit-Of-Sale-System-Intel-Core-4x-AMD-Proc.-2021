using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class SettingsMgmt
    {
        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        internal bool AddNewSectionDetails(string SectionId, string SectionName, string Sectiondescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand AddNewSectiondetails = new SqlCeCommand("insert into SectionTable (sec_id,sec_name,description) values (@sec_id,@sec_name,@description)", conn);
                AddNewSectiondetails.Parameters.Add("@sec_id", SectionId);
                AddNewSectiondetails.Parameters.Add("@sec_name", SectionName);
                AddNewSectiondetails.Parameters.Add("@description", Sectiondescription);

                AddNewSectiondetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] SearchSectiondetails(string Sectionid)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableSectiondetails = new string[50];
            SqlCeCommand SearchSectiondetails = new SqlCeCommand("select * from SectionTable", conn);
            SqlCeDataReader getSectiondetails = SearchSectiondetails.ExecuteReader();

            while (getSectiondetails.Read())
            {
                for (int each_col = 0; each_col < 4; each_col++)
                {
                    AvailableSectiondetails[each_col] = getSectiondetails[each_col].ToString();
                }
            }

            return AvailableSectiondetails;
        }

        internal bool UpdateSelectedSectionDetails(string SectionId,string SectionName,string Sectiondescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedSectiondetails = new SqlCeCommand("update SectionTable set sec_name = @SectionName,description = @Sectiondescription where sec_id = @SectionId", conn);
                UpdateSelectedSectiondetails.Parameters.Add("@SectionId", SectionId);
                UpdateSelectedSectiondetails.Parameters.Add("@SectionName", SectionName);
                UpdateSelectedSectiondetails.Parameters.Add("@Sectiondescription", Sectiondescription);

                UpdateSelectedSectiondetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteSelectedSectionDetails(string SectionIdNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedSectiondetails = new SqlCeCommand("delete from SectionTable where sec_id = @SectionIdNumber", conn);
                DeleteSelectedSectiondetails.Parameters.Add("@SectionIdNumber", SectionIdNumber);

                DeleteSelectedSectiondetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool RegisterNewPositionDetails(string PositionIdNumber, string Positionname, string PosiotionDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterNewPositionDetails = new SqlCeCommand("insert into PositionTable (position_id,position_name,description) values (@position_id,@position_name,@description)", conn);
                RegisterNewPositionDetails.Parameters.Add("@position_id", PositionIdNumber);
                RegisterNewPositionDetails.Parameters.Add("@position_name", Positionname);
                RegisterNewPositionDetails.Parameters.Add("@description", PosiotionDescription);

                RegisterNewPositionDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetSelectedPositiondetails(string PositionIdNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] PositionDetails = new string[10];

            SqlCeCommand GetSelectedPositiondetails = new SqlCeCommand("select * from PositionTable where position_id = @PositionId",conn);
            GetSelectedPositiondetails.Parameters.Add("@PositionId", PositionIdNumber);

            SqlCeDataReader SelectedPositiondetails = GetSelectedPositiondetails.ExecuteReader();

            SelectedPositiondetails.Read();

            for (int each_col = 0; each_col < 4; each_col++)
            {
                PositionDetails[each_col] = SelectedPositiondetails[each_col].ToString();
            }

            return PositionDetails;
        }

        internal bool UpdateNewPositionDetails(string PositionIdNumber, string Positionname, string PosiotionDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand UpdateSelectedPositiondetails = new SqlCeCommand("update PositionTable set position_name = @PositionName,description = @PositionDescription where position_id = @PositionId", conn);
                UpdateSelectedPositiondetails.Parameters.Add("@PositionId", PositionIdNumber);
                UpdateSelectedPositiondetails.Parameters.Add("@PositionName", Positionname);
                UpdateSelectedPositiondetails.Parameters.Add("@PositionDescription", PosiotionDescription);

                UpdateSelectedPositiondetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteSelectedPositionDetails(string PositionIdNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteSelectedPositiondetails = new SqlCeCommand("delete from PositionTable where position_id = @PositionIdNumber", conn);
                DeleteSelectedPositiondetails.Parameters.Add("@PositionIdNumber", PositionIdNumber);

                DeleteSelectedPositiondetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

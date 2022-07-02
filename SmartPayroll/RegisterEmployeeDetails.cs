using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    class RegisterEmployeeDetails
    {
        public static SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        internal bool RegisterEmployeeGeneralDetailsInSystem(string FullName, string NicNumber, DateTime BirthDate, string EmailAddress, string Password, string Address, string Gender, string Contact_01, string Contact_02, byte[] EmployeeProfileImage)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeGeneralDetails = new SqlCeCommand("insert into EMP_GeneralDetails(full_name,nic_no,email,password,address,gender,contact_01,contact_02,EMP_image,bdate) values (@full_name,@nic_no,@email,@password,@address,@gender,@contact_01,@contact_02,@EMP_image,@bdate)", conn);
                RegisterEmployeeGeneralDetails.Parameters.Add("@full_name", FullName);
                RegisterEmployeeGeneralDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeGeneralDetails.Parameters.Add("@email", EmailAddress);
                RegisterEmployeeGeneralDetails.Parameters.Add("@password", Password);
                RegisterEmployeeGeneralDetails.Parameters.Add("@address", Address);
                RegisterEmployeeGeneralDetails.Parameters.Add("@gender", Gender);
                RegisterEmployeeGeneralDetails.Parameters.Add("@contact_01", Contact_01);
                RegisterEmployeeGeneralDetails.Parameters.Add("@contact_02", Contact_02);
                RegisterEmployeeGeneralDetails.Parameters.Add("@bdate", BirthDate);
                RegisterEmployeeGeneralDetails.Parameters.Add(new SqlCeParameter("@EMP_Image", EmployeeProfileImage));

                RegisterEmployeeGeneralDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetSelectedEMP_PersonalDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] EMP_PersonalDetails = new string[100];

            SqlCeCommand GetSelectedEMP_PersonalDetails = new SqlCeCommand("select * from EMP_GeneralDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader SelectedEMPDetails = GetSelectedEMP_PersonalDetails.ExecuteReader();

            while (SelectedEMPDetails.Read())
            {
                EMP_PersonalDetails[0] = SelectedEMPDetails[1].ToString();
                EMP_PersonalDetails[1] = SelectedEMPDetails[2].ToString();
                EMP_PersonalDetails[2] = SelectedEMPDetails[3].ToString();
                EMP_PersonalDetails[3] = SelectedEMPDetails[4].ToString();
                EMP_PersonalDetails[4] = SelectedEMPDetails[5].ToString();
                EMP_PersonalDetails[5] = SelectedEMPDetails[6].ToString();
                EMP_PersonalDetails[6] = SelectedEMPDetails[7].ToString();
                EMP_PersonalDetails[7] = SelectedEMPDetails[8].ToString();
                EMP_PersonalDetails[8] = SelectedEMPDetails[9].ToString();
                EMP_PersonalDetails[9] = SelectedEMPDetails[10].ToString();
            }

            return EMP_PersonalDetails;
        }

        internal string[] GetAvailablePositiondetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailablePositionDetails = new string[20];
            SqlCeCommand GetAvailablePositionDetails = new SqlCeCommand("select position_name from PositionTable", conn);
            SqlCeDataReader SelectedPositiondetails = GetAvailablePositionDetails.ExecuteReader();

            int x = 0;
            while (SelectedPositiondetails.Read())
            {
                AvailablePositionDetails[x] = SelectedPositiondetails[0].ToString();
                x++;
            }

            return AvailablePositionDetails;
        }

        internal string[] GetAvailableSectionDetails()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] AvailableSectiondetails = new string[20];
            SqlCeCommand GetAvailablesectionDetails = new SqlCeCommand("select sec_name from SectionTable", conn);
            SqlCeDataReader SelectedAvailableSectiondetails = GetAvailablesectionDetails.ExecuteReader();

            int x = 0;
            while (SelectedAvailableSectiondetails.Read())
            {
                AvailableSectiondetails[x] = SelectedAvailableSectiondetails[0].ToString();
                x++;
            }

            return AvailableSectiondetails;
        }

        internal bool RegisterEmployeeEmployementDetails(string NicNumber,string JobTitle, string JobPosition, DateTime JoiningDate, DateTime RegistrationDate, DateTime RetrivementDate, string JobSection, string PrevCompany, string PrevPositiondescription, string ETF_EPF_No, string Province, string District, string PostalCode, string EmployeementType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployementDetails = new SqlCeCommand("insert into EMP_EmployementDetails (nic_no,job_title,job_position,joining_date,registration_date,retriving_date,prev_company,description,job_section,etf_epf_no,home_province,district,postal_code,employement_status) values (@nic_no,@job_title,@job_position,@joining_date,@Registration_date,@retriving_date,@prev_company,@description,@job_section,@etf_epf_no,@home_province,@district,@postal_code,@employement_status)", conn);
                RegisterEmployementDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployementDetails.Parameters.Add("@job_title", JobTitle);
                RegisterEmployementDetails.Parameters.Add("@job_position", JobPosition);
                RegisterEmployementDetails.Parameters.Add("@joining_date", JoiningDate);
                RegisterEmployementDetails.Parameters.Add("@Registration_date", RegistrationDate);
                RegisterEmployementDetails.Parameters.Add("@retriving_date", RetrivementDate);
                RegisterEmployementDetails.Parameters.Add("@prev_company", PrevCompany);
                RegisterEmployementDetails.Parameters.Add("@description", PrevPositiondescription);
                RegisterEmployementDetails.Parameters.Add("@job_section", JobSection);
                RegisterEmployementDetails.Parameters.Add("@etf_epf_no", ETF_EPF_No);
                RegisterEmployementDetails.Parameters.Add("@home_province", Province);
                RegisterEmployementDetails.Parameters.Add("@district", District);
                RegisterEmployementDetails.Parameters.Add("@postal_code", PostalCode);
                RegisterEmployementDetails.Parameters.Add("@employement_status", EmployeementType);

                RegisterEmployementDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool RegisterEmployeeEducationalQualificationDetails(string NicNumber, string OlevelStatus, string OlevelDescription, string AlevelStatus, string AlevelDescription, string OtherStatus, string OtherDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeEducationalDetails = new SqlCeCommand("insert into EMP_EducationalDetails(nic_no,ol_status,ol_dsesc,al_status,al_desc,other_qualifications,other_desc) values (@nic_no,@ol_status,@ol_dsesc,@al_status,@al_desc,@other_qualifications,@other_desc)", conn);
                RegisterEmployeeEducationalDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeEducationalDetails.Parameters.Add("@ol_status", OlevelStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@ol_dsesc", OlevelDescription);
                RegisterEmployeeEducationalDetails.Parameters.Add("@al_status", AlevelStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@al_desc", AlevelDescription);
                RegisterEmployeeEducationalDetails.Parameters.Add("@other_qualifications", OtherStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@other_desc", OtherDescription);

                RegisterEmployeeEducationalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool RegisterEmployeeEmergenvyContactDetails(string NicNumber, string NameTitle, string FirstName, string LastName, string Relationship, string Description, string EmergencyAddress, string EmergencyContact_01, string EmergencyContact_02, string EmergencyEmailAddress)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeEmergencyDetails = new SqlCeCommand("insert into EMP_EmergencyContactDetails (nic_no,name_title,f_name,l_name,relationship,description,address,contact_01,contact_02,email) values (@nic_no,@name_title,@f_name,@l_name,@relationship,@description,@address,@contact_01,@contact_02,@email)", conn);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@name_title", NameTitle);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@f_name", FirstName);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@l_name", LastName);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@relationship", Relationship);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@description", Description);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@address", EmergencyAddress);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@contact_01", EmergencyContact_01);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@contact_02", EmergencyContact_02);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@email", EmergencyEmailAddress);

                RegisterEmployeeEmergencyDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool RegisterEmployeeBankDetails(string NicNumber, string BankName, string BranchName, string AccountType, string AccountNumber, string BSBNumber, DateTime SystemDate)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeBankdetails = new SqlCeCommand("insert into EMP_BankDetails (nic_no,bank_name,branch_name,account_type,account_number,BSB_number,sys_date) values (@nic_no,@bank_name,@branch_name,@account_type,@account_number,@BSB_number,@sys_date) ", conn);
                RegisterEmployeeBankdetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@bank_name", BankName);
                RegisterEmployeeBankdetails.Parameters.Add("@branch_name", BranchName);
                RegisterEmployeeBankdetails.Parameters.Add("@account_type", AccountType);
                RegisterEmployeeBankdetails.Parameters.Add("@account_number", AccountNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@BSB_number", BSBNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@sys_date", SystemDate);

                RegisterEmployeeBankdetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal string[] GetSelectedEmployeementDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] EmployeementDetails = new string[50];
            SqlCeCommand GetSelectedEmployeementDetails = new SqlCeCommand("select * from EMP_EmployementDetails where nic_no = '" + NicNumber + "'",conn);
            SqlCeDataReader SelectedEmployeementDetails = GetSelectedEmployeementDetails.ExecuteReader();

            while (SelectedEmployeementDetails.Read())
            {
                for (int each_col = 0; each_col < 14; each_col++)
                {
                    EmployeementDetails[each_col] = SelectedEmployeementDetails[each_col].ToString();
                }
            }

            return EmployeementDetails;
        }

        internal string[] GetSelectedEmployeeEducationalDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] EducationalDetails = new string[50];
            SqlCeCommand GetEmployeeEducationalDetails = new SqlCeCommand("select * from EMP_EducationalDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader SelectedEmployeeEducationalDetails = GetEmployeeEducationalDetails.ExecuteReader();

            while (SelectedEmployeeEducationalDetails.Read())
            {
                for (int each_col = 0; each_col < 7; each_col++)
                {
                    EducationalDetails[each_col] = SelectedEmployeeEducationalDetails[each_col].ToString();
                }
            }

            return EducationalDetails;
        }

        internal string[] GetEmployeeEmergencyContactDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] EmergencyContactDetails = new string[50];
            SqlCeCommand GetEmployeeEmergencyContactDetails = new SqlCeCommand("select * from EMP_EmergencyContactDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader SelectedEmergencyDetails = GetEmployeeEmergencyContactDetails.ExecuteReader();

            while (SelectedEmergencyDetails.Read())
            {
                for (int each_col = 0; each_col < 10; each_col++)
                {
                    EmergencyContactDetails[each_col] = SelectedEmergencyDetails[each_col].ToString();
                }
            }

            return EmergencyContactDetails;
        }

        internal string[] GetEmployeeBankDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            string[] EmployeeBankDetails = new string[50];
            SqlCeCommand GetEmployeeBankDetails = new SqlCeCommand("select * from EMP_BankDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader SelectedEmployeeBankDetails = GetEmployeeBankDetails.ExecuteReader();

            while (SelectedEmployeeBankDetails.Read())
            {
                for (int each_col = 0; each_col < 7; each_col++)
                {
                    EmployeeBankDetails[each_col] = SelectedEmployeeBankDetails[each_col].ToString();
                }
            }

            return EmployeeBankDetails;
        }

        internal bool UpdateEmployeeGeneralDetailsInSystem(string FullName, string NicNumber, DateTime BirthDate, string EmailAddress, string Password, string Address, string Gender, string Contact_01, string Contact_02, byte[] EmployeeProfileImage)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeGeneralDetails = new SqlCeCommand("update EMP_GeneralDetails set full_name = @full_name ,email = @email,password = @password,address = @address,gender = @gender,contact_01 = @contact_01,contact_02 = @contact_02,bdate = @bdate where nic_no = @nic_no", conn);
                RegisterEmployeeGeneralDetails.Parameters.Add("@full_name", FullName);
                RegisterEmployeeGeneralDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeGeneralDetails.Parameters.Add("@email", EmailAddress);
                RegisterEmployeeGeneralDetails.Parameters.Add("@password", Password);
                RegisterEmployeeGeneralDetails.Parameters.Add("@address", Address);
                RegisterEmployeeGeneralDetails.Parameters.Add("@gender", Gender);
                RegisterEmployeeGeneralDetails.Parameters.Add("@contact_01", Contact_01);
                RegisterEmployeeGeneralDetails.Parameters.Add("@contact_02", Contact_02);
                RegisterEmployeeGeneralDetails.Parameters.Add("@bdate", BirthDate);

                if (EmployeeProfileImage == null)
                {
                    RegisterEmployeeGeneralDetails.ExecuteNonQuery();
                }
                else
                {
                    SqlCeCommand UpdateProfileImage = new SqlCeCommand("update EMP_GeneralDetails set EMP_Image = @EMP_Image where nic_no = @nic_no", conn);
                    UpdateProfileImage.Parameters.Add("@nic_no", NicNumber);
                    UpdateProfileImage.Parameters.Add(new SqlCeParameter("@EMP_Image", EmployeeProfileImage));
                    UpdateProfileImage.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool UpdateEmployeeEmployementDetails(string NicNumber, string JobTitle, string JobPosition, DateTime JoiningDate, DateTime RegistrationDate, DateTime RetrivementDate, string JobSection, string PrevCompany, string PrevPositiondescription, string ETF_EPF_No, string Province, string District, string PostalCode, string EmployeementType)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployementDetails = new SqlCeCommand("update EMP_EmployementDetails set job_title = @job_title,job_position = @job_position,joining_date = @joining_date,registration_date = @Registration_date,retriving_date = @retriving_date,prev_company = @prev_company,description = @description,job_section = @job_section,etf_epf_no = @etf_epf_no,home_province = @home_province,district = @district,postal_code = @postal_code,employement_status = @employement_status where nic_no = @nic_no", conn);
                RegisterEmployementDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployementDetails.Parameters.Add("@job_title", JobTitle);
                RegisterEmployementDetails.Parameters.Add("@job_position", JobPosition);
                RegisterEmployementDetails.Parameters.Add("@joining_date", JoiningDate);
                RegisterEmployementDetails.Parameters.Add("@Registration_date", RegistrationDate);
                RegisterEmployementDetails.Parameters.Add("@retriving_date", RetrivementDate);
                RegisterEmployementDetails.Parameters.Add("@prev_company", PrevCompany);
                RegisterEmployementDetails.Parameters.Add("@description", PrevPositiondescription);
                RegisterEmployementDetails.Parameters.Add("@job_section", JobSection);
                RegisterEmployementDetails.Parameters.Add("@etf_epf_no", ETF_EPF_No);
                RegisterEmployementDetails.Parameters.Add("@home_province", Province);
                RegisterEmployementDetails.Parameters.Add("@district", District);
                RegisterEmployementDetails.Parameters.Add("@postal_code", PostalCode);
                RegisterEmployementDetails.Parameters.Add("@employement_status", EmployeementType);

                RegisterEmployementDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool UpdateEmployeeEducationalQualificationDetails(string NicNumber, string OlevelStatus, string OlevelDescription, string AlevelStatus, string AlevelDescription, string OtherStatus, string OtherDescription)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeEducationalDetails = new SqlCeCommand("update EMP_EducationalDetails set ol_status = @ol_status,ol_dsesc = @ol_dsesc,al_status = @al_status,al_desc = @al_desc,other_qualifications = @other_qualifications,other_desc = @other_desc where nic_no = @nic_no", conn);
                RegisterEmployeeEducationalDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeEducationalDetails.Parameters.Add("@ol_status", OlevelStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@ol_dsesc", OlevelDescription);
                RegisterEmployeeEducationalDetails.Parameters.Add("@al_status", AlevelStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@al_desc", AlevelDescription);
                RegisterEmployeeEducationalDetails.Parameters.Add("@other_qualifications", OtherStatus);
                RegisterEmployeeEducationalDetails.Parameters.Add("@other_desc", OtherDescription);

                RegisterEmployeeEducationalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool UpdateEmployeeEmergenvyContactDetails(string NicNumber, string NameTitle, string FirstName, string LastName, string Relationship, string Description, string EmergencyAddress, string EmergencyContact_01, string EmergencyContact_02, string EmergencyEmailAddress)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeEmergencyDetails = new SqlCeCommand("update EMP_EmergencyContactDetails set name_title = @name_title,f_name = @f_name,l_name = @l_name,relationship = @relationship,description = @description,address = @address,contact_01 = @contact_01,contact_02 = @contact_02,email = @email where nic_no = @nic_no", conn);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@name_title", NameTitle);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@f_name", FirstName);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@l_name", LastName);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@relationship", Relationship);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@description", Description);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@address", EmergencyAddress);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@contact_01", EmergencyContact_01);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@contact_02", EmergencyContact_02);
                RegisterEmployeeEmergencyDetails.Parameters.Add("@email", EmergencyEmailAddress);

                RegisterEmployeeEmergencyDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool UpdateEmployeeBankDetails(string NicNumber, string BankName, string BranchName, string AccountType, string AccountNumber, string BSBNumber, DateTime SystemDate)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand RegisterEmployeeBankdetails = new SqlCeCommand("update EMP_BankDetails set bank_name = @bank_name,branch_name = @branch_name,account_type = @account_type,account_number = @account_number,BSB_number = @BSB_number,sys_date = @sys_date where nic_no = @nic_no", conn);
                RegisterEmployeeBankdetails.Parameters.Add("@nic_no", NicNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@bank_name", BankName);
                RegisterEmployeeBankdetails.Parameters.Add("@branch_name", BranchName);
                RegisterEmployeeBankdetails.Parameters.Add("@account_type", AccountType);
                RegisterEmployeeBankdetails.Parameters.Add("@account_number", AccountNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@BSB_number", BSBNumber);
                RegisterEmployeeBankdetails.Parameters.Add("@sys_date", SystemDate);

                RegisterEmployeeBankdetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteEmployeePersonalDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteEmployeePersonalDetails = new SqlCeCommand("delete from EMP_GeneralDetails where nic_no = '" + NicNumber + "'", conn);
                DeleteEmployeePersonalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteEmployeeEmployementDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteEmployeePersonalDetails = new SqlCeCommand("delete from EMP_EmployementDetails where nic_no = '" + NicNumber + "'", conn);
                DeleteEmployeePersonalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteEmployeeEducationalDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteEmployeePersonalDetails = new SqlCeCommand("delete from EMP_EducationalDetails where nic_no = '" + NicNumber + "'", conn);
                DeleteEmployeePersonalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteEmployeeEmergencyContactDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteEmployeePersonalDetails = new SqlCeCommand("delete from EMP_EmergencyContactDetails where nic_no = '" + NicNumber + "'", conn);
                DeleteEmployeePersonalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool DeleteEmployeeEmployeBankDetails(string NicNumber)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();

                SqlCeCommand DeleteEmployeePersonalDetails = new SqlCeCommand("delete from EMP_BankDetails where nic_no = '" + NicNumber + "'", conn);
                DeleteEmployeePersonalDetails.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

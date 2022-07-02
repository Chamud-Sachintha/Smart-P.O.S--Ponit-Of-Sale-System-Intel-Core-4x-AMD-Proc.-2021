using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlServerCe;

namespace SmartPayroll
{
    public partial class EmployeeDetailsManagement : UserControl
    {
        public EmployeeDetailsManagement()
        {
            InitializeComponent();
        }

        RegisterEmployeeDetails EmployeeObj = new RegisterEmployeeDetails();

        public void ReturnSysSectiondetails()
        {
            string[] AvailableSectiondetails = EmployeeObj.GetAvailableSectionDetails();

            for (int Each_Section = 0; Each_Section < AvailableSectiondetails.Length; Each_Section++)
            {
                if (AvailableSectiondetails[Each_Section] == null)
                {
                    break;
                }

                jobsection_cmb.Items.Add(AvailableSectiondetails[Each_Section]);
            }
        }

        public void ReturnSysPositiondetails()
        {
            string[] AvailablePositiondetails = EmployeeObj.GetAvailablePositiondetails();

            for (int Each_Position = 0; Each_Position < AvailablePositiondetails.Length; Each_Position++)
            {
                if (AvailablePositiondetails[Each_Position] == null)
                {
                    break;
                }

                jobpos_cmb.Items.Add(AvailablePositiondetails[Each_Position]);
            }
        }

        public bool CheckFeildsValues(string StringValues)
        {
            if (string.IsNullOrEmpty(StringValues))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckNumericFeilds(string value)
        {
            int GetValue;

            try
            {
                GetValue = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }

        public DateTime CheckValidDateValue(string DateValue)
        {
            DateTime ConVal;

            try
            {
                ConVal = Convert.ToDateTime(DateValue);
            }
            catch (Exception)
            {
                ConVal = System.DateTime.Now;
            }

            return ConVal;
        }

        string EmployeeImageLocation = "";

        private void browse_image_Click(object sender, EventArgs e)
        {
            //Get The Employee Profile Image for PictureBox

            OpenFileDialog FileDialog = new OpenFileDialog();

            FileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                emp_profile_picture.Image = null;
                EmployeeImageLocation = FileDialog.FileName.ToString();
                emp_profile_picture.ImageLocation = EmployeeImageLocation;
            }
        }

        private void registerEmployee_btn_Click(object sender, EventArgs e)
        {
            byte[] EmployeeProfileImage = null;
            string EmployeementStatus = "";
            string Gender = "";

            string NicNumber = nic_no_txt.Text;
            string FullName = fullname_txt.Text;
            DateTime BirthDate = CheckValidDateValue(bdate_dtpick.Text);
            string EmailAddress = email_txt.Text;
            string Password = pass_txt.Text;
            string Address = address_txt.Text;

            if (male_radio.Checked == true)
            {
                Gender = male_radio.Name;
            }
            else
            {
                Gender = female_radio.Name;
            }

            string Contact_01 = contact01_txt.Text;
            string Contact_02 = contact02_txt.Text;

            string JobTitle = jobtitle_txt.Text;
            string Jobposition = jobsection_cmb.Text;
            DateTime JoiningDate = CheckValidDateValue(joininmgDate_dtpick.Text);
            DateTime Registrationdate = CheckValidDateValue(registrationDate_dpick.Text);
            string PrevCompany = prevcompany_txt.Text;
            string PrevCompanyDesc = prevPosDesc_txt.Text;

            string Jobsection = jobsection_cmb.Text;
            string ETF_EPF_No = etf_epf_txt.Text;
            DateTime RetrivementDate = CheckValidDateValue(retrivingDate_dtpick.Text);
            string Province = province_cmb.Text;
            string District = district_cmb.Text;
            string PostalCode = postalCode_txt.Text;

            if (FullTime.Checked == true)
            {
                EmployeementStatus = FullTime.Name;
            }
            else if (PartTime.Checked == true)
            {
                EmployeementStatus = PartTime.Name;
            }
            else if (Cassual.Checked == true)
            {
                EmployeementStatus = Cassual.Name;
            }
            else
            {
                EmployeementStatus = Tempory.Name;
            }

            string OlevelStatus = olevel_status_cmb.Text;
            string OlevelDescription = olevel_desc_txt.Text;
            string AlevelStatus = alevel_status_cmb.Text;
            string AlevelDescription = alevel_desc_txt.Text;
            string OtherStatus = other_status_cmb.Text;
            string OtherDescription = other_desc_txt.Text;

            string NameTitle = name_title_cmb.Text;
            string FirstName = fname_txt.Text;
            string LastName = lname_txt.Text;
            string Relationship = relationship_txt.Text;
            string Description = desc_txt.Text;
            string EmergencyAddress = emrg_address_txt.Text;
            string EmergencyContact01 = emrg_contact_1_txt.Text;
            string EmergencyContact02 = emrg_contact_2_txt.Text;
            string EmergencyEmailAddress = emrg_email_txt.Text;

            string BankName = bank_name_txt.Text;
            string BranchName = branch_name_txt.Text;
            string AccountType = acc_type_txt.Text;
            string AccountNumber = acc_number_txt.Text;
            string BSBNumber = bsb_txt.Text;
            DateTime SysDate = CheckValidDateValue(date_dtpick.Text);

            if (CheckFeildsValues(NicNumber) == true && CheckFeildsValues(FullName) == true && CheckFeildsValues(EmailAddress) == true && CheckFeildsValues(Password) == true
                && CheckFeildsValues(Address) == true && CheckFeildsValues(Gender) == true && (CheckFeildsValues(Contact_01) == true || CheckFeildsValues(Contact_02) == true)
                && CheckFeildsValues(JobTitle) == true && CheckFeildsValues(Jobposition) == true && CheckFeildsValues(Jobsection) == true && CheckFeildsValues(ETF_EPF_No) == true
                && CheckFeildsValues(Province) == true && CheckFeildsValues(District) == true && CheckFeildsValues(PostalCode) == true && CheckFeildsValues(EmployeementStatus) == true
                && (CheckFeildsValues(OlevelStatus) == true || CheckFeildsValues(AlevelStatus) == true || CheckFeildsValues(OtherStatus) == true) && CheckFeildsValues(NameTitle) == true
                && CheckFeildsValues(FirstName) == true && CheckFeildsValues(LastName) == true && CheckFeildsValues(Relationship) == true && CheckFeildsValues(EmergencyAddress) == true
                && (CheckFeildsValues(EmergencyContact01) == true || CheckFeildsValues(EmergencyContact02) == true) && CheckFeildsValues(EmergencyEmailAddress) == true && CheckFeildsValues(BankName) == true
                && CheckFeildsValues(BranchName) == true && CheckFeildsValues(AccountType) == true && CheckFeildsValues(AccountNumber) == true && CheckFeildsValues(BSBNumber) == true)
            {
                try
                {
                    FileStream FStream = new FileStream(EmployeeImageLocation,FileMode.Open,FileAccess.Read);
                    BinaryReader BrsObj = new BinaryReader(FStream);

                    EmployeeProfileImage = BrsObj.ReadBytes((int)FStream.Length);

                    if ((EmployeeObj.RegisterEmployeeGeneralDetailsInSystem(FullName, NicNumber, BirthDate, EmailAddress, Password, Address, Gender, Contact_01, Contact_02, EmployeeProfileImage) == true) && 
                        (EmployeeObj.RegisterEmployeeEmployementDetails( NicNumber, JobTitle,  Jobposition,  JoiningDate,  Registrationdate,  RetrivementDate,  Jobsection,  PrevCompany,  PrevCompanyDesc,  ETF_EPF_No, 
                        Province,  District,  PostalCode,  EmployeementStatus) == true) && (EmployeeObj.RegisterEmployeeEducationalQualificationDetails( NicNumber,  OlevelStatus,  OlevelDescription,  AlevelStatus, 
                        AlevelDescription,  OtherStatus,  OtherDescription) == true) && (EmployeeObj.RegisterEmployeeEmergenvyContactDetails( NicNumber,  NameTitle,  FirstName,  LastName,  Relationship,  Description,  
                        EmergencyAddress,  EmergencyContact01,  EmergencyContact02,  EmergencyEmailAddress) == true) && EmployeeObj.RegisterEmployeeBankDetails( NicNumber,  BankName,  BranchName,  AccountType,  
                        AccountNumber,  BSBNumber,  SysDate) == true)
                    {
                        MessageBox.Show("Employee Details Registration Succesffuly..", "Employee Details Registration.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("There Are Some Error Occured While Registration.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Select Profile Image.","Invalid Profile Image.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill All feilds Before Register Employee Details.", "Empty feilds Founded.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        public void ReturnEmployeeProfileImage(string NicNumber)
        {
            SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetEmployeeImage = new SqlCeCommand("select EMP_Image from EMP_GeneralDetails where nic_no = '" + NicNumber + "'", conn);
            SqlCeDataReader SelectedImage = GetEmployeeImage.ExecuteReader();

            SelectedImage.Read();
            byte[] EmployeeProfileImage = ((byte[])SelectedImage[0]);

            MemoryStream MStream = new MemoryStream(EmployeeProfileImage);
            emp_profile_picture.Image = Image.FromStream(MStream);
        }

        public void ReturnEmployeeEmployementDetails(string NicNumber)
        {
            string[] EmployeementDetails = EmployeeObj.GetSelectedEmployeementDetails(NicNumber);

            jobtitle_txt.Text = EmployeementDetails[1];
            jobpos_cmb.Text = EmployeementDetails[2];
            joininmgDate_dtpick.Text = EmployeementDetails[3];
            registrationDate_dpick.Text = EmployeementDetails[4];
            retrivingDate_dtpick.Text = EmployeementDetails[5];
            prevcompany_txt.Text = EmployeementDetails[6];
            prevPosDesc_txt.Text = EmployeementDetails[7];
            jobsection_cmb.Text = EmployeementDetails[8];
            etf_epf_txt.Text = EmployeementDetails[9];
            province_cmb.Text = EmployeementDetails[10];
            district_cmb.Text = EmployeementDetails[11];
            postalCode_txt.Text = EmployeementDetails[12];

            if (EmployeementDetails[13] == FullTime.Name)
            {
                FullTime.Checked = true;
            }
            else if (EmployeementDetails[13] == PartTime.Name)
            {
                PartTime.Checked = true;
            }
            else if (EmployeementDetails[13] == Cassual.Name)
            {
                Cassual.Checked = true;
            }
            else
            {
                Tempory.Checked = true;
            }
        }

        public void ReturnEmplyeeEducationalDetails(string NicNumber)
        {
            string[] EducationalDetails = EmployeeObj.GetSelectedEmployeeEducationalDetails(NicNumber);

            olevel_status_cmb.Text = EducationalDetails[1];
            olevel_desc_txt.Text = EducationalDetails[2];

            alevel_status_cmb.Text = EducationalDetails[3];
            alevel_desc_txt.Text = EducationalDetails[4];

            other_status_cmb.Text = EducationalDetails[5];
            other_desc_txt.Text = EducationalDetails[6];
        }

        public void ReturnEmployeeEmergencyDetails(string NicNumber)
        {
            string[] EmergencyContactDetails = EmployeeObj.GetEmployeeEmergencyContactDetails(NicNumber);

            name_title_cmb.Text = EmergencyContactDetails[1];
            fname_txt.Text = EmergencyContactDetails[2];
            lname_txt.Text = EmergencyContactDetails[3];
            relationship_txt.Text = EmergencyContactDetails[4];
            desc_txt.Text = EmergencyContactDetails[5];
            emrg_address_txt.Text = EmergencyContactDetails[6];
            emrg_contact_1_txt.Text = EmergencyContactDetails[7];
            emrg_contact_2_txt.Text = EmergencyContactDetails[8];
            emrg_email_txt.Text = EmergencyContactDetails[9];
        }

        public void ReturnEmployeeBankDetails(string NicNumber)
        {
            string[] EmployeeBankdetails = EmployeeObj.GetEmployeeBankDetails(NicNumber);

            bank_name_txt.Text = EmployeeBankdetails[1];
            branch_name_txt.Text = EmployeeBankdetails[2];
            acc_type_txt.Text = EmployeeBankdetails[3];
            acc_number_txt.Text = EmployeeBankdetails[4];
            bsb_txt.Text = EmployeeBankdetails[5];
            date_dtpick.Text = EmployeeBankdetails[6];
        }

        private void EmployeeDetailsSearch_btn_Click(object sender, EventArgs e)
        {
            string NicNumber = nic_no_txt.Text;

            if (CheckFeildsValues(NicNumber) == true)
            {
                string[] EmployeeGeneralDetails = EmployeeObj.GetSelectedEMP_PersonalDetails(NicNumber);

                if (EmployeeGeneralDetails[0] == null)
                {
                    MessageBox.Show("There is No Employee Details For That NIC Number.","Invalid NIC Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    fullname_txt.Text = EmployeeGeneralDetails[0];
                    bdate_dtpick.Text = EmployeeGeneralDetails[9];
                    email_txt.Text = EmployeeGeneralDetails[2];
                    pass_txt.Text = EmployeeGeneralDetails[3];
                    address_txt.Text = EmployeeGeneralDetails[4];

                    if (EmployeeGeneralDetails[5] == male_radio.Name)
                    {
                        male_radio.Checked = true;
                    }
                    else
                    {
                        female_radio.Checked = true;
                    }

                    contact01_txt.Text = EmployeeGeneralDetails[6];
                    contact02_txt.Text = EmployeeGeneralDetails[7];

                    ReturnEmployeeProfileImage(NicNumber);
                    ReturnEmployeeEmployementDetails(NicNumber);
                    ReturnEmplyeeEducationalDetails(NicNumber);
                    ReturnEmployeeEmergencyDetails(NicNumber);
                    ReturnEmployeeBankDetails(NicNumber);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Nic Number Before Search Employee Details.","Empty Nic Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void EmployeeDetailsManagement_Load(object sender, EventArgs e)
        {
            ReturnSysPositiondetails();
            ReturnSysSectiondetails();
        }

        private void updateemployeedetails_btn_Click(object sender, EventArgs e)
        {
            string EmployeementStatus = "";
            string Gender = "";
            byte[] EmployeeProfileImage = null;

            if (EmployeeImageLocation != "")
            {
                FileStream FStream = new FileStream(EmployeeImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader BrsObj = new BinaryReader(FStream);

                EmployeeProfileImage = BrsObj.ReadBytes((int)FStream.Length);
            }

            string NicNumber = nic_no_txt.Text;
            string FullName = fullname_txt.Text;
            DateTime BirthDate = CheckValidDateValue(bdate_dtpick.Text);
            string EmailAddress = email_txt.Text;
            string Password = pass_txt.Text;
            string Address = address_txt.Text;

            if (male_radio.Checked == true)
            {
                Gender = male_radio.Name;
            }
            else
            {
                Gender = female_radio.Name;
            }

            string Contact_01 = contact01_txt.Text;
            string Contact_02 = contact02_txt.Text;

            string JobTitle = jobtitle_txt.Text;
            string Jobposition = jobsection_cmb.Text;
            DateTime JoiningDate = CheckValidDateValue(joininmgDate_dtpick.Text);
            DateTime Registrationdate = CheckValidDateValue(registrationDate_dpick.Text);
            string PrevCompany = prevcompany_txt.Text;
            string PrevCompanyDesc = prevPosDesc_txt.Text;

            string Jobsection = jobsection_cmb.Text;
            string ETF_EPF_No = etf_epf_txt.Text;
            DateTime RetrivementDate = CheckValidDateValue(retrivingDate_dtpick.Text);
            string Province = province_cmb.Text;
            string District = district_cmb.Text;
            string PostalCode = postalCode_txt.Text;

            if (FullTime.Checked == true)
            {
                EmployeementStatus = FullTime.Name;
            }
            else if (PartTime.Checked == true)
            {
                EmployeementStatus = PartTime.Name;
            }
            else if (Cassual.Checked == true)
            {
                EmployeementStatus = Cassual.Name;
            }
            else
            {
                EmployeementStatus = Tempory.Name;
            }

            string OlevelStatus = olevel_status_cmb.Text;
            string OlevelDescription = olevel_desc_txt.Text;
            string AlevelStatus = alevel_status_cmb.Text;
            string AlevelDescription = alevel_desc_txt.Text;
            string OtherStatus = other_status_cmb.Text;
            string OtherDescription = other_desc_txt.Text;

            string NameTitle = name_title_cmb.Text;
            string FirstName = fname_txt.Text;
            string LastName = lname_txt.Text;
            string Relationship = relationship_txt.Text;
            string Description = desc_txt.Text;
            string EmergencyAddress = emrg_address_txt.Text;
            string EmergencyContact01 = emrg_contact_1_txt.Text;
            string EmergencyContact02 = emrg_contact_2_txt.Text;
            string EmergencyEmailAddress = emrg_email_txt.Text;

            string BankName = bank_name_txt.Text;
            string BranchName = branch_name_txt.Text;
            string AccountType = acc_type_txt.Text;
            string AccountNumber = acc_number_txt.Text;
            string BSBNumber = bsb_txt.Text;
            DateTime SysDate = CheckValidDateValue(date_dtpick.Text);

            if (CheckFeildsValues(NicNumber) == true && CheckFeildsValues(FullName) == true && CheckFeildsValues(EmailAddress) == true && CheckFeildsValues(Password) == true
                && CheckFeildsValues(Address) == true && CheckFeildsValues(Gender) == true && (CheckFeildsValues(Contact_01) == true || CheckFeildsValues(Contact_02) == true)
                && CheckFeildsValues(JobTitle) == true && CheckFeildsValues(Jobposition) == true && CheckFeildsValues(Jobsection) == true && CheckFeildsValues(ETF_EPF_No) == true
                && CheckFeildsValues(Province) == true && CheckFeildsValues(District) == true && CheckFeildsValues(PostalCode) == true && CheckFeildsValues(EmployeementStatus) == true
                && (CheckFeildsValues(OlevelStatus) == true || CheckFeildsValues(AlevelStatus) == true || CheckFeildsValues(OtherStatus) == true) && CheckFeildsValues(NameTitle) == true
                && CheckFeildsValues(FirstName) == true && CheckFeildsValues(LastName) == true && CheckFeildsValues(Relationship) == true && CheckFeildsValues(EmergencyAddress) == true
                && (CheckFeildsValues(EmergencyContact01) == true || CheckFeildsValues(EmergencyContact02) == true) && CheckFeildsValues(EmergencyEmailAddress) == true && CheckFeildsValues(BankName) == true
                && CheckFeildsValues(BranchName) == true && CheckFeildsValues(AccountType) == true && CheckFeildsValues(AccountNumber) == true && CheckFeildsValues(BSBNumber) == true)
            {
                if ((EmployeeObj.UpdateEmployeeGeneralDetailsInSystem(FullName, NicNumber, BirthDate, EmailAddress, Password, Address, Gender, Contact_01, Contact_02, EmployeeProfileImage) == true) &&
                    (EmployeeObj.UpdateEmployeeEmployementDetails(NicNumber, JobTitle, Jobposition, JoiningDate, Registrationdate, RetrivementDate, Jobsection, PrevCompany, PrevCompanyDesc, ETF_EPF_No,
                    Province, District, PostalCode, EmployeementStatus) == true) && (EmployeeObj.UpdateEmployeeEducationalQualificationDetails(NicNumber, OlevelStatus, OlevelDescription, AlevelStatus,
                    AlevelDescription, OtherStatus, OtherDescription) == true) && (EmployeeObj.UpdateEmployeeEmergenvyContactDetails(NicNumber, NameTitle, FirstName, LastName, Relationship, Description,
                    EmergencyAddress, EmergencyContact01, EmergencyContact02, EmergencyEmailAddress) == true) && EmployeeObj.UpdateEmployeeBankDetails(NicNumber, BankName, BranchName, AccountType,
                    AccountNumber, BSBNumber, SysDate) == true)
                {
                    MessageBox.Show("Employee Details Update Succesffuly..", "Employee Details Updation.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There Are Some Error Occured While Updating.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill All feilds Before Update Employee Details.", "Empty feilds Founded.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void deleteEmployeeDetails_btn_Click(object sender, EventArgs e)
        {
            string NicNumber = nic_no_txt.Text;

            if (CheckFeildsValues(NicNumber) == true)
            {
                DialogResult DeleteConf = MessageBox.Show("Are You Sure Want To Delete This Employee Details From The System ? ","Employee Details Deletion.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (DeleteConf == DialogResult.Yes)
                {
                    if (EmployeeObj.DeleteEmployeePersonalDetails(NicNumber) == true && EmployeeObj.DeleteEmployeeEducationalDetails(NicNumber) == true && EmployeeObj.DeleteEmployeeEmployementDetails(NicNumber) == true
                        && EmployeeObj.DeleteEmployeeEmergencyContactDetails(NicNumber) == true && EmployeeObj.DeleteEmployeeEmployeBankDetails(NicNumber) == true)
                    {
                        MessageBox.Show("Employee Details Deletion Successfully.","Employee Details Deletion.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("There Is Some Error Occured While Deleting.","database Or SQL Error.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter NIC Number Before Delete The Details.","Invalid NIC Number.",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}

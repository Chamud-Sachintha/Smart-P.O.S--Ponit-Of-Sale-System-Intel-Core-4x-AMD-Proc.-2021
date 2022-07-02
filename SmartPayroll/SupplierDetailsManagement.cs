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
    public partial class SupplierDetailsManagement : UserControl
    {
        public SupplierDetailsManagement()
        {
            InitializeComponent();
        }

        SupplierDetailsRegistration SupplierObj = new SupplierDetailsRegistration();

        public bool CheckStringFeilds(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckIntegerFeilds(string value)
        {
            int GetInt;

            try
            {
                GetInt = Convert.ToInt32(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        string SupplierIdentifyImageLocation = "";

        private void image_browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImageFileDialog = new OpenFileDialog();
            ImageFileDialog.Filter = "PNG Files(*.png) | *.png |JPG Files(*.jpg) | *.jpg |All Files(*.*) | *.*";

            if (ImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                supplier_profile_picture.Image = null;
                SupplierIdentifyImageLocation = ImageFileDialog.FileName.ToString();
                supplier_profile_picture.ImageLocation = SupplierIdentifyImageLocation;
            }
        }

        private void registersupplierdetails_btn_Click(object sender, EventArgs e)
        {
            string InsuaranceStatus = "";
            string LicenseStatus = "";
            string Services = "";
            byte[] SupplierProfileImage = null;

            string SupplierIDNumber = supplierid_txt.Text;
            string CompanyName = companyname_txt.Text;
            string AddressLine01 = address01_txt.Text;
            string AddressLine02 = address02_txt.Text;
            string City = city_txt.Text;
            string EmailAddress = email_txt.Text;
            string ContactNumber = contact_txt.Text;
            string FaxNumber = fax_txt.Text;
            DateTime JoiningDate = joiningdate_dtpick.Value;

            if (insyes_chk.Checked == true)
            {
                InsuaranceStatus = "Yes";
            }
            else
            {
                InsuaranceStatus = "No";
            }

            if (licyes_chk.Checked == true)
            {
                LicenseStatus = "Yes";
            }
            else
            {
                LicenseStatus = "No";
            }

            string LicensedNumber = licencenum_txt.Text;
            string ProvidedCategoryType = producttype_cmb.Text;
            string CategoryDescription = productdescription_txt.Text;

            if (serviceyes_chk.Checked == true)
            {
                Services = "Yes";
            }
            else
            {
                Services = "No";
            }

            string ServiceDescription = servicedescription_txt.Text;
            string AdditionalComments = additionalcomments_txt.Text;

            if (CheckStringFeilds(SupplierIDNumber) == true && CheckStringFeilds(CompanyName) == true && CheckStringFeilds(AddressLine01) == true && CheckStringFeilds(City) == true &&
                CheckStringFeilds(EmailAddress) == true && CheckStringFeilds(ContactNumber) == true && CheckStringFeilds(FaxNumber) == true && CheckStringFeilds(InsuaranceStatus) == true
                && CheckStringFeilds(LicenseStatus) == true && CheckStringFeilds(ProvidedCategoryType) == true && CheckStringFeilds(CategoryDescription) == true
                && CheckStringFeilds(Services) == true)
            {
                try
                {
                    FileStream Stream = new FileStream(SupplierIdentifyImageLocation, FileMode.Open, FileAccess.Read);
                    BinaryReader BrsReader = new BinaryReader(Stream);

                    SupplierProfileImage = BrsReader.ReadBytes((int)Stream.Length);

                    SupplierObj.RegisterSupllierGeneralDetails(SupplierIDNumber, CompanyName, AddressLine01, AddressLine02, City, EmailAddress, ContactNumber, FaxNumber,
                    JoiningDate, SupplierProfileImage);
                    SupplierObj.RegisterSupplierSupplyDetails(SupplierIDNumber, InsuaranceStatus, LicenseStatus, LicensedNumber, ProvidedCategoryType, CategoryDescription, Services, ServiceDescription, AdditionalComments);
                }
                catch (Exception)
                {
                    MessageBox.Show("Please Enter Supplier Profile Image.", "Invalid Supplier Profile Image Detected.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter All feilds Before Register Supplier Details.","Empty feilds Detected.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        public bool SearchSupplierGeneralDetails(string SupplierIDNumber)
        {
            string[] SupplierGeneralDetails = SupplierObj.GetSupplierGeneralDetails(SupplierIDNumber);

            if (SupplierGeneralDetails[0] == null)
            {
                return false;
            }
            else
            {
                companyname_txt.Text = SupplierGeneralDetails[2];
                address01_txt.Text = SupplierGeneralDetails[3];
                address02_txt.Text = SupplierGeneralDetails[4];
                city_txt.Text = SupplierGeneralDetails[5];
                email_txt.Text = SupplierGeneralDetails[6];
                contact_txt.Text = SupplierGeneralDetails[7];
                fax_txt.Text = SupplierGeneralDetails[8];
                joiningdate_dtpick.Text = SupplierGeneralDetails[9];

                SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                conn.Open();

                SqlCeCommand getSupplierProfileImage = new SqlCeCommand("select SupplierProfileImage from Supplier_GeneralDetails where SupplierID = '" + SupplierIDNumber + "'", conn);
                SqlCeDataReader SelectSupplierImage = getSupplierProfileImage.ExecuteReader();

                SelectSupplierImage.Read();
                byte[] SupplierProfileImage = ((byte[])SelectSupplierImage[0]);

                MemoryStream MStream = new MemoryStream(SupplierProfileImage);
                supplier_profile_picture.Image = Image.FromStream(MStream);

                return true;
            }
        }

        public bool SearchSupplierSupplyDetails(string SupplierIDNumber)
        {
            string[] SupplierSupplyDetails = SupplierObj.GetSupplierSupplyDetails(SupplierIDNumber);

            if (SupplierSupplyDetails[0] == null)
            {
                return false;
            }
            else
            {
                if (SupplierSupplyDetails[2] == "Yes")
                {
                    insyes_chk.Checked = true;
                }
                else
                {
                    insno_chk.Checked = true;
                }

                if (SupplierSupplyDetails[3] == "Yes")
                {
                    licyes_chk.Checked = true;
                }
                else
                {
                    licno_chk.Checked = true;
                }

                licencenum_txt.Text = SupplierSupplyDetails[4];
                producttype_cmb.Text = SupplierSupplyDetails[5];
                productdescription_txt.Text = SupplierSupplyDetails[6];

                if (SupplierSupplyDetails[7] == "yes")
                {
                    serviceyes_chk.Checked = true;
                }
                else
                {
                    serviceno_chk.Checked = true;
                }

                servicedescription_txt.Text = SupplierSupplyDetails[8];
                additionalcomments_txt.Text = SupplierSupplyDetails[9];

                return true;
            }
        }
        private void searchsupplierdetails_btn_Click(object sender, EventArgs e)
        {
            string SupplierIDNumber = supplierid_txt.Text;

            if (CheckStringFeilds(SupplierIDNumber) == true)
            {
                if (SearchSupplierGeneralDetails(SupplierIDNumber) != true || SearchSupplierSupplyDetails(SupplierIDNumber) != true)
                {
                    MessageBox.Show("Ther Is No Supplier Details For That Supplier ID.","Invalid Supplier ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Supplier ID Number Before Search Supplier Details.","Empty Supplier ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void updatesupplierdetails_btn_Click(object sender, EventArgs e)
        {
            string InsuaranceStatus = "";
            string LicenseStatus = "";
            string Services = "";
            byte[] SupplierProfileImage = null;

            if (SupplierIdentifyImageLocation != "")
            {
                FileStream Stream = new FileStream(SupplierIdentifyImageLocation, FileMode.Open, FileAccess.Read);
                BinaryReader BrsReader = new BinaryReader(Stream);

                SupplierProfileImage = BrsReader.ReadBytes((int)Stream.Length);
            }

            string SupplierIDNumber = supplierid_txt.Text;
            string CompanyName = companyname_txt.Text;
            string AddressLine01 = address01_txt.Text;
            string AddressLine02 = address02_txt.Text;
            string City = city_txt.Text;
            string EmailAddress = email_txt.Text;
            string ContactNumber = contact_txt.Text;
            string FaxNumber = fax_txt.Text;
            DateTime JoiningDate = joiningdate_dtpick.Value;

            if (insyes_chk.Checked == true)
            {
                InsuaranceStatus = "Yes";
            }
            else
            {
                InsuaranceStatus = "No";
            }

            if (licyes_chk.Checked == true)
            {
                LicenseStatus = "Yes";
            }
            else
            {
                LicenseStatus = "No";
            }

            string LicensedNumber = licencenum_txt.Text;
            string ProvidedCategoryType = producttype_cmb.Text;
            string CategoryDescription = productdescription_txt.Text;

            if (serviceyes_chk.Checked == true)
            {
                Services = "Yes";
            }
            else
            {
                Services = "No";
            }

            string ServiceDescription = servicedescription_txt.Text;
            string AdditionalComments = additionalcomments_txt.Text;

            if (CheckStringFeilds(SupplierIDNumber) == true && CheckStringFeilds(CompanyName) == true && CheckStringFeilds(AddressLine01) == true && CheckStringFeilds(City) == true &&
                CheckStringFeilds(EmailAddress) == true && CheckStringFeilds(ContactNumber) == true && CheckStringFeilds(FaxNumber) == true && CheckStringFeilds(InsuaranceStatus) == true
                && CheckStringFeilds(LicenseStatus) == true && CheckStringFeilds(ProvidedCategoryType) == true && CheckStringFeilds(CategoryDescription) == true
                && CheckStringFeilds(Services) == true)
            {
                SupplierObj.UpdateSupllierGeneralDetails(SupplierIDNumber, CompanyName, AddressLine01, AddressLine02, City, EmailAddress, ContactNumber, FaxNumber,
                    JoiningDate, SupplierProfileImage);
                SupplierObj.UpdateSupplierSupplyDetails(SupplierIDNumber, InsuaranceStatus, LicenseStatus, LicensedNumber, ProvidedCategoryType, CategoryDescription, Services, ServiceDescription, AdditionalComments);
            }
            else
            {
                MessageBox.Show("Please Enter All feilds Before Register Supplier Details.", "Empty feilds Detected.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void deletesupplierdetails_btn_Click(object sender, EventArgs e)
        {
            string SupplierIdNumber = supplierid_txt.Text;

            if (CheckStringFeilds(SupplierIdNumber) == true)
            {
                DialogResult DeleteConf = MessageBox.Show("Are Tou Sure Want to Delete This Details From the System ? ","Supplier Details Deletion.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (DeleteConf == DialogResult.Yes)
                {
                    SupplierObj.DeleteSupplierGeneralDetails(SupplierIdNumber);
                    SupplierObj.DeleteSupplierSupplyDetails(SupplierIdNumber);
                }
            }
            else
            {

            }
        }
    }
}

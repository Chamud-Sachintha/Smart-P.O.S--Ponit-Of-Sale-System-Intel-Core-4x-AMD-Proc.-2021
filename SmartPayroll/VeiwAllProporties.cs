using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using DGVPrinterHelper;

namespace SmartPayroll
{
    public partial class VeiwAllProporties : UserControl
    {
        public VeiwAllProporties()
        {
            InitializeComponent();
        }

        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");
        ManageAllVeiws VeiwsObj = new ManageAllVeiws();

        public void GetAvailableSectionDetails()
        {
            string[] AvailableSectionDetails = VeiwsObj.GetAllSections();

            for (int each_val = 0; each_val <= AvailableSectionDetails.Length; each_val++)
            {
                if (AvailableSectionDetails[each_val] == null)
                {
                    break;
                }

                jobsection_cmb.Items.Add(AvailableSectionDetails[each_val]);
            }
        }

        public void GetAvailablePositionDetails()
        {
            string[] AvailablePositionDetails = VeiwsObj.GetAllPositions();

            for (int each_val = 0; each_val <= AvailablePositionDetails.Length; each_val++)
            {
                if (AvailablePositionDetails[each_val] == null)
                {
                    break;
                }

                jobposition_cmb.Items.Add(AvailablePositionDetails[each_val]);
            }
        }

        private void loadEmployeecriterialist()
        {
            SqlCeDataAdapter DataAdapter;
            DataTable Dtable = new DataTable();
            DataSet ds = new DataSet();
            DataView dv = Dtable.DefaultView;
            DataAdapter = new SqlCeDataAdapter("select EMP_GeneralDetails.nic_no as Nic_Number,EMP_GeneralDetails.full_name as FullName,EMP_GeneralDetails.email as Email_Address,EMP_GeneralDetails.address as Address,EMP_GeneralDetails.gender as Gender,EMP_GeneralDetails.contact_01 as Contact_01,EMP_GeneralDetails.bdate as BirthDate,EMP_EmployementDetails.etf_epf_no as ETF_EPF_No,EMP_EmployementDetails.home_province as Province,EMP_EmployementDetails.district as District,EMP_EmployementDetails.job_title as JobTitle,EMP_EmployementDetails.job_position as JobPosition,EMP_EmployementDetails.job_section as JobSection,EMP_EmployementDetails.joining_date as JoiningDate,EMP_EmployementDetails.employement_status as EmployeementStatus from EMP_GeneralDetails join EMP_EmployementDetails on EMP_EmployementDetails.nic_no = EMP_GeneralDetails.nic_no", conn);
            DataAdapter.Fill(Dtable);
            EmployeeList_Veiw.DataSource = Dtable;

            DataAdapter.Dispose();
        }

        private void loadsuppliercriterialist()
        {
            SqlCeDataAdapter DataAdapter;
            DataTable Dtable = new DataTable();
            DataSet ds = new DataSet();
            DataView dv = Dtable.DefaultView;
            DataAdapter = new SqlCeDataAdapter("select Supplier_GeneralDetails.SupplierId,Supplier_GeneralDetails.CompanyName,Supplier_GeneralDetails.Address_01,Supplier_GeneralDetails.Email,Supplier_GeneralDetails.Contact,Supplier_GeneralDetails.JoiningDate,Supplier_SupplyDetails.InsuaranceStatus,Supplier_SupplyDetails.LicenseStatus,Supplier_SupplyDetails.CategoryType,Supplier_SupplyDetails.ServiceStatus from Supplier_GeneralDetails join Supplier_SupplyDetails on Supplier_GeneralDetails.SupplierID = Supplier_SupplyDetails.SupplierID", conn);
            DataAdapter.Fill(Dtable);
            supplierDetails_veiw.DataSource = Dtable;

            DataAdapter.Dispose();
        }

        private void loadproductcriterialist()
        {
            SqlCeDataAdapter DataAdapter;
            DataTable Dtable = new DataTable();
            DataSet ds = new DataSet();
            DataView dv = Dtable.DefaultView;
            DataAdapter = new SqlCeDataAdapter("select serial_num,category,category_name,quentity,price,tot Total,sup_id,company_name,invoice_date from ProductDetails", conn);
            DataAdapter.Fill(Dtable);
            pdetails_veiw.DataSource = Dtable;

            DataAdapter.Dispose();
        }

        private void VeiwAllProporties_Load(object sender, EventArgs e)
        {
            string[] CompanyNames = VeiwsObj.GetAvailableCompanyNames();
            string[] ProvideProductTypes = VeiwsObj.GetProvideProductTypes();

            for (int each_company = 0; each_company <= CompanyNames.Length; each_company++)
            {
                if (CompanyNames[each_company] == null)
                {
                    break;
                }

                companyname_cmb.Items.Add(CompanyNames[each_company]);
                pdetailscompanyname_cmb.Items.Add(CompanyNames[each_company]);
            }

            for (int each_product = 0; each_product < ProvideProductTypes.Length; each_product++)
            {
                if (ProvideProductTypes[each_product] == null)
                {
                    break;
                }

                producttype_cmb.Items.Add(ProvideProductTypes[each_product]);
                pdetailsproducttype_cmb.Items.Add(ProvideProductTypes[each_product]);
            }

            GetAvailableSectionDetails();
            GetAvailablePositionDetails();

            loadEmployeecriterialist();
            loadsuppliercriterialist();
            loadproductcriterialist();
        }

        private string GetEmployeementStatus()
        {
            string EmployeementStatus = "";

            if (FullTime.Checked == true)
            {
                EmployeementStatus = FullTime.Name;
            }
            else if (PartTime.Checked == true)
            {
                EmployeementStatus = PartTime.Name;
            }
            else if (Tempory.Checked == true)
            {
                EmployeementStatus = Tempory.Name;
            }
            else if (Cassual.Checked == true)
            {
                EmployeementStatus = Cassual.Name;
            }

            return EmployeementStatus;
        }

        private string GetGenderStatus()
        {
            string GenderStatus = "";

            if (Male.Checked == true)
            {
                GenderStatus = Male.Name;
            }
            else if (Female.Checked == true)
            {
                GenderStatus = Female.Name;
            }

            return GenderStatus;
        }

        private void getdetails_btn_Click(object sender, EventArgs e)
        {
            var flit = "";

            BindingSource bs = new BindingSource();
            bs.DataSource = EmployeeList_Veiw.DataSource;

            if (!string.IsNullOrEmpty(jobsection_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[JobSection] like '%" + jobsection_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [JobSection] like '%" + jobsection_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(jobposition_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[JobPosition] like '%" + jobposition_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [JobPosition] like '%" + jobposition_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(province_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[Province] like '%" + province_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [Province] like '%" + province_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(district_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[District] like '%" + district_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [District] like '%" + district_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(GetEmployeementStatus()))
            {
                if (flit == "")
                {
                    flit += "[EmployeementStatus] like '%" + GetEmployeementStatus() + "%'";
                }
                else
                {
                    flit += "and [EmployeementStatus] like '%" + GetEmployeementStatus() + "%'";
                }
            }
            if (!string.IsNullOrEmpty(job_title_txt.Text))
            {
                if (flit == "")
                {
                    flit += "[JobTitle] like '%" + job_title_txt.Text + "%'";
                }
                else
                {
                    flit += "and [JobTitle] like '%" + job_title_txt.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(GetGenderStatus()))
            {
                if (flit == "")
                {
                    flit += "[Gender] like '%" + GetGenderStatus() + "%'";
                }
                else
                {
                    flit += "and [Gender] like '%" + GetGenderStatus() + "%'";
                }
            }

            bs.Filter = flit;
            EmployeeList_Veiw.DataSource = bs;
        }

        private string HaveInsured()
        {
            string InsuaranceStatus = "";

            if(insuarance_chkbox_yes.Checked == true)
            {
                InsuaranceStatus = "Yes";
            }
            else if(insuarance_chkbox_no.Checked == true)
            {
                InsuaranceStatus = "No";
            }

            return InsuaranceStatus;
        }

        private string haveLicenced()
        {
            string LicencedStatus = "";

            if (licenced_yes.Checked == true)
            {
                LicencedStatus = "Yes";
            }
            else if (licenced_no.Checked == true)
            {
                LicencedStatus = "No";
            }

            return LicencedStatus;
        }

        private string HaveService()
        {
            string ServiceStatus = "";

            if (service_yes.Checked == true)
            {
                ServiceStatus = "Yes";
            }
            else if (service_no.Checked == true)
            {
                ServiceStatus = "No";
            }

            return ServiceStatus;
        }

        private void GetSupplierCriteria_btn_Click(object sender, EventArgs e)
        {
            var flit = "";

            BindingSource bs = new BindingSource();
            bs.DataSource = supplierDetails_veiw.DataSource;

            if (!string.IsNullOrEmpty(companyname_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[CompanyName] like '%" + companyname_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [CompanyName] like '%" + companyname_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(producttype_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[CategoryType] like '%" + producttype_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [CategoryType] like '%" + producttype_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(HaveInsured()))
            {
                if (flit == "")
                {
                    flit += "[InsuaranceStatus] like '%" + HaveInsured() + "%'";
                }
                else
                {
                    flit += "and [InsuaranceStatus] like '%" + HaveInsured() + "%'";
                }
            }
            if (!string.IsNullOrEmpty(haveLicenced()))
            {
                if (flit == "")
                {
                    flit += "[LicenseStatus] like '%" + haveLicenced() + "%'";
                }
                else
                {
                    flit += "and [LicenseStatus] like '%" + haveLicenced() + "%'";
                }
            }
            if (!string.IsNullOrEmpty(HaveService()))
            {
                if (flit == "")
                {
                    flit += "[serviceStatus] like '%" + HaveService() + "%'";
                }
                else
                {
                    flit += "and [ServiceStatus] like '%" + HaveService() + "%'";
                }
            }

            bs.Filter = flit;
            supplierDetails_veiw.DataSource = bs;
        }

        private string sortstockavailability()
        {
            string SortType = "";

            if (availability_mh.Checked == true)
            {
                SortType = "mh";
            }
            else if(availability_hm.Checked == true)
            {
                SortType = "hm";
            }

            return SortType;
        }

        private string sortstockprice()
        {
            string SortType = "";

            if (price_mh.Checked == true)
            {
                SortType = "mh";
            }
            else if (price_hm.Checked == true)
            {
                SortType = "hm";
            }

            return SortType;
        }

        private void GetPdetailsCriteria_btn_Click(object sender, EventArgs e)
        {
            var flit = "";

            BindingSource bs = new BindingSource();
            bs.DataSource = pdetails_veiw.DataSource;

            if(!string.IsNullOrEmpty(pdetailsproducttype_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[category] like '%" + pdetailsproducttype_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [category] like '%" + pdetailsproducttype_cmb.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(pdetailssupplierid_txt.Text))
            {
                if (flit == "")
                {
                    flit += "[sup_id] like '%" + pdetailssupplierid_txt.Text + "%'";
                }
                else
                {
                    flit += "and [sup_id] like '%" + pdetailssupplierid_txt.Text + "%'";
                }
            }
            if (!string.IsNullOrEmpty(pdetailscompanyname_cmb.Text))
            {
                if (flit == "")
                {
                    flit += "[company_name] like '%" + pdetailscompanyname_cmb.Text + "%'";
                }
                else
                {
                    flit += "and [company_name] like '%" + pdetailscompanyname_cmb.Text + "%'";
                }
            }
            if (sortstockavailability() == "mh")
            {
                pdetails_veiw.Sort(pdetails_veiw.Columns[3], ListSortDirection.Ascending);
            }
            if (sortstockavailability() == "hm")
            {
                pdetails_veiw.Sort(pdetails_veiw.Columns[3], ListSortDirection.Descending);
            }
            if (sortstockprice() == "mh")
            {
                pdetails_veiw.Sort(pdetails_veiw.Columns[4], ListSortDirection.Ascending);
            }
            if (sortstockprice() == "hm")
            {
                pdetails_veiw.Sort(pdetails_veiw.Columns[4], ListSortDirection.Descending);
            }

            bs.Filter = flit;
            pdetails_veiw.DataSource = bs;
        }

        private void PrintAvailableDatagridVeiws(DataGridView dgveiw)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "\r\n\r\n SmartStore PVT.LTD";
            printer.SubTitle = "Sherlok Development \r\n Phone - +94 11 - 2 765 321 \r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "Sherlok Software Development. \r\n Thank you for Buying Us.";
            printer.PrintDataGridView(dgveiw);
            printer.FooterSpacing = 30;
        }

        private void printemployeelist_veiw_Click(object sender, EventArgs e)
        {
            PrintAvailableDatagridVeiws(EmployeeList_Veiw);
        }

        private void printsupplierlist_veiw_Click(object sender, EventArgs e)
        {
            PrintAvailableDatagridVeiws(supplierDetails_veiw);
        }

        private void printproductlist_veiw_Click(object sender, EventArgs e)
        {
            PrintAvailableDatagridVeiws(pdetails_veiw);
        }
    }
}

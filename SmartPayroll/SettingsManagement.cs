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
    public partial class SettingsManagement : UserControl
    {
        public SettingsManagement()
        {
            InitializeComponent();
        }

        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");
        SettingsMgmt settingsobj = new SettingsMgmt();

        private void register_btn_Click(object sender, EventArgs e)
        {
            string SectionId = sectionid_txt.Text;
            string SectionName = secname_txt.Text;
            string Sectiondescription = description_txt.Text;

            if (!string.IsNullOrEmpty(SectionId) && !string.IsNullOrEmpty(SectionName))
            {
                if (settingsobj.AddNewSectionDetails(SectionId, SectionName, Sectiondescription) == true)
                {
                    MessageBox.Show("New Section Details Added Successfully.","Register Section Details.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    LoadAvailableSectiondetails();
                }
                else
                {
                    MessageBox.Show("There Is An Error Occured While Registration Details.","Database Or SQL Error.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Section ID And Section Name Before Register details.","Empty feilds Founded.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void LoadAvailableSectiondetails()
        {
            SqlCeDataAdapter DataAdapter;
            DataTable Dtable = new DataTable();
            DataSet ds = new DataSet();
            DataView dv = Dtable.DefaultView;
            DataAdapter = new SqlCeDataAdapter("select * from SectionTable", conn);
            DataAdapter.Fill(Dtable);
            sectiondetails_veiw.DataSource = Dtable;

            DataAdapter.Dispose();
        }

        private void LoadAvailablePositionDetails()
        {
            SqlCeDataAdapter DataAdapter;
            DataTable Dtable = new DataTable();
            DataSet ds = new DataSet();
            DataView dv = Dtable.DefaultView;
            DataAdapter = new SqlCeDataAdapter("select * from PositionTable", conn);
            DataAdapter.Fill(Dtable);

            positiondetails_view.DataSource = Dtable;
            DataAdapter.Dispose();
        }

        private void SettingsManagement_Load(object sender, EventArgs e)
        {
            LoadAvailableSectiondetails();
            LoadAvailablePositionDetails();
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string Sectionid = sectionid_txt.Text;

            if (!string.IsNullOrEmpty(Sectionid))
            {
                string[] selectedSectiondetails = settingsobj.SearchSectiondetails(Sectionid);

                if (selectedSectiondetails[0] == null)
                {
                    MessageBox.Show("There Is No Section details For That Section Id Number","Invalid Section ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    sectionid_txt.Text = selectedSectiondetails[1];
                    secname_txt.Text = selectedSectiondetails[2];
                    description_txt.Text = selectedSectiondetails[3];
                }
            }
            else
            {
                MessageBox.Show("Please Enter secrtion Id Before Search SAection details");
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            string SectionId = sectionid_txt.Text;
            string SectionName = secname_txt.Text;
            string Sectiondescription = description_txt.Text;

            if (!string.IsNullOrEmpty(SectionId) && !string.IsNullOrEmpty(SectionName))
            {
                if (settingsobj.UpdateSelectedSectionDetails(SectionId, SectionName, Sectiondescription) == true)
                {
                    MessageBox.Show("Section Details Updating Successfully!.","Section Details Updating.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    LoadAvailableSectiondetails(); 
                }
                else
                {
                    MessageBox.Show("There Is Some Error Occured While Updating.","Database Or SQL Error.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Section Id Before Updatre Section Details.","Invalid Section ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string SectionIdNumber = sectionid_txt.Text;

            if (!string.IsNullOrEmpty(SectionIdNumber))
            {
                DialogResult DeleteConfirm = MessageBox.Show("Are You Sure Want To Delete This Section Details.?","Section Details Deletion.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (DeleteConfirm == DialogResult.Yes)
                {
                    if (settingsobj.DeleteSelectedSectionDetails(SectionIdNumber) == true)
                    {
                        MessageBox.Show("Section Details Deletion Successfully.","Section Details Deletion.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                        LoadAvailableSectiondetails();
                    }
                    else
                    {
                        MessageBox.Show("There is Some Error Occured While Deleteing.","Database Or SQL Error.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Section Id Before Delete Section Details.","Invalid Section Id Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void posregister_btn_Click(object sender, EventArgs e)
        {
            string PositionIdNumber = posid_txt.Text;
            string Positionname = posname_txt.Text;
            string PosiotionDescription = posdecription_txt.Text;

            if (!string.IsNullOrEmpty(PositionIdNumber) && !string.IsNullOrEmpty(Positionname))
            {
                if (settingsobj.RegisterNewPositionDetails(PositionIdNumber, Positionname, PosiotionDescription) == true)
                {
                    MessageBox.Show("New Position Details Registration Successfully.", "Position Details Registration.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    LoadAvailablePositionDetails();
                }
                else
                {
                    MessageBox.Show("There is Some Error Occured While Registration details.","Database Or SQL Error.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Necessary Feilds Before Register Position Details.","Empty Feilds Founded.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void possearch_btn_Click(object sender, EventArgs e)
        {
            string PositionIdNumber = posid_txt.Text;

            if (!string.IsNullOrEmpty(PositionIdNumber))
            {
                string[] SelectedPositiondetails = settingsobj.GetSelectedPositiondetails(PositionIdNumber);

                if (SelectedPositiondetails[0] == null)
                {
                    MessageBox.Show("There Is No Details For That Position Number.", "Invalid Position Id Number.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    posid_txt.Text = SelectedPositiondetails[1];
                    posname_txt.Text = SelectedPositiondetails[2];
                    posdecription_txt.Text = SelectedPositiondetails[3];
                }
            }
            else
            {
                MessageBox.Show("Please Enter Position Id Before Search Position Details.", "Invalid Position ID Number.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void posupdate_btn_Click(object sender, EventArgs e)
        {
            string PositionIdNumber = posid_txt.Text;
            string Positionname = posname_txt.Text;
            string PosiotionDescription = posdecription_txt.Text;

            if (!string.IsNullOrEmpty(PositionIdNumber) && !string.IsNullOrEmpty(Positionname))
            {
                if (settingsobj.UpdateNewPositionDetails(PositionIdNumber, Positionname, PosiotionDescription) == true)
                {
                    MessageBox.Show("New Position Details Updating Successfully.", "Position Details Updating.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    LoadAvailablePositionDetails();
                }
                else
                {
                    MessageBox.Show("There is Some Error Occured While Updating details.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill Necessary Feilds Before Updating Position Details.", "Empty Feilds Founded.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void posdelete_btn_Click(object sender, EventArgs e)
        {
            string PositionIdNumber = posid_txt.Text;

            if (!string.IsNullOrEmpty(PositionIdNumber))
            {
                DialogResult DeleteConfirm = MessageBox.Show("Are You Sure Want To Delete This Position Details.?", "Position Details Deletion.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DeleteConfirm == DialogResult.Yes)
                {
                    if (settingsobj.DeleteSelectedPositionDetails(PositionIdNumber) == true)
                    {
                        MessageBox.Show("Position Details Deletion Successfully.", "Position Details Deletion.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        LoadAvailableSectiondetails();
                    }
                    else
                    {
                        MessageBox.Show("There is Some Error Occured While Deleteing.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Position Id Before Delete Section Details.", "Invalid Position Id Number.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void PrintDatagridViews(DataGridView datagridView)
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
            printer.PrintDataGridView(datagridView);
            printer.FooterSpacing = 30;
        }

        private void printveiws_btn_Click(object sender, EventArgs e)
        {
            PrintDatagridViews(sectiondetails_veiw);
        }

        private void printviews_btn_Click(object sender, EventArgs e)
        {
            PrintDatagridViews(positiondetails_view);
        }
    }
}

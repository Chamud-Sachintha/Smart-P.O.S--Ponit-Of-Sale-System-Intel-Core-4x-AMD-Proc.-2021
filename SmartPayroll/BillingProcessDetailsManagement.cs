using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
using DGVPrinterHelper;

namespace SmartPayroll
{
    public partial class BillingProcessDetailsManagement : UserControl
    {
        public BillingProcessDetailsManagement()
        {
            InitializeComponent();
        }

        DataTable DTable = new DataTable();
        ManageBillingProcess BillingObj = new ManageBillingProcess();

        FilterInfoCollection filterinfocollection;
        VideoCaptureDevice capturedevice;

        public int ReplaceInvalidInt(string value)
        {
            int GetValue;

            try
            {
                GetValue = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                GetValue = 0;
            }

            return GetValue;
        }

        private void BillingProcessDetailsManagement_Load(object sender, EventArgs e)
        {
            filterinfocollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterinfocollection)
                selectcam_cmb.Items.Add(device.Name);

            selectcam_cmb.SelectedIndex = 0;

            DTable.Columns.Add("Serial Number",typeof(string));
            DTable.Columns.Add("Item Name", typeof(string));
            DTable.Columns.Add("Item Quentity", typeof(string));
            DTable.Columns.Add("Item Price", typeof(string));
            DTable.Columns.Add("Total Price", typeof(string));

            ItemList_GridVeiw.DataSource = DTable;
        }

        private void StartCamProc_btn_Click(object sender, EventArgs e)
        {
            capturedevice = new VideoCaptureDevice(filterinfocollection[selectcam_cmb.SelectedIndex].MonikerString);
            capturedevice.NewFrame += capturedevice_NewFrame;
            capturedevice.Start();
        }

        private void capturedevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            SoundPlayer SPlayer = new SoundPlayer(@"J:\MyProjects\CSPRG -  Projects\CSPRG - Smart P.O.S  -Ponit Of Sale System Intel Core 4x AMD Proc. 2021\SoundFile\144418_zerolagtime_store-scanner-beep (online-audio-converter.com).wav");

            Bitmap BitImage = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader BrCodeReader = new BarcodeReader();

            var Result = BrCodeReader.Decode(BitImage);

            if (Result != null)
            {
                productSerialNumber_txt.Invoke(new MethodInvoker(delegate()
                    {
                        productSerialNumber_txt.Text = Result.ToString();

                        GetProductDetailsAndSuppDetails(Result);

                        itemquentity_txt.Focus();
                        itemquentity_txt.Text = "";
                        SPlayer.Play();
                    }));

                SPlayer.Stop();
                Thread.Sleep(50);
            }

            BarcodeBox.Image = BitImage;
        }

        private void GetProductDetailsAndSuppDetails(Result Result)
        {
            string[] ProductDetails = BillingObj.GetSelectedProductDetails(productSerialNumber_txt.Text);

            productname_txt.Text = ProductDetails[1];
            productCategory_txt.Text = ProductDetails[0];
            productPrice_txt.Text = ProductDetails[2];
        }

        private void camstop_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ProcessTerminate = MessageBox.Show("Do You Want To Exit The Application ?", "Process Termination.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ProcessTerminate == DialogResult.OK)
                {
                    capturedevice.Stop();
                    Application.Exit();
                }

                BarcodeBox.Image = null;
                capturedevice.Stop();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Before You Scan The QR Codes Start the Camera Input.","Invalid Argumets.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        int ProductPrice = 0;
        int ItemQuentity = 0;
        int GlobalTotalBill = 0;

        private void addtobill_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int TotalAmt = ReplaceInvalidInt(totamt_txt.Text);

                GlobalTotalBill += TotalAmt;

                totbillamt_txt.Text = GlobalTotalBill.ToString();

                DTable.Rows.Add(productSerialNumber_txt.Text, productname_txt.Text, itemquentity_txt.Text, productPrice_txt.Text, totamt_txt.Text);
                ItemList_GridVeiw.DataSource = DTable;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please Enter Product To Add Bill", "Invalid Arguments.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void itemquentity_txt_TextChanged(object sender, EventArgs e)
        {
            ProductPrice = ReplaceInvalidInt(productPrice_txt.Text);
            ItemQuentity = ReplaceInvalidInt(itemquentity_txt.Text);

            totamt_txt.Text = (ProductPrice * ItemQuentity).ToString();
        }

        private void removeitem_btn_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalTotalBill -= (ProductPrice * ItemQuentity);
                totbillamt_txt.Text = GlobalTotalBill.ToString();

                int RowIndex = (ItemList_GridVeiw.Rows.Count) - 1;

                ItemList_GridVeiw.Rows.RemoveAt(RowIndex);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("There Are No products To Remove.", "Invalid Argumets.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void calculatebal_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime BillingDate = System.DateTime.Now;
                int TotalAmount = Convert.ToInt32(totbillamt_txt.Text);

                int GetCustormerCash = ReplaceInvalidInt(customercash_txt.Text);
                int Balance = (GetCustormerCash - Convert.ToInt32(totbillamt_txt.Text));

                balance_txt.Text = Balance.ToString();

                BillingObj.InsertBillCache(TotalAmount,BillingDate);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please Enter Valid Numbers To Calculate Balance.","Invalid Number Format.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void printbill_btn_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            DTable.Rows.Add(" "," ", ""," Total bill Amount :-  ",totbillamt_txt.Text);
            DTable.Rows.Add(" ", " ", "", " Custormer Cash :-  ", customercash_txt.Text);
            DTable.Rows.Add(" ", " ", "", " Balance :-  ", balance_txt.Text);

            printer.Title = "\r\n\r\n SmartStore PVT.LTD";
            printer.SubTitle = "Sherlok Development \r\n Phone - +94 11 - 2 765 321";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "Sherlok Software Development. \r\n Thank you for Buying Us.";
            printer.PrintDataGridView(ItemList_GridVeiw);
            printer.FooterSpacing = 30;
        }
    }
}
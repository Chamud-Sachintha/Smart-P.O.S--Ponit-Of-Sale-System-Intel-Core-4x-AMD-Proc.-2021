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
using QRCoder;

namespace SmartPayroll
{
    public partial class ProductDetailsManagement : UserControl
    {
        public ProductDetailsManagement()
        {
            InitializeComponent();
        }

        ProductionDetailsRegister ProductObj = new ProductionDetailsRegister();

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

        public int ReturnChkIntVal(string value)
        {
            int GetVal;

            try
            {
                GetVal = Convert.ToInt32(value);
            }
            catch (Exception)
            {
                GetVal = 0;
            }

            return GetVal;
        }

        private void productprice_txt_TextChanged(object sender, EventArgs e)
        {
            int GetQuentity = ReturnChkIntVal(itemquenity_count.Text);
            int GetPrice = ReturnChkIntVal(productprice_txt.Text);

            totalamt_txt.Text = (GetPrice * GetQuentity).ToString();
        }

        private void productdetailsregister_btn_Click(object sender, EventArgs e)
        {
            byte[] BarcodeChar = null;

            DateTime AssigningDate = Convert.ToDateTime(assigningdate_dtpick.Text);
            string ProductCategory = productcategory_cmb.Text;
            string ProductName = productname_txt.Text;
            int ItemQuentity = ReturnChkIntVal(itemquenity_count.Text);
            int PricePerItem = ReturnChkIntVal(productprice_txt.Text);
            string TotalAmount = totalamt_txt.Text;
            string SellingPrice = sellingprice_txt.Text;

            string ProductSerialNumber = productserialnumber_txt.Text;

            string SupplierIDNumber = supplierid_txt.Text;
            DateTime ModifyDate = Convert.ToDateTime(modifieddate_dtpick.Text);
            string Companyname = companyname_txt.Text;
            string SupplierName = suppliername_txt.Text;
            string AdditionalComments = additionalcomments_txt.Text;

            ImageConverter ImgConverter = new ImageConverter();
            Image ProductBarcode = barcode_img_box.Image;

            BarcodeChar = (byte[])ImgConverter.ConvertTo(ProductBarcode, typeof(byte[]));

            if (CheckStringFeilds(ProductCategory) == true && CheckStringFeilds(SellingPrice) == true && CheckStringFeilds(SupplierIDNumber) == true && CheckStringFeilds(Companyname) == true)
            {
                string[] Response = ProductObj.CheckCategoryNames(ProductName);

                if (Response[0] != null)
                {
                    MessageBox.Show("There is Already Have Product Same Product Name - " + Response[0] + "", "Duplicate ProductNames.");
                }
                else
                {
                    if (ProductObj.registerProductionDetails(AssigningDate, ProductCategory, ProductName, ItemQuentity, PricePerItem, TotalAmount, SellingPrice, ProductSerialNumber, SupplierIDNumber, ModifyDate, Companyname, SupplierName,
                    AdditionalComments, BarcodeChar) == true)
                    {
                        MessageBox.Show("Product details registration Successfully!.", "Product Details Registration.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("There is Some Error Occured While Registration.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Necessary feilds Before Register poroduct.","Empty Feilds Founded.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void generatebarcode_btn_Click(object sender, EventArgs e)
        {
            string BarcodeStringValue = productserialnumber_txt.Text;

            if (CheckStringFeilds(BarcodeStringValue) == true)
            {
                QRCodeGenerator Code = new QRCodeGenerator();
                QRCodeData QRcodeData = Code.CreateQrCode(productserialnumber_txt.Text, QRCodeGenerator.ECCLevel.Q);
                QRCode QrCode = new QRCode(QRcodeData);
                barcode_img_box.Image = QrCode.GetGraphic(5);
            }
            else
            {
                MessageBox.Show("Please Enter Serial Number Before Generating Barcode ID Number.","Empty Barcode Reference.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void productname_txt_Leave(object sender, EventArgs e)
        {
            string CategoryNumber;

            string ProductName = productname_txt.Text;
            string GetSerialNumber = productserialnumber_txt.Text;

            string SelectedProductCategory = productcategory_cmb.Text;

            if (SelectedProductCategory == "Foods For Cooking and Other Things")
            {
                CategoryNumber = "PRO_CAT01_";
            }
            else if (SelectedProductCategory == "Beverage and Short Foods")
            {
                CategoryNumber = "PRO_CAT02_";
            }
            else if (SelectedProductCategory == "Instance Foods and Packages")
            {
                CategoryNumber = "PRO_CAT03_";
            }
            else if (SelectedProductCategory == "Kitchen Utilities and Helper Machines")
            {
                CategoryNumber = "PRO_CAT04_";
            }
            else if (SelectedProductCategory == "Electronic And Electrical Things")
            {
                CategoryNumber = "PRO_CAT05_";
            }
            else if (SelectedProductCategory == "Costumes And Fashion Instruments")
            {
                CategoryNumber = "PRO_CAT06_";
            }
            else
            {
                CategoryNumber = "PRO_CAT07_";
            }

            string SelectedRowCount = ProductObj.GettableRowCountForSerialNum();

            productserialnumber_txt.Text = CategoryNumber + GetSerialNumber + ProductName + "_" + SelectedRowCount;
            productname_txt.Enabled = false;
        }

        private void serial_clear_btn_Click(object sender, EventArgs e)
        {
            productname_txt.Text = "";
            productserialnumber_txt.Text = "";

            productname_txt.Enabled = true;
        }

        private void selectsupplier_btn_Click(object sender, EventArgs e)
        {
            string SupplierIDNumber = supplierid_txt.Text;

            if (CheckStringFeilds(SupplierIDNumber) == true)
            {
                string Companyname = ProductObj.SelectedSupplierDetails(SupplierIDNumber);

                if (Companyname == "Invalid Supplier ID")
                {
                    MessageBox.Show("This Supplier Is Not Registerd Supplier.","Invalid Supplier ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    companyname_txt.Text = Companyname;
                }
            }
            else
            {
                MessageBox.Show("Please Enter Supplier ID Number Before Select Supplier Details.","Empty Supplier ID Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void productdetailssearch_btn_Click(object sender, EventArgs e)
        {
            string ProductSerialNumber = productserialnumber_txt.Text;

            if (CheckStringFeilds(ProductSerialNumber) == true)
            {
                string[] GetProductionDetails = ProductObj.GetSelectedProductionDetails(ProductSerialNumber);

                if (GetProductionDetails[0] == null)
                {
                    MessageBox.Show("There is No Details for That Serial Number.","Invalid Serial Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                }
                else
                {
                    assigningdate_dtpick.Text = GetProductionDetails[1];
                    productcategory_cmb.Text = GetProductionDetails[2];
                    productname_txt.Text = GetProductionDetails[3];
                    itemquenity_count.Text = GetProductionDetails[5];
                    productprice_txt.Text = GetProductionDetails[6];
                    totalamt_txt.Text = GetProductionDetails[7];
                    sellingprice_txt.Text = GetProductionDetails[15];
                    productserialnumber_txt.Text = GetProductionDetails[8];

                    supplierid_txt.Text = GetProductionDetails[9];
                    modifieddate_dtpick.Text = GetProductionDetails[10];
                    companyname_txt.Text = GetProductionDetails[11];
                    suppliername_txt.Text = GetProductionDetails[12];
                    additionalcomments_txt.Text = GetProductionDetails[13];

                    SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    conn.Open();

                    byte[] BarcodeArr = null;
                    SqlCeCommand GetBarcodeImage = new SqlCeCommand("select BarcodeGen from ProductDetails where serial_num = '" + ProductSerialNumber + "'", conn);
                    SqlCeDataReader SelectedBarcode = GetBarcodeImage.ExecuteReader();

                    SelectedBarcode.Read();

                    BarcodeArr = (byte[])SelectedBarcode[0];

                    if (BarcodeArr.Length != 0)
                    {
                        MemoryStream Mstream = new MemoryStream(BarcodeArr);
                        barcode_img_box.Image = Image.FromStream(Mstream);
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Product Serial Number Before Search Product Details.","Empty Serial Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }

        private void getpng_btn_Click(object sender, EventArgs e)
        {
            if (barcode_img_box.Image == null)
            {
                MessageBox.Show("Please Generate Barcode Before Print Barcode.", "Empty Barcode Reference.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = @"JPG | *.jpg" })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        barcode_img_box.Image.Save(saveFileDialog.FileName);
                        MessageBox.Show("Barcode File Is Save Successfully!.", "Save Barcode PNG.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void productdetailsupdate_btn_Click(object sender, EventArgs e)
        {
            byte[] BarcodeChar = null;

            DateTime AssigningDate = Convert.ToDateTime(assigningdate_dtpick.Text);
            string ProductCategory = productcategory_cmb.Text;
            string ProductName = productname_txt.Text;
            int ItemQuentity = ReturnChkIntVal(itemquenity_count.Text);
            int PricePerItem = ReturnChkIntVal(productprice_txt.Text);
            string TotalAmount = totalamt_txt.Text;

            string SellingPrice = sellingprice_txt.Text;

            string ProductSerialNumber = productserialnumber_txt.Text;

            string SupplierIDNumber = supplierid_txt.Text;
            DateTime ModifyDate = Convert.ToDateTime(modifieddate_dtpick.Text);
            string Companyname = companyname_txt.Text;
            string SupplierName = suppliername_txt.Text;
            string AdditionalComments = additionalcomments_txt.Text;

            ImageConverter ImgConverter = new ImageConverter();
            Image ProductBarcode = barcode_img_box.Image;

            BarcodeChar = (byte[])ImgConverter.ConvertTo(ProductBarcode, typeof(byte[]));

            if (CheckStringFeilds(ProductCategory) == true && CheckStringFeilds(SellingPrice) == true && CheckStringFeilds(SupplierIDNumber) == true && CheckStringFeilds(Companyname) == true)
            {
                if (ProductObj.UpdateProductionDetails(AssigningDate, ProductCategory, ProductName, ItemQuentity, PricePerItem, TotalAmount,SellingPrice, ProductSerialNumber, SupplierIDNumber, ModifyDate, Companyname, SupplierName,
                    AdditionalComments, BarcodeChar) == true)
                {
                    MessageBox.Show("Product details Updating Successfully!.", "Product Details Updating.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There is Some Error Occured While Updating.", "Database Or SQL Error.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill All Necessary feilds Before Update poroduct.", "Empty Feilds Founded.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void productdetailsdelete_btn_Click(object sender, EventArgs e)
        {
            string ProductSerialNumber = productserialnumber_txt.Text;

            if (CheckStringFeilds(ProductSerialNumber) == true)
            {
                DialogResult DeleteConf = MessageBox.Show("Are You Sure Want To Delete This Delails From The System ? ","Product Details Deletion.",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (DeleteConf == DialogResult.OK)
                {
                    if (ProductObj.DeleteProductDetails(ProductSerialNumber) == true)
                    {
                        MessageBox.Show("Product Details Deletion Successfully!.","Product Details Deletion.",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("There Is An Error Occured While Deletion.","Product Details Deletion.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Serial Number Before Clear The Details.","Empty Serial Number.",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
        }
    }
}

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

namespace SmartPayroll
{
    public partial class DashboardFom : UserControl
    {
        public DashboardFom()
        {
            InitializeComponent();
        }

        SqlCeConnection conn = new SqlCeConnection(@"Data Source=C:\Users\Sherlock\Documents\SmartPayroll_SysDetails.sdf;Password='root123'");

        private void resetDate_btn_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            DateTime TodayDate = System.DateTime.Now;

            since_date_lab.Text = TodayDate.ToString();

            SqlCeCommand UpdateSysLogDetails = new SqlCeCommand("update log_sys_dates set net_sys_date = @net_sys_date where id = 2", conn);
            UpdateSysLogDetails.Parameters.Add("@net_sys_date", TodayDate);
            UpdateSysLogDetails.Parameters.Add("@deduct_sys_date", TodayDate);

            UpdateSysLogDetails.ExecuteNonQuery();
        }

        private void GetSyseDates()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetSysDates = new SqlCeCommand("select net_sys_date,deduct_sys_date from log_sys_dates where id = 2", conn);
            SqlCeDataReader AvailableDates = GetSysDates.ExecuteReader();

            AvailableDates.Read();

            since_date_lab.Text = AvailableDates[0].ToString();
            deductdate_lab.Text = AvailableDates[1].ToString();
        }

        private void CalculateTotalNetAmount()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int TotalNetPay = 0;

            DateTime GetSelectedDate = Convert.ToDateTime(since_date_lab.Text);

            SqlCeCommand GetEachNetAmount = new SqlCeCommand("select tot from ProductDetails where assign_date >= @GetEachNetAmount", conn);
            GetEachNetAmount.Parameters.Add("@GetEachNetAmount", GetSelectedDate);

            SqlCeDataReader AvailableTotalAmounts = GetEachNetAmount.ExecuteReader();

            while (AvailableTotalAmounts.Read())
            {
                TotalNetPay += Convert.ToInt32(AvailableTotalAmounts[0].ToString());
            }

            netpay_lab.Text = (TotalNetPay.ToString()) + ".00 /=";
        }

        private void GetActiveEmployeeCount()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            SqlCeCommand GetEmployeeCount = new SqlCeCommand("select count(nic_no) from EMP_GeneralDetails", conn);
            SqlCeDataReader EmployeeCount = GetEmployeeCount.ExecuteReader();

            EmployeeCount.Read();

            empcount_lab.Text = EmployeeCount[0].ToString();
        }

        private List<Tuple<string, string>> UpdateCategoryProgressBarValues()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            //string[] CategoryAvailability = new string[100];
            List<Tuple<string, string>> mylist = new List<Tuple<string, string>>();

            SqlCeCommand GetCategoryAvailability = new SqlCeCommand("select category,count(*) from ProductDetails group by category", conn);
            SqlCeDataReader SelectedCategoryAvailability = GetCategoryAvailability.ExecuteReader();

            while (SelectedCategoryAvailability.Read())
            {
                mylist.Add(new Tuple<string, string>(SelectedCategoryAvailability[0].ToString(), SelectedCategoryAvailability[1].ToString()));
            }

            return mylist;
        }

        private void DashboardFom_Load(object sender, EventArgs e)
        {
            List<Tuple<string, string>> CategoryAvailability = new List<Tuple<string, string>>();
            CategoryAvailability = UpdateCategoryProgressBarValues();

            todate_lab.Text = System.DateTime.Now.ToShortDateString();

            try
            {
                Tuple<string, string> Cat01 = CategoryAvailability[0];
                cat01_progbar.Value = Convert.ToInt32(Cat01.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat01_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat02 = CategoryAvailability[1];
                cat02_progbar.Value = Convert.ToInt32(Cat02.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat02_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat03 = CategoryAvailability[2];
                cat03_progbar.Value = Convert.ToInt32(Cat03.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat03_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat04 = CategoryAvailability[3];
                cat04_progbar.Value = Convert.ToInt32(Cat04.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat04_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat05 = CategoryAvailability[4];
                cat05_progbar.Value = Convert.ToInt32(Cat05.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat05_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat06 = CategoryAvailability[4];
                cat06_progbar.Value = Convert.ToInt32(Cat06.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat06_progbar.Value = 0;
            }

            try
            {
                Tuple<string, string> Cat07 = CategoryAvailability[4];
                cat07_progbar.Value = Convert.ToInt32(Cat07.Item2);
            }
            catch (ArgumentOutOfRangeException)
            {
                cat07_progbar.Value = 0;
            }

            GetSyseDates();
            CalculateTotalNetAmount();
            GetActiveEmployeeCount();

            CalculateTotalSellingAmount();
        }

        private void CalculateTotalSellingAmount()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();

            int SellingAmount = 0;
            DateTime GetBillingDate = Convert.ToDateTime(deductdate_lab.Text);

            SqlCeCommand GetNetSellingAmount = new SqlCeCommand("select total_selling from bill_chache where billing_date >= @GetBillingDate", conn);
            GetNetSellingAmount.Parameters.Add("@GetBillingDate", GetBillingDate);

            SqlCeDataReader NetSellingAmount = GetNetSellingAmount.ExecuteReader();

            while (NetSellingAmount.Read())
            {
                SellingAmount += Convert.ToInt32(NetSellingAmount[0].ToString());
            }

            netselling_lab.Text = SellingAmount.ToString();
        }
    }
}

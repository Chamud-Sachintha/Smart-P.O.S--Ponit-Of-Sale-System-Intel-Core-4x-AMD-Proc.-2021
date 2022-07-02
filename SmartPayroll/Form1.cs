using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPayroll
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        BillingProcessDetailsManagement obj = new BillingProcessDetailsManagement();

        private void Form1_Load(object sender, EventArgs e)
        {
            dashboard_btn.Checked = true;
            employeemgmt_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            productmanagement_btn.Checked = false;
            Billing_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            dashboardFom1.Show();
            dashboardFom1.BringToFront();

            employeeForm1.Hide();
            supplierDetailsManagement1.Hide();
            productDetailsManagement1.Hide();
            billingProcessDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void employeemgmt_btn_Click(object sender, EventArgs e)
        {
            employeemgmt_btn.Checked = true;
            dashboard_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            productmanagement_btn.Checked = false;
            Billing_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            employeeForm1.Show();
            employeeForm1.BringToFront();

            supplierDetailsManagement1.Hide();
            dashboardFom1.Hide();
            productDetailsManagement1.Hide();
            billingProcessDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard_btn.Checked = true;
            employeemgmt_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            productmanagement_btn.Checked = false;
            Billing_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            dashboardFom1.Show();
            dashboardFom1.BringToFront();

            supplierDetailsManagement1.Hide();
            employeeForm1.Hide();
            productDetailsManagement1.Hide();
            billingProcessDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void suppliermgmt_btn_Click(object sender, EventArgs e)
        {
            suppliermgmt_btn.Checked = true;
            dashboard_btn.Checked = false;
            employeemgmt_btn.Checked = false;
            productmanagement_btn.Checked = false;
            Billing_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            supplierDetailsManagement1.Show();
            supplierDetailsManagement1.BringToFront();

            dashboardFom1.Hide();
            employeeForm1.Hide();
            productDetailsManagement1.Hide();
            billingProcessDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void productmanagement_btn_Click(object sender, EventArgs e)
        {
            productmanagement_btn.Checked = true;
            suppliermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            employeemgmt_btn.Checked = false;
            Billing_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            productDetailsManagement1.Show();
            productDetailsManagement1.BringToFront();

            dashboardFom1.Hide();
            employeeForm1.Hide();
            supplierDetailsManagement1.Hide();
            billingProcessDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void Billing_btn_Click(object sender, EventArgs e)
        {
            Billing_btn.Checked = true;
            productmanagement_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            employeemgmt_btn.Checked = false;
            VeiwProporty_btn.Checked = false;
            settings_btn.Checked = false;

            billingProcessDetailsManagement1.Show();
            billingProcessDetailsManagement1.BringToFront();

            dashboardFom1.Hide();
            employeeForm1.Hide();
            supplierDetailsManagement1.Hide();
            productDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
            settingsManagement1.Hide();
        }

        private void VeiwProporty_btn_Click(object sender, EventArgs e)
        {
            VeiwProporty_btn.Checked = true;
            Billing_btn.Checked = false;
            productmanagement_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            employeemgmt_btn.Checked = false;
            settings_btn.Checked = false;

            veiwAllProporties1.Show();
            veiwAllProporties1.BringToFront();

            billingProcessDetailsManagement1.Hide();
            dashboardFom1.Hide();
            employeeForm1.Hide();
            supplierDetailsManagement1.Hide();
            productDetailsManagement1.Hide();
            settingsManagement1.Hide();
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            VeiwProporty_btn.Checked = false;
            Billing_btn.Checked = false;
            productmanagement_btn.Checked = false;
            suppliermgmt_btn.Checked = false;
            dashboard_btn.Checked = false;
            employeemgmt_btn.Checked = false;
            settings_btn.Checked = true;

            settingsManagement1.Show();
            settingsManagement1.BringToFront();

            billingProcessDetailsManagement1.Hide();
            dashboardFom1.Hide();
            employeeForm1.Hide();
            supplierDetailsManagement1.Hide();
            productDetailsManagement1.Hide();
            veiwAllProporties1.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dashbrdbilling_btn_Click(object sender, EventArgs e)
        {
            billingProcessDetailsManagement1.Show();
            billingProcessDetailsManagement1.BringToFront();
        }
    }
}

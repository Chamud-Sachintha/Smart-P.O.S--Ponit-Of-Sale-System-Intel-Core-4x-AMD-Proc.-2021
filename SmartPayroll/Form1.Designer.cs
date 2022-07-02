namespace SmartPayroll
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.settings_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.VeiwProporty_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.productmanagement_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.Billing_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.suppliermgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.employeemgmt_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.dashboard_btn = new Guna.UI.WinForms.GunaAdvenceButton();
            this.side_panel = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.gunaCircleButton3 = new Guna.UI.WinForms.GunaCircleButton();
            this.gunaCircleButton2 = new Guna.UI.WinForms.GunaCircleButton();
            this.dashbrdbilling_btn = new Guna.UI.WinForms.GunaCircleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaCirclePictureBox1 = new Guna.UI.WinForms.GunaCirclePictureBox();
            this.upper_panel = new Guna.UI.WinForms.GunaElipse(this.components);
            this.sqlCeCommand1 = new System.Data.SqlServerCe.SqlCeCommand();
            this.sqlCeConnection1 = new System.Data.SqlServerCe.SqlCeConnection();
            this.settingsManagement1 = new SmartPayroll.SettingsManagement();
            this.veiwAllProporties1 = new SmartPayroll.VeiwAllProporties();
            this.billingProcessDetailsManagement1 = new SmartPayroll.BillingProcessDetailsManagement();
            this.productDetailsManagement1 = new SmartPayroll.ProductDetailsManagement();
            this.supplierDetailsManagement1 = new SmartPayroll.SupplierDetailsManagement();
            this.employeeForm1 = new SmartPayroll.EmployeeDetailsManagement();
            this.dashboardFom1 = new SmartPayroll.DashboardFom();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Indigo;
            this.panel1.Controls.Add(this.settings_btn);
            this.panel1.Controls.Add(this.VeiwProporty_btn);
            this.panel1.Controls.Add(this.productmanagement_btn);
            this.panel1.Controls.Add(this.Billing_btn);
            this.panel1.Controls.Add(this.suppliermgmt_btn);
            this.panel1.Controls.Add(this.employeemgmt_btn);
            this.panel1.Controls.Add(this.dashboard_btn);
            this.panel1.Location = new System.Drawing.Point(-36, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 747);
            this.panel1.TabIndex = 0;
            // 
            // settings_btn
            // 
            this.settings_btn.AnimationHoverSpeed = 0.07F;
            this.settings_btn.AnimationSpeed = 0.03F;
            this.settings_btn.BackColor = System.Drawing.Color.Transparent;
            this.settings_btn.BaseColor = System.Drawing.Color.Transparent;
            this.settings_btn.BorderColor = System.Drawing.Color.Black;
            this.settings_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.settings_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.settings_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.settings_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("settings_btn.CheckedImage")));
            this.settings_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.settings_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.settings_btn.FocusedColor = System.Drawing.Color.Empty;
            this.settings_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_btn.ForeColor = System.Drawing.Color.White;
            this.settings_btn.Image = global::SmartPayroll.Properties.Resources.icons8_settings_256;
            this.settings_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.settings_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.settings_btn.Location = new System.Drawing.Point(35, 675);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.settings_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.settings_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.settings_btn.OnHoverImage = null;
            this.settings_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.settings_btn.OnPressedColor = System.Drawing.Color.Black;
            this.settings_btn.Radius = 20;
            this.settings_btn.Size = new System.Drawing.Size(275, 48);
            this.settings_btn.TabIndex = 1;
            this.settings_btn.Text = "Settings";
            this.settings_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            // 
            // VeiwProporty_btn
            // 
            this.VeiwProporty_btn.AnimationHoverSpeed = 0.07F;
            this.VeiwProporty_btn.AnimationSpeed = 0.03F;
            this.VeiwProporty_btn.BackColor = System.Drawing.Color.Transparent;
            this.VeiwProporty_btn.BaseColor = System.Drawing.Color.Transparent;
            this.VeiwProporty_btn.BorderColor = System.Drawing.Color.Black;
            this.VeiwProporty_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.VeiwProporty_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.VeiwProporty_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.VeiwProporty_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("VeiwProporty_btn.CheckedImage")));
            this.VeiwProporty_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.VeiwProporty_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.VeiwProporty_btn.FocusedColor = System.Drawing.Color.Empty;
            this.VeiwProporty_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VeiwProporty_btn.ForeColor = System.Drawing.Color.White;
            this.VeiwProporty_btn.Image = global::SmartPayroll.Properties.Resources.icons8_shopping_bag_100;
            this.VeiwProporty_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.VeiwProporty_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.VeiwProporty_btn.Location = new System.Drawing.Point(38, 621);
            this.VeiwProporty_btn.Name = "VeiwProporty_btn";
            this.VeiwProporty_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.VeiwProporty_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.VeiwProporty_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.VeiwProporty_btn.OnHoverImage = null;
            this.VeiwProporty_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.VeiwProporty_btn.OnPressedColor = System.Drawing.Color.Black;
            this.VeiwProporty_btn.Radius = 20;
            this.VeiwProporty_btn.Size = new System.Drawing.Size(272, 48);
            this.VeiwProporty_btn.TabIndex = 1;
            this.VeiwProporty_btn.Text = "Veiw Proporties";
            this.VeiwProporty_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VeiwProporty_btn.Click += new System.EventHandler(this.VeiwProporty_btn_Click);
            // 
            // productmanagement_btn
            // 
            this.productmanagement_btn.AnimationHoverSpeed = 0.07F;
            this.productmanagement_btn.AnimationSpeed = 0.03F;
            this.productmanagement_btn.BackColor = System.Drawing.Color.Transparent;
            this.productmanagement_btn.BaseColor = System.Drawing.Color.Transparent;
            this.productmanagement_btn.BorderColor = System.Drawing.Color.Black;
            this.productmanagement_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.productmanagement_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.productmanagement_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.productmanagement_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("productmanagement_btn.CheckedImage")));
            this.productmanagement_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.productmanagement_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.productmanagement_btn.FocusedColor = System.Drawing.Color.Empty;
            this.productmanagement_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productmanagement_btn.ForeColor = System.Drawing.Color.White;
            this.productmanagement_btn.Image = global::SmartPayroll.Properties.Resources.icons8_bread_and_rye_100;
            this.productmanagement_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.productmanagement_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.productmanagement_btn.Location = new System.Drawing.Point(35, 301);
            this.productmanagement_btn.Name = "productmanagement_btn";
            this.productmanagement_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.productmanagement_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.productmanagement_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.productmanagement_btn.OnHoverImage = null;
            this.productmanagement_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.productmanagement_btn.OnPressedColor = System.Drawing.Color.Black;
            this.productmanagement_btn.Radius = 20;
            this.productmanagement_btn.Size = new System.Drawing.Size(285, 48);
            this.productmanagement_btn.TabIndex = 1;
            this.productmanagement_btn.Text = "Products";
            this.productmanagement_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.productmanagement_btn.Click += new System.EventHandler(this.productmanagement_btn_Click);
            // 
            // Billing_btn
            // 
            this.Billing_btn.AnimationHoverSpeed = 0.07F;
            this.Billing_btn.AnimationSpeed = 0.03F;
            this.Billing_btn.BackColor = System.Drawing.Color.Transparent;
            this.Billing_btn.BaseColor = System.Drawing.Color.Transparent;
            this.Billing_btn.BorderColor = System.Drawing.Color.Black;
            this.Billing_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.Billing_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.Billing_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.Billing_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("Billing_btn.CheckedImage")));
            this.Billing_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.Billing_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Billing_btn.FocusedColor = System.Drawing.Color.Empty;
            this.Billing_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Billing_btn.ForeColor = System.Drawing.Color.White;
            this.Billing_btn.Image = global::SmartPayroll.Properties.Resources.icons8_bill_60;
            this.Billing_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.Billing_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.Billing_btn.Location = new System.Drawing.Point(38, 355);
            this.Billing_btn.Name = "Billing_btn";
            this.Billing_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.Billing_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Billing_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.Billing_btn.OnHoverImage = null;
            this.Billing_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.Billing_btn.OnPressedColor = System.Drawing.Color.Black;
            this.Billing_btn.Radius = 20;
            this.Billing_btn.Size = new System.Drawing.Size(285, 48);
            this.Billing_btn.TabIndex = 1;
            this.Billing_btn.Text = "Billing";
            this.Billing_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Billing_btn.Click += new System.EventHandler(this.Billing_btn_Click);
            // 
            // suppliermgmt_btn
            // 
            this.suppliermgmt_btn.AnimationHoverSpeed = 0.07F;
            this.suppliermgmt_btn.AnimationSpeed = 0.03F;
            this.suppliermgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.suppliermgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.suppliermgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.suppliermgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.suppliermgmt_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.suppliermgmt_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.suppliermgmt_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("suppliermgmt_btn.CheckedImage")));
            this.suppliermgmt_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.suppliermgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.suppliermgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.suppliermgmt_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliermgmt_btn.ForeColor = System.Drawing.Color.White;
            this.suppliermgmt_btn.Image = global::SmartPayroll.Properties.Resources.icons8_team_64;
            this.suppliermgmt_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.suppliermgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.suppliermgmt_btn.Location = new System.Drawing.Point(38, 247);
            this.suppliermgmt_btn.Name = "suppliermgmt_btn";
            this.suppliermgmt_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.suppliermgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.suppliermgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.suppliermgmt_btn.OnHoverImage = null;
            this.suppliermgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.suppliermgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.suppliermgmt_btn.Radius = 20;
            this.suppliermgmt_btn.Size = new System.Drawing.Size(285, 48);
            this.suppliermgmt_btn.TabIndex = 1;
            this.suppliermgmt_btn.Text = "Suppliers";
            this.suppliermgmt_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.suppliermgmt_btn.Click += new System.EventHandler(this.suppliermgmt_btn_Click);
            // 
            // employeemgmt_btn
            // 
            this.employeemgmt_btn.AnimationHoverSpeed = 0.07F;
            this.employeemgmt_btn.AnimationSpeed = 0.03F;
            this.employeemgmt_btn.BackColor = System.Drawing.Color.Transparent;
            this.employeemgmt_btn.BaseColor = System.Drawing.Color.Transparent;
            this.employeemgmt_btn.BorderColor = System.Drawing.Color.Black;
            this.employeemgmt_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.employeemgmt_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.employeemgmt_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.employeemgmt_btn.CheckedImage = ((System.Drawing.Image)(resources.GetObject("employeemgmt_btn.CheckedImage")));
            this.employeemgmt_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.employeemgmt_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.employeemgmt_btn.FocusedColor = System.Drawing.Color.Empty;
            this.employeemgmt_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeemgmt_btn.ForeColor = System.Drawing.Color.White;
            this.employeemgmt_btn.Image = global::SmartPayroll.Properties.Resources.icons8_group_64;
            this.employeemgmt_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.employeemgmt_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.employeemgmt_btn.Location = new System.Drawing.Point(38, 193);
            this.employeemgmt_btn.Name = "employeemgmt_btn";
            this.employeemgmt_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.employeemgmt_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.employeemgmt_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.employeemgmt_btn.OnHoverImage = null;
            this.employeemgmt_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.employeemgmt_btn.OnPressedColor = System.Drawing.Color.Black;
            this.employeemgmt_btn.Radius = 20;
            this.employeemgmt_btn.Size = new System.Drawing.Size(285, 48);
            this.employeemgmt_btn.TabIndex = 1;
            this.employeemgmt_btn.Text = "Employees";
            this.employeemgmt_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.employeemgmt_btn.Click += new System.EventHandler(this.employeemgmt_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.AnimationHoverSpeed = 0.07F;
            this.dashboard_btn.AnimationSpeed = 0.03F;
            this.dashboard_btn.BackColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.BaseColor = System.Drawing.Color.Transparent;
            this.dashboard_btn.BorderColor = System.Drawing.Color.Black;
            this.dashboard_btn.CheckedBaseColor = System.Drawing.Color.White;
            this.dashboard_btn.CheckedBorderColor = System.Drawing.Color.Black;
            this.dashboard_btn.CheckedForeColor = System.Drawing.Color.Indigo;
            this.dashboard_btn.CheckedImage = global::SmartPayroll.Properties.Resources.icons8_dashboard_100__1_;
            this.dashboard_btn.CheckedLineColor = System.Drawing.Color.DimGray;
            this.dashboard_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dashboard_btn.FocusedColor = System.Drawing.Color.Empty;
            this.dashboard_btn.Font = new System.Drawing.Font("Quicksand", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.White;
            this.dashboard_btn.Image = global::SmartPayroll.Properties.Resources.icons8_dashboard_100__2_;
            this.dashboard_btn.ImageSize = new System.Drawing.Size(20, 20);
            this.dashboard_btn.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.dashboard_btn.Location = new System.Drawing.Point(38, 139);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.dashboard_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.dashboard_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.dashboard_btn.OnHoverImage = null;
            this.dashboard_btn.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.dashboard_btn.OnPressedColor = System.Drawing.Color.Black;
            this.dashboard_btn.Radius = 20;
            this.dashboard_btn.Size = new System.Drawing.Size(285, 48);
            this.dashboard_btn.TabIndex = 1;
            this.dashboard_btn.Text = "Dashboard";
            this.dashboard_btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // side_panel
            // 
            this.side_panel.Radius = 40;
            this.side_panel.TargetControl = this.panel1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.gunaCircleButton3);
            this.panel2.Controls.Add(this.gunaCircleButton2);
            this.panel2.Controls.Add(this.dashbrdbilling_btn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.gunaLabel2);
            this.panel2.Controls.Add(this.gunaLabel1);
            this.panel2.Controls.Add(this.gunaCirclePictureBox1);
            this.panel2.Location = new System.Drawing.Point(259, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 43);
            this.panel2.TabIndex = 1;
            // 
            // gunaCircleButton3
            // 
            this.gunaCircleButton3.Animated = true;
            this.gunaCircleButton3.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton3.AnimationSpeed = 0.03F;
            this.gunaCircleButton3.BackColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton3.BaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton3.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaCircleButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton3.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton3.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton3.Image = global::SmartPayroll.Properties.Resources.icons8_settings_480;
            this.gunaCircleButton3.ImageSize = new System.Drawing.Size(30, 30);
            this.gunaCircleButton3.Location = new System.Drawing.Point(893, 3);
            this.gunaCircleButton3.Name = "gunaCircleButton3";
            this.gunaCircleButton3.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton3.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton3.OnHoverImage = null;
            this.gunaCircleButton3.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton3.Size = new System.Drawing.Size(40, 40);
            this.gunaCircleButton3.TabIndex = 4;
            // 
            // gunaCircleButton2
            // 
            this.gunaCircleButton2.Animated = true;
            this.gunaCircleButton2.AnimationHoverSpeed = 0.07F;
            this.gunaCircleButton2.AnimationSpeed = 0.03F;
            this.gunaCircleButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton2.BaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaCircleButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaCircleButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaCircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaCircleButton2.ForeColor = System.Drawing.Color.White;
            this.gunaCircleButton2.Image = global::SmartPayroll.Properties.Resources.icons8_get_help_240;
            this.gunaCircleButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.gunaCircleButton2.Location = new System.Drawing.Point(847, 3);
            this.gunaCircleButton2.Name = "gunaCircleButton2";
            this.gunaCircleButton2.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.gunaCircleButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaCircleButton2.OnHoverImage = null;
            this.gunaCircleButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaCircleButton2.Size = new System.Drawing.Size(40, 40);
            this.gunaCircleButton2.TabIndex = 4;
            // 
            // dashbrdbilling_btn
            // 
            this.dashbrdbilling_btn.Animated = true;
            this.dashbrdbilling_btn.AnimationHoverSpeed = 0.07F;
            this.dashbrdbilling_btn.AnimationSpeed = 0.03F;
            this.dashbrdbilling_btn.BackColor = System.Drawing.Color.Transparent;
            this.dashbrdbilling_btn.BaseColor = System.Drawing.Color.Transparent;
            this.dashbrdbilling_btn.BorderColor = System.Drawing.Color.Black;
            this.dashbrdbilling_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dashbrdbilling_btn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.dashbrdbilling_btn.FocusedColor = System.Drawing.Color.Empty;
            this.dashbrdbilling_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dashbrdbilling_btn.ForeColor = System.Drawing.Color.White;
            this.dashbrdbilling_btn.Image = global::SmartPayroll.Properties.Resources.icons8_pay_date_96;
            this.dashbrdbilling_btn.ImageSize = new System.Drawing.Size(30, 30);
            this.dashbrdbilling_btn.Location = new System.Drawing.Point(801, 3);
            this.dashbrdbilling_btn.Name = "dashbrdbilling_btn";
            this.dashbrdbilling_btn.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.dashbrdbilling_btn.OnHoverBorderColor = System.Drawing.Color.Black;
            this.dashbrdbilling_btn.OnHoverForeColor = System.Drawing.Color.White;
            this.dashbrdbilling_btn.OnHoverImage = null;
            this.dashbrdbilling_btn.OnPressedColor = System.Drawing.Color.Black;
            this.dashbrdbilling_btn.Size = new System.Drawing.Size(40, 40);
            this.dashbrdbilling_btn.TabIndex = 4;
            this.dashbrdbilling_btn.Click += new System.EventHandler(this.dashbrdbilling_btn_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::SmartPayroll.Properties.Resources.icons8_email_64;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(15, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 30);
            this.panel3.TabIndex = 2;
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Quicksand", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel2.Location = new System.Drawing.Point(954, 8);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(82, 24);
            this.gunaLabel2.TabIndex = 3;
            this.gunaLabel2.Text = "John Doe";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Quicksand", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel1.Location = new System.Drawing.Point(51, 12);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(125, 19);
            this.gunaLabel1.TabIndex = 3;
            this.gunaLabel1.Text = "johndoe123@info.lk";
            // 
            // gunaCirclePictureBox1
            // 
            this.gunaCirclePictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaCirclePictureBox1.Image = global::SmartPayroll.Properties.Resources.depositphotos_39258143_stock_illustration_businessman_avatar_profile_picture;
            this.gunaCirclePictureBox1.Location = new System.Drawing.Point(1042, 1);
            this.gunaCirclePictureBox1.Name = "gunaCirclePictureBox1";
            this.gunaCirclePictureBox1.Size = new System.Drawing.Size(40, 40);
            this.gunaCirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaCirclePictureBox1.TabIndex = 2;
            this.gunaCirclePictureBox1.TabStop = false;
            this.gunaCirclePictureBox1.UseTransfarantBackground = false;
            // 
            // upper_panel
            // 
            this.upper_panel.Radius = 20;
            this.upper_panel.TargetControl = this.panel2;
            // 
            // sqlCeCommand1
            // 
            this.sqlCeCommand1.CommandTimeout = 0;
            this.sqlCeCommand1.Connection = null;
            this.sqlCeCommand1.IndexName = null;
            this.sqlCeCommand1.Transaction = null;
            // 
            // settingsManagement1
            // 
            this.settingsManagement1.BackColor = System.Drawing.Color.White;
            this.settingsManagement1.Location = new System.Drawing.Point(259, 83);
            this.settingsManagement1.Name = "settingsManagement1";
            this.settingsManagement1.Size = new System.Drawing.Size(1112, 663);
            this.settingsManagement1.TabIndex = 8;
            // 
            // veiwAllProporties1
            // 
            this.veiwAllProporties1.BackColor = System.Drawing.Color.White;
            this.veiwAllProporties1.Location = new System.Drawing.Point(259, 83);
            this.veiwAllProporties1.Name = "veiwAllProporties1";
            this.veiwAllProporties1.Size = new System.Drawing.Size(1112, 639);
            this.veiwAllProporties1.TabIndex = 7;
            // 
            // billingProcessDetailsManagement1
            // 
            this.billingProcessDetailsManagement1.BackColor = System.Drawing.Color.White;
            this.billingProcessDetailsManagement1.Location = new System.Drawing.Point(259, 83);
            this.billingProcessDetailsManagement1.Name = "billingProcessDetailsManagement1";
            this.billingProcessDetailsManagement1.Size = new System.Drawing.Size(1112, 639);
            this.billingProcessDetailsManagement1.TabIndex = 6;
            // 
            // productDetailsManagement1
            // 
            this.productDetailsManagement1.BackColor = System.Drawing.Color.White;
            this.productDetailsManagement1.Location = new System.Drawing.Point(259, 83);
            this.productDetailsManagement1.Name = "productDetailsManagement1";
            this.productDetailsManagement1.Size = new System.Drawing.Size(1112, 639);
            this.productDetailsManagement1.TabIndex = 5;
            // 
            // supplierDetailsManagement1
            // 
            this.supplierDetailsManagement1.BackColor = System.Drawing.Color.White;
            this.supplierDetailsManagement1.Location = new System.Drawing.Point(259, 83);
            this.supplierDetailsManagement1.Name = "supplierDetailsManagement1";
            this.supplierDetailsManagement1.Size = new System.Drawing.Size(1112, 639);
            this.supplierDetailsManagement1.TabIndex = 4;
            // 
            // employeeForm1
            // 
            this.employeeForm1.BackColor = System.Drawing.Color.White;
            this.employeeForm1.Location = new System.Drawing.Point(259, 83);
            this.employeeForm1.Name = "employeeForm1";
            this.employeeForm1.Size = new System.Drawing.Size(1112, 639);
            this.employeeForm1.TabIndex = 3;
            // 
            // dashboardFom1
            // 
            this.dashboardFom1.BackColor = System.Drawing.Color.White;
            this.dashboardFom1.Location = new System.Drawing.Point(259, 83);
            this.dashboardFom1.Name = "dashboardFom1";
            this.dashboardFom1.Size = new System.Drawing.Size(1112, 639);
            this.dashboardFom1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 736);
            this.Controls.Add(this.settingsManagement1);
            this.Controls.Add(this.veiwAllProporties1);
            this.Controls.Add(this.billingProcessDetailsManagement1);
            this.Controls.Add(this.productDetailsManagement1);
            this.Controls.Add(this.supplierDetailsManagement1);
            this.Controls.Add(this.employeeForm1);
            this.Controls.Add(this.dashboardFom1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaCirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaElipse side_panel;
        private Guna.UI.WinForms.GunaAdvenceButton settings_btn;
        private Guna.UI.WinForms.GunaAdvenceButton VeiwProporty_btn;
        private Guna.UI.WinForms.GunaAdvenceButton Billing_btn;
        private Guna.UI.WinForms.GunaAdvenceButton suppliermgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton employeemgmt_btn;
        private Guna.UI.WinForms.GunaAdvenceButton dashboard_btn;
        private Guna.UI.WinForms.GunaAdvenceButton productmanagement_btn;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI.WinForms.GunaCirclePictureBox gunaCirclePictureBox1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaElipse upper_panel;
        private DashboardFom dashboardFom1;
        private EmployeeDetailsManagement employeeForm1;
        private Guna.UI.WinForms.GunaCircleButton dashbrdbilling_btn;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton3;
        private Guna.UI.WinForms.GunaCircleButton gunaCircleButton2;
        private SupplierDetailsManagement supplierDetailsManagement1;
        private ProductDetailsManagement productDetailsManagement1;
        private BillingProcessDetailsManagement billingProcessDetailsManagement1;
        private VeiwAllProporties veiwAllProporties1;
        private SettingsManagement settingsManagement1;
        private System.Data.SqlServerCe.SqlCeCommand sqlCeCommand1;
        private System.Data.SqlServerCe.SqlCeConnection sqlCeConnection1;
    }
}


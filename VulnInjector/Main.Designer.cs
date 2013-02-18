namespace VulnInjector
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtKey = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDriveISO = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.DriveISOMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cdDriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rescanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openImageFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.txtStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lbTargetArch = new System.Windows.Forms.Label();
            this.lbTargetEdition = new System.Windows.Forms.Label();
            this.lbTargetSP = new System.Windows.Forms.Label();
            this.lbTargetOS = new System.Windows.Forms.Label();
            this.lbSourceLicense = new System.Windows.Forms.Label();
            this.lbSourceArch = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbSourceEdition = new System.Windows.Forms.Label();
            this.lbSourceSP = new System.Windows.Forms.Label();
            this.lbSourceOS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTarget = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.Readme = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Generate = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DriveISOMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtKey);
            this.groupBox5.Location = new System.Drawing.Point(12, 90);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 54);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "2.) Product Key";
            // 
            // txtKey
            // 
            this.txtKey.AsciiOnly = true;
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(14, 19);
            this.txtKey.Mask = ">aaaaa-aaaaa-aaaaa-aaaaa-aaaaa";
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(268, 22);
            this.txtKey.TabIndex = 2;
            this.txtKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtKey.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtKey.TextChanged += new System.EventHandler(this.KeyTextChanged);
            this.txtKey.Enter += new System.EventHandler(this.KeyEnterLeave);
            this.txtKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Key_Press);
            this.txtKey.Leave += new System.EventHandler(this.KeyEnterLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDriveISO);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 61);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1.) Source";
            // 
            // btnDriveISO
            // 
            this.btnDriveISO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDriveISO.Image = ((System.Drawing.Image)(resources.GetObject("btnDriveISO.Image")));
            this.btnDriveISO.Location = new System.Drawing.Point(255, 21);
            this.btnDriveISO.Name = "btnDriveISO";
            this.btnDriveISO.Size = new System.Drawing.Size(27, 27);
            this.btnDriveISO.TabIndex = 12;
            this.btnDriveISO.UseVisualStyleBackColor = true;
            this.btnDriveISO.Click += new System.EventHandler(this.DriveIsoClick);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(20, 25);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(229, 20);
            this.txtSource.TabIndex = 10;
            // 
            // DriveISOMenu
            // 
            this.DriveISOMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cdDriveToolStripMenuItem,
            this.toolStripSeparator2,
            this.rescanToolStripMenuItem,
            this.toolStripSeparator3,
            this.openImageFileToolStripMenuItem,
            this.nAToolStripMenuItem});
            this.DriveISOMenu.Name = "contextMenuStrip1";
            this.DriveISOMenu.Size = new System.Drawing.Size(161, 104);
            this.DriveISOMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DriveIsoMenuItemClicked);
            // 
            // cdDriveToolStripMenuItem
            // 
            this.cdDriveToolStripMenuItem.Image = global::VulnInjector.Properties.Resources.EmptyDrive;
            this.cdDriveToolStripMenuItem.Name = "cdDriveToolStripMenuItem";
            this.cdDriveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cdDriveToolStripMenuItem.Text = "<cd drive>";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            this.toolStripSeparator2.Tag = "used";
            // 
            // rescanToolStripMenuItem
            // 
            this.rescanToolStripMenuItem.Image = global::VulnInjector.Properties.Resources.refresh;
            this.rescanToolStripMenuItem.Name = "rescanToolStripMenuItem";
            this.rescanToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.rescanToolStripMenuItem.Tag = "used";
            this.rescanToolStripMenuItem.Text = "Rescan";
            this.rescanToolStripMenuItem.Click += new System.EventHandler(this.RescanToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            this.toolStripSeparator3.Tag = "used";
            // 
            // openImageFileToolStripMenuItem
            // 
            this.openImageFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openImageFileToolStripMenuItem.Image")));
            this.openImageFileToolStripMenuItem.Name = "openImageFileToolStripMenuItem";
            this.openImageFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.openImageFileToolStripMenuItem.Tag = "used";
            this.openImageFileToolStripMenuItem.Text = "Open Image File";
            this.openImageFileToolStripMenuItem.Click += new System.EventHandler(this.OpenImageFileToolStripMenuItemClick);
            // 
            // nAToolStripMenuItem
            // 
            this.nAToolStripMenuItem.Enabled = false;
            this.nAToolStripMenuItem.Name = "nAToolStripMenuItem";
            this.nAToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.nAToolStripMenuItem.Tag = "used";
            this.nAToolStripMenuItem.Text = "N/A";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 197);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(621, 22);
            this.statusStrip.TabIndex = 22;
            this.statusStrip.Text = "statusStrip1";
            // 
            // txtStatus
            // 
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(504, 17);
            this.txtStatus.Spring = true;
            this.txtStatus.Text = "<status>";
            this.txtStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Value = 100;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::VulnInjector.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripSeparator1,
            this.websiteToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Image = global::VulnInjector.Properties.Resources.help;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem1.Text = "FAQ/Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Image = global::VulnInjector.Properties.Resources.Web;
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::VulnInjector.Properties.Resources.info;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About/Legal";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel);
            this.groupBox2.Location = new System.Drawing.Point(313, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 117);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Controls.Add(this.lbTargetArch, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.lbTargetEdition, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.lbTargetSP, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.lbTargetOS, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.lbSourceLicense, 1, 7);
            this.tableLayoutPanel.Controls.Add(this.lbSourceArch, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.label9, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lbSourceEdition, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.lbSourceSP, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.lbSourceOS, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lbTarget, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.lbResult, 1, 8);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(293, 98);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // lbTargetArch
            // 
            this.lbTargetArch.AutoSize = true;
            this.lbTargetArch.Location = new System.Drawing.Point(207, 52);
            this.lbTargetArch.Name = "lbTargetArch";
            this.lbTargetArch.Size = new System.Drawing.Size(25, 13);
            this.lbTargetArch.TabIndex = 25;
            this.lbTargetArch.Text = "???";
            this.lbTargetArch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTargetEdition
            // 
            this.lbTargetEdition.AutoSize = true;
            this.lbTargetEdition.Location = new System.Drawing.Point(207, 39);
            this.lbTargetEdition.Name = "lbTargetEdition";
            this.lbTargetEdition.Size = new System.Drawing.Size(25, 13);
            this.lbTargetEdition.TabIndex = 24;
            this.lbTargetEdition.Text = "???";
            this.lbTargetEdition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTargetSP
            // 
            this.lbTargetSP.AutoSize = true;
            this.lbTargetSP.Location = new System.Drawing.Point(207, 26);
            this.lbTargetSP.Name = "lbTargetSP";
            this.lbTargetSP.Size = new System.Drawing.Size(25, 13);
            this.lbTargetSP.TabIndex = 23;
            this.lbTargetSP.Text = "???";
            this.lbTargetSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTargetOS
            // 
            this.lbTargetOS.AutoSize = true;
            this.lbTargetOS.Location = new System.Drawing.Point(207, 13);
            this.lbTargetOS.Name = "lbTargetOS";
            this.lbTargetOS.Size = new System.Drawing.Size(25, 13);
            this.lbTargetOS.TabIndex = 26;
            this.lbTargetOS.Text = "???";
            this.lbTargetOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSourceLicense
            // 
            this.lbSourceLicense.AutoSize = true;
            this.lbSourceLicense.Location = new System.Drawing.Point(120, 65);
            this.lbSourceLicense.Name = "lbSourceLicense";
            this.lbSourceLicense.Size = new System.Drawing.Size(25, 13);
            this.lbSourceLicense.TabIndex = 21;
            this.lbSourceLicense.Text = "???";
            this.lbSourceLicense.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSourceArch
            // 
            this.lbSourceArch.AutoSize = true;
            this.lbSourceArch.Location = new System.Drawing.Point(120, 52);
            this.lbSourceArch.Name = "lbSourceArch";
            this.lbSourceArch.Size = new System.Drawing.Size(25, 13);
            this.lbSourceArch.TabIndex = 20;
            this.lbSourceArch.Text = "???";
            this.lbSourceArch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(67, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Result:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "License:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Architecture:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Edition:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Service Pack:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Operating System:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSourceEdition
            // 
            this.lbSourceEdition.AutoSize = true;
            this.lbSourceEdition.Location = new System.Drawing.Point(120, 39);
            this.lbSourceEdition.Name = "lbSourceEdition";
            this.lbSourceEdition.Size = new System.Drawing.Size(25, 13);
            this.lbSourceEdition.TabIndex = 19;
            this.lbSourceEdition.Text = "???";
            this.lbSourceEdition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSourceSP
            // 
            this.lbSourceSP.AutoSize = true;
            this.lbSourceSP.Location = new System.Drawing.Point(120, 26);
            this.lbSourceSP.Name = "lbSourceSP";
            this.lbSourceSP.Size = new System.Drawing.Size(25, 13);
            this.lbSourceSP.TabIndex = 18;
            this.lbSourceSP.Text = "???";
            this.lbSourceSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSourceOS
            // 
            this.lbSourceOS.AutoSize = true;
            this.lbSourceOS.Location = new System.Drawing.Point(120, 13);
            this.lbSourceOS.Name = "lbSourceOS";
            this.lbSourceOS.Size = new System.Drawing.Size(25, 13);
            this.lbSourceOS.TabIndex = 17;
            this.lbSourceOS.Text = "???";
            this.lbSourceOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Source";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbTarget
            // 
            this.lbTarget.AutoSize = true;
            this.lbTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTarget.Location = new System.Drawing.Point(207, 0);
            this.lbTarget.Name = "lbTarget";
            this.lbTarget.Size = new System.Drawing.Size(83, 13);
            this.lbTarget.TabIndex = 29;
            this.lbTarget.Text = "???";
            this.lbTarget.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.lbResult, 2);
            this.lbResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.ForeColor = System.Drawing.Color.Green;
            this.lbResult.Location = new System.Drawing.Point(120, 78);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(170, 20);
            this.lbResult.TabIndex = 30;
            this.lbResult.Text = "<result>";
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Readme
            // 
            this.Readme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Readme.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Readme.Location = new System.Drawing.Point(439, 147);
            this.Readme.Name = "Readme";
            this.Readme.Size = new System.Drawing.Size(173, 42);
            this.Readme.TabIndex = 24;
            this.Readme.Text = "View &README";
            this.Readme.UseVisualStyleBackColor = true;
            this.Readme.Click += new System.EventHandler(this.ReadmeClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(621, 24);
            this.menuStrip.TabIndex = 23;
            this.menuStrip.Text = "menuStrip1";
            // 
            // Generate
            // 
            this.Generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Generate.Image = ((System.Drawing.Image)(resources.GetObject("Generate.Image")));
            this.Generate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Generate.Location = new System.Drawing.Point(12, 147);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(295, 42);
            this.Generate.TabIndex = 19;
            this.Generate.Text = "3.) &Generate Image (.ISO)";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.GenerateClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 219);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.Readme);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Generate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "VulnInjector v0.1";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DriveISOMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.MaskedTextBox txtKey;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDriveISO;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.ContextMenuStrip DriveISOMenu;
        private System.Windows.Forms.ToolStripMenuItem cdDriveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem rescanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openImageFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nAToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel txtStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lbSourceSP;
        private System.Windows.Forms.Label lbSourceOS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbSourceEdition;
        private System.Windows.Forms.Label lbSourceArch;
        private System.Windows.Forms.Label lbTargetSP;
        private System.Windows.Forms.Label lbTargetEdition;
        private System.Windows.Forms.Label lbTargetArch;
        private System.Windows.Forms.Label lbTargetOS;
        private System.Windows.Forms.Label lbSourceLicense;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTarget;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Button Readme;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
    }
}


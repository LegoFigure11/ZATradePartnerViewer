namespace ZATradePartnerViewer.WinForms;

    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        GB_Connection = new GroupBox();
        TB_Status = new TextBox();
        L_Status = new Label();
        B_Disconnect = new Button();
        B_Connect = new Button();
        L_SwitchIP = new Label();
        TB_SwitchIP = new TextBox();
        GB_SAVInfo = new GroupBox();
        L_Theme = new Label();
        CB_Theme = new ComboBox();
        B_ReadTrade = new Button();
        TB_PartnerOT = new TextBox();
        L_PartnerOT = new Label();
        TB_NID = new TextBox();
        L_NID = new Label();
        TB_PartnerTID = new TextBox();
        L_PartnerTID = new Label();
        B_Copy = new Button();
        CB_Auto = new CheckBox();
        B_PinToTop = new Button();
        TT_PinToTop = new ToolTip(components);
        GB_Connection.SuspendLayout();
        GB_SAVInfo.SuspendLayout();
        SuspendLayout();
        // 
        // GB_Connection
        // 
        GB_Connection.Controls.Add(TB_Status);
        GB_Connection.Controls.Add(L_Status);
        GB_Connection.Controls.Add(B_Disconnect);
        GB_Connection.Controls.Add(B_Connect);
        GB_Connection.Controls.Add(L_SwitchIP);
        GB_Connection.Controls.Add(TB_SwitchIP);
        GB_Connection.Location = new Point(0, -8);
        GB_Connection.Margin = new Padding(3, 0, 3, 3);
        GB_Connection.Name = "GB_Connection";
        GB_Connection.RightToLeft = RightToLeft.No;
        GB_Connection.Size = new Size(212, 83);
        GB_Connection.TabIndex = 2;
        GB_Connection.TabStop = false;
        // 
        // TB_Status
        // 
        TB_Status.BackColor = SystemColors.Control;
        TB_Status.BorderStyle = BorderStyle.None;
        TB_Status.Location = new Point(74, 64);
        TB_Status.Name = "TB_Status";
        TB_Status.ReadOnly = true;
        TB_Status.RightToLeft = RightToLeft.No;
        TB_Status.Size = new Size(132, 16);
        TB_Status.TabIndex = 18;
        TB_Status.TabStop = false;
        TB_Status.Text = "wwwwwwwwwwwwww";
        TB_Status.TextAlign = HorizontalAlignment.Right;
        // 
        // L_Status
        // 
        L_Status.AutoSize = true;
        L_Status.Location = new Point(11, 64);
        L_Status.Name = "L_Status";
        L_Status.Size = new Size(42, 15);
        L_Status.TabIndex = 17;
        L_Status.Text = "Status:";
        // 
        // B_Disconnect
        // 
        B_Disconnect.Enabled = false;
        B_Disconnect.Location = new Point(109, 36);
        B_Disconnect.Name = "B_Disconnect";
        B_Disconnect.Size = new Size(97, 25);
        B_Disconnect.TabIndex = 2;
        B_Disconnect.Text = "Disconnect";
        B_Disconnect.UseVisualStyleBackColor = true;
        B_Disconnect.Click += B_Disconnect_Click;
        // 
        // B_Connect
        // 
        B_Connect.Location = new Point(11, 36);
        B_Connect.Name = "B_Connect";
        B_Connect.Size = new Size(97, 25);
        B_Connect.TabIndex = 1;
        B_Connect.Text = "Connect";
        B_Connect.UseVisualStyleBackColor = true;
        B_Connect.Click += B_Connect_Click;
        // 
        // L_SwitchIP
        // 
        L_SwitchIP.AutoSize = true;
        L_SwitchIP.Location = new Point(11, 14);
        L_SwitchIP.Name = "L_SwitchIP";
        L_SwitchIP.Size = new Size(58, 15);
        L_SwitchIP.TabIndex = 12;
        L_SwitchIP.Text = "Switch IP:";
        // 
        // TB_SwitchIP
        // 
        TB_SwitchIP.CharacterCasing = CharacterCasing.Lower;
        TB_SwitchIP.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SwitchIP.Location = new Point(95, 12);
        TB_SwitchIP.MaxLength = 15;
        TB_SwitchIP.Name = "TB_SwitchIP";
        TB_SwitchIP.Size = new Size(111, 22);
        TB_SwitchIP.TabIndex = 0;
        TB_SwitchIP.Text = "123.123.123.123";
        TB_SwitchIP.TextChanged += TB_SwitchIP_TextChanged;
        // 
        // GB_SAVInfo
        // 
        GB_SAVInfo.Controls.Add(L_Theme);
        GB_SAVInfo.Controls.Add(CB_Theme);
        GB_SAVInfo.Location = new Point(0, 65);
        GB_SAVInfo.Name = "GB_SAVInfo";
        GB_SAVInfo.Size = new Size(212, 48);
        GB_SAVInfo.TabIndex = 4;
        GB_SAVInfo.TabStop = false;
        // 
        // L_Theme
        // 
        L_Theme.AutoSize = true;
        L_Theme.Location = new Point(12, 19);
        L_Theme.Name = "L_Theme";
        L_Theme.Size = new Size(47, 15);
        L_Theme.TabIndex = 179;
        L_Theme.Text = "Theme:";
        // 
        // CB_Theme
        // 
        CB_Theme.FormattingEnabled = true;
        CB_Theme.Items.AddRange(new object[] { "Light", "System", "Dark" });
        CB_Theme.Location = new Point(95, 16);
        CB_Theme.Name = "CB_Theme";
        CB_Theme.Size = new Size(111, 23);
        CB_Theme.TabIndex = 178;
        CB_Theme.SelectedIndexChanged += CB_Theme_SelectedIndexChanged;
        // 
        // B_ReadTrade
        // 
        B_ReadTrade.Location = new Point(6, 117);
        B_ReadTrade.Name = "B_ReadTrade";
        B_ReadTrade.Size = new Size(200, 25);
        B_ReadTrade.TabIndex = 7;
        B_ReadTrade.Text = "Read Trade Partner";
        B_ReadTrade.UseVisualStyleBackColor = true;
        B_ReadTrade.Click += B_ReadTrade_Click;
        // 
        // TB_PartnerOT
        // 
        TB_PartnerOT.Font = new Font("Consolas", 9F);
        TB_PartnerOT.Location = new Point(342, 7);
        TB_PartnerOT.Margin = new Padding(4, 3, 4, 3);
        TB_PartnerOT.Name = "TB_PartnerOT";
        TB_PartnerOT.ReadOnly = true;
        TB_PartnerOT.Size = new Size(118, 22);
        TB_PartnerOT.TabIndex = 130;
        // 
        // L_PartnerOT
        // 
        L_PartnerOT.AutoSize = true;
        L_PartnerOT.Location = new Point(239, 9);
        L_PartnerOT.Name = "L_PartnerOT";
        L_PartnerOT.Size = new Size(98, 15);
        L_PartnerOT.TabIndex = 129;
        L_PartnerOT.Text = "Trade Partner OT:";
        L_PartnerOT.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TB_NID
        // 
        TB_NID.Font = new Font("Consolas", 9F);
        TB_NID.Location = new Point(342, 35);
        TB_NID.Margin = new Padding(4, 3, 4, 3);
        TB_NID.Name = "TB_NID";
        TB_NID.ReadOnly = true;
        TB_NID.Size = new Size(118, 22);
        TB_NID.TabIndex = 132;
        // 
        // L_NID
        // 
        L_NID.AutoSize = true;
        L_NID.Location = new Point(233, 37);
        L_NID.Name = "L_NID";
        L_NID.Size = new Size(103, 15);
        L_NID.TabIndex = 131;
        L_NID.Text = "Trade Partner NID:";
        L_NID.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TB_PartnerTID
        // 
        TB_PartnerTID.Font = new Font("Consolas", 9F);
        TB_PartnerTID.Location = new Point(342, 63);
        TB_PartnerTID.Margin = new Padding(4, 3, 4, 3);
        TB_PartnerTID.Name = "TB_PartnerTID";
        TB_PartnerTID.ReadOnly = true;
        TB_PartnerTID.Size = new Size(118, 22);
        TB_PartnerTID.TabIndex = 134;
        // 
        // L_PartnerTID
        // 
        L_PartnerTID.AutoSize = true;
        L_PartnerTID.Location = new Point(278, 65);
        L_PartnerTID.Name = "L_PartnerTID";
        L_PartnerTID.Size = new Size(57, 15);
        L_PartnerTID.TabIndex = 133;
        L_PartnerTID.Text = "Trader ID:";
        L_PartnerTID.TextAlign = ContentAlignment.MiddleRight;
        // 
        // B_Copy
        // 
        B_Copy.Location = new Point(221, 117);
        B_Copy.Name = "B_Copy";
        B_Copy.Size = new Size(215, 25);
        B_Copy.TabIndex = 135;
        B_Copy.Text = "Copy";
        B_Copy.UseVisualStyleBackColor = true;
        B_Copy.Click += B_Copy_Click;
        // 
        // CB_Auto
        // 
        CB_Auto.AutoSize = true;
        CB_Auto.Location = new Point(221, 94);
        CB_Auto.Name = "CB_Auto";
        CB_Auto.Size = new Size(88, 19);
        CB_Auto.TabIndex = 136;
        CB_Auto.Text = "Auto Copy?";
        CB_Auto.UseVisualStyleBackColor = true;
        CB_Auto.CheckedChanged += CB_Auto_CheckedChanged;
        // 
        // B_PinToTop
        // 
        B_PinToTop.Location = new Point(442, 117);
        B_PinToTop.Name = "B_PinToTop";
        B_PinToTop.Size = new Size(18, 25);
        B_PinToTop.TabIndex = 137;
        B_PinToTop.Text = "↑";
        TT_PinToTop.SetToolTip(B_PinToTop, "Pin as top window");
        B_PinToTop.UseVisualStyleBackColor = true;
        B_PinToTop.Click += B_PinToTop_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(470, 153);
        Controls.Add(B_PinToTop);
        Controls.Add(CB_Auto);
        Controls.Add(B_Copy);
        Controls.Add(TB_PartnerTID);
        Controls.Add(L_PartnerTID);
        Controls.Add(TB_NID);
        Controls.Add(L_NID);
        Controls.Add(TB_PartnerOT);
        Controls.Add(L_PartnerOT);
        Controls.Add(B_ReadTrade);
        Controls.Add(GB_Connection);
        Controls.Add(GB_SAVInfo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        Name = "MainWindow";
        FormClosing += MainWindow_FormClosing;
        Load += MainWindow_Load;
        GB_Connection.ResumeLayout(false);
        GB_Connection.PerformLayout();
        GB_SAVInfo.ResumeLayout(false);
        GB_SAVInfo.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox GB_Connection;
    private TextBox TB_Status;
    private Label L_Status;
    private Button B_Disconnect;
    private Button B_Connect;
    private Label L_SwitchIP;
    private TextBox TB_SwitchIP;
    private GroupBox GB_SAVInfo;
    private Button B_ReadTrade;
    private TextBox TB_PartnerOT;
    private Label L_PartnerOT;
    private TextBox TB_NID;
    private Label L_NID;
    private TextBox TB_PartnerTID;
    private Label L_PartnerTID;
    private Label L_Theme;
    private ComboBox CB_Theme;
    private Button B_Copy;
    private CheckBox CB_Auto;
    private Button B_PinToTop;
    private ToolTip TT_PinToTop;
}


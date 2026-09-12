<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HPT
    Inherits Cyber.From.Frmvoucher

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HPT))
        Me.CbbMa_GD = New System.Windows.Forms.ComboBox()
        Me.LabNgay_LCt = New System.Windows.Forms.Label()
        Me.LabNgay_Ct = New System.Windows.Forms.Label()
        Me.txtDien_giai = New System.Windows.Forms.TextBox()
        Me.lblLoai_ct = New System.Windows.Forms.Label()
        Me.lblSo_ct = New System.Windows.Forms.Label()
        Me.txtSo_ct = New System.Windows.Forms.TextBox()
        Me.LabMa_kh = New System.Windows.Forms.Label()
        Me.TxtNgay_LCt = New ClsTextBox.txtDate()
        Me.TxtNgay_Ct = New ClsTextBox.txtDate()
        Me.GroupBoxLine = New System.Windows.Forms.GroupBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TxtMa_Dvcs = New System.Windows.Forms.TextBox()
        Me.TxtStt_Rec = New System.Windows.Forms.TextBox()
        Me.PopupMenuMasterGrid = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.LabLenh_RO = New System.Windows.Forms.Label()
        Me.TxtMa_Xe = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtTen_vtthue = New System.Windows.Forms.TextBox()
        Me.LblDien_Giai = New System.Windows.Forms.Label()
        Me.TxtTen_Hs_H = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtMa_Hs_H = New Cyber.SmLists.TxtLookup()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtT_Tong_Hang = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien_Hang = New ClsTextBox.txtTien_NT()
        Me.TxtT_Thue_hang = New ClsTextBox.txtTien_NT()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtHan_TT = New ClsTextBox.txtSo_luong()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtT_Tien_Nt2 = New ClsTextBox.txtTien_NT()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtT_Thue_Nt = New ClsTextBox.txtTien_NT()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblTong_Cong = New System.Windows.Forms.Label()
        Me.TxtT_TT_NT = New ClsTextBox.txtTien_NT()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TabHDK = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Detail = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TabCv = New System.Windows.Forms.TabPage()
        Me.DetailCv = New DevExpress.XtraGrid.GridControl()
        Me.DetailGRVCv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TxtLenh_RO = New System.Windows.Forms.TextBox()
        Me.TxtT_Tien2 = New ClsTextBox.txtTien_NT()
        Me.TxtT_Thue = New ClsTextBox.txtTien_NT()
        Me.TxtT_TT = New ClsTextBox.txtTien_NT()
        Me.TxtTen_kh = New System.Windows.Forms.TextBox()
        Me.TxtDia_Chi = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTen_BP_H = New System.Windows.Forms.TextBox()
        Me.TxtMa_Bp_H = New Cyber.SmLists.TxtLookup()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkSua_Thue = New System.Windows.Forms.CheckBox()
        Me.cmdXac_nhan_I = New System.Windows.Forms.Button()
        Me.CmdXe_Ra = New System.Windows.Forms.Button()
        Me.CmdHuy_HD = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMa_NT = New System.Windows.Forms.TextBox()
        Me.TxtLenh_PO = New System.Windows.Forms.TextBox()
        Me.TxtLenh_SO = New System.Windows.Forms.TextBox()
        Me.TxtLenh_Vt = New System.Windows.Forms.TextBox()
        Me.TxtTy_Gia = New ClsTextBox.txtTy_Gia()
        Me.TxtMa_Quyen = New System.Windows.Forms.TextBox()
        Me.TxtT_Tong_Cong = New ClsTextBox.txtTien_NT()
        Me.TxtT_Thue_Cong = New ClsTextBox.txtTien_NT()
        Me.TxtT_Tien_Cong = New ClsTextBox.txtTien_NT()
        Me.TxtGio_Dn = New System.Windows.Forms.TextBox()
        Me.TxtNgay_Dn = New ClsTextBox.txtDate()
        Me.CmdDe_Nghi = New DevExpress.XtraEditors.SimpleButton()
        Me.BttDelIsCv = New DevExpress.XtraEditors.SimpleButton()
        Me.LabMa_TTCP_H = New System.Windows.Forms.Label()
        Me.CbbMa_TTCP_H = New System.Windows.Forms.ComboBox()
        CType(Me.PopupMenuMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenuMasterGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Hs_H.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabHDK.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Detail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCv.SuspendLayout()
        CType(Me.DetailCv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetailGRVCv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMa_Bp_H.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdEdit
        '
        Me.CmdEdit.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdEdit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdEdit.Appearance.Options.UseBackColor = True
        Me.CmdEdit.Appearance.Options.UseFont = True
        Me.CmdEdit.Appearance.Options.UseForeColor = True
        Me.CmdEdit.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdEdit.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdEdit.Location = New System.Drawing.Point(239, 565)
        '
        'CmdSave
        '
        Me.CmdSave.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSave.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSave.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSave.Appearance.Options.UseBackColor = True
        Me.CmdSave.Appearance.Options.UseFont = True
        Me.CmdSave.Appearance.Options.UseForeColor = True
        Me.CmdSave.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSave.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSave.Location = New System.Drawing.Point(-1, 565)
        Me.CmdSave.TabIndex = 25
        '
        'CmdView
        '
        Me.CmdView.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdView.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdView.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdView.Appearance.Options.UseBackColor = True
        Me.CmdView.Appearance.Options.UseFont = True
        Me.CmdView.Appearance.Options.UseForeColor = True
        Me.CmdView.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdView.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdView.Location = New System.Drawing.Point(478, 565)
        Me.CmdView.TabIndex = 31
        '
        'LabMa_Post
        '
        Me.LabMa_Post.ForeColor = System.Drawing.Color.Navy
        Me.LabMa_Post.Location = New System.Drawing.Point(24, 546)
        '
        'CmdSms
        '
        Me.CmdSms.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSms.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSms.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSms.Appearance.Options.UseBackColor = True
        Me.CmdSms.Appearance.Options.UseFont = True
        Me.CmdSms.Appearance.Options.UseForeColor = True
        Me.CmdSms.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSms.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSms.Location = New System.Drawing.Point(983, 565)
        '
        'CmdImport
        '
        Me.CmdImport.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdImport.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdImport.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdImport.Appearance.Options.UseBackColor = True
        Me.CmdImport.Appearance.Options.UseFont = True
        Me.CmdImport.Appearance.Options.UseForeColor = True
        Me.CmdImport.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdImport.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdImport.Location = New System.Drawing.Point(1027, 565)
        Me.CmdImport.TabIndex = 39
        '
        'CbbMa_Post
        '
        Me.CbbMa_Post.Location = New System.Drawing.Point(87, 542)
        Me.CbbMa_Post.TabIndex = 16
        '
        'CmdExit
        '
        Me.CmdExit.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdExit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdExit.Appearance.Options.UseBackColor = True
        Me.CmdExit.Appearance.Options.UseFont = True
        Me.CmdExit.Appearance.Options.UseForeColor = True
        Me.CmdExit.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdExit.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdExit.Location = New System.Drawing.Point(637, 565)
        Me.CmdExit.TabIndex = 33
        '
        'CmdSearch
        '
        Me.CmdSearch.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdSearch.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdSearch.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdSearch.Appearance.Options.UseBackColor = True
        Me.CmdSearch.Appearance.Options.UseFont = True
        Me.CmdSearch.Appearance.Options.UseForeColor = True
        Me.CmdSearch.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdSearch.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdSearch.Location = New System.Drawing.Point(558, 565)
        Me.CmdSearch.TabIndex = 32
        '
        'CmdCopy
        '
        Me.CmdCopy.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCopy.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdCopy.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdCopy.Appearance.Options.UseBackColor = True
        Me.CmdCopy.Appearance.Options.UseFont = True
        Me.CmdCopy.Appearance.Options.UseForeColor = True
        Me.CmdCopy.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdCopy.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdCopy.Location = New System.Drawing.Point(399, 565)
        Me.CmdCopy.TabIndex = 30
        '
        'CmdDelete
        '
        Me.CmdDelete.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdDelete.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdDelete.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdDelete.Appearance.Options.UseBackColor = True
        Me.CmdDelete.Appearance.Options.UseFont = True
        Me.CmdDelete.Appearance.Options.UseForeColor = True
        Me.CmdDelete.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdDelete.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdDelete.Location = New System.Drawing.Point(319, 565)
        Me.CmdDelete.TabIndex = 29
        '
        'CmdPrint
        '
        Me.CmdPrint.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPrint.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdPrint.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdPrint.Appearance.Options.UseBackColor = True
        Me.CmdPrint.Appearance.Options.UseFont = True
        Me.CmdPrint.Appearance.Options.UseForeColor = True
        Me.CmdPrint.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdPrint.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdPrint.Location = New System.Drawing.Point(159, 565)
        Me.CmdPrint.TabIndex = 27
        '
        'CmdNew
        '
        Me.CmdNew.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdNew.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdNew.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdNew.Appearance.Options.UseBackColor = True
        Me.CmdNew.Appearance.Options.UseFont = True
        Me.CmdNew.Appearance.Options.UseForeColor = True
        Me.CmdNew.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdNew.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdNew.Location = New System.Drawing.Point(79, 565)
        Me.CmdNew.TabIndex = 26
        '
        'CmdCancel
        '
        Me.CmdCancel.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdCancel.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdCancel.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdCancel.Appearance.Options.UseBackColor = True
        Me.CmdCancel.Appearance.Options.UseFont = True
        Me.CmdCancel.Appearance.Options.UseForeColor = True
        Me.CmdCancel.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdCancel.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdCancel.Location = New System.Drawing.Point(239, 565)
        Me.CmdCancel.TabIndex = 28
        '
        'CmdPhan_Bo
        '
        Me.CmdPhan_Bo.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.CmdPhan_Bo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.CmdPhan_Bo.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.CmdPhan_Bo.Appearance.Options.UseBackColor = True
        Me.CmdPhan_Bo.Appearance.Options.UseFont = True
        Me.CmdPhan_Bo.Appearance.Options.UseForeColor = True
        Me.CmdPhan_Bo.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CmdPhan_Bo.AppearanceDisabled.Options.UseForeColor = True
        Me.CmdPhan_Bo.Location = New System.Drawing.Point(922, 564)
        Me.CmdPhan_Bo.TabIndex = 37
        '
        'TxtUser_id
        '
        Me.TxtUser_id.Location = New System.Drawing.Point(633, 518)
        '
        'CbbMa_GD
        '
        Me.CbbMa_GD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbMa_GD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbbMa_GD.ForeColor = System.Drawing.Color.Navy
        Me.CbbMa_GD.FormattingEnabled = True
        Me.CbbMa_GD.Location = New System.Drawing.Point(271, 33)
        Me.CbbMa_GD.Name = "CbbMa_GD"
        Me.CbbMa_GD.Size = New System.Drawing.Size(133, 23)
        Me.CbbMa_GD.TabIndex = 2
        '
        'LabNgay_LCt
        '
        Me.LabNgay_LCt.AutoSize = True
        Me.LabNgay_LCt.BackColor = System.Drawing.Color.Transparent
        Me.LabNgay_LCt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LabNgay_LCt.ForeColor = System.Drawing.Color.Navy
        Me.LabNgay_LCt.Location = New System.Drawing.Point(12, 38)
        Me.LabNgay_LCt.Name = "LabNgay_LCt"
        Me.LabNgay_LCt.Size = New System.Drawing.Size(52, 13)
        Me.LabNgay_LCt.TabIndex = 144
        Me.LabNgay_LCt.Tag = "Create date"
        Me.LabNgay_LCt.Text = "Ngày Lập"
        '
        'LabNgay_Ct
        '
        Me.LabNgay_Ct.AutoSize = True
        Me.LabNgay_Ct.BackColor = System.Drawing.Color.Transparent
        Me.LabNgay_Ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LabNgay_Ct.ForeColor = System.Drawing.Color.Navy
        Me.LabNgay_Ct.Location = New System.Drawing.Point(12, 60)
        Me.LabNgay_Ct.Name = "LabNgay_Ct"
        Me.LabNgay_Ct.Size = New System.Drawing.Size(55, 13)
        Me.LabNgay_Ct.TabIndex = 143
        Me.LabNgay_Ct.Tag = "Voucher date"
        Me.LabNgay_Ct.Text = "Ngày c.từ"
        '
        'txtDien_giai
        '
        Me.txtDien_giai.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDien_giai.BackColor = System.Drawing.Color.White
        Me.txtDien_giai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDien_giai.ForeColor = System.Drawing.Color.Navy
        Me.txtDien_giai.Location = New System.Drawing.Point(96, 157)
        Me.txtDien_giai.Name = "txtDien_giai"
        Me.txtDien_giai.Size = New System.Drawing.Size(507, 20)
        Me.txtDien_giai.TabIndex = 24
        '
        'lblLoai_ct
        '
        Me.lblLoai_ct.AutoSize = True
        Me.lblLoai_ct.BackColor = System.Drawing.Color.Transparent
        Me.lblLoai_ct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoai_ct.ForeColor = System.Drawing.Color.Navy
        Me.lblLoai_ct.Location = New System.Drawing.Point(203, 37)
        Me.lblLoai_ct.Margin = New System.Windows.Forms.Padding(0)
        Me.lblLoai_ct.Name = "lblLoai_ct"
        Me.lblLoai_ct.Size = New System.Drawing.Size(65, 15)
        Me.lblLoai_ct.TabIndex = 138
        Me.lblLoai_ct.Tag = "Voucher style"
        Me.lblLoai_ct.Text = "Loại phiếu"
        '
        'lblSo_ct
        '
        Me.lblSo_ct.AutoSize = True
        Me.lblSo_ct.BackColor = System.Drawing.Color.Transparent
        Me.lblSo_ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblSo_ct.ForeColor = System.Drawing.Color.Navy
        Me.lblSo_ct.Location = New System.Drawing.Point(203, 60)
        Me.lblSo_ct.Name = "lblSo_ct"
        Me.lblSo_ct.Size = New System.Drawing.Size(48, 13)
        Me.lblSo_ct.TabIndex = 135
        Me.lblSo_ct.Tag = "Voucher no."
        Me.lblSo_ct.Text = "Số phiếu"
        '
        'txtSo_ct
        '
        Me.txtSo_ct.BackColor = System.Drawing.Color.White
        Me.txtSo_ct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSo_ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtSo_ct.ForeColor = System.Drawing.Color.Navy
        Me.txtSo_ct.Location = New System.Drawing.Point(271, 56)
        Me.txtSo_ct.Name = "txtSo_ct"
        Me.txtSo_ct.Size = New System.Drawing.Size(133, 21)
        Me.txtSo_ct.TabIndex = 3
        Me.txtSo_ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabMa_kh
        '
        Me.LabMa_kh.AutoSize = True
        Me.LabMa_kh.BackColor = System.Drawing.Color.Transparent
        Me.LabMa_kh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabMa_kh.ForeColor = System.Drawing.Color.Navy
        Me.LabMa_kh.Location = New System.Drawing.Point(12, 117)
        Me.LabMa_kh.Margin = New System.Windows.Forms.Padding(0)
        Me.LabMa_kh.Name = "LabMa_kh"
        Me.LabMa_kh.Size = New System.Drawing.Size(53, 13)
        Me.LabMa_kh.TabIndex = 133
        Me.LabMa_kh.Tag = "Cus code"
        Me.LabMa_kh.Text = "Đối tượng"
        '
        'TxtNgay_LCt
        '
        Me.TxtNgay_LCt.BackColor = System.Drawing.Color.White
        Me.TxtNgay_LCt.Flags = 65536
        Me.TxtNgay_LCt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_LCt.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_LCt.isEmpty = True
        Me.TxtNgay_LCt.Location = New System.Drawing.Point(96, 34)
        Me.TxtNgay_LCt.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_LCt.MaxLength = 10
        Me.TxtNgay_LCt.Name = "TxtNgay_LCt"
        Me.TxtNgay_LCt.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_LCt.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_LCt.ReadOnly = True
        Me.TxtNgay_LCt.ShowDayBeforeMonth = False
        Me.TxtNgay_LCt.Size = New System.Drawing.Size(107, 21)
        Me.TxtNgay_LCt.TabIndex = 0
        Me.TxtNgay_LCt.Text = "18/09/2011"
        Me.TxtNgay_LCt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_LCt.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'TxtNgay_Ct
        '
        Me.TxtNgay_Ct.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Ct.Flags = 65536
        Me.TxtNgay_Ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_Ct.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_Ct.isEmpty = True
        Me.TxtNgay_Ct.Location = New System.Drawing.Point(96, 56)
        Me.TxtNgay_Ct.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Ct.MaxLength = 10
        Me.TxtNgay_Ct.Name = "TxtNgay_Ct"
        Me.TxtNgay_Ct.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Ct.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Ct.ReadOnly = True
        Me.TxtNgay_Ct.ShowDayBeforeMonth = False
        Me.TxtNgay_Ct.Size = New System.Drawing.Size(107, 21)
        Me.TxtNgay_Ct.TabIndex = 1
        Me.TxtNgay_Ct.Text = "18/09/2011"
        Me.TxtNgay_Ct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Ct.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxLine.Location = New System.Drawing.Point(9, 85)
        Me.GroupBoxLine.Name = "GroupBoxLine"
        Me.GroupBoxLine.Size = New System.Drawing.Size(1055, 2)
        Me.GroupBoxLine.TabIndex = 156
        Me.GroupBoxLine.TabStop = False
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMa_Dvcs.BackColor = System.Drawing.Color.White
        Me.TxtMa_Dvcs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Dvcs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_Dvcs.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(1041, 570)
        Me.TxtMa_Dvcs.Name = "TxtMa_Dvcs"
        Me.TxtMa_Dvcs.Size = New System.Drawing.Size(21, 21)
        Me.TxtMa_Dvcs.TabIndex = 161
        Me.TxtMa_Dvcs.TabStop = False
        Me.TxtMa_Dvcs.Visible = False
        '
        'TxtStt_Rec
        '
        Me.TxtStt_Rec.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtStt_Rec.BackColor = System.Drawing.Color.White
        Me.TxtStt_Rec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtStt_Rec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStt_Rec.ForeColor = System.Drawing.Color.Navy
        Me.TxtStt_Rec.Location = New System.Drawing.Point(1014, 570)
        Me.TxtStt_Rec.Name = "TxtStt_Rec"
        Me.TxtStt_Rec.Size = New System.Drawing.Size(21, 21)
        Me.TxtStt_Rec.TabIndex = 162
        Me.TxtStt_Rec.TabStop = False
        Me.TxtStt_Rec.Visible = False
        '
        'PopupMenuMasterGrid
        '
        Me.PopupMenuMasterGrid.Name = "PopupMenuMasterGrid"
        '
        'LabLenh_RO
        '
        Me.LabLenh_RO.AutoSize = True
        Me.LabLenh_RO.BackColor = System.Drawing.Color.Transparent
        Me.LabLenh_RO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabLenh_RO.ForeColor = System.Drawing.Color.Navy
        Me.LabLenh_RO.Location = New System.Drawing.Point(12, 96)
        Me.LabLenh_RO.Name = "LabLenh_RO"
        Me.LabLenh_RO.Size = New System.Drawing.Size(46, 13)
        Me.LabLenh_RO.TabIndex = 169
        Me.LabLenh_RO.Tag = "R/O"
        Me.LabLenh_RO.Text = "Số R/O"
        '
        'TxtMa_Xe
        '
        Me.TxtMa_Xe.BackColor = System.Drawing.Color.White
        Me.TxtMa_Xe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Xe.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Xe.Location = New System.Drawing.Point(271, 92)
        Me.TxtMa_Xe.Name = "TxtMa_Xe"
        Me.TxtMa_Xe.ReadOnly = True
        Me.TxtMa_Xe.Size = New System.Drawing.Size(133, 20)
        Me.TxtMa_Xe.TabIndex = 11
        Me.TxtMa_Xe.TabStop = False
        Me.TxtMa_Xe.Tag = ""
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(1096, 262)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 1772
        Me.Label13.Tag = "Good group"
        Me.Label13.Text = "Nhóm hàng"
        Me.Label13.Visible = False
        '
        'TxtTen_vtthue
        '
        Me.TxtTen_vtthue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTen_vtthue.BackColor = System.Drawing.Color.White
        Me.TxtTen_vtthue.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_vtthue.Location = New System.Drawing.Point(1184, 258)
        Me.TxtTen_vtthue.Name = "TxtTen_vtthue"
        Me.TxtTen_vtthue.Size = New System.Drawing.Size(368, 20)
        Me.TxtTen_vtthue.TabIndex = 1769
        Me.TxtTen_vtthue.Tag = ""
        Me.TxtTen_vtthue.Visible = False
        '
        'LblDien_Giai
        '
        Me.LblDien_Giai.AutoSize = True
        Me.LblDien_Giai.ForeColor = System.Drawing.Color.Navy
        Me.LblDien_Giai.Location = New System.Drawing.Point(12, 161)
        Me.LblDien_Giai.Margin = New System.Windows.Forms.Padding(0)
        Me.LblDien_Giai.Name = "LblDien_Giai"
        Me.LblDien_Giai.Size = New System.Drawing.Size(48, 13)
        Me.LblDien_Giai.TabIndex = 1771
        Me.LblDien_Giai.Tag = "Explaination"
        Me.LblDien_Giai.Text = "Diễn giải"
        '
        'TxtTen_Hs_H
        '
        Me.TxtTen_Hs_H.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTen_Hs_H.BackColor = System.Drawing.Color.White
        Me.TxtTen_Hs_H.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_Hs_H.Location = New System.Drawing.Point(206, 202)
        Me.TxtTen_Hs_H.Name = "TxtTen_Hs_H"
        Me.TxtTen_Hs_H.ReadOnly = True
        Me.TxtTen_Hs_H.Size = New System.Drawing.Size(397, 20)
        Me.TxtTen_Hs_H.TabIndex = 1776
        Me.TxtTen_Hs_H.TabStop = False
        Me.TxtTen_Hs_H.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 208)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1777
        Me.Label1.Tag = "Employee"
        Me.Label1.Text = "CVDV"
        '
        'TxtMa_Hs_H
        '
        Me.TxtMa_Hs_H._ActilookupPopup = False
        Me.TxtMa_Hs_H.CyberActilookupPopup = True
        Me.TxtMa_Hs_H.Dv_ListDetail = Nothing
        Me.TxtMa_Hs_H.Dv_Master = Nothing
        Me.TxtMa_Hs_H.FilterClient = ""
        Me.TxtMa_Hs_H.FilterSQL = ""
        Me.TxtMa_Hs_H.Location = New System.Drawing.Point(96, 201)
        Me.TxtMa_Hs_H.Name = "TxtMa_Hs_H"
        Me.TxtMa_Hs_H.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtMa_Hs_H.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Hs_H.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_Hs_H.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Hs_H.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TxtMa_Hs_H.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Hs_H.Size = New System.Drawing.Size(107, 22)
        Me.TxtMa_Hs_H.TabIndex = 20
        Me.TxtMa_Hs_H.Table_Name = ""
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Navy
        Me.Label21.Location = New System.Drawing.Point(265, 525)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(59, 13)
        Me.Label21.TabIndex = 1831
        Me.Label21.Tag = "Tax"
        Me.Label21.Text = "Thuế công"
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Navy
        Me.Label22.Location = New System.Drawing.Point(265, 504)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(55, 13)
        Me.Label22.TabIndex = 1830
        Me.Label22.Tag = "Jobs"
        Me.Label22.Text = "Tiền công"
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.Location = New System.Drawing.Point(265, 546)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 1829
        Me.Label23.Tag = "Total"
        Me.Label23.Text = "Tổng tiền "
        '
        'TxtT_Tong_Hang
        '
        Me.TxtT_Tong_Hang.AllowNegative = True
        Me.TxtT_Tong_Hang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tong_Hang.BackColor = System.Drawing.Color.White
        Me.TxtT_Tong_Hang.Flags = 7680
        Me.TxtT_Tong_Hang.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_Tong_Hang.ForeColor = System.Drawing.Color.Blue
        Me.TxtT_Tong_Hang.InputMask = "### ### ### ### ###"
        Me.TxtT_Tong_Hang.Location = New System.Drawing.Point(554, 542)
        Me.TxtT_Tong_Hang.MaxWholeDigits = 14
        Me.TxtT_Tong_Hang.Name = "TxtT_Tong_Hang"
        Me.TxtT_Tong_Hang.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tong_Hang.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tong_Hang.ReadOnly = True
        Me.TxtT_Tong_Hang.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Tong_Hang.TabIndex = 1825
        Me.TxtT_Tong_Hang.TabStop = False
        Me.TxtT_Tong_Hang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtT_Tien_Hang
        '
        Me.TxtT_Tien_Hang.AllowNegative = True
        Me.TxtT_Tien_Hang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_Hang.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_Hang.Flags = 7680
        Me.TxtT_Tien_Hang.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_Hang.InputMask = "### ### ### ### ###"
        Me.TxtT_Tien_Hang.Location = New System.Drawing.Point(554, 500)
        Me.TxtT_Tien_Hang.MaxWholeDigits = 14
        Me.TxtT_Tien_Hang.Name = "TxtT_Tien_Hang"
        Me.TxtT_Tien_Hang.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_Hang.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_Hang.ReadOnly = True
        Me.TxtT_Tien_Hang.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Tien_Hang.TabIndex = 1823
        Me.TxtT_Tien_Hang.TabStop = False
        Me.TxtT_Tien_Hang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtT_Thue_hang
        '
        Me.TxtT_Thue_hang.AllowNegative = True
        Me.TxtT_Thue_hang.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Thue_hang.BackColor = System.Drawing.Color.White
        Me.TxtT_Thue_hang.Flags = 7680
        Me.TxtT_Thue_hang.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Thue_hang.InputMask = "### ### ### ### ###"
        Me.TxtT_Thue_hang.Location = New System.Drawing.Point(554, 521)
        Me.TxtT_Thue_hang.MaxWholeDigits = 14
        Me.TxtT_Thue_hang.Name = "TxtT_Thue_hang"
        Me.TxtT_Thue_hang.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Thue_hang.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Thue_hang.ReadOnly = True
        Me.TxtT_Thue_hang.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Thue_hang.TabIndex = 1822
        Me.TxtT_Thue_hang.TabStop = False
        Me.TxtT_Thue_hang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(965, 528)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 1818
        Me.Label12.Tag = "Days"
        Me.Label12.Text = "Ngày"
        Me.Label12.Visible = False
        '
        'TxtHan_TT
        '
        Me.TxtHan_TT.AllowNegative = True
        Me.TxtHan_TT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtHan_TT.BackColor = System.Drawing.Color.White
        Me.TxtHan_TT.Flags = 7680
        Me.TxtHan_TT.ForeColor = System.Drawing.Color.Navy
        Me.TxtHan_TT.InputMask = "## ###"
        Me.TxtHan_TT.Location = New System.Drawing.Point(946, 528)
        Me.TxtHan_TT.MaxWholeDigits = 4
        Me.TxtHan_TT.Name = "TxtHan_TT"
        Me.TxtHan_TT.RangeMax = 1.7976931348623157E+308R
        Me.TxtHan_TT.RangeMin = -1.7976931348623157E+308R
        Me.TxtHan_TT.ReadOnly = True
        Me.TxtHan_TT.Size = New System.Drawing.Size(89, 20)
        Me.TxtHan_TT.TabIndex = 1808
        Me.TxtHan_TT.Text = "0"
        Me.TxtHan_TT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtHan_TT.Visible = False
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(965, 529)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 1817
        Me.Label11.Tag = "P.date"
        Me.Label11.Text = "Hạn TT"
        Me.Label11.Visible = False
        '
        'TxtT_Tien_Nt2
        '
        Me.TxtT_Tien_Nt2.AllowNegative = True
        Me.TxtT_Tien_Nt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_Nt2.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_Nt2.Flags = 7680
        Me.TxtT_Tien_Nt2.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_Nt2.InputMask = "### ### ### ### ###"
        Me.TxtT_Tien_Nt2.Location = New System.Drawing.Point(753, 500)
        Me.TxtT_Tien_Nt2.MaxWholeDigits = 14
        Me.TxtT_Tien_Nt2.Name = "TxtT_Tien_Nt2"
        Me.TxtT_Tien_Nt2.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_Nt2.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_Nt2.ReadOnly = True
        Me.TxtT_Tien_Nt2.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Tien_Nt2.TabIndex = 1816
        Me.TxtT_Tien_Nt2.TabStop = False
        Me.TxtT_Tien_Nt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(685, 525)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 1815
        Me.Label3.Tag = "Total tax"
        Me.Label3.Text = "Tổng thuế"
        '
        'TxtT_Thue_Nt
        '
        Me.TxtT_Thue_Nt.AllowNegative = True
        Me.TxtT_Thue_Nt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Thue_Nt.BackColor = System.Drawing.Color.White
        Me.TxtT_Thue_Nt.Flags = 7680
        Me.TxtT_Thue_Nt.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Thue_Nt.InputMask = "### ### ### ### ###"
        Me.TxtT_Thue_Nt.Location = New System.Drawing.Point(753, 521)
        Me.TxtT_Thue_Nt.MaxWholeDigits = 14
        Me.TxtT_Thue_Nt.Name = "TxtT_Thue_Nt"
        Me.TxtT_Thue_Nt.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Thue_Nt.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Thue_Nt.ReadOnly = True
        Me.TxtT_Thue_Nt.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Thue_Nt.TabIndex = 1814
        Me.TxtT_Thue_Nt.TabStop = False
        Me.TxtT_Thue_Nt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(685, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 1813
        Me.Label2.Tag = "Total"
        Me.Label2.Text = "Tổng tiền"
        '
        'LblTong_Cong
        '
        Me.LblTong_Cong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblTong_Cong.AutoSize = True
        Me.LblTong_Cong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTong_Cong.ForeColor = System.Drawing.Color.Blue
        Me.LblTong_Cong.Location = New System.Drawing.Point(685, 546)
        Me.LblTong_Cong.Name = "LblTong_Cong"
        Me.LblTong_Cong.Size = New System.Drawing.Size(68, 13)
        Me.LblTong_Cong.TabIndex = 1812
        Me.LblTong_Cong.Tag = "Total"
        Me.LblTong_Cong.Text = "Tổng cộng"
        '
        'TxtT_TT_NT
        '
        Me.TxtT_TT_NT.AllowNegative = True
        Me.TxtT_TT_NT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_TT_NT.BackColor = System.Drawing.Color.White
        Me.TxtT_TT_NT.Flags = 7680
        Me.TxtT_TT_NT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_TT_NT.ForeColor = System.Drawing.Color.Blue
        Me.TxtT_TT_NT.InputMask = "### ### ### ### ###"
        Me.TxtT_TT_NT.Location = New System.Drawing.Point(753, 542)
        Me.TxtT_TT_NT.MaxWholeDigits = 14
        Me.TxtT_TT_NT.Name = "TxtT_TT_NT"
        Me.TxtT_TT_NT.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_TT_NT.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_TT_NT.ReadOnly = True
        Me.TxtT_TT_NT.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_TT_NT.TabIndex = 1811
        Me.TxtT_TT_NT.TabStop = False
        Me.TxtT_TT_NT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Navy
        Me.Label18.Location = New System.Drawing.Point(485, 525)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 1828
        Me.Label18.Tag = "Tax"
        Me.Label18.Text = "Thuế VTPT"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Navy
        Me.Label19.Location = New System.Drawing.Point(486, 504)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 1827
        Me.Label19.Tag = "Parts"
        Me.Label19.Text = "Tiền VTPT"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(485, 546)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 1826
        Me.Label20.Tag = "Total"
        Me.Label20.Text = "Tổng tiền"
        '
        'TabHDK
        '
        Me.TabHDK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabHDK.Controls.Add(Me.TabPage1)
        Me.TabHDK.Controls.Add(Me.TabCv)
        Me.TabHDK.Location = New System.Drawing.Point(2, 243)
        Me.TabHDK.Name = "TabHDK"
        Me.TabHDK.SelectedIndex = 0
        Me.TabHDK.Size = New System.Drawing.Size(1069, 250)
        Me.TabHDK.TabIndex = 1833
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Detail)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1061, 224)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Tag = "Parts"
        Me.TabPage1.Text = "Vật tư phụ tùng"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Detail
        '
        Me.Detail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Detail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Detail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Detail.Location = New System.Drawing.Point(3, 3)
        Me.Detail.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.Detail.MainView = Me.DetailGRV
        Me.Detail.Name = "Detail"
        Me.Detail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit5, Me.RepositoryItemTextEdit6})
        Me.Detail.Size = New System.Drawing.Size(1055, 218)
        Me.Detail.TabIndex = 9
        Me.Detail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRV})
        '
        'DetailGRV
        '
        Me.DetailGRV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRV.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRV.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRV.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRV.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRV.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRV.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRV.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRV.GridControl = Me.Detail
        Me.DetailGRV.GroupRowHeight = 30
        Me.DetailGRV.Name = "DetailGRV"
        Me.DetailGRV.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRV.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRV.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRV.OptionsView.ColumnAutoWidth = False
        Me.DetailGRV.OptionsView.ShowGroupPanel = False
        Me.DetailGRV.RowHeight = 21
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.AutoHeight = False
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        '
        'RepositoryItemTextEdit6
        '
        Me.RepositoryItemTextEdit6.AutoHeight = False
        Me.RepositoryItemTextEdit6.Name = "RepositoryItemTextEdit6"
        '
        'TabCv
        '
        Me.TabCv.Controls.Add(Me.DetailCv)
        Me.TabCv.Location = New System.Drawing.Point(4, 22)
        Me.TabCv.Name = "TabCv"
        Me.TabCv.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCv.Size = New System.Drawing.Size(1061, 224)
        Me.TabCv.TabIndex = 1
        Me.TabCv.Tag = "Jobs"
        Me.TabCv.Text = "Công việc"
        Me.TabCv.UseVisualStyleBackColor = True
        '
        'DetailCv
        '
        Me.DetailCv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.DetailCv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailCv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailCv.Location = New System.Drawing.Point(3, 3)
        Me.DetailCv.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.DetailCv.MainView = Me.DetailGRVCv
        Me.DetailCv.Name = "DetailCv"
        Me.DetailCv.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3, Me.RepositoryItemTextEdit4})
        Me.DetailCv.Size = New System.Drawing.Size(1055, 218)
        Me.DetailCv.TabIndex = 0
        Me.DetailCv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.DetailGRVCv})
        '
        'DetailGRVCv
        '
        Me.DetailGRVCv.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DetailGRVCv.Appearance.FocusedRow.Options.UseBackColor = True
        Me.DetailGRVCv.Appearance.SelectedRow.BackColor = System.Drawing.Color.Red
        Me.DetailGRVCv.Appearance.SelectedRow.Options.UseBackColor = True
        Me.DetailGRVCv.Appearance.ViewCaption.Options.UseTextOptions = True
        Me.DetailGRVCv.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DetailGRVCv.Appearance.ViewCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DetailGRVCv.Appearance.ViewCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap
        Me.DetailGRVCv.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DetailGRVCv.AppearancePrint.EvenRow.Options.UseFont = True
        Me.DetailGRVCv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D
        Me.DetailGRVCv.CustomizationFormBounds = New System.Drawing.Rectangle(907, 465, 210, 172)
        Me.DetailGRVCv.GridControl = Me.DetailCv
        Me.DetailGRVCv.GroupRowHeight = 30
        Me.DetailGRVCv.Name = "DetailGRVCv"
        Me.DetailGRVCv.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.DetailGRVCv.OptionsLayout.Columns.AddNewColumns = False
        Me.DetailGRVCv.OptionsSelection.CheckBoxSelectorColumnWidth = 20
        Me.DetailGRVCv.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.DetailGRVCv.OptionsView.ColumnAutoWidth = False
        Me.DetailGRVCv.OptionsView.ShowGroupPanel = False
        Me.DetailGRVCv.RowHeight = 21
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.AutoHeight = False
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        '
        'TxtLenh_RO
        '
        Me.TxtLenh_RO.BackColor = System.Drawing.Color.White
        Me.TxtLenh_RO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLenh_RO.ForeColor = System.Drawing.Color.Navy
        Me.TxtLenh_RO.Location = New System.Drawing.Point(96, 92)
        Me.TxtLenh_RO.Name = "TxtLenh_RO"
        Me.TxtLenh_RO.Size = New System.Drawing.Size(107, 20)
        Me.TxtLenh_RO.TabIndex = 9
        Me.TxtLenh_RO.Tag = ""
        Me.TxtLenh_RO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtT_Tien2
        '
        Me.TxtT_Tien2.AllowNegative = True
        Me.TxtT_Tien2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien2.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien2.Enabled = False
        Me.TxtT_Tien2.Flags = 7680
        Me.TxtT_Tien2.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien2.InputMask = "## ### ### ### ###"
        Me.TxtT_Tien2.Location = New System.Drawing.Point(983, 0)
        Me.TxtT_Tien2.MaxWholeDigits = 13
        Me.TxtT_Tien2.Name = "TxtT_Tien2"
        Me.TxtT_Tien2.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien2.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien2.ReadOnly = True
        Me.TxtT_Tien2.Size = New System.Drawing.Size(47, 20)
        Me.TxtT_Tien2.TabIndex = 1844
        Me.TxtT_Tien2.Text = "0"
        Me.TxtT_Tien2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Tien2.Visible = False
        '
        'TxtT_Thue
        '
        Me.TxtT_Thue.AllowNegative = True
        Me.TxtT_Thue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Thue.BackColor = System.Drawing.Color.White
        Me.TxtT_Thue.Enabled = False
        Me.TxtT_Thue.Flags = 7680
        Me.TxtT_Thue.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Thue.InputMask = "## ### ### ### ###"
        Me.TxtT_Thue.Location = New System.Drawing.Point(946, 528)
        Me.TxtT_Thue.MaxWholeDigits = 13
        Me.TxtT_Thue.Name = "TxtT_Thue"
        Me.TxtT_Thue.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Thue.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Thue.ReadOnly = True
        Me.TxtT_Thue.Size = New System.Drawing.Size(37, 20)
        Me.TxtT_Thue.TabIndex = 1845
        Me.TxtT_Thue.Text = "0"
        Me.TxtT_Thue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_Thue.Visible = False
        '
        'TxtT_TT
        '
        Me.TxtT_TT.AllowNegative = True
        Me.TxtT_TT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtT_TT.BackColor = System.Drawing.Color.White
        Me.TxtT_TT.Enabled = False
        Me.TxtT_TT.Flags = 7680
        Me.TxtT_TT.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_TT.InputMask = "## ### ### ### ###"
        Me.TxtT_TT.Location = New System.Drawing.Point(946, 528)
        Me.TxtT_TT.MaxWholeDigits = 13
        Me.TxtT_TT.Name = "TxtT_TT"
        Me.TxtT_TT.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_TT.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_TT.ReadOnly = True
        Me.TxtT_TT.Size = New System.Drawing.Size(31, 20)
        Me.TxtT_TT.TabIndex = 1846
        Me.TxtT_TT.Text = "0"
        Me.TxtT_TT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtT_TT.Visible = False
        '
        'TxtTen_kh
        '
        Me.TxtTen_kh.BackColor = System.Drawing.Color.White
        Me.TxtTen_kh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtTen_kh.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_kh.Location = New System.Drawing.Point(96, 115)
        Me.TxtTen_kh.Name = "TxtTen_kh"
        Me.TxtTen_kh.ReadOnly = True
        Me.TxtTen_kh.Size = New System.Drawing.Size(507, 20)
        Me.TxtTen_kh.TabIndex = 1848
        Me.TxtTen_kh.TabStop = False
        '
        'TxtDia_Chi
        '
        Me.TxtDia_Chi.BackColor = System.Drawing.Color.White
        Me.TxtDia_Chi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtDia_Chi.ForeColor = System.Drawing.Color.Navy
        Me.TxtDia_Chi.Location = New System.Drawing.Point(96, 136)
        Me.TxtDia_Chi.Name = "TxtDia_Chi"
        Me.TxtDia_Chi.Size = New System.Drawing.Size(507, 20)
        Me.TxtDia_Chi.TabIndex = 13
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label15.ForeColor = System.Drawing.Color.Navy
        Me.Label15.Location = New System.Drawing.Point(13, 139)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 13)
        Me.Label15.TabIndex = 1850
        Me.Label15.Tag = "Address"
        Me.Label15.Text = "Địa chỉ"
        '
        'txtTen_BP_H
        '
        Me.txtTen_BP_H.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTen_BP_H.BackColor = System.Drawing.Color.White
        Me.txtTen_BP_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtTen_BP_H.ForeColor = System.Drawing.Color.Navy
        Me.txtTen_BP_H.Location = New System.Drawing.Point(206, 180)
        Me.txtTen_BP_H.Name = "txtTen_BP_H"
        Me.txtTen_BP_H.ReadOnly = True
        Me.txtTen_BP_H.Size = New System.Drawing.Size(397, 20)
        Me.txtTen_BP_H.TabIndex = 1853
        Me.txtTen_BP_H.TabStop = False
        '
        'TxtMa_Bp_H
        '
        Me.TxtMa_Bp_H._ActilookupPopup = False
        Me.TxtMa_Bp_H.CyberActilookupPopup = True
        Me.TxtMa_Bp_H.Dv_ListDetail = Nothing
        Me.TxtMa_Bp_H.Dv_Master = Nothing
        Me.TxtMa_Bp_H.FilterClient = ""
        Me.TxtMa_Bp_H.FilterSQL = ""
        Me.TxtMa_Bp_H.Location = New System.Drawing.Point(96, 180)
        Me.TxtMa_Bp_H.Name = "TxtMa_Bp_H"
        Me.TxtMa_Bp_H.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtMa_Bp_H.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Bp_H.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_Bp_H.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Bp_H.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.TxtMa_Bp_H.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.TxtMa_Bp_H.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Bp_H.Size = New System.Drawing.Size(107, 20)
        Me.TxtMa_Bp_H.TabIndex = 19
        Me.TxtMa_Bp_H.Table_Name = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(12, 183)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 14)
        Me.Label5.TabIndex = 1852
        Me.Label5.Tag = "Department"
        Me.Label5.Text = "Bộ phận"
        '
        'ChkSua_Thue
        '
        Me.ChkSua_Thue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkSua_Thue.AutoSize = True
        Me.ChkSua_Thue.Location = New System.Drawing.Point(946, 528)
        Me.ChkSua_Thue.Name = "ChkSua_Thue"
        Me.ChkSua_Thue.Size = New System.Drawing.Size(89, 17)
        Me.ChkSua_Thue.TabIndex = 1859
        Me.ChkSua_Thue.Tag = "Change tax"
        Me.ChkSua_Thue.Text = "Sửa tiền thuế"
        Me.ChkSua_Thue.UseVisualStyleBackColor = True
        Me.ChkSua_Thue.Visible = False
        '
        'cmdXac_nhan_I
        '
        Me.cmdXac_nhan_I.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdXac_nhan_I.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdXac_nhan_I.ForeColor = System.Drawing.Color.Blue
        Me.cmdXac_nhan_I.Location = New System.Drawing.Point(717, 565)
        Me.cmdXac_nhan_I.Name = "cmdXac_nhan_I"
        Me.cmdXac_nhan_I.Size = New System.Drawing.Size(85, 32)
        Me.cmdXac_nhan_I.TabIndex = 34
        Me.cmdXac_nhan_I.TabStop = False
        Me.cmdXac_nhan_I.Tag = "Insurance"
        Me.cmdXac_nhan_I.Text = "X.nhận b.hiểm"
        Me.cmdXac_nhan_I.UseVisualStyleBackColor = True
        Me.cmdXac_nhan_I.Visible = False
        '
        'CmdXe_Ra
        '
        Me.CmdXe_Ra.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdXe_Ra.Location = New System.Drawing.Point(804, 565)
        Me.CmdXe_Ra.Name = "CmdXe_Ra"
        Me.CmdXe_Ra.Size = New System.Drawing.Size(87, 32)
        Me.CmdXe_Ra.TabIndex = 35
        Me.CmdXe_Ra.Tag = "Car-out"
        Me.CmdXe_Ra.Text = "Xe  ra"
        Me.CmdXe_Ra.UseVisualStyleBackColor = True
        Me.CmdXe_Ra.Visible = False
        '
        'CmdHuy_HD
        '
        Me.CmdHuy_HD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdHuy_HD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdHuy_HD.ForeColor = System.Drawing.Color.Red
        Me.CmdHuy_HD.Location = New System.Drawing.Point(896, 564)
        Me.CmdHuy_HD.Name = "CmdHuy_HD"
        Me.CmdHuy_HD.Size = New System.Drawing.Size(87, 32)
        Me.CmdHuy_HD.TabIndex = 2116
        Me.CmdHuy_HD.Tag = "Cancellation"
        Me.CmdHuy_HD.Text = "Hủy HĐ"
        Me.CmdHuy_HD.UseVisualStyleBackColor = True
        Me.CmdHuy_HD.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(203, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 1765
        Me.Label4.Tag = "Car Id"
        Me.Label4.Text = "Biển số"
        '
        'TxtMa_NT
        '
        Me.TxtMa_NT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMa_NT.BackColor = System.Drawing.Color.White
        Me.TxtMa_NT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_NT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_NT.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_NT.Location = New System.Drawing.Point(849, 58)
        Me.TxtMa_NT.Name = "TxtMa_NT"
        Me.TxtMa_NT.Size = New System.Drawing.Size(32, 21)
        Me.TxtMa_NT.TabIndex = 7
        Me.TxtMa_NT.TabStop = False
        Me.TxtMa_NT.Visible = False
        '
        'TxtLenh_PO
        '
        Me.TxtLenh_PO.BackColor = System.Drawing.Color.White
        Me.TxtLenh_PO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLenh_PO.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtLenh_PO.ForeColor = System.Drawing.Color.Navy
        Me.TxtLenh_PO.Location = New System.Drawing.Point(849, 58)
        Me.TxtLenh_PO.Name = "TxtLenh_PO"
        Me.TxtLenh_PO.Size = New System.Drawing.Size(32, 21)
        Me.TxtLenh_PO.TabIndex = 5
        Me.TxtLenh_PO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtLenh_PO.Visible = False
        '
        'TxtLenh_SO
        '
        Me.TxtLenh_SO.BackColor = System.Drawing.Color.White
        Me.TxtLenh_SO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLenh_SO.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtLenh_SO.ForeColor = System.Drawing.Color.Navy
        Me.TxtLenh_SO.Location = New System.Drawing.Point(849, 58)
        Me.TxtLenh_SO.Name = "TxtLenh_SO"
        Me.TxtLenh_SO.Size = New System.Drawing.Size(32, 21)
        Me.TxtLenh_SO.TabIndex = 6
        Me.TxtLenh_SO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtLenh_SO.Visible = False
        '
        'TxtLenh_Vt
        '
        Me.TxtLenh_Vt.BackColor = System.Drawing.Color.White
        Me.TxtLenh_Vt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLenh_Vt.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtLenh_Vt.ForeColor = System.Drawing.Color.Navy
        Me.TxtLenh_Vt.Location = New System.Drawing.Point(849, 58)
        Me.TxtLenh_Vt.Name = "TxtLenh_Vt"
        Me.TxtLenh_Vt.Size = New System.Drawing.Size(32, 21)
        Me.TxtLenh_Vt.TabIndex = 250
        Me.TxtLenh_Vt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtLenh_Vt.Visible = False
        '
        'TxtTy_Gia
        '
        Me.TxtTy_Gia.AllowNegative = True
        Me.TxtTy_Gia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTy_Gia.BackColor = System.Drawing.Color.White
        Me.TxtTy_Gia.Flags = 7680
        Me.TxtTy_Gia.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtTy_Gia.ForeColor = System.Drawing.Color.Navy
        Me.TxtTy_Gia.InputMask = "## ### ###.##"
        Me.TxtTy_Gia.Location = New System.Drawing.Point(849, 58)
        Me.TxtTy_Gia.MaxWholeDigits = 10
        Me.TxtTy_Gia.Name = "TxtTy_Gia"
        Me.TxtTy_Gia.RangeMax = 1.7976931348623157E+308R
        Me.TxtTy_Gia.RangeMin = -1.7976931348623157E+308R
        Me.TxtTy_Gia.ReadOnly = True
        Me.TxtTy_Gia.Size = New System.Drawing.Size(32, 21)
        Me.TxtTy_Gia.TabIndex = 8
        Me.TxtTy_Gia.Text = "22 500.01"
        Me.TxtTy_Gia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtTy_Gia.Visible = False
        '
        'TxtMa_Quyen
        '
        Me.TxtMa_Quyen.BackColor = System.Drawing.Color.White
        Me.TxtMa_Quyen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Quyen.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtMa_Quyen.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Quyen.Location = New System.Drawing.Point(849, 58)
        Me.TxtMa_Quyen.Name = "TxtMa_Quyen"
        Me.TxtMa_Quyen.Size = New System.Drawing.Size(32, 21)
        Me.TxtMa_Quyen.TabIndex = 4
        Me.TxtMa_Quyen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtMa_Quyen.Visible = False
        '
        'TxtT_Tong_Cong
        '
        Me.TxtT_Tong_Cong.AllowNegative = True
        Me.TxtT_Tong_Cong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tong_Cong.BackColor = System.Drawing.Color.White
        Me.TxtT_Tong_Cong.Flags = 7680
        Me.TxtT_Tong_Cong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtT_Tong_Cong.ForeColor = System.Drawing.Color.Blue
        Me.TxtT_Tong_Cong.InputMask = "### ### ### ### ###"
        Me.TxtT_Tong_Cong.Location = New System.Drawing.Point(348, 542)
        Me.TxtT_Tong_Cong.MaxWholeDigits = 14
        Me.TxtT_Tong_Cong.Name = "TxtT_Tong_Cong"
        Me.TxtT_Tong_Cong.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tong_Cong.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tong_Cong.ReadOnly = True
        Me.TxtT_Tong_Cong.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Tong_Cong.TabIndex = 1824
        Me.TxtT_Tong_Cong.TabStop = False
        Me.TxtT_Tong_Cong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtT_Thue_Cong
        '
        Me.TxtT_Thue_Cong.AllowNegative = True
        Me.TxtT_Thue_Cong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Thue_Cong.BackColor = System.Drawing.Color.White
        Me.TxtT_Thue_Cong.Flags = 7680
        Me.TxtT_Thue_Cong.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Thue_Cong.InputMask = "### ### ### ### ###"
        Me.TxtT_Thue_Cong.Location = New System.Drawing.Point(348, 521)
        Me.TxtT_Thue_Cong.MaxWholeDigits = 14
        Me.TxtT_Thue_Cong.Name = "TxtT_Thue_Cong"
        Me.TxtT_Thue_Cong.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Thue_Cong.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Thue_Cong.ReadOnly = True
        Me.TxtT_Thue_Cong.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Thue_Cong.TabIndex = 1820
        Me.TxtT_Thue_Cong.TabStop = False
        Me.TxtT_Thue_Cong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtT_Tien_Cong
        '
        Me.TxtT_Tien_Cong.AllowNegative = True
        Me.TxtT_Tien_Cong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtT_Tien_Cong.BackColor = System.Drawing.Color.White
        Me.TxtT_Tien_Cong.Flags = 7680
        Me.TxtT_Tien_Cong.ForeColor = System.Drawing.Color.Navy
        Me.TxtT_Tien_Cong.InputMask = "### ### ### ### ###"
        Me.TxtT_Tien_Cong.Location = New System.Drawing.Point(348, 500)
        Me.TxtT_Tien_Cong.MaxWholeDigits = 14
        Me.TxtT_Tien_Cong.Name = "TxtT_Tien_Cong"
        Me.TxtT_Tien_Cong.RangeMax = 1.7976931348623157E+308R
        Me.TxtT_Tien_Cong.RangeMin = -1.7976931348623157E+308R
        Me.TxtT_Tien_Cong.ReadOnly = True
        Me.TxtT_Tien_Cong.Size = New System.Drawing.Size(124, 20)
        Me.TxtT_Tien_Cong.TabIndex = 1821
        Me.TxtT_Tien_Cong.TabStop = False
        Me.TxtT_Tien_Cong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtGio_Dn
        '
        Me.TxtGio_Dn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGio_Dn.BackColor = System.Drawing.Color.White
        Me.TxtGio_Dn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGio_Dn.ForeColor = System.Drawing.Color.Blue
        Me.TxtGio_Dn.Location = New System.Drawing.Point(940, 164)
        Me.TxtGio_Dn.Name = "TxtGio_Dn"
        Me.TxtGio_Dn.ReadOnly = True
        Me.TxtGio_Dn.Size = New System.Drawing.Size(51, 22)
        Me.TxtGio_Dn.TabIndex = 2119
        Me.TxtGio_Dn.TabStop = False
        Me.TxtGio_Dn.Tag = ""
        Me.TxtGio_Dn.Text = "24:30"
        Me.TxtGio_Dn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNgay_Dn
        '
        Me.TxtNgay_Dn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNgay_Dn.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Dn.Flags = 65536
        Me.TxtNgay_Dn.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNgay_Dn.ForeColor = System.Drawing.Color.Blue
        Me.TxtNgay_Dn.isEmpty = True
        Me.TxtNgay_Dn.Location = New System.Drawing.Point(849, 164)
        Me.TxtNgay_Dn.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Dn.MaxLength = 10
        Me.TxtNgay_Dn.Name = "TxtNgay_Dn"
        Me.TxtNgay_Dn.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Dn.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Dn.ReadOnly = True
        Me.TxtNgay_Dn.ShowDayBeforeMonth = False
        Me.TxtNgay_Dn.Size = New System.Drawing.Size(87, 22)
        Me.TxtNgay_Dn.TabIndex = 2118
        Me.TxtNgay_Dn.TabStop = False
        Me.TxtNgay_Dn.Text = "18/09/2011"
        Me.TxtNgay_Dn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Dn.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'CmdDe_Nghi
        '
        Me.CmdDe_Nghi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdDe_Nghi.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDe_Nghi.Appearance.Options.UseFont = True
        Me.CmdDe_Nghi.AutoSize = True
        Me.CmdDe_Nghi.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.CmdDe_Nghi.Image = CType(resources.GetObject("CmdDe_Nghi.Image"), System.Drawing.Image)
        Me.CmdDe_Nghi.Location = New System.Drawing.Point(701, 156)
        Me.CmdDe_Nghi.Name = "CmdDe_Nghi"
        Me.CmdDe_Nghi.Size = New System.Drawing.Size(140, 38)
        Me.CmdDe_Nghi.TabIndex = 2120
        Me.CmdDe_Nghi.TabStop = False
        Me.CmdDe_Nghi.Text = "Đề nghị xuất kho"
        '
        'BttDelIsCv
        '
        Me.BttDelIsCv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BttDelIsCv.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BttDelIsCv.Appearance.Options.UseFont = True
        Me.BttDelIsCv.AutoSize = True
        Me.BttDelIsCv.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.BttDelIsCv.Image = CType(resources.GetObject("BttDelIsCv.Image"), System.Drawing.Image)
        Me.BttDelIsCv.Location = New System.Drawing.Point(890, 500)
        Me.BttDelIsCv.Name = "BttDelIsCv"
        Me.BttDelIsCv.Size = New System.Drawing.Size(143, 22)
        Me.BttDelIsCv.TabIndex = 2120
        Me.BttDelIsCv.TabStop = False
        Me.BttDelIsCv.Text = "Lọc công việc còn nợ"
        '
        'LabMa_TTCP_H
        '
        Me.LabMa_TTCP_H.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabMa_TTCP_H.BackColor = System.Drawing.SystemColors.Control
        Me.LabMa_TTCP_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabMa_TTCP_H.ForeColor = System.Drawing.Color.Navy
        Me.LabMa_TTCP_H.Location = New System.Drawing.Point(716, 35)
        Me.LabMa_TTCP_H.Margin = New System.Windows.Forms.Padding(0)
        Me.LabMa_TTCP_H.Name = "LabMa_TTCP_H"
        Me.LabMa_TTCP_H.Size = New System.Drawing.Size(144, 17)
        Me.LabMa_TTCP_H.TabIndex = 2167
        Me.LabMa_TTCP_H.Tag = "Cost centrer"
        Me.LabMa_TTCP_H.Text = "TTCP"
        Me.LabMa_TTCP_H.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LabMa_TTCP_H.Visible = False
        '
        'CbbMa_TTCP_H
        '
        Me.CbbMa_TTCP_H.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbbMa_TTCP_H.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbMa_TTCP_H.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbbMa_TTCP_H.ForeColor = System.Drawing.Color.Navy
        Me.CbbMa_TTCP_H.FormattingEnabled = True
        Me.CbbMa_TTCP_H.Location = New System.Drawing.Point(862, 33)
        Me.CbbMa_TTCP_H.Name = "CbbMa_TTCP_H"
        Me.CbbMa_TTCP_H.Size = New System.Drawing.Size(205, 23)
        Me.CbbMa_TTCP_H.TabIndex = 2166
        Me.CbbMa_TTCP_H.TabStop = False
        Me.CbbMa_TTCP_H.Visible = False
        '
        'HPT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1074, 621)
        Me.Controls.Add(Me.LabMa_TTCP_H)
        Me.Controls.Add(Me.CbbMa_TTCP_H)
        Me.Controls.Add(Me.BttDelIsCv)
        Me.Controls.Add(Me.CmdDe_Nghi)
        Me.Controls.Add(Me.TxtGio_Dn)
        Me.Controls.Add(Me.TxtNgay_Dn)
        Me.Controls.Add(Me.CmdHuy_HD)
        Me.Controls.Add(Me.CmdXe_Ra)
        Me.Controls.Add(Me.cmdXac_nhan_I)
        Me.Controls.Add(Me.ChkSua_Thue)
        Me.Controls.Add(Me.txtTen_BP_H)
        Me.Controls.Add(Me.TxtMa_Bp_H)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtTen_kh)
        Me.Controls.Add(Me.TxtDia_Chi)
        Me.Controls.Add(Me.TxtT_TT)
        Me.Controls.Add(Me.TxtT_Thue)
        Me.Controls.Add(Me.TxtT_Tien2)
        Me.Controls.Add(Me.TxtLenh_RO)
        Me.Controls.Add(Me.TabHDK)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.TxtT_Tong_Hang)
        Me.Controls.Add(Me.TxtT_Tong_Cong)
        Me.Controls.Add(Me.TxtT_Tien_Hang)
        Me.Controls.Add(Me.TxtT_Thue_hang)
        Me.Controls.Add(Me.TxtT_Tien_Cong)
        Me.Controls.Add(Me.TxtT_Thue_Cong)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtHan_TT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtT_Tien_Nt2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtT_Thue_Nt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblTong_Cong)
        Me.Controls.Add(Me.TxtT_TT_NT)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TxtMa_Hs_H)
        Me.Controls.Add(Me.TxtTen_Hs_H)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblDien_Giai)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMa_Xe)
        Me.Controls.Add(Me.TxtLenh_Vt)
        Me.Controls.Add(Me.TxtLenh_SO)
        Me.Controls.Add(Me.TxtLenh_PO)
        Me.Controls.Add(Me.LabLenh_RO)
        Me.Controls.Add(Me.GroupBoxLine)
        Me.Controls.Add(Me.TxtMa_NT)
        Me.Controls.Add(Me.TxtTy_Gia)
        Me.Controls.Add(Me.TxtNgay_LCt)
        Me.Controls.Add(Me.TxtNgay_Ct)
        Me.Controls.Add(Me.CbbMa_GD)
        Me.Controls.Add(Me.TxtMa_Quyen)
        Me.Controls.Add(Me.LabNgay_LCt)
        Me.Controls.Add(Me.LabNgay_Ct)
        Me.Controls.Add(Me.txtDien_giai)
        Me.Controls.Add(Me.lblLoai_ct)
        Me.Controls.Add(Me.lblSo_ct)
        Me.Controls.Add(Me.txtSo_ct)
        Me.Controls.Add(Me.LabMa_kh)
        Me.Controls.Add(Me.TxtStt_Rec)
        Me.Controls.Add(Me.TxtMa_Dvcs)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtTen_vtthue)
        Me.KeyPreview = True
        Me.Name = "HPT"
        Me.Text = "     "
        Me.Controls.SetChildIndex(Me.TxtTen_vtthue, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.TxtStt_Rec, 0)
        Me.Controls.SetChildIndex(Me.LabMa_kh, 0)
        Me.Controls.SetChildIndex(Me.txtSo_ct, 0)
        Me.Controls.SetChildIndex(Me.lblSo_ct, 0)
        Me.Controls.SetChildIndex(Me.lblLoai_ct, 0)
        Me.Controls.SetChildIndex(Me.txtDien_giai, 0)
        Me.Controls.SetChildIndex(Me.LabNgay_Ct, 0)
        Me.Controls.SetChildIndex(Me.LabNgay_LCt, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Quyen, 0)
        Me.Controls.SetChildIndex(Me.CbbMa_GD, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Ct, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_LCt, 0)
        Me.Controls.SetChildIndex(Me.TxtTy_Gia, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_NT, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.LabLenh_RO, 0)
        Me.Controls.SetChildIndex(Me.TxtLenh_PO, 0)
        Me.Controls.SetChildIndex(Me.TxtLenh_SO, 0)
        Me.Controls.SetChildIndex(Me.TxtLenh_Vt, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Xe, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.LblDien_Giai, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_Hs_H, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Hs_H, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.TxtT_TT_NT, 0)
        Me.Controls.SetChildIndex(Me.LblTong_Cong, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Thue_Nt, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien_Nt2, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.TxtHan_TT, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Thue_Cong, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien_Cong, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Thue_hang, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien_Hang, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tong_Cong, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tong_Hang, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.TabHDK, 0)
        Me.Controls.SetChildIndex(Me.TxtLenh_RO, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Tien2, 0)
        Me.Controls.SetChildIndex(Me.TxtT_Thue, 0)
        Me.Controls.SetChildIndex(Me.TxtT_TT, 0)
        Me.Controls.SetChildIndex(Me.TxtDia_Chi, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_kh, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Bp_H, 0)
        Me.Controls.SetChildIndex(Me.txtTen_BP_H, 0)
        Me.Controls.SetChildIndex(Me.ChkSua_Thue, 0)
        Me.Controls.SetChildIndex(Me.cmdXac_nhan_I, 0)
        Me.Controls.SetChildIndex(Me.CmdXe_Ra, 0)
        Me.Controls.SetChildIndex(Me.CmdHuy_HD, 0)
        Me.Controls.SetChildIndex(Me.TxtUser_id, 0)
        Me.Controls.SetChildIndex(Me.CmdPhan_Bo, 0)
        Me.Controls.SetChildIndex(Me.CmdNew, 0)
        Me.Controls.SetChildIndex(Me.CmdSave, 0)
        Me.Controls.SetChildIndex(Me.CmdPrint, 0)
        Me.Controls.SetChildIndex(Me.CmdEdit, 0)
        Me.Controls.SetChildIndex(Me.CmdCancel, 0)
        Me.Controls.SetChildIndex(Me.CmdDelete, 0)
        Me.Controls.SetChildIndex(Me.CmdCopy, 0)
        Me.Controls.SetChildIndex(Me.CmdSearch, 0)
        Me.Controls.SetChildIndex(Me.CmdExit, 0)
        Me.Controls.SetChildIndex(Me.CbbMa_Post, 0)
        Me.Controls.SetChildIndex(Me.CmdImport, 0)
        Me.Controls.SetChildIndex(Me.CmdSms, 0)
        Me.Controls.SetChildIndex(Me.LabMa_Post, 0)
        Me.Controls.SetChildIndex(Me.CmdView, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Dn, 0)
        Me.Controls.SetChildIndex(Me.TxtGio_Dn, 0)
        Me.Controls.SetChildIndex(Me.CmdDe_Nghi, 0)
        Me.Controls.SetChildIndex(Me.BttDelIsCv, 0)
        Me.Controls.SetChildIndex(Me.CbbMa_TTCP_H, 0)
        Me.Controls.SetChildIndex(Me.LabMa_TTCP_H, 0)
        CType(Me.PopupMenuMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenuMasterGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Hs_H.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabHDK.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Detail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCv.ResumeLayout(False)
        CType(Me.DetailCv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetailGRVCv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMa_Bp_H.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbbMa_GD As System.Windows.Forms.ComboBox
    Friend WithEvents LabNgay_LCt As System.Windows.Forms.Label
    Friend WithEvents LabNgay_Ct As System.Windows.Forms.Label
    Friend WithEvents txtDien_giai As System.Windows.Forms.TextBox
    Friend WithEvents lblLoai_ct As System.Windows.Forms.Label
    Friend WithEvents lblSo_ct As System.Windows.Forms.Label
    Friend WithEvents txtSo_ct As System.Windows.Forms.TextBox
    Friend WithEvents LabMa_kh As System.Windows.Forms.Label
    Friend WithEvents TxtNgay_LCt As ClsTextBox.txtDate
    Friend WithEvents TxtNgay_Ct As ClsTextBox.txtDate
    Friend WithEvents GroupBoxLine As System.Windows.Forms.GroupBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents TxtMa_Dvcs As System.Windows.Forms.TextBox
    Friend WithEvents TxtStt_Rec As System.Windows.Forms.TextBox
    Friend WithEvents PopupMenuMasterGrid As DevExpress.XtraBars.PopupMenu
    Friend WithEvents LabLenh_RO As System.Windows.Forms.Label
    Friend WithEvents TxtMa_Xe As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_vtthue As System.Windows.Forms.TextBox
    Friend WithEvents LblDien_Giai As System.Windows.Forms.Label
    Friend WithEvents TxtTen_Hs_H As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtMa_Hs_H As Cyber.SmLists.TxtLookup
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtT_Tong_Hang As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien_Hang As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Thue_hang As ClsTextBox.txtTien_NT
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtHan_TT As ClsTextBox.txtSo_luong
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtT_Tien_Nt2 As ClsTextBox.txtTien_NT
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtT_Thue_Nt As ClsTextBox.txtTien_NT
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTong_Cong As System.Windows.Forms.Label
    Friend WithEvents TxtT_TT_NT As ClsTextBox.txtTien_NT
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TabHDK As System.Windows.Forms.TabControl
    Friend WithEvents TabCv As System.Windows.Forms.TabPage
    Friend WithEvents DetailCv As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRVCv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Detail As DevExpress.XtraGrid.GridControl
    Friend WithEvents DetailGRV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TxtLenh_RO As System.Windows.Forms.TextBox
    Friend WithEvents TxtT_Tien2 As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Thue As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_TT As ClsTextBox.txtTien_NT
    Friend WithEvents TxtTen_kh As System.Windows.Forms.TextBox
    Friend WithEvents TxtDia_Chi As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTen_BP_H As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Bp_H As Cyber.SmLists.TxtLookup
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkSua_Thue As System.Windows.Forms.CheckBox
    Public WithEvents cmdXac_nhan_I As System.Windows.Forms.Button
    Friend WithEvents CmdXe_Ra As System.Windows.Forms.Button
    Friend WithEvents CmdHuy_HD As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMa_NT As System.Windows.Forms.TextBox
    Friend WithEvents TxtLenh_PO As System.Windows.Forms.TextBox
    Friend WithEvents TxtLenh_SO As System.Windows.Forms.TextBox
    Friend WithEvents TxtLenh_Vt As System.Windows.Forms.TextBox
    Friend WithEvents TxtTy_Gia As ClsTextBox.txtTy_Gia
    Friend WithEvents TxtMa_Quyen As System.Windows.Forms.TextBox
    Friend WithEvents TxtT_Tong_Cong As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Thue_Cong As ClsTextBox.txtTien_NT
    Friend WithEvents TxtT_Tien_Cong As ClsTextBox.txtTien_NT
    Friend WithEvents TxtGio_Dn As System.Windows.Forms.TextBox
    Friend WithEvents TxtNgay_Dn As ClsTextBox.txtDate
    Friend WithEvents CmdDe_Nghi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BttDelIsCv As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabMa_TTCP_H As Label
    Friend WithEvents CbbMa_TTCP_H As ComboBox
End Class

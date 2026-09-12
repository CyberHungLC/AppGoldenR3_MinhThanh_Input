<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRMNghiemThu
    Inherits Cyber.From.FrmCalculator

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtGio_NT = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TxtNgay_NT = New ClsTextBox.txtDate()
        Me.TxtGhi_Chu = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TxtND_Hen = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChkIs_Hen = New System.Windows.Forms.CheckBox()
        Me.LabSo_km_Hen = New System.Windows.Forms.Label()
        Me.TxtSo_km_Hen = New ClsTextBox.txtTien_NT()
        Me.Chkthu = New System.Windows.Forms.CheckBox()
        Me.ChkDT = New System.Windows.Forms.CheckBox()
        Me.Chkkhong = New System.Windows.Forms.CheckBox()
        Me.Txtngay_Hen = New ClsTextBox.txtDate()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TxtMa_So_Thue = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.TxtDia_ChiVAT = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TxtTen_kh = New System.Windows.Forms.TextBox()
        Me.LabDia_Chi = New System.Windows.Forms.Label()
        Me.TxtDia_Chi = New System.Windows.Forms.TextBox()
        Me.LabMa_kh = New System.Windows.Forms.Label()
        Me.TxtTen_khVAT = New System.Windows.Forms.TextBox()
        Me.TxtMa_Kh = New Cyber.SmLists.TxtLookup()
        Me.TxtTen_LX = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDT_LX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtE_mail = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtFax = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDien_Thoai = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.TxtMa_Kh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 276)
        Me.GroupBoxLine.Size = New System.Drawing.Size(602, 8)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(402, 286)
        Me.ButtOK.TabIndex = 16
        Me.ButtOK.Tag = "&Acceptance"
        Me.ButtOK.Text = "&Nghiệm thu"
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(504, 286)
        Me.ButtExit.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(210, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 18)
        Me.Label1.TabIndex = 280
        Me.Label1.Tag = "Time"
        Me.Label1.Text = "Giờ"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtGio_NT
        '
        Me.TxtGio_NT.BackColor = System.Drawing.Color.White
        Me.TxtGio_NT.Enabled = False
        Me.TxtGio_NT.ForeColor = System.Drawing.Color.Navy
        Me.TxtGio_NT.Location = New System.Drawing.Point(241, 8)
        Me.TxtGio_NT.MaxLength = 4
        Me.TxtGio_NT.Name = "TxtGio_NT"
        Me.TxtGio_NT.Size = New System.Drawing.Size(81, 20)
        Me.TxtGio_NT.TabIndex = 1
        Me.TxtGio_NT.Tag = ""
        Me.TxtGio_NT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label33
        '
        Me.Label33.ForeColor = System.Drawing.Color.Navy
        Me.Label33.Location = New System.Drawing.Point(8, 8)
        Me.Label33.Margin = New System.Windows.Forms.Padding(0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(89, 18)
        Me.Label33.TabIndex = 279
        Me.Label33.Tag = "Acceptance date"
        Me.Label33.Text = "Ngày nghiệm thu"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtNgay_NT
        '
        Me.TxtNgay_NT.BackColor = System.Drawing.Color.White
        Me.TxtNgay_NT.Flags = 65536
        Me.TxtNgay_NT.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_NT.isEmpty = True
        Me.TxtNgay_NT.Location = New System.Drawing.Point(101, 8)
        Me.TxtNgay_NT.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_NT.MaxLength = 10
        Me.TxtNgay_NT.Name = "TxtNgay_NT"
        Me.TxtNgay_NT.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_NT.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_NT.ShowDayBeforeMonth = False
        Me.TxtNgay_NT.Size = New System.Drawing.Size(108, 20)
        Me.TxtNgay_NT.TabIndex = 0
        Me.TxtNgay_NT.Text = "18/09/2011"
        Me.TxtNgay_NT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_NT.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'TxtGhi_Chu
        '
        Me.TxtGhi_Chu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtGhi_Chu.BackColor = System.Drawing.Color.White
        Me.TxtGhi_Chu.ForeColor = System.Drawing.Color.Navy
        Me.TxtGhi_Chu.Location = New System.Drawing.Point(101, 199)
        Me.TxtGhi_Chu.Name = "TxtGhi_Chu"
        Me.TxtGhi_Chu.Size = New System.Drawing.Size(501, 20)
        Me.TxtGhi_Chu.TabIndex = 8
        Me.TxtGhi_Chu.Tag = ""
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.Navy
        Me.Label30.Location = New System.Drawing.Point(8, 201)
        Me.Label30.Margin = New System.Windows.Forms.Padding(0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 13)
        Me.Label30.TabIndex = 1913
        Me.Label30.Tag = "Note"
        Me.Label30.Text = "Ghi chú"
        '
        'TxtND_Hen
        '
        Me.TxtND_Hen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtND_Hen.BackColor = System.Drawing.Color.White
        Me.TxtND_Hen.ForeColor = System.Drawing.Color.Navy
        Me.TxtND_Hen.Location = New System.Drawing.Point(101, 223)
        Me.TxtND_Hen.Name = "TxtND_Hen"
        Me.TxtND_Hen.Size = New System.Drawing.Size(501, 20)
        Me.TxtND_Hen.TabIndex = 9
        Me.TxtND_Hen.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(8, 225)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 1916
        Me.Label5.Tag = "Booking content"
        Me.Label5.Text = "Nội dung hẹn"
        '
        'ChkIs_Hen
        '
        Me.ChkIs_Hen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkIs_Hen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkIs_Hen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChkIs_Hen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ChkIs_Hen.Location = New System.Drawing.Point(11, 252)
        Me.ChkIs_Hen.Name = "ChkIs_Hen"
        Me.ChkIs_Hen.Size = New System.Drawing.Size(87, 18)
        Me.ChkIs_Hen.TabIndex = 10
        Me.ChkIs_Hen.Tag = "Booking war"
        Me.ChkIs_Hen.Text = "Hẹn BD"
        Me.ChkIs_Hen.UseVisualStyleBackColor = True
        '
        'LabSo_km_Hen
        '
        Me.LabSo_km_Hen.AutoSize = True
        Me.LabSo_km_Hen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabSo_km_Hen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabSo_km_Hen.Location = New System.Drawing.Point(192, 253)
        Me.LabSo_km_Hen.Margin = New System.Windows.Forms.Padding(0)
        Me.LabSo_km_Hen.Name = "LabSo_km_Hen"
        Me.LabSo_km_Hen.Size = New System.Drawing.Size(57, 13)
        Me.LabSo_km_Hen.TabIndex = 2028
        Me.LabSo_km_Hen.Tag = "Or km"
        Me.LabSo_km_Hen.Text = "Hoặc km"
        '
        'TxtSo_km_Hen
        '
        Me.TxtSo_km_Hen.AllowNegative = True
        Me.TxtSo_km_Hen.BackColor = System.Drawing.Color.White
        Me.TxtSo_km_Hen.Flags = 7680
        Me.TxtSo_km_Hen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSo_km_Hen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TxtSo_km_Hen.InputMask = "### ### ### ###"
        Me.TxtSo_km_Hen.Location = New System.Drawing.Point(257, 250)
        Me.TxtSo_km_Hen.MaxWholeDigits = 11
        Me.TxtSo_km_Hen.Name = "TxtSo_km_Hen"
        Me.TxtSo_km_Hen.RangeMax = 1.7976931348623157E+308R
        Me.TxtSo_km_Hen.RangeMin = -1.7976931348623157E+308R
        Me.TxtSo_km_Hen.Size = New System.Drawing.Size(84, 20)
        Me.TxtSo_km_Hen.TabIndex = 12
        Me.TxtSo_km_Hen.Text = "0"
        Me.TxtSo_km_Hen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Chkthu
        '
        Me.Chkthu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chkthu.AutoSize = True
        Me.Chkthu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chkthu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkthu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Chkthu.Location = New System.Drawing.Point(451, 253)
        Me.Chkthu.Name = "Chkthu"
        Me.Chkthu.Size = New System.Drawing.Size(48, 17)
        Me.Chkthu.TabIndex = 14
        Me.Chkthu.Tag = "Mail"
        Me.Chkthu.Text = "Thư"
        Me.Chkthu.UseVisualStyleBackColor = True
        '
        'ChkDT
        '
        Me.ChkDT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkDT.AutoSize = True
        Me.ChkDT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ChkDT.Location = New System.Drawing.Point(399, 253)
        Me.ChkDT.Name = "ChkDT"
        Me.ChkDT.Size = New System.Drawing.Size(43, 17)
        Me.ChkDT.TabIndex = 13
        Me.ChkDT.Tag = "Tel"
        Me.ChkDT.Text = "ĐT"
        Me.ChkDT.UseVisualStyleBackColor = True
        '
        'Chkkhong
        '
        Me.Chkkhong.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chkkhong.AutoSize = True
        Me.Chkkhong.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Chkkhong.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chkkhong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Chkkhong.Location = New System.Drawing.Point(517, 253)
        Me.Chkkhong.Name = "Chkkhong"
        Me.Chkkhong.Size = New System.Drawing.Size(87, 17)
        Me.Chkkhong.TabIndex = 15
        Me.Chkkhong.Tag = "None"
        Me.Chkkhong.Text = "Không cần"
        Me.Chkkhong.UseVisualStyleBackColor = True
        '
        'Txtngay_Hen
        '
        Me.Txtngay_Hen.BackColor = System.Drawing.Color.White
        Me.Txtngay_Hen.Flags = 65536
        Me.Txtngay_Hen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtngay_Hen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Txtngay_Hen.isEmpty = True
        Me.Txtngay_Hen.Location = New System.Drawing.Point(108, 250)
        Me.Txtngay_Hen.MaskDate = "dd/MM/yyyy"
        Me.Txtngay_Hen.MaxLength = 10
        Me.Txtngay_Hen.Name = "Txtngay_Hen"
        Me.Txtngay_Hen.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.Txtngay_Hen.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.Txtngay_Hen.ShowDayBeforeMonth = False
        Me.Txtngay_Hen.Size = New System.Drawing.Size(74, 20)
        Me.Txtngay_Hen.TabIndex = 11
        Me.Txtngay_Hen.Text = "18/09/2011"
        Me.Txtngay_Hen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txtngay_Hen.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'Label34
        '
        Me.Label34.ForeColor = System.Drawing.Color.Blue
        Me.Label34.Location = New System.Drawing.Point(8, 82)
        Me.Label34.Margin = New System.Windows.Forms.Padding(0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(75, 15)
        Me.Label34.TabIndex = 2038
        Me.Label34.Tag = "VAT name"
        Me.Label34.Text = "Tên VAT"
        '
        'TxtMa_So_Thue
        '
        Me.TxtMa_So_Thue.BackColor = System.Drawing.Color.White
        Me.TxtMa_So_Thue.ForeColor = System.Drawing.Color.Blue
        Me.TxtMa_So_Thue.Location = New System.Drawing.Point(101, 124)
        Me.TxtMa_So_Thue.Name = "TxtMa_So_Thue"
        Me.TxtMa_So_Thue.Size = New System.Drawing.Size(108, 20)
        Me.TxtMa_So_Thue.TabIndex = 7
        Me.TxtMa_So_Thue.Tag = ""
        Me.TxtMa_So_Thue.Text = "0101419580"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(8, 128)
        Me.Label36.Margin = New System.Windows.Forms.Padding(0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(60, 13)
        Me.Label36.TabIndex = 2037
        Me.Label36.Tag = "Tax Id"
        Me.Label36.Text = "Mã số thuế"
        '
        'TxtDia_ChiVAT
        '
        Me.TxtDia_ChiVAT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDia_ChiVAT.BackColor = System.Drawing.Color.White
        Me.TxtDia_ChiVAT.ForeColor = System.Drawing.Color.Blue
        Me.TxtDia_ChiVAT.Location = New System.Drawing.Point(101, 101)
        Me.TxtDia_ChiVAT.Name = "TxtDia_ChiVAT"
        Me.TxtDia_ChiVAT.Size = New System.Drawing.Size(501, 20)
        Me.TxtDia_ChiVAT.TabIndex = 6
        Me.TxtDia_ChiVAT.Tag = ""
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Blue
        Me.Label35.Location = New System.Drawing.Point(8, 105)
        Me.Label35.Margin = New System.Windows.Forms.Padding(0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(64, 13)
        Me.Label35.TabIndex = 2036
        Me.Label35.Tag = "Vat address "
        Me.Label35.Text = "Địa chỉ VAT"
        '
        'TxtTen_kh
        '
        Me.TxtTen_kh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTen_kh.BackColor = System.Drawing.Color.White
        Me.TxtTen_kh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTen_kh.ForeColor = System.Drawing.Color.Blue
        Me.TxtTen_kh.Location = New System.Drawing.Point(213, 31)
        Me.TxtTen_kh.Name = "TxtTen_kh"
        Me.TxtTen_kh.Size = New System.Drawing.Size(389, 22)
        Me.TxtTen_kh.TabIndex = 3
        Me.TxtTen_kh.TabStop = False
        '
        'LabDia_Chi
        '
        Me.LabDia_Chi.AutoSize = True
        Me.LabDia_Chi.BackColor = System.Drawing.Color.Transparent
        Me.LabDia_Chi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabDia_Chi.ForeColor = System.Drawing.Color.Blue
        Me.LabDia_Chi.Location = New System.Drawing.Point(8, 59)
        Me.LabDia_Chi.Margin = New System.Windows.Forms.Padding(0)
        Me.LabDia_Chi.Name = "LabDia_Chi"
        Me.LabDia_Chi.Size = New System.Drawing.Size(42, 14)
        Me.LabDia_Chi.TabIndex = 2035
        Me.LabDia_Chi.Tag = "Address"
        Me.LabDia_Chi.Text = "Địa chỉ"
        '
        'TxtDia_Chi
        '
        Me.TxtDia_Chi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDia_Chi.BackColor = System.Drawing.Color.White
        Me.TxtDia_Chi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDia_Chi.ForeColor = System.Drawing.Color.Blue
        Me.TxtDia_Chi.Location = New System.Drawing.Point(101, 55)
        Me.TxtDia_Chi.Name = "TxtDia_Chi"
        Me.TxtDia_Chi.ReadOnly = True
        Me.TxtDia_Chi.Size = New System.Drawing.Size(501, 22)
        Me.TxtDia_Chi.TabIndex = 4
        '
        'LabMa_kh
        '
        Me.LabMa_kh.AutoSize = True
        Me.LabMa_kh.BackColor = System.Drawing.Color.Transparent
        Me.LabMa_kh.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabMa_kh.ForeColor = System.Drawing.Color.Blue
        Me.LabMa_kh.Location = New System.Drawing.Point(8, 38)
        Me.LabMa_kh.Margin = New System.Windows.Forms.Padding(0)
        Me.LabMa_kh.Name = "LabMa_kh"
        Me.LabMa_kh.Size = New System.Drawing.Size(71, 14)
        Me.LabMa_kh.TabIndex = 2034
        Me.LabMa_kh.Tag = "Cus code"
        Me.LabMa_kh.Text = "Khách hàng"
        '
        'TxtTen_khVAT
        '
        Me.TxtTen_khVAT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtTen_khVAT.BackColor = System.Drawing.Color.White
        Me.TxtTen_khVAT.ForeColor = System.Drawing.Color.Blue
        Me.TxtTen_khVAT.Location = New System.Drawing.Point(101, 79)
        Me.TxtTen_khVAT.Name = "TxtTen_khVAT"
        Me.TxtTen_khVAT.Size = New System.Drawing.Size(501, 20)
        Me.TxtTen_khVAT.TabIndex = 5
        Me.TxtTen_khVAT.Tag = ""
        '
        'TxtMa_Kh
        '
        Me.TxtMa_Kh._ActilookupPopup = False
        Me.TxtMa_Kh.CyberActilookupPopup = True
        Me.TxtMa_Kh.Dv_ListDetail = Nothing
        Me.TxtMa_Kh.Dv_Master = Nothing
        Me.TxtMa_Kh.FilterClient = ""
        Me.TxtMa_Kh.FilterSQL = ""
        Me.TxtMa_Kh.Location = New System.Drawing.Point(101, 31)
        Me.TxtMa_Kh.Name = "TxtMa_Kh"
        Me.TxtMa_Kh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_Kh.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Kh.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_Kh.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_Kh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TxtMa_Kh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_Kh.Size = New System.Drawing.Size(108, 22)
        Me.TxtMa_Kh.TabIndex = 2
        Me.TxtMa_Kh.Table_Name = ""
        Me.TxtMa_Kh.Visible = False
        '
        'TxtTen_LX
        '
        Me.TxtTen_LX.BackColor = System.Drawing.Color.White
        Me.TxtTen_LX.ForeColor = System.Drawing.Color.Blue
        Me.TxtTen_LX.Location = New System.Drawing.Point(257, 124)
        Me.TxtTen_LX.Name = "TxtTen_LX"
        Me.TxtTen_LX.Size = New System.Drawing.Size(143, 20)
        Me.TxtTen_LX.TabIndex = 2040
        Me.TxtTen_LX.Tag = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(214, 129)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2041
        Me.Label2.Tag = "Tax Id"
        Me.Label2.Text = "Lái xe"
        '
        'TxtDT_LX
        '
        Me.TxtDT_LX.BackColor = System.Drawing.Color.White
        Me.TxtDT_LX.ForeColor = System.Drawing.Color.Blue
        Me.TxtDT_LX.Location = New System.Drawing.Point(458, 124)
        Me.TxtDT_LX.Name = "TxtDT_LX"
        Me.TxtDT_LX.Size = New System.Drawing.Size(144, 20)
        Me.TxtDT_LX.TabIndex = 2042
        Me.TxtDT_LX.Tag = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(404, 129)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 2043
        Me.Label3.Tag = "Tax Id"
        Me.Label3.Text = "Điện thoại"
        '
        'TxtE_mail
        '
        Me.TxtE_mail.BackColor = System.Drawing.Color.White
        Me.TxtE_mail.ForeColor = System.Drawing.Color.Blue
        Me.TxtE_mail.Location = New System.Drawing.Point(458, 148)
        Me.TxtE_mail.Name = "TxtE_mail"
        Me.TxtE_mail.Size = New System.Drawing.Size(144, 20)
        Me.TxtE_mail.TabIndex = 2048
        Me.TxtE_mail.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(404, 152)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 2049
        Me.Label4.Tag = "Tax Id"
        Me.Label4.Text = "Email"
        '
        'TxtFax
        '
        Me.TxtFax.BackColor = System.Drawing.Color.White
        Me.TxtFax.ForeColor = System.Drawing.Color.Blue
        Me.TxtFax.Location = New System.Drawing.Point(257, 148)
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(143, 20)
        Me.TxtFax.TabIndex = 2046
        Me.TxtFax.Tag = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(214, 152)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 2047
        Me.Label6.Tag = "Tax Id"
        Me.Label6.Text = "Fax"
        '
        'TxtDien_Thoai
        '
        Me.TxtDien_Thoai.BackColor = System.Drawing.Color.White
        Me.TxtDien_Thoai.ForeColor = System.Drawing.Color.Blue
        Me.TxtDien_Thoai.Location = New System.Drawing.Point(101, 147)
        Me.TxtDien_Thoai.Name = "TxtDien_Thoai"
        Me.TxtDien_Thoai.Size = New System.Drawing.Size(108, 20)
        Me.TxtDien_Thoai.TabIndex = 2044
        Me.TxtDien_Thoai.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(8, 151)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 2045
        Me.Label7.Tag = "Tax Id"
        Me.Label7.Text = "Điện thoại (KH)"
        '
        'TextBox6
        '
        Me.TextBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox6.BackColor = System.Drawing.Color.White
        Me.TextBox6.ForeColor = System.Drawing.Color.Blue
        Me.TextBox6.Location = New System.Drawing.Point(101, 174)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(501, 20)
        Me.TextBox6.TabIndex = 2050
        Me.TextBox6.Tag = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(8, 178)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 2051
        Me.Label8.Tag = "Vat address "
        Me.Label8.Text = "Địa chỉ VAT"
        '
        'FRMNghiemThu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(606, 340)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtE_mail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtFax)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDien_Thoai)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtDT_LX)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTen_LX)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtMa_Kh)
        Me.Controls.Add(Me.TxtTen_khVAT)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.TxtMa_So_Thue)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.TxtDia_ChiVAT)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.TxtTen_kh)
        Me.Controls.Add(Me.LabDia_Chi)
        Me.Controls.Add(Me.TxtDia_Chi)
        Me.Controls.Add(Me.LabMa_kh)
        Me.Controls.Add(Me.ChkIs_Hen)
        Me.Controls.Add(Me.LabSo_km_Hen)
        Me.Controls.Add(Me.TxtSo_km_Hen)
        Me.Controls.Add(Me.Chkthu)
        Me.Controls.Add(Me.ChkDT)
        Me.Controls.Add(Me.Chkkhong)
        Me.Controls.Add(Me.Txtngay_Hen)
        Me.Controls.Add(Me.TxtND_Hen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtGhi_Chu)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtGio_NT)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.TxtNgay_NT)
        Me.MinimizeBox = False
        Me.Name = "FRMNghiemThu"
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_NT, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.TxtGio_NT, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.TxtGhi_Chu, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtND_Hen, 0)
        Me.Controls.SetChildIndex(Me.Txtngay_Hen, 0)
        Me.Controls.SetChildIndex(Me.Chkkhong, 0)
        Me.Controls.SetChildIndex(Me.ChkDT, 0)
        Me.Controls.SetChildIndex(Me.Chkthu, 0)
        Me.Controls.SetChildIndex(Me.TxtSo_km_Hen, 0)
        Me.Controls.SetChildIndex(Me.LabSo_km_Hen, 0)
        Me.Controls.SetChildIndex(Me.ChkIs_Hen, 0)
        Me.Controls.SetChildIndex(Me.LabMa_kh, 0)
        Me.Controls.SetChildIndex(Me.TxtDia_Chi, 0)
        Me.Controls.SetChildIndex(Me.LabDia_Chi, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_kh, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.TxtDia_ChiVAT, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_So_Thue, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_khVAT, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Kh, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_LX, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtDT_LX, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtDien_Thoai, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtE_mail, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TextBox6, 0)
        CType(Me.TxtMa_Kh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGio_NT As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtNgay_NT As ClsTextBox.txtDate
    Friend WithEvents TxtGhi_Chu As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtND_Hen As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ChkIs_Hen As System.Windows.Forms.CheckBox
    Friend WithEvents LabSo_km_Hen As System.Windows.Forms.Label
    Friend WithEvents TxtSo_km_Hen As ClsTextBox.txtTien_NT
    Friend WithEvents Chkthu As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDT As System.Windows.Forms.CheckBox
    Friend WithEvents Chkkhong As System.Windows.Forms.CheckBox
    Friend WithEvents Txtngay_Hen As ClsTextBox.txtDate
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtMa_So_Thue As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TxtDia_ChiVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TxtTen_kh As System.Windows.Forms.TextBox
    Friend WithEvents LabDia_Chi As System.Windows.Forms.Label
    Friend WithEvents TxtDia_Chi As System.Windows.Forms.TextBox
    Friend WithEvents LabMa_kh As System.Windows.Forms.Label
    Friend WithEvents TxtTen_khVAT As System.Windows.Forms.TextBox
    Friend WithEvents TxtMa_Kh As Cyber.SmLists.TxtLookup
    Friend WithEvents TxtTen_LX As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDT_LX As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtE_mail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDien_Thoai As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class

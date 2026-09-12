<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTTDC
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
        Me.TxtSo_CT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtLy_Do = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNgay_Huy = New ClsTextBox.txtDate()
        Me.LabNgay_Ct = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtStt_rec_TT = New System.Windows.Forms.TextBox()
        Me.txtSo_ct_tt = New Cyber.SmLists.TxtLookup()
        Me.TxtSo_SeriHD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtMau_VatHD = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtLoai_HD = New System.Windows.Forms.TextBox()
        CType(Me.txtSo_ct_tt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 103)
        Me.GroupBoxLine.Size = New System.Drawing.Size(505, 8)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(305, 113)
        Me.ButtOK.TabIndex = 4
        Me.ButtOK.Text = "&Chấp nhận"
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(407, 113)
        Me.ButtExit.TabIndex = 5
        '
        'TxtSo_CT
        '
        Me.TxtSo_CT.BackColor = System.Drawing.Color.White
        Me.TxtSo_CT.ForeColor = System.Drawing.Color.Navy
        Me.TxtSo_CT.Location = New System.Drawing.Point(108, 58)
        Me.TxtSo_CT.Name = "TxtSo_CT"
        Me.TxtSo_CT.Size = New System.Drawing.Size(143, 20)
        Me.TxtSo_CT.TabIndex = 1
        Me.TxtSo_CT.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(5, 61)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 1916
        Me.Label5.Tag = "Explaination"
        Me.Label5.Text = "Số văn bản "
        '
        'TxtLy_Do
        '
        Me.TxtLy_Do.BackColor = System.Drawing.Color.White
        Me.TxtLy_Do.ForeColor = System.Drawing.Color.Navy
        Me.TxtLy_Do.Location = New System.Drawing.Point(108, 80)
        Me.TxtLy_Do.Name = "TxtLy_Do"
        Me.TxtLy_Do.Size = New System.Drawing.Size(399, 20)
        Me.TxtLy_Do.TabIndex = 3
        Me.TxtLy_Do.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(5, 83)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 1918
        Me.Label1.Tag = "Explaination"
        Me.Label1.Text = "Lý do "
        '
        'TxtNgay_Huy
        '
        Me.TxtNgay_Huy.BackColor = System.Drawing.Color.White
        Me.TxtNgay_Huy.Flags = 65536
        Me.TxtNgay_Huy.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtNgay_Huy.ForeColor = System.Drawing.Color.Navy
        Me.TxtNgay_Huy.isEmpty = True
        Me.TxtNgay_Huy.Location = New System.Drawing.Point(374, 57)
        Me.TxtNgay_Huy.MaskDate = "dd/MM/yyyy"
        Me.TxtNgay_Huy.MaxLength = 10
        Me.TxtNgay_Huy.Name = "TxtNgay_Huy"
        Me.TxtNgay_Huy.RangeMax = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.TxtNgay_Huy.RangeMin = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.TxtNgay_Huy.ShowDayBeforeMonth = False
        Me.TxtNgay_Huy.Size = New System.Drawing.Size(133, 21)
        Me.TxtNgay_Huy.TabIndex = 2
        Me.TxtNgay_Huy.Text = "18/09/2011"
        Me.TxtNgay_Huy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtNgay_Huy.Value = New Date(2011, 9, 18, 0, 0, 0, 0)
        '
        'LabNgay_Ct
        '
        Me.LabNgay_Ct.AutoSize = True
        Me.LabNgay_Ct.BackColor = System.Drawing.Color.Transparent
        Me.LabNgay_Ct.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.LabNgay_Ct.ForeColor = System.Drawing.Color.Navy
        Me.LabNgay_Ct.Location = New System.Drawing.Point(297, 61)
        Me.LabNgay_Ct.Name = "LabNgay_Ct"
        Me.LabNgay_Ct.Size = New System.Drawing.Size(74, 13)
        Me.LabNgay_Ct.TabIndex = 1920
        Me.LabNgay_Ct.Tag = "Voucher date"
        Me.LabNgay_Ct.Text = "Ngày văn bản"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(5, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 1922
        Me.Label2.Tag = "Explaination"
        Me.Label2.Text = "Số hóa đơn TT/ĐC"
        '
        'TxtStt_rec_TT
        '
        Me.TxtStt_rec_TT.BackColor = System.Drawing.Color.White
        Me.TxtStt_rec_TT.ForeColor = System.Drawing.Color.Navy
        Me.TxtStt_rec_TT.Location = New System.Drawing.Point(96, 120)
        Me.TxtStt_rec_TT.Name = "TxtStt_rec_TT"
        Me.TxtStt_rec_TT.Size = New System.Drawing.Size(143, 20)
        Me.TxtStt_rec_TT.TabIndex = 1923
        Me.TxtStt_rec_TT.Tag = ""
        Me.TxtStt_rec_TT.Visible = False
        '
        'txtSo_ct_tt
        '
        Me.txtSo_ct_tt._ActilookupPopup = False
        Me.txtSo_ct_tt.CyberActilookupPopup = True
        Me.txtSo_ct_tt.Dv_ListDetail = Nothing
        Me.txtSo_ct_tt.Dv_Master = Nothing
        Me.txtSo_ct_tt.FilterClient = ""
        Me.txtSo_ct_tt.FilterSQL = ""
        Me.txtSo_ct_tt.Location = New System.Drawing.Point(108, 15)
        Me.txtSo_ct_tt.Name = "txtSo_ct_tt"
        Me.txtSo_ct_tt.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtSo_ct_tt.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.txtSo_ct_tt.Properties.Appearance.Options.UseFont = True
        Me.txtSo_ct_tt.Properties.Appearance.Options.UseForeColor = True
        Me.txtSo_ct_tt.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White
        Me.txtSo_ct_tt.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.txtSo_ct_tt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.txtSo_ct_tt.Size = New System.Drawing.Size(143, 20)
        Me.txtSo_ct_tt.TabIndex = 0
        Me.txtSo_ct_tt.Table_Name = ""
        '
        'TxtSo_SeriHD
        '
        Me.TxtSo_SeriHD.BackColor = System.Drawing.Color.White
        Me.TxtSo_SeriHD.ForeColor = System.Drawing.Color.Navy
        Me.TxtSo_SeriHD.Location = New System.Drawing.Point(108, 37)
        Me.TxtSo_SeriHD.Name = "TxtSo_SeriHD"
        Me.TxtSo_SeriHD.Size = New System.Drawing.Size(143, 20)
        Me.TxtSo_SeriHD.TabIndex = 1924
        Me.TxtSo_SeriHD.Tag = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(5, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 1925
        Me.Label3.Tag = "Explaination"
        Me.Label3.Text = "Số seri HĐ"
        '
        'TxtMau_VatHD
        '
        Me.TxtMau_VatHD.BackColor = System.Drawing.Color.White
        Me.TxtMau_VatHD.ForeColor = System.Drawing.Color.Navy
        Me.TxtMau_VatHD.Location = New System.Drawing.Point(374, 36)
        Me.TxtMau_VatHD.Name = "TxtMau_VatHD"
        Me.TxtMau_VatHD.Size = New System.Drawing.Size(133, 20)
        Me.TxtMau_VatHD.TabIndex = 1926
        Me.TxtMau_VatHD.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(297, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 1927
        Me.Label4.Tag = "Explaination"
        Me.Label4.Text = "Mẫu vat HĐ"
        '
        'TxtLoai_HD
        '
        Me.TxtLoai_HD.BackColor = System.Drawing.Color.White
        Me.TxtLoai_HD.ForeColor = System.Drawing.Color.Navy
        Me.TxtLoai_HD.Location = New System.Drawing.Point(14, 118)
        Me.TxtLoai_HD.Name = "TxtLoai_HD"
        Me.TxtLoai_HD.Size = New System.Drawing.Size(56, 20)
        Me.TxtLoai_HD.TabIndex = 1928
        Me.TxtLoai_HD.Tag = ""
        Me.TxtLoai_HD.Visible = False
        '
        'FrmTTDC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(509, 167)
        Me.Controls.Add(Me.TxtLoai_HD)
        Me.Controls.Add(Me.TxtMau_VatHD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSo_SeriHD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSo_ct_tt)
        Me.Controls.Add(Me.TxtStt_rec_TT)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtNgay_Huy)
        Me.Controls.Add(Me.LabNgay_Ct)
        Me.Controls.Add(Me.TxtLy_Do)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtSo_CT)
        Me.Controls.Add(Me.Label5)
        Me.MinimizeBox = False
        Me.Name = "FrmTTDC"
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtSo_CT, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtLy_Do, 0)
        Me.Controls.SetChildIndex(Me.LabNgay_Ct, 0)
        Me.Controls.SetChildIndex(Me.TxtNgay_Huy, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtStt_rec_TT, 0)
        Me.Controls.SetChildIndex(Me.txtSo_ct_tt, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtSo_SeriHD, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtMau_VatHD, 0)
        Me.Controls.SetChildIndex(Me.TxtLoai_HD, 0)
        CType(Me.txtSo_ct_tt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSo_CT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtLy_Do As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNgay_Huy As ClsTextBox.txtDate
    Friend WithEvents LabNgay_Ct As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStt_rec_TT As System.Windows.Forms.TextBox
    Friend WithEvents txtSo_ct_tt As Cyber.SmLists.TxtLookup
    Friend WithEvents TxtSo_SeriHD As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMau_VatHD As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtLoai_HD As System.Windows.Forms.TextBox

End Class

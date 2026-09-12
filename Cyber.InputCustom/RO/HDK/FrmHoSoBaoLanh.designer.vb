<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHoSoBaoLanh
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
        Me.TxtMa_Dvcs = New System.Windows.Forms.TextBox()
        Me.CmdDanh_Sach_BL = New System.Windows.Forms.Button()
        Me.LabLenh_PO = New System.Windows.Forms.Label()
        Me.TxtMa_Cv_BL = New System.Windows.Forms.TextBox()
        Me.ChkIs_Xin_BL = New System.Windows.Forms.CheckBox()
        Me.TxtTen_HS_BL = New System.Windows.Forms.TextBox()
        Me.TxtMa_HS_BL = New Cyber.SmLists.TxtLookup()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ChkIs_Xin_BL_BH = New System.Windows.Forms.CheckBox()
        CType(Me.TxtMa_HS_BL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 138)
        Me.GroupBoxLine.Size = New System.Drawing.Size(497, 8)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(297, 148)
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(399, 148)
        '
        'TxtMa_Dvcs
        '
        Me.TxtMa_Dvcs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMa_Dvcs.BackColor = System.Drawing.Color.White
        Me.TxtMa_Dvcs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Dvcs.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Dvcs.Location = New System.Drawing.Point(12, 152)
        Me.TxtMa_Dvcs.Name = "TxtMa_Dvcs"
        Me.TxtMa_Dvcs.Size = New System.Drawing.Size(122, 20)
        Me.TxtMa_Dvcs.TabIndex = 1937
        Me.TxtMa_Dvcs.Tag = ""
        Me.TxtMa_Dvcs.Visible = False
        '
        'CmdDanh_Sach_BL
        '
        Me.CmdDanh_Sach_BL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDanh_Sach_BL.Location = New System.Drawing.Point(226, 12)
        Me.CmdDanh_Sach_BL.Name = "CmdDanh_Sach_BL"
        Me.CmdDanh_Sach_BL.Size = New System.Drawing.Size(29, 22)
        Me.CmdDanh_Sach_BL.TabIndex = 2178
        Me.CmdDanh_Sach_BL.Tag = "..."
        Me.CmdDanh_Sach_BL.Text = "..."
        Me.CmdDanh_Sach_BL.UseVisualStyleBackColor = True
        '
        'LabLenh_PO
        '
        Me.LabLenh_PO.BackColor = System.Drawing.Color.Transparent
        Me.LabLenh_PO.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.LabLenh_PO.ForeColor = System.Drawing.Color.Navy
        Me.LabLenh_PO.Location = New System.Drawing.Point(12, 16)
        Me.LabLenh_PO.Name = "LabLenh_PO"
        Me.LabLenh_PO.Size = New System.Drawing.Size(112, 17)
        Me.LabLenh_PO.TabIndex = 2180
        Me.LabLenh_PO.Tag = "P/O"
        Me.LabLenh_PO.Text = "Công việc bảo lãnh"
        '
        'TxtMa_Cv_BL
        '
        Me.TxtMa_Cv_BL.BackColor = System.Drawing.Color.White
        Me.TxtMa_Cv_BL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMa_Cv_BL.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.TxtMa_Cv_BL.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_Cv_BL.Location = New System.Drawing.Point(138, 12)
        Me.TxtMa_Cv_BL.Name = "TxtMa_Cv_BL"
        Me.TxtMa_Cv_BL.Size = New System.Drawing.Size(86, 21)
        Me.TxtMa_Cv_BL.TabIndex = 2179
        Me.TxtMa_Cv_BL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ChkIs_Xin_BL
        '
        Me.ChkIs_Xin_BL.AutoSize = True
        Me.ChkIs_Xin_BL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.ChkIs_Xin_BL.ForeColor = System.Drawing.Color.Red
        Me.ChkIs_Xin_BL.Location = New System.Drawing.Point(9, 63)
        Me.ChkIs_Xin_BL.Name = "ChkIs_Xin_BL"
        Me.ChkIs_Xin_BL.Size = New System.Drawing.Size(166, 19)
        Me.ChkIs_Xin_BL.TabIndex = 2181
        Me.ChkIs_Xin_BL.TabStop = False
        Me.ChkIs_Xin_BL.Tag = "Disc"
        Me.ChkIs_Xin_BL.Text = "Xin duyệt bảo lãnh CV"
        Me.ChkIs_Xin_BL.UseVisualStyleBackColor = True
        '
        'TxtTen_HS_BL
        '
        Me.TxtTen_HS_BL.BackColor = System.Drawing.Color.White
        Me.TxtTen_HS_BL.ForeColor = System.Drawing.Color.Navy
        Me.TxtTen_HS_BL.Location = New System.Drawing.Point(238, 109)
        Me.TxtTen_HS_BL.Name = "TxtTen_HS_BL"
        Me.TxtTen_HS_BL.ReadOnly = True
        Me.TxtTen_HS_BL.Size = New System.Drawing.Size(259, 20)
        Me.TxtTen_HS_BL.TabIndex = 2184
        Me.TxtTen_HS_BL.TabStop = False
        Me.TxtTen_HS_BL.Tag = ""
        '
        'TxtMa_HS_BL
        '
        Me.TxtMa_HS_BL._ActilookupPopup = False
        Me.TxtMa_HS_BL.CyberActilookupPopup = True
        Me.TxtMa_HS_BL.Dv_ListDetail = Nothing
        Me.TxtMa_HS_BL.Dv_Master = Nothing
        Me.TxtMa_HS_BL.FilterClient = ""
        Me.TxtMa_HS_BL.FilterSQL = ""
        Me.TxtMa_HS_BL.Location = New System.Drawing.Point(138, 108)
        Me.TxtMa_HS_BL.Name = "TxtMa_HS_BL"
        Me.TxtMa_HS_BL.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMa_HS_BL.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.TxtMa_HS_BL.Properties.Appearance.Options.UseFont = True
        Me.TxtMa_HS_BL.Properties.Appearance.Options.UseForeColor = True
        Me.TxtMa_HS_BL.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.TxtMa_HS_BL.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.TxtMa_HS_BL.Size = New System.Drawing.Size(98, 22)
        Me.TxtMa_HS_BL.TabIndex = 2182
        Me.TxtMa_HS_BL.Table_Name = ""
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(8, 112)
        Me.Label21.Margin = New System.Windows.Forms.Padding(0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(128, 13)
        Me.Label21.TabIndex = 2183
        Me.Label21.Tag = "Type"
        Me.Label21.Text = "Người duyệt bảo lãnh"
        '
        'ChkIs_Xin_BL_BH
        '
        Me.ChkIs_Xin_BL_BH.AutoSize = True
        Me.ChkIs_Xin_BL_BH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.ChkIs_Xin_BL_BH.ForeColor = System.Drawing.Color.Red
        Me.ChkIs_Xin_BL_BH.Location = New System.Drawing.Point(9, 85)
        Me.ChkIs_Xin_BL_BH.Name = "ChkIs_Xin_BL_BH"
        Me.ChkIs_Xin_BL_BH.Size = New System.Drawing.Size(261, 19)
        Me.ChkIs_Xin_BL_BH.TabIndex = 2185
        Me.ChkIs_Xin_BL_BH.TabStop = False
        Me.ChkIs_Xin_BL_BH.Tag = "Disc"
        Me.ChkIs_Xin_BL_BH.Text = "Xin duyệt bảo lãnh chưa có hồ sơ BH"
        Me.ChkIs_Xin_BL_BH.UseVisualStyleBackColor = True
        '
        'FrmHoSoBaoLanh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(501, 202)
        Me.Controls.Add(Me.ChkIs_Xin_BL_BH)
        Me.Controls.Add(Me.TxtTen_HS_BL)
        Me.Controls.Add(Me.TxtMa_HS_BL)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.ChkIs_Xin_BL)
        Me.Controls.Add(Me.LabLenh_PO)
        Me.Controls.Add(Me.TxtMa_Cv_BL)
        Me.Controls.Add(Me.CmdDanh_Sach_BL)
        Me.Controls.Add(Me.TxtMa_Dvcs)
        Me.Name = "FrmHoSoBaoLanh"
        Me.Controls.SetChildIndex(Me.TxtMa_Dvcs, 0)
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.CmdDanh_Sach_BL, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_Cv_BL, 0)
        Me.Controls.SetChildIndex(Me.LabLenh_PO, 0)
        Me.Controls.SetChildIndex(Me.ChkIs_Xin_BL, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.TxtMa_HS_BL, 0)
        Me.Controls.SetChildIndex(Me.TxtTen_HS_BL, 0)
        Me.Controls.SetChildIndex(Me.ChkIs_Xin_BL_BH, 0)
        CType(Me.TxtMa_HS_BL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtMa_Dvcs As System.Windows.Forms.TextBox
    Friend WithEvents CmdDanh_Sach_BL As Button
    Friend WithEvents LabLenh_PO As Label
    Friend WithEvents TxtMa_Cv_BL As TextBox
    Friend WithEvents ChkIs_Xin_BL As CheckBox
    Friend WithEvents TxtTen_HS_BL As TextBox
    Friend WithEvents TxtMa_HS_BL As SmLists.TxtLookup
    Friend WithEvents Label21 As Label
    Friend WithEvents ChkIs_Xin_BL_BH As System.Windows.Forms.CheckBox
End Class

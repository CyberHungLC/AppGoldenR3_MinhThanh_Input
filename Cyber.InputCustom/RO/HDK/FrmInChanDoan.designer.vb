<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInChanDoan
    Inherits Cyber.From.FrmCalculator

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CbbMau_BC = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'GroupBoxLine
        '
        Me.GroupBoxLine.Location = New System.Drawing.Point(2, 37)
        Me.GroupBoxLine.Size = New System.Drawing.Size(387, 8)
        '
        'ButtOK
        '
        Me.ButtOK.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtOK.Appearance.Options.UseForeColor = True
        Me.ButtOK.Location = New System.Drawing.Point(187, 47)
        Me.ButtOK.Text = "&Chấp nhận"
        '
        'ButtExit
        '
        Me.ButtExit.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.ButtExit.Appearance.Options.UseForeColor = True
        Me.ButtExit.Location = New System.Drawing.Point(289, 47)
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Olive
        Me.Label7.Location = New System.Drawing.Point(4, 14)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 18)
        Me.Label7.TabIndex = 332
        Me.Label7.Tag = "Forms"
        Me.Label7.Text = "Mẫu in"
        '
        'CbbMau_BC
        '
        Me.CbbMau_BC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CbbMau_BC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbbMau_BC.ForeColor = System.Drawing.Color.Navy
        Me.CbbMau_BC.FormattingEnabled = True
        Me.CbbMau_BC.Location = New System.Drawing.Point(65, 13)
        Me.CbbMau_BC.Name = "CbbMau_BC"
        Me.CbbMau_BC.Size = New System.Drawing.Size(323, 21)
        Me.CbbMau_BC.TabIndex = 321
        '
        'FrmInChanDoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(391, 101)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CbbMau_BC)
        Me.Name = "FrmInChanDoan"
        Me.Text = "In chẩn đoán"
        Me.Controls.SetChildIndex(Me.ButtExit, 0)
        Me.Controls.SetChildIndex(Me.ButtOK, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxLine, 0)
        Me.Controls.SetChildIndex(Me.CbbMau_BC, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CbbMau_BC As System.Windows.Forms.ComboBox

End Class

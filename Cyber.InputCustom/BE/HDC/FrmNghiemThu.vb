Public Class FRMNghiemThu
    Public Property Stt_rec() As String
        Get
            Return M_Stt_rec
        End Get
        Set(ByVal value As String)
            M_Stt_rec = value
        End Set
    End Property
    Public Property Ma_Ct() As String
        Get
            Return M_Ma_Ct
        End Get
        Set(ByVal value As String)
            M_Ma_Ct = value
        End Set
    End Property
    Public Property DT_Return() As DataTable
        Get
            Return M_DT_Return
        End Get
        Set(ByVal value As DataTable)
            M_DT_Return = value
        End Set
    End Property
    Dim M_Stt_rec As String = ""
    Dim M_Ma_Ct As String = ""
    Dim M_DT_Return As DataTable
    Dim DrReturn As DataRow
    Dim DsLookup As DataSet
    Dim Cyberinput As New Cyber.InputCustom.Sys
    Private Sub FrmNghiemthu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        V_Addhandler()
        Me.Text = "Nghiệm thu lệnh"
        If Not M_Ma_Ct.Trim.ToUpper.Trim = "HDK" Then

            ChkIs_Hen.Visible = False
            Txtngay_Hen.Visible = False
            LabSo_km_Hen.Visible = False
            TxtSo_km_Hen.Visible = False

            ChkDT.Visible = False
            Chkthu.Visible = False
            Chkkhong.Visible = False

            TxtMa_Kh.Visible = True
            TxtMa_Kh.ReadOnly = False
            TxtTen_kh.ReadOnly = True
        Else
            TxtMa_Kh.Visible = False
            TxtMa_Kh.ReadOnly = True
            TxtTen_kh.ReadOnly = False

            Dim _X As Decimal = TxtDia_Chi.Location.X
            Dim _Y As Decimal = TxtTen_kh.Location.Y

            TxtTen_kh.Location = New System.Drawing.Point(_X, _Y)
            TxtTen_kh.ReadOnly = False

            Dim _W As Decimal = TxtDia_Chi.Size.Width
            Dim _H As Decimal = TxtTen_kh.Size.Height

            TxtTen_kh.Size = New System.Drawing.Size(_W, _H)

        End If

    End Sub
    Private Sub V_Addhandler()
        AddHandler TxtGio_NT.Leave, AddressOf V_Gio_NT
        AddHandler ButtExit.Click, AddressOf V_Exit
        AddHandler ButtOK.Click, AddressOf V_Nhan
        AddHandler TxtMa_Kh.CyberValiting, AddressOf V_Ma_KH
        AddHandler TxtMa_Kh.CyberLeave, AddressOf L_Ma_KH

    End Sub

    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoNghiemthuLoad", M_Stt_rec + "#" + M_Ma_Ct + "#" + M_Ma_Dvcs + "#" + M_User_Name)
        Dim _TG As String = CyberVoucher.V_GetTG2("", 0, AppConn, CyberSmlib, M_Ma_Dvcs, M_User_Name)
        If DsTmp.Tables.Count = 0 Then
            TxtNgay_NT.Value = DateTime.Now
            'TxtGio_NT.Text = CyberVoucher.V_GetTG("", 0)
            TxtGio_NT.Text = _TG
            DsTmp.Dispose()
            Exit Sub

        End If
        If DsTmp.Tables(0).Rows.Count = 0 Then

            TxtNgay_NT.Value = DateTime.Now
            'TxtGio_NT.Text = CyberVoucher.V_GetTG("", 0)
            TxtGio_NT.Text = _TG
            DsTmp.Dispose()
            Exit Sub
        End If

        CyberSmodb.SetValueTObj(Me, DsTmp.Tables(0).Rows(0))
       
        TxtNgay_NT.Value = DateTime.Now
        'TxtGio_NT.Text = CyberVoucher.V_GetTG("", 0)
        TxtGio_NT.Text = _TG
        DsTmp.Dispose()
    End Sub
    Private Sub V_Gio_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TxtGio_NT.Text = IIf(TxtGio_NT.Text = "", CyberVoucher.V_GetTG2("", 0, AppConn, CyberSmlib, M_Ma_Dvcs, M_User_Name), CyberVoucher.V_GetTG(TxtGio_NT.Text, 0))
    End Sub
    Private Sub V_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        TxtMa_Kh.V_LookUp(M_LAN, Me.Para, Me.Sysvar, AppConn, DsLookup, "Ma_kh", "DmKh", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If TxtMa_Kh.Text = "" Then
            TxtTen_kh.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Kh.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Kh.Text = DrReturn.Item("Ma_KH")
            TxtTen_kh.Text = DrReturn.Item("Ten_KH")
            TxtDia_Chi.Text = IIf(TxtDia_Chi.Text.Trim = "", DrReturn.Item("Dia_Chi").ToString.Trim, TxtDia_Chi.Text)
            'txtTen_Lx.Text = IIf(txtTen_Lx.Text.Trim = "", DrReturn.Item("Ong_ba").ToString.Trim, TxtDia_Chi.Text)
            TxtTen_khVAT.Text = IIf(TxtTen_khVAT.Text = "", DrReturn("Ten_khVat").ToString.Trim, TxtTen_khVAT.Text)
            TxtDia_ChiVAT.Text = IIf(TxtDia_ChiVAT.Text = "", DrReturn("Dia_ChiVat").ToString.Trim, TxtDia_ChiVAT.Text)

            TxtTen_khVAT.Text = IIf(TxtTen_khVAT.Text = "", DrReturn("Ten_kh").ToString.Trim, TxtTen_khVAT.Text)
            TxtDia_ChiVAT.Text = IIf(TxtDia_ChiVAT.Text = "", DrReturn("Dia_Chi").ToString.Trim, TxtDia_ChiVAT.Text)
        Else
            TxtMa_Kh.Text = ""
            'TxtTen_kh.Text = ""
        End If
        'If TxtMa_Kh.Text = "" Then
        '    'TxtTen_kh.Text = ""
        '    'TxtDia_Chi.Text = ""
        '    'txtTen_Lx.Text = ""
        '    Exit Sub
        'End If
    End Sub

    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim _strField As String = ""
        Dim _strValue As String = ""
        TxtND_Hen.Text = TxtND_Hen.Text.Replace("#", "").Trim
        TxtND_Hen.Text = TxtND_Hen.Text.Replace("'", "").Trim

        TxtGhi_Chu.Text = TxtGhi_Chu.Text.Replace("#", "").Trim
        TxtGhi_Chu.Text = TxtGhi_Chu.Text.Replace("'", "").Trim

        CyberSmodb.GetValueControler(Me, _strField, _strValue)

        Dim _Ngay_NT As Date = TxtNgay_NT.Value
        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoNghiemthu", M_Stt_rec.Trim + "#" + M_Ma_Ct.Trim + "#" + _strField + "#" + _strValue + "#" + M_User_Name.Trim)

        If Not CyberSupport.V_MsgChk(DsTmp.Tables(0), Me.Sysvar, Me.Lan) Then
            DsTmp.Dispose()
            Exit Sub
        End If

        M_DT_Return = DsTmp.Tables(0).Copy
        Me.DT_Return = DsTmp.Tables(0).Copy
        DsTmp.Dispose()
        Me.Save_OK = True
        Me.Close()

        'Dim _Ngay_NT As Date = TxtNgay_NT.Value
        'Dim dsNghiemthu As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoNghiemthu", M_Stt_rec.Trim + "#" + M_Ma_Ct.Trim + "#" + _Ngay_NT.ToString("yyyyMMdd") + "#" + TxtGio_NT.Text.Trim.Replace("'", "").Replace("#", "") + "#" + M_User_Name.Trim)
        'If Not CyberSupport.V_MsgChk(dsNghiemthu.Tables(0), Me.Sysvar, Me.Lan) Then
        '    dsNghiemthu.Dispose()
        '    Exit Sub
        'End If
        'M_DT_Return = dsNghiemthu.Tables(0).Copy
        'Me.DT_Return = dsNghiemthu.Tables(0).Copy
        'dsNghiemthu.Dispose()
        'Me.Save_OK = True
        'Me.Close()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = False
        Me.Close()
    End Sub
End Class

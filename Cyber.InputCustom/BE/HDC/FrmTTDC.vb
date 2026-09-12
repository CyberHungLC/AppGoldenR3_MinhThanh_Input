Public Class FrmTTDC
    Public Property Stt_rec() As String
        Get
            Return M_Stt_rec
        End Get
        Set(ByVal value As String)
            M_Stt_rec = value
        End Set
    End Property
    Public Property Mode() As String
        Get
            Return M_Mode
        End Get
        Set(ByVal value As String)
            M_Mode = value
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
    Public Property ngay_ct() As DateTime
        Get
            Return M_Ngay_CT
        End Get
        Set(ByVal value As DateTime)
            M_Ngay_CT = value
        End Set
    End Property
    Public Property Nam() As String
        Get
            Return M_Nam
        End Get
        Set(ByVal value As String)
            M_Nam = value
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
    Dim M_Thang As String = ""
    Dim M_Nam As String = ""
    Dim M_Ma_HD_KH As String = ""
    Dim M_Mode As String = ""
    Dim M_Ngay_CT As DateTime
    Dim M_DT_Return, DtNam As DataTable
    Dim DrReturn As DataRow
    Dim DsLookup As DataSet

    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para

    Private Sub FrmNghiemthu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        V_Addhandler()
        Me.Text = "Hủy hóa đơn"
    End Sub
    Private Sub V_Addhandler()
        AddHandler ButtExit.Click, AddressOf V_Exit
        AddHandler ButtOK.Click, AddressOf V_Nhan

        AddHandler txtSo_ct_tt.CyberValiting, AddressOf V_Ma_CTTT
        AddHandler txtSo_ct_tt.CyberLeave, AddressOf L_Ma_CTTT
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        TxtNgay_Huy.Value = Now.Date

        Dim Dstmp As New DataSet
        Dim dt As Date = TxtNgay_Huy.Value

        Dstmp = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_API_GetSo_Vanban", TxtLoai_HD.Text + "#" + dt.ToString("yyyyMMdd") + "#" + M_Ma_Ct.Trim + "#" + M_Stt_rec.Trim + "#" + M_Ma_Dvcs.Trim + "#" + M_User_Name.Trim)

        TxtSo_CT.Text = Dstmp.Tables(0).Rows(0).Item("So_VB")
        TxtSo_CT.Refresh()
    End Sub
#Region "Valid --- So_CT_TT"
    Private Sub V_Ma_CTTT(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        txtSo_ct_tt.V_LookUp(M_LAN, Para, Sysvar, AppConn, DsLookup, "Stt_rec", "DMHDDT", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_CTTT(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If txtSo_ct_tt.Text = "" Then
            Exit Sub
        End If
        DrReturn = txtSo_ct_tt.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            txtSo_ct_tt.Text = DrReturn.Item("So_HDDT")
            TxtStt_rec_TT.Text = DrReturn.Item("Stt_rec")
            TxtSo_SeriHD.Text = DrReturn.Item("So_SeriHD")
            TxtMau_VatHD.Text = DrReturn.Item("Mau_vatHD")
        Else
            txtSo_ct_tt.Text = ""
            TxtStt_rec_TT.Text = ""
            TxtSo_SeriHD.Text = ""
            TxtMau_VatHD.Text = ""
            Exit Sub
        End If
    End Sub
#End Region
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtSo_ct_tt.Text.Trim = "" Then
            MsgBox("Số hóa đơn cần thay thế/điều chỉnh không được bỏ trống!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Sysvar("M_CYBER_VER"))
            Exit Sub
        End If
        If TxtSo_CT.Text.Trim = "" Then
            MsgBox("Số văn bản hủy không được bỏ trống!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, Sysvar("M_CYBER_VER"))
            Exit Sub
        End If
        Me.Save_OK = True
        Me.Close()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = False
        Me.Close()
    End Sub
End Class

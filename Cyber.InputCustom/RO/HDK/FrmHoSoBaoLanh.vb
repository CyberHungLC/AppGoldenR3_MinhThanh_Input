Imports System.Data.SqlClient
Imports System.IO

Public Class FrmHoSoBaoLanh
    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para
    Dim M_AppConn As SqlConnection
    Dim M_DsData, M_DsHead, M_DsLookUp As DataSet
    Dim CyberFrom As New Cyber.From.Sys
    Dim CyberInput As New Sys
    Dim DrReturn As DataRow

#Region "AddProperty"
    Public Property Ma_TTCP_H() As String
        Get
            Ma_TTCP_H = M_Ma_TTCP_H
        End Get
        Set(ByVal Value As String)
            M_Ma_TTCP_H = Value
        End Set
    End Property
    Dim M_Ma_TTCP_H As String = ""
    Public Property Ma_Cv_BL() As String
        Get
            Ma_Cv_BL = M_Ma_Cv_BL
        End Get
        Set(ByVal Value As String)
            M_Ma_Cv_BL = Value
        End Set
    End Property
    Dim M_Ma_Cv_BL As String = ""

    Public Property Ma_HS_BL() As String
        Get
            Ma_HS_BL = M_Ma_HS_BL
        End Get
        Set(ByVal Value As String)
            M_Ma_HS_BL = Value
        End Set
    End Property
    Dim M_Ma_HS_BL As String = ""
    Public Property Is_HS_BL() As Boolean
        Get
            Is_HS_BL = M_Is_HS_BL
        End Get
        Set(ByVal Value As Boolean)
            M_Is_HS_BL = Value
        End Set
    End Property
    Dim M_Is_HS_BL As Boolean = 0
    Public Property Is_Xin_BL() As Boolean
        Get
            Is_Xin_BL = M_Is_Xin_BL
        End Get
        Set(ByVal Value As Boolean)
            M_Is_Xin_BL = Value
        End Set
    End Property
    Dim M_Is_Xin_BL As Boolean = 0
#End Region
#Region "Khai báo biến"
    Dim M_Dr As DataRow
    Dim _Dt_BH_DS, _Dt_BH_VC, _Dt_BH_NL As DataTable
#End Region
    Private Sub FrmbaoHiem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        TxtMa_Dvcs.Text = M_Ma_Dvcs
        TxtMa_Cv_BL.Text = M_Ma_Cv_BL
        TxtMa_HS_BL.Text = M_Ma_HS_BL
        'ChkIs_Hs_BL.Checked = M_Is_HS_BL
        ChkIs_Xin_BL.Checked = M_Is_Xin_BL
        V_Load()
        osysvar = Me.Sysvar
        M_LAN = Me.Lan
        M_Para = Me.Para
        AppConn = Me.AppConn
        'M_DsLookUp = Me.DsLookup

        AddHandler CmdDanh_Sach_BL.Click, AddressOf V_Danh_sach_BL
        AddHandler ButtOK.Click, AddressOf V_Nhan
        '--KX
        AddHandler TxtMa_HS_BL.CyberValiting, AddressOf V_Ma_HS_BL
        AddHandler TxtMa_HS_BL.CyberLeave, AddressOf L_Ma_HS_BL
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()

    End Sub
#Region "Ds bảo lãnh"
    Private Sub V_Danh_sach_BL(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String
        str = CyberSupport.V_GetStrSelectList(AppConn, osysvar, M_Para, "CP_GetListHDKGetBaoLanh", M_Ma_TTCP_H & "#" & M_Ma_Dvcs & "#" & M_User_Name, M_LAN)
        If str Is Nothing Then Exit Sub
        TxtMa_Cv_BL.Text = str.ToString.Trim
    End Sub
#End Region

#Region "Valid --- Ma_HS_BL"
    Private Sub V_Ma_HS_BL(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        sender.V_LookUp(M_LAN, M_Para, osysvar, AppConn, M_DsLookUp, "Ma_HS", "DmHs", "1=1", "NH_HS5 ='01'")
    End Sub
    Private Sub L_Ma_HS_BL(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        DrReturn = sender.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_HS_BL.Text = DrReturn.Item("Ma_HS")
            TxtTen_HS_BL.Text = DrReturn.Item("Ten_HS")
        Else
            TxtMa_HS_BL.Text = ""
            TxtTen_HS_BL.Text = ""
        End If
    End Sub
#End Region
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = False
        Dim M_strParameterStore As String = ""

        Me.Ma_Cv_BL = TxtMa_Cv_BL.Text
        M_Ma_Cv_BL = TxtMa_Cv_BL.Text

        'Me.Is_HS_BL = ChkHs_BL.Text
        'M_Is_HS_BL = ChkHs_BL.Text

        Me.Save_OK = True
        Me.Close()
    End Sub
End Class

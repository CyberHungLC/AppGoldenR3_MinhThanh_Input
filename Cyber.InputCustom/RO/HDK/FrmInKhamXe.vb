Public Class FrmInKhamXe
#Region "AddProperty"
    Public Property _RepoName() As String
        Get
            _RepoName = M_Repo_name
        End Get
        Set(ByVal Value As String)
            M_Repo_name = Value
        End Set
    End Property
#End Region
#Region "Khai báo biến"
    Dim M_Dr As DataRow
    Dim M_Repo_name As String = ""
    Dim _DtMauBC As DataTable
#End Region
    Private Sub FrmInKhamXe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        V_Load()
        AddHandler ButtOK.Click, AddressOf V_Nhan
    End Sub
    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_Load()
        GetCombo()
    End Sub
    Sub GetCombo()
        Dim Mau_Repo As String = ""
        '---
        Dim DsCombo As New DataSet
        DsCombo = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetComboboxInKhamXe", M_Ma_Dvcs + "#" + M_User_Name)
        _DtMauBC = DsCombo.Tables(0)
        Mau_Repo = DsCombo.Tables(1).Rows(0).Item("Mau_Repo")
        CyberFill.V_FillComBoxValue(Me.CbbMau_BC, _DtMauBC, "Mau_Repo", "Ten_Mau", Mau_Repo)
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = True
        Dim M_strParameterStore As String = ""
        M_Repo_name = CbbMau_BC.SelectedValue
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
End Class

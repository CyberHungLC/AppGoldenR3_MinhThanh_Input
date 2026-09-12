Public Class VOC_LSKN
#Region "Get or Set Property----------------------"
    Dim M_Ma_Get, M_Ma_Xe, M_So_Khung As String
    Public Property Stt_rec() As String
        Get
            Return M_Stt_rec
        End Get
        Set(ByVal value As String)
            M_Stt_rec = value
        End Set
    End Property
    Public Property Ma_Xe() As String
        Get
            Return M_Ma_Xe
        End Get
        Set(ByVal value As String)
            M_Ma_xe = value
        End Set
    End Property
    Public Property So_Khung() As String
        Get
            Return M_So_Khung
        End Get
        Set(ByVal value As String)
            M_So_Khung = value
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
    Public Property Ma_Get() As String
        Get
            Return M_Ma_Get
        End Get
        Set(ByVal value As String)
            M_Ma_Get = value
        End Set
    End Property
    Public Property Ma_GD() As String
        Get
            Return M_Ma_GD
        End Get
        Set(ByVal value As String)
            M_Ma_GD = value
        End Set
    End Property
    Public Property Master_Return() As DataTable
        Get
            Master_Return = M_Master_Return
        End Get
        Set(ByVal Value As DataTable)
            M_Master_Return = Value
        End Set
    End Property
    Public Property _Ds_LoolUp() As DataSet
        Get
            _Ds_LoolUp = DsLookup
        End Get
        Set(ByVal Value As DataSet)
            DsLookup = Value
        End Set
    End Property
#End Region
#Region "Bien----------------------"
    Dim M_Stt_rec As String = ""
    Dim M_Ma_Ct As String = ""
    Dim M_Mode As String = "M"
    Dim M_Ma_KH As String = ""
    Dim M_Ma_GD As String = "1"

    Dim DsLookup As New DataSet
    Dim Dt_Master, Dt_head, Dt_Detail, Dt_headDetail, Dt_MasterBH, Dt_headBH As New DataTable
    Dim Dv_Master, Dv_head, Dv_Detail, Dv_headDetail, Dv_MasterBH, Dv_headBH As New DataView

    Dim EditMasterTag As New Cyber.Fill.CyberColumnGridView

    Private Sub Master_Click(sender As Object, e As EventArgs) Handles Master.Click
        Dim iRow As Integer = -1
        iRow = MasterGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Return
        Dv_Detail.RowFilter = "Stt_Rec='" + Dt_Master.Rows.Item(iRow)("Stt_Rec") + "'"
    End Sub

    Dim M_Master_Return, Dt_Post As DataTable

    Dim DrReturn As DataRow
#End Region
    Private Sub FrmXemTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        'V_Load()
        V_GetColumn()
        V_AddHander()
        V_Loc()
        'Dim FixCol As Integer = 4
        'If FixCol < MasterGRV.Columns.Count And FixCol > 0 Then
        '    For iCol = 0 To FixCol
        '        MasterGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        '    Next
        'End If
    End Sub


    Protected Overrides Sub V_GetValueParameter()
        MyBase.V_GetValueParameter()
        '----------------------------
    End Sub
    Private Sub V_GetColumn()
        EditMasterTag.GetColumn(MasterGRV, "tag")
    End Sub
    Private Sub V_AddHander()
        'V_Menu(DetailGRVRo_Master, AddressOf V_EditVoucherRo)
        CyberFill.V_GridviewRowCellStyle(MasterGRV)

        AddHandler ButtOK.Click, AddressOf V_Nhan

        AddHandler CbbLoc.Click, AddressOf V_Loc

    End Sub

#Region "Load - "
    Private Sub V_EditVoucherRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, MasterGRV)
    End Sub
    Private Sub V_Load()
        'V_LoadDatabase("1")
    End Sub
    Private Sub V_Loc()
        Dim DsTT_Xe As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_CrmXemLsKn", M_Ma_Xe.Trim + "#" & M_So_Khung.Trim + "#" & M_Ma_Dvcs & "#" & M_User_Name)
        For i = 0 To DsTT_Xe.Tables.Count - 1
            CyberSmodb.SetNotNullTable(DsTT_Xe.Tables(i))
        Next
        Dt_Master = DsTT_Xe.Tables(1)
        Dt_head = DsTT_Xe.Tables(2)
        Dv_Master = New DataView(Dt_Master)
        Dv_head = New DataView(Dt_head)
        Dt_Detail = DsTT_Xe.Tables(3)
        Dt_headDetail = DsTT_Xe.Tables(4)
        Dv_Detail = New DataView(Dt_Detail)
        Dv_headDetail = New DataView(Dt_headDetail)

        V_FillDataToGridview(MasterGRV, M_LAN, Dv_head, Dv_Master)
        V_FillDataToGridview(DetailGRV, M_LAN, Dv_headDetail, Dv_Detail)
        If Dt_Master.Rows.Count <= 0 Then
            Return
        End If
        Dim iRow As Integer = -1
        iRow = MasterGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Return
        Dv_Detail.RowFilter = "Stt_Rec='" + Dt_Master.Rows.Item(iRow)("Stt_Rec") + "'"
    End Sub
    Private Sub V_FillDataToGridview(ByRef GRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _M_lan As String, ByVal DvHeader As DataView, ByVal DvData As DataView)
        CyberFill.V_FillReports(GRV, _M_lan, DvHeader, DvData)
        GRV.GridControl.DataSource = DvData
    End Sub
#End Region
#Region "Tinh toan"
#End Region
    Private Sub V_LocRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'V_LoadDatabase("0")
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Save_OK = True
        Dim M_strParameterStore As String = ""
        Me.Tag = M_strParameterStore

        Dim _Master_Return As DataTable = Dt_Master.Clone
        Dim iRow As Integer = -1
        iRow = MasterGRV.GetFocusedDataSourceRowIndex

        If iRow >= 0 Then
            _Master_Return.ImportRow(Dt_Master.Rows(iRow))
        End If

        Me.Master_Return = _Master_Return
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
End Class

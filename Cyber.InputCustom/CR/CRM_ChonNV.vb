Public Class CRM_ChonNV
#Region "Get or Set Property----------------------"
    Dim M_Ma_Get As String : Dim M_Ngay_Tb As DateTime
    Dim M_Stt_Rec0, M_BienLoc, M_LoaiLoc, M_ThuTuc As String
    Public Property Stt_rec() As String
        Get
            Return M_Stt_rec
        End Get
        Set(ByVal value As String)
            M_Stt_rec = value
        End Set
    End Property
    Public Property Stt_Rec0() As String
        Get
            Return M_Stt_Rec0
        End Get
        Set(ByVal value As String)
            M_Stt_Rec0 = value
        End Set
    End Property
    Public Property BienLoc() As String
        Get
            Return M_BienLoc
        End Get
        Set(ByVal value As String)
            M_BienLoc = value
        End Set
    End Property
    Public Property LoaiLoc() As String
        Get
            Return M_LoaiLoc
        End Get
        Set(ByVal value As String)
            M_LoaiLoc = value
        End Set
    End Property
    Public Property ThuTuc() As String
        Get
            Return M_Thutuc
        End Get
        Set(ByVal value As String)
            M_Thutuc = value
        End Set
    End Property
    Public Property Ngay_Tb() As DateTime
        Get
            Return M_Ngay_Tb
        End Get
        Set(ByVal value As DateTime)
            M_Ngay_Tb = value
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
    Dim Dt_Master, Dt_head, Dt_MasterBH, Dt_headBH, Dt_Tb As New DataTable
    Dim Dv_Master, Dv_head, Dv_MasterBH, Dv_headBH As New DataView

    Dim EditMasterTag As New Cyber.Fill.CyberColumnGridView
    Dim M_Master_Return, Dt_Post As DataTable
    Public NhanVienDaChon As New List(Of String)
    Dim DrReturn As DataRow
#End Region
    Private Sub FrmXemTT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Save_OK = False
        'V_Load()
        V_GetColumn()
        V_AddHander()

        Dim FixCol As Integer = 4
        If FixCol < MasterGRV.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                MasterGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        V_Loc()
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

        'CyberFill.V_GridviewRowCellStyle(MasterGRV)

        AddHandler ButtOK.Click, AddressOf V_Nhan

    End Sub

#Region "Load - "
    Private Sub V_EditVoucherRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberFill.V_EditVoucher(M_LAN, Me.Para, Me.Sysvar, AppConn, MasterGRV)
    End Sub
    Private Sub V_Load()
        'V_LoadDatabase("1")
    End Sub
    Private Sub V_Loc()
        Dim DsTT_Xe As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_VOC_Notify", M_BienLoc + "#" + M_Ma_Dvcs + "#" + M_User_Name)
        For i = 0 To DsTT_Xe.Tables.Count - 1
            CyberSmodb.SetNotNullTable(DsTT_Xe.Tables(i))
        Next
        Dt_Master = DsTT_Xe.Tables(0)
        Dt_Tb = DsTT_Xe.Tables(1)
        Dt_head = DsTT_Xe.Tables(2)
        Dv_Master = New DataView(Dt_Master)
        Dv_head = New DataView(Dt_head)
        TxtNguoi_Nhan.Text = ""
        TxtTen_Nhan.Text = ""
        V_FillDataToGridview(MasterGRV, M_LAN, Dv_head, Dv_Master)
        MasterGRV.OptionsView.ShowAutoFilterRow = True
        MasterGRV.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click ' Quan trọng
    End Sub
    Private Sub V_FillDataToGridview(ByRef GRV As DevExpress.XtraGrid.Views.Grid.GridView, ByVal _M_lan As String, ByVal DvHeader As DataView, ByVal DvData As DataView)
        CyberFill.V_FillReports(GRV, _M_lan, DvHeader, DvData)
        GRV.GridControl.DataSource = DvData

    End Sub
    Private Sub gvNV_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles MasterGRV.RowClick
        ' Kiểm tra xem cột bị thay đổi có phải là cột CheckBox hay không
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        ' Xác định vị trí click của chuột
        Dim hi As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Location)

        ' Chỉ xử lý nếu click vào cột "Chon"
        If hi.InRowCell AndAlso hi.Column.FieldName = "Chon" Then
            Dim rowHandle As Integer = hi.RowHandle
            If rowHandle >= 0 Then
                ' Lấy giá trị hiện tại của cột "Chon" dòng đó
                Dim isChecked As Boolean = Convert.ToBoolean(view.GetRowCellValue(rowHandle, "Chon"))

                ' Đảo giá trị: True -> False hoặc False -> True
                view.SetRowCellValue(rowHandle, "Chon", Not isChecked)

                ' (Nếu muốn xử lý gì thêm, ví dụ tính tổng)
                CapNhatDanhSachNhanVienChon()
            End If
        End If
    End Sub
    Private Sub CapNhatDanhSachNhanVienChon()
        Dim danhSachMa As New List(Of String)
        Dim danhSachTen As New List(Of String)
        For Each row As DataRow In Dt_Master.Rows
            If Convert.ToBoolean(row("Chon")) Then
                Dim MaNV As String = row("Ma_Hs").ToString()
                Dim TenNV As String = row("Ten_Hs").ToString()
                danhSachMa.Add(MaNV)
                danhSachTen.Add(TenNV)
            End If
        Next
        ' Gán kết quả vào TextBox
        TxtTen_Nhan.Text = String.Join(", ", danhSachTen)
        TxtNguoi_Nhan.Text = String.Join(",", danhSachMa)
    End Sub

#End Region
#Region "Tinh toan"
#End Region
    Private Sub V_LocRo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'V_LoadDatabase("0")
    End Sub
    Private Sub V_Nhan(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If TxtNguoi_Nhan.Text = "" Then
            MsgBox("Không có nhân sự được chọn!")
            Return
        End If
        If M_BienLoc = "" Then
            Return
        End If

        'Dim _Ngay_Tb As DateTime = DateTime.Now()
        'Dim DsTT_Xe As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, M_ThuTuc.Trim + "_Save", M_BienLoc + "#" & TxtNguoi_Nhan.Text + "#" & M_Ma_Dvcs & "#" & M_User_Name)
        'Me.Ngay_Tb = _Ngay_Tb
        Me.Save_OK = True
        CyberSmlib.FlushMemorySave()
        Me.Close()
    End Sub
End Class

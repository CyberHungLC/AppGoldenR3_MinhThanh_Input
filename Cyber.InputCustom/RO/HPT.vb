Imports System.Data.SqlClient
Public Class HPT
#Region "Khai bao bien Property----------------------"
    Dim M_strFilter As String = "1=1"
    Dim M_DrDmct As DataRow
    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para
    Dim M_AppConn As SqlConnection
    Dim M_DsData, M_DsHead, M_DsLookUp As DataSet

#End Region
#Region "Khai bao bien Paramater----------------------"
#End Region
#Region "Khai bao bien Dll"
    Dim CyberInput As New Cyber.Input.Sys
    Dim CyberMe As New Cyber.From.Frmvoucher
    Dim CyberFrom As New Cyber.From.Sys
#End Region
#Region "Columns Edit"
    Dim EditMa_lo, EditTk_VT, EditMa_Nx_I, EditMa_kh_I As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditMa_VT, EditMa_Vitri, EditMa_Kho_I, EditMa_Vv_I, EditMa_phi_i, EditMa_HD_I, EditMa_Sp_I, EditMa_ku_I, EditMa_TTLN_i, EditMa_TTCP_i, EditMa_BP_I, EditMa_HS_I, EditMa_CD_I, EditMa_TD1_I, EditMa_TD2_I, EditMa_TD3_I, EditMa_TD4_I, EditMa_TD5_I As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim Editma_Db_I, EditMa_Xe_I, EditMa_KX_I, EditMa_Tuyen_I, EditMa_Ts, EditMa_Cc As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditTen_Vt, EditTen_Nx_I, EditTen_Tk_VT, EditTen_kho_i, EditDvt, EditSo_Luong, EditGia_NT, EditGia, EditTien_NT, EditTien, EditDien_Giaii, EditSo_So, EditSo_Po, EditSo_Ro, EditSo_VT As New Cyber.Fill.CyberColumnGridView 'DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
#End Region
#Region "Khai bao bien Private"
    Dim M_Ct, M_Ph As String
    Dim DrReturn As DataRow
    Dim M_Count As Integer = 1
    Dim DtPost, DtMaGD As New DataTable
    Dim tbDmSttHD As New DataTable
    Dim Dt_DetailCv As New DataTable
    Dim Dt_DetailCvTmp As New DataTable
    Dim Dv_DetailCv As New DataView
    Dim Dv_DetailCvTmp As New DataView
    Dim M_Ma_TT, M_HT_TT, M_Ma_Thue, M_ma_tang As String
    Dim _Para_So_RO As String = ""
#End Region
    Private Sub HPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_Load()
        V_GetColumn()
        V_AddHandler()
        V_Databing()
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_MainSystem()
        V_MainSystemCv()
        GetRound()
        CmdNew.Select()
        V_LoadNew(sender, e)
    End Sub
#Region "Load And Set And Default"
    Private Sub V_LoadNew(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If _Para_So_RO.Trim = "" Then Exit Sub
        Dim nCount As Integer = 0
        Dim irow As Integer = -1
        Dim dtMasterRf, dtDetailRf, dtDetailCvRf As DataTable

        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetDefaultHPT", _Para_So_RO.ToString.Trim & "#" & M_Ma_CT & "#" & M_Mode & "#" & M_Ma_Dvcs & "#" & M_User_Name)
        If DsTmp.Tables(1).Rows.Count = 1 Then
            M_Stt_Rec = DsTmp.Tables(1).Rows(0).Item("Stt_Rec")
            dtMasterRf = DsTmp.Tables(1)
            dtDetailRf = DsTmp.Tables(0)
            dtDetailCvRf = DsTmp.Tables(2)
            '-------------------------------------
            nCount = Dt_Master.Rows.Count
            For irow = nCount - 1 To 0 Step -1
                If Dt_Master.Rows(irow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                    Dt_Master.Rows(irow).Delete()
                    Dt_Master.AcceptChanges()
                End If
            Next
            nCount = Dt_Detail.Rows.Count
            For irow = nCount - 1 To 0 Step -1
                If Dt_Detail.Rows(irow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                    Dt_Detail.Rows(irow).Delete()
                    Dt_Detail.AcceptChanges()
                End If
            Next
            nCount = Dt_DetailCv.Rows.Count
            For irow = nCount - 1 To 0 Step -1
                If Dt_DetailCv.Rows(irow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                    Dt_DetailCv.Rows(irow).Delete()
                    Dt_DetailCv.AcceptChanges()
                End If
            Next
            '-------------------------------------
            For irow = 0 To dtMasterRf.Rows.Count - 1
                Dt_Master.ImportRow(dtMasterRf.Rows(irow))
            Next
            For irow = 0 To dtDetailRf.Rows.Count - 1
                Dt_Detail.ImportRow(dtDetailRf.Rows(irow))
            Next
            For irow = 0 To dtDetailCvRf.Rows.Count - 1
                Dt_DetailCv.ImportRow(dtDetailCvRf.Rows(irow))
            Next

            V_Databing()
            M_Mode = "X"
            CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
            V_Setstatus()
            V_SetFocus(M_Mode)
        Else
            V_New(sender, e)
            If Not M_Mode = "M" Then Exit Sub
            TxtLenh_RO.Text = _Para_So_RO
            L_Lenh_Ro(sender, e)
        End If
    End Sub
    Private Sub V_Load()
        V_Getdefault()

        Dt_Detail = M_DsData.Tables(0)
        Dt_DetailTmp = Dt_Detail.Clone

        Dt_Master = M_DsData.Tables(1)

        Dt_DetailCv = M_DsData.Tables(2)
        Dt_DetailCvTmp = Dt_DetailCv.Clone

        '====== hach toans
        Dv_Detail = New DataView(Dt_Detail)
        Dv_DetailTmp = New DataView(Dt_DetailTmp)
        '====== Cong viec
        Dv_DetailCv = New DataView(Dt_DetailCv)
        Dv_DetailCvTmp = New DataView(Dt_DetailCvTmp)

        '====== Master
        Dv_Master = New DataView(Dt_Master)
        '====== hach toans
        Detail.DataSource = Dv_DetailTmp
        CyberFill.V_FillVoucher(DetailGRV, M_LAN, New DataView(M_DsHead.Tables(1)), Dv_DetailTmp, Me.DrDmct)
        '====== Cong viec
        DetailCv.DataSource = Dv_DetailCvTmp
        CyberFill.V_FillVoucher(DetailGRVCv, M_LAN, New DataView(M_DsHead.Tables(2)), Dv_DetailCvTmp, Me.DrDmct)

        V_SetProperty()
        CyberSupport.Translaste(Me, M_LAN, True)

        TxtTy_Gia.InputMask = IIf(DrDmct.Item("M_IP_MK_TG").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TG").ToString.Trim, TxtTy_Gia.InputMask)

        TxtT_Tien_Cong.InputMask = IIf(DrDmct.Item("M_IP_MK_SL").ToString.Trim <> "", DrDmct.Item("M_IP_MK_SL").ToString.Trim, TxtT_Tien_Cong.InputMask)
        TxtT_Thue_Cong.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Thue_Cong.InputMask)
        TxtT_Tong_Cong.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tong_Cong.InputMask)

        TxtT_Tien_Hang.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_Hang.InputMask)
        TxtT_Thue_hang.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Thue_hang.InputMask)
        TxtT_Tong_Hang.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tong_Hang.InputMask)

        TxtT_Tien_Nt2.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien_Nt2.InputMask)
        TxtT_Thue_Nt.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Thue_Nt.InputMask)
        TxtT_TT_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_TT_NT.InputMask)

        DetailGRV.ViewCaption = "Danh sách vật tư phụ tùng"
        DetailGRVCv.ViewCaption = "Danh sách công việc sửa chữa"
    End Sub
    Private Sub V_Getdefault()
        M_strFilter = Me.strFilter
        M_DrDmct = Me.DrDmct
        M_Ph = M_DrDmct.Item("M_Ph").ToString.Trim
        M_Ct = M_DrDmct.Item("M_Ct").ToString.Trim

        osysvar = Me.SysVar
        M_Stt_Rec = Me.Stt_Rec
        M_LAN = Me.Lan
        M_Para = Me.Para
        AppConn = Me.AppConn
        M_DsData = Me.DsData
        M_DsHead = Me.DsHead
        M_DsLookUp = Me.DsLookup

        Dim M_VT_PARA As Integer = CType(M_Para(0).Trim, Integer)
        K_Tmp = M_Para(1).Trim
        K_System = M_Para(2).Trim
        K_Repo = M_Para(3).Trim
        K_Repo_Nt = M_Para(4).Trim
        M_CYBER_VER = M_Para(5).Trim
        M_User_Name = M_Para(6).Trim
        M_Comment = M_Para(7).Trim
        M_is_Admin = CType(M_Para(8), Boolean)
        M_User_ID = M_Para(9).Trim
        M_Menu_ID0 = M_Para(10).Trim
        M_Bar = M_Para(11).Trim
        M_Bar2 = M_Para(12).Trim
        M_LAN = M_Para(13).Trim
        M_Ma_Dvcs = M_Para(14).Trim
        '---------------------------------------------------------------------------------------------'
        M_Ma_GD = M_Para(M_VT_PARA + 1).Trim
        M_Ma_CT = M_Para(M_VT_PARA + 2).Trim
        M_Ma_TT = M_Para(M_VT_PARA + 3).Trim
        M_Ma_Thue = M_Para(M_VT_PARA + 4).Trim
        M_HT_TT = M_Para(M_VT_PARA + 5).Trim
        M_ma_tang = "01"

        _Para_So_RO = ""
        Try
            _Para_So_RO = M_Para(M_VT_PARA + 6).Trim
        Catch ex As Exception

        End Try
        '---------------------------------------------------------------------------------------------'

        M_Ma_Post = CyberSupport.V_GetMaxPost(AppConn, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
        '---
        M_Tk_No = DrDmct.Item("M_Tk_No").ToString.Trim
        M_Tk_Co = DrDmct.Item("M_Tk_Co").ToString.Trim
        M_Tk_Thue = DrDmct.Item("M_Tk_Thue").ToString.Trim
        M_Ma_Nt = DrDmct.Item("Ma_Nt").ToString.Trim
        M_Dien_Giai = DrDmct.Item("Dien_Giai").ToString.Trim

        If M_Tk_No.Trim <> "" Then M_Ten_Tk_No = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_No.Trim + "'", CyberSmlib) Else M_Ten_Tk_No = ""
        If M_Tk_Co.Trim <> "" Then M_Ten_Tk_Co = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_Co.Trim + "'", CyberSmlib) Else M_Ten_Tk_Co = ""
        If M_Tk_Thue.Trim <> "" Then M_Ten_Tk_Thue = CyberSmodb.SQLGetvalue(AppConn, "Ten_Tk", "Dmtk", "Tk = N'" + M_Tk_Thue.Trim + "'", CyberSmlib) Else M_Ten_Tk_Thue = ""

        Dim Dstmp = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetLoaiTT", M_Ma_CT.Trim + "#" + M_User_Name)
        Dim tbDmTT = Dstmp.Tables(0).Copy

        DtPost = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmPost", "Ma_Post", "Ma_Ct = N'" + M_Ma_CT + "'", CyberSmlib)
        DtMaGD = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmMaGd", "Ma_GD", "Ma_Ct = N'" + M_Ma_CT + "'", CyberSmlib)
        Dim tbDmThue = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmThue", "Ma_thue", "Ma_Thue IN ('00','05','10','20') ", CyberSmlib)

        CyberFill.V_FillComBoxValue(Me.CbbMa_Post, DtPost, "Ma_Post", If(M_LAN = "V", "Ten_Post", "Ten_Post2"), M_Ma_Post)
        CyberFill.V_FillComBoxValue(Me.CbbMa_GD, DtMaGD, "Ma_GD", If(M_LAN = "V", "Ten_GD", "Ten_GD2"), M_Ma_GD)

    End Sub
    Private Sub V_SetProperty()

        Me.Mode = M_Mode
        Me.Stt_Rec = M_Stt_Rec
        '---
        Dim FixCol As Integer = -1
        FixCol = DrDmct.Item("ColFrozen_master")
        If FixCol < DetailGRV.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        DetailGRV.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown
    End Sub
    Private Sub V_GetColumn()

        EditMa_lo.GetColumn(DetailGRV, "Ma_Lo")
        EditMa_VT.GetColumn(DetailGRV, "Ma_VT")
        EditTen_Vt.GetColumn(DetailGRV, "Ten_VT")
        EditDvt.GetColumn(DetailGRV, "DVT")
        EditMa_Vitri.GetColumn(DetailGRV, "ma_Vitri")

        EditMa_Kho_I.GetColumn(DetailGRV, "Ma_kho_I")
        EditTen_kho_i.GetColumn(DetailGRV, "TEN_KHo_I")

        EditTk_VT.GetColumn(DetailGRV, "TK_VT")
        EditTen_Tk_VT.GetColumn(DetailGRV, "TEN_TK_VT")

        EditMa_Nx_I.GetColumn(DetailGRV, "Ma_Nx_I")
        EditTen_Nx_I.GetColumn(DetailGRV, "TEN_Nx_I")

        EditDien_Giaii.GetColumn(DetailGRV, "DIEN_GIAII")

        EditSo_Luong.GetColumn(DetailGRV, "So_Luong")
        EditGia_NT.GetColumn(DetailGRV, "Gia_NT")
        EditGia.GetColumn(DetailGRV, "Gia")
        EditTien_NT.GetColumn(DetailGRV, "TIEN_NT")
        EditTien.GetColumn(DetailGRV, "TIEN")


        EditMa_Vv_I.GetColumn(DetailGRV, "Ma_Vv_I")
        EditMa_phi_i.GetColumn(DetailGRV, "Ma_Phi_I")
        EditMa_HD_I.GetColumn(DetailGRV, "Ma_HD_I")
        EditMa_Sp_I.GetColumn(DetailGRV, "Ma_SP_I")
        EditMa_ku_I.GetColumn(DetailGRV, "Ma_KU_I")
        EditMa_TTLN_i.GetColumn(DetailGRV, "Ma_TTLN_I")
        EditMa_TTCP_i.GetColumn(DetailGRV, "Ma_TTCP_I")
        EditMa_BP_I.GetColumn(DetailGRV, "Ma_BP_I")
        EditMa_HS_I.GetColumn(DetailGRV, "Ma_Hs_I")
        EditMa_CD_I.GetColumn(DetailGRV, "Ma_CD_I")

        EditMa_TD1_I.GetColumn(DetailGRV, "Ma_TD1_I")
        EditMa_TD2_I.GetColumn(DetailGRV, "Ma_TD2_I")
        EditMa_TD3_I.GetColumn(DetailGRV, "Ma_TD3_I")
        EditMa_TD4_I.GetColumn(DetailGRV, "Ma_TD4_I")
        EditMa_TD5_I.GetColumn(DetailGRV, "Ma_TD5_I")

        EditSo_So.GetColumn(DetailGRV, "SO_SO")
        EditSo_Po.GetColumn(DetailGRV, "SO_PO")
        EditSo_Ro.GetColumn(DetailGRV, "SO_RO")
        EditSo_VT.GetColumn(DetailGRV, "SO_VT")

        Editma_Db_I.GetColumn(DetailGRV, "Ma_Db_I")
        EditMa_Xe_I.GetColumn(DetailGRV, "MA_XE_I")
        EditMa_Tuyen_I.GetColumn(DetailGRV, "Ma_TUYEN_I")
        EditMa_Ts.GetColumn(DetailGRV, "Ma_Ts")
        EditMa_Cc.GetColumn(DetailGRV, "Ma_Cc")
    End Sub
    Private Sub V_SetFocus(ByVal _Loai As String)
        _Loai = _Loai.Trim.ToUpper
        Select Case _Loai
            Case "M"
                If DrDmct.Item("M_Ngay_CT").ToString.Trim <> "1" Then TxtNgay_Ct.Focus() Else TxtLenh_RO.Focus()
            Case "S"
            Case "L"
                CmdPrint.Select()
        End Select
    End Sub
    Private Sub GetRound()
        M_R_TIEN = DrDmct.Item("M_R_Tien")
        M_R_TIEN_NT = DrDmct.Item("M_R_Tien_NT")
        M_R_GIA = DrDmct.Item("M_R_GIA")
        M_R_GIA_NT = DrDmct.Item("M_R_GIA_NT")
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.ToUpper.Trim = osysvar("M_MA_NT0").ToString.Trim.ToUpper Then
            M_R_GIA_NT = M_R_GIA
            M_R_TIEN_NT = M_R_TIEN
        End If
    End Sub
#End Region
#Region "V_AddHandler"
    Private Sub V_AddHandler()
        V_AddHandler_System()
        V_AddHandler_Master()
        V_AddHandler_Detail()
    End Sub
    Private Sub V_AddHandler_System()
        AddHandler Me.KeyDown, AddressOf FrmMain_KeyDown
        '---
        AddHandler CmdSave.Click, AddressOf V_Save
        AddHandler CmdNew.Click, AddressOf V_New
        AddHandler CmdEdit.Click, AddressOf V_Edit
        AddHandler CmdDelete.Click, AddressOf V_Delete
        AddHandler CmdCancel.Click, AddressOf V_Cancel
        AddHandler CmdPrint.Click, AddressOf V_Print
        AddHandler CmdView.Click, AddressOf V_View
        AddHandler CmdSearch.Click, AddressOf V_Search
        AddHandler CmdExit.Click, AddressOf V_Exit

        AddHandler CmdImport.Click, AddressOf V_Import
        AddHandler CmdCopy.Click, AddressOf V_Copy
        AddHandler CmdHuy_HD.Click, AddressOf V_Huy_HD
        '---
        AddHandler DetailGRV.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing
        AddHandler DetailGRV.KeyDown, AddressOf MasterGRV_KeyDown
        '---
        AddHandler CbbMa_GD.SelectedValueChanged, AddressOf L_Ma_GD
    End Sub
    Private Sub L_Ma_GD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_AddHandler_Master()

        AddHandler TxtMa_Quyen.Leave, AddressOf L_Ma_Quyen
        AddHandler TxtNgay_Ct.Leave, AddressOf V_Ngay_Ct
        AddHandler TxtNgay_LCt.Leave, AddressOf V_Ngay_LCt
        AddHandler txtSo_ct.Enter, AddressOf V_So_Ct
        AddHandler TxtMa_NT.Leave, AddressOf L_Ma_NT
        AddHandler TxtTy_Gia.Leave, AddressOf L_Ty_Gia
        '--Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberValiting, AddressOf V_Ma_BP_H
        AddHandler TxtMa_Bp_H.CyberLeave, AddressOf L_Ma_BP_H
        '--Ma_HS_H
        AddHandler TxtMa_Hs_H.CyberValiting, AddressOf V_Ma_HS_H
        AddHandler TxtMa_Hs_H.CyberLeave, AddressOf L_Ma_HS_H

        AddHandler TxtT_Thue_Cong.Leave, AddressOf V_E_Thue
        AddHandler TxtT_Thue_hang.Leave, AddressOf V_E_Thue
        '----------------------------------------------------------------------------------------------------------
        AddHandler TxtLenh_SO.Leave, AddressOf L_Lenh_So
        AddHandler TxtLenh_PO.Leave, AddressOf L_Lenh_Po

        AddHandler TxtLenh_Vt.Leave, AddressOf L_Lenh_VT
        AddHandler TxtLenh_RO.Leave, AddressOf L_Lenh_Ro

        AddHandler CmdXe_Ra.Click, AddressOf V_Xe_Ra
        AddHandler cmdXac_nhan_I.Click, AddressOf V_Xac_nhan_I
        AddHandler BttDelIsCv.Click, AddressOf V_DelIsCv
        AddHandler CmdDe_Nghi.Click, AddressOf V_DeNghi

    End Sub
    Private Sub V_AddHandler_Detail()
        If Not EditSo_Luong.Column Is Nothing Then AddHandler EditSo_Luong.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditGia_NT.Column Is Nothing Then AddHandler EditGia_NT.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditGia.Column Is Nothing Then AddHandler EditGia.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditTien_NT.Column Is Nothing Then AddHandler EditTien_NT.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditTien.Column Is Nothing Then AddHandler EditTien.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditDien_Giaii.Column Is Nothing Then AddHandler EditDien_Giaii.EditColumn.Enter, AddressOf E_Dien_Giaii
        '-------------------------------------
        EditTk_VT.V_ActiLookUpColumn(AddressOf V_Tk_VT, AddressOf L_Tk_VT)
        EditMa_Nx_I.V_ActiLookUpColumn(AddressOf V_Ma_Nx_I, AddressOf L_Ma_Nx_I)
        EditMa_lo.V_ActiLookUpColumn(AddressOf V_Ma_Lo, AddressOf L_Ma_Lo)
        EditMa_VT.V_ActiLookUpColumn(AddressOf V_Ma_Vt, AddressOf L_Ma_Vt)
        EditMa_Kho_I.V_ActiLookUpColumn(AddressOf V_Ma_Kho_i, AddressOf L_Ma_Kho_i)
        EditMa_Vitri.V_ActiLookUpColumn(AddressOf V_Ma_Vitri, AddressOf L_Ma_Vitri)
        EditMa_Vv_I.V_ActiLookUpColumn(AddressOf V_Ma_Vv_i, AddressOf L_Ma_Vv_i)
        EditMa_phi_i.V_ActiLookUpColumn(AddressOf V_Ma_Phi_i, AddressOf L_Ma_Phi_i)
        EditMa_HD_I.V_ActiLookUpColumn(AddressOf V_Ma_HD_i, AddressOf L_Ma_HD_i)
        EditMa_Sp_I.V_ActiLookUpColumn(AddressOf V_Ma_SP_i, AddressOf L_Ma_SP_i)
        EditMa_ku_I.V_ActiLookUpColumn(AddressOf V_Ma_KU_i, AddressOf L_Ma_KU_i)
        EditMa_TTLN_i.V_ActiLookUpColumn(AddressOf V_Ma_TTLN_i, AddressOf L_Ma_TTLN_i)
        EditMa_TTCP_i.V_ActiLookUpColumn(AddressOf V_Ma_TTCP_i, AddressOf L_Ma_TTCP_i)
        EditMa_BP_I.V_ActiLookUpColumn(AddressOf V_Ma_Bp_i, AddressOf L_Ma_Bp_i)
        EditMa_HS_I.V_ActiLookUpColumn(AddressOf V_Ma_HS_i, AddressOf L_Ma_HS_i)
        EditMa_CD_I.V_ActiLookUpColumn(AddressOf V_Ma_CD_i, AddressOf L_Ma_CD_i)
        EditMa_TD1_I.V_ActiLookUpColumn(AddressOf V_Ma_TD1_i, AddressOf L_Ma_TD1_i)
        EditMa_TD2_I.V_ActiLookUpColumn(AddressOf V_Ma_TD2_i, AddressOf L_Ma_TD2_i)
        EditMa_TD3_I.V_ActiLookUpColumn(AddressOf V_Ma_TD3_i, AddressOf L_Ma_TD3_i)
        EditMa_TD4_I.V_ActiLookUpColumn(AddressOf V_Ma_TD4_i, AddressOf L_Ma_TD4_i)
        EditMa_TD5_I.V_ActiLookUpColumn(AddressOf V_Ma_TD5_i, AddressOf L_Ma_TD5_i)
        Editma_Db_I.V_ActiLookUpColumn(AddressOf V_Ma_Db_i, AddressOf L_Ma_Db_i)
        EditMa_Xe_I.V_ActiLookUpColumn(AddressOf V_Ma_Xe_i, AddressOf L_Ma_Xe_i)
        EditMa_KX_I.V_ActiLookUpColumn(AddressOf V_Ma_Kx_i, AddressOf L_Ma_Kx_i)
        EditMa_Tuyen_I.V_ActiLookUpColumn(AddressOf V_Ma_Tuyen_i, AddressOf L_Ma_Tuyen_i)
        EditMa_Ts.V_ActiLookUpColumn(AddressOf V_Ma_Ts, AddressOf L_Ma_Ts)
        EditMa_Cc.V_ActiLookUpColumn(AddressOf V_Ma_Cc, AddressOf L_Ma_Cc)
        If Not EditSo_So.Column Is Nothing Then AddHandler EditSo_So.EditColumn.Leave, AddressOf L_So_So
        If Not EditSo_Po.Column Is Nothing Then AddHandler EditSo_Po.EditColumn.Leave, AddressOf L_So_Po
        If Not EditSo_Ro.Column Is Nothing Then AddHandler EditSo_Ro.EditColumn.Leave, AddressOf L_So_Ro
        If Not EditSo_VT.Column Is Nothing Then AddHandler EditSo_VT.EditColumn.Leave, AddressOf L_So_VT
    End Sub
    Private Sub VisibleColumnMa_NT()
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_Ma_NT0").ToString.Trim.ToUpper Then
            EditTien.Visible = False
            EditGia.Visible = False
        Else
            EditTien.Visible = True
            EditGia.Visible = True
        End If
        CyberFill.SetFoCusGRV(DetailGRV, M_Mode)
    End Sub
    Private Sub VisibleColumnMa_GD()
        Enableloc_Ro()
    End Sub
    Protected Overrides Sub V_Databing()
        Dim i As Integer
        Dim Drv As DataRowView
        Drv = Nothing

        For i = 0 To Dv_Master.Count - 1
            If Dv_Master.Item(i).Item("Stt_Rec").ToString.Trim = M_Stt_Rec.Trim Then
                Drv = Dv_Master.Item(i)
                Exit For
            End If
        Next

        CyberSmodb.SetValueTObj(Me, Drv)
        If Drv Is Nothing Then
            TxtMa_NT.Text = M_Ma_Nt
            TxtNgay_Ct.Value = Now.Date
            Dim _DT As Date = TxtNgay_Ct.Value
            TxtTy_Gia.Double = CyberSupport.GetRate(_DT, TxtMa_NT.Text, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
            CbbMa_GD.SelectedValue = M_Ma_GD
            CbbMa_Post.SelectedValue = M_Ma_Post
        End If

        Dt_DetailTmp.Clear()
        Dt_DetailTmp.AcceptChanges()
        For i = 0 To Dt_Detail.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'").Length - 1
            Dt_DetailTmp.ImportRow(Dt_Detail.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(i))
        Next

        Dt_DetailCvTmp.Clear()
        Dt_DetailCvTmp.AcceptChanges()
        For i = 0 To Dt_DetailCv.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'").Length - 1
            Dt_DetailCvTmp.ImportRow(Dt_DetailCv.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(i))
        Next

        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_Ma_NT0").ToString.Trim.ToUpper
        M_Count = Dt_Master.Rows.Count
        '---------------------------------------------------------
        UpdateList()
        VisibleColumnMa_NT()
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_Setstatus()
        If (M_Mode = "M" Or M_Mode = "S") Then
            DetailGRV.OptionsBehavior.Editable = True
            If DrDmct.Item("M_Ngay_LCT").ToString.Trim = "1" Then TxtNgay_LCt.ReadOnly = False Else TxtNgay_LCt.ReadOnly = True 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Ngay_CT").ToString.Trim = "1" Then TxtNgay_Ct.ReadOnly = True Else TxtNgay_Ct.ReadOnly = False 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Au_So_CT").ToString.Trim = "1" Then txtSo_ct.ReadOnly = True Else txtSo_ct.ReadOnly = False 'Tu dong danh so chung tu
        Else
            DetailGRV.OptionsBehavior.Editable = False
        End If
        If M_Mode = "S" Then CbbMa_GD.Enabled = False
        If M_Mode = "M" Then CbbMa_GD.Enabled = True
        TxtMa_Xe.ReadOnly = True
        CyberFill.SetFoCusGRV(DetailGRV, M_Mode)
        SetTxt()
        Enableloc_Ro()
    End Sub
    Private Sub V_GetDateVoucher(ByVal _Mode As String, ByRef _Ngay_Ct As Date, ByRef _Ngay_LCT As Date)
        Dim _DtReturn As DataTable = CyberSupport.V_GetDateVoucher(_Mode, _Ngay_Ct, _Ngay_LCT, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        If _DtReturn Is Nothing Then Exit Sub Else If _DtReturn.Rows.Count <= 0 Then Exit Sub
        If Not _DtReturn.Columns.Contains("Status") Then Exit Sub
        If _DtReturn.Rows(0).Item("Status").ToString.Trim = "N" Then Exit Sub
        If Not DrDmct.Item("M_Ngay_LCt").ToString.Trim = "1" Then TxtNgay_LCt.Value = _DtReturn.Rows(0).Item("Ngay_HT")
        If DrDmct.Item("M_Ngay_Ct").ToString.Trim = "1" Then TxtNgay_Ct.Value = _DtReturn.Rows(0).Item("Ngay_HT")
        _Ngay_Ct = TxtNgay_Ct.Value
        _Ngay_LCT = TxtNgay_Ct.Value
    End Sub
    Private Sub V_GetNoVoucherAuto()
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" And txtSo_ct.Text.Trim <> "" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucherAuto(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
#End Region
#Region "Valid --- Tao phieu Xe Ra "
    Private Sub V_Xe_Ra(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Xe.Text.Trim.Replace("#", "").Trim = "" Then Exit Sub
        Dim strAddParar As String = "2#TD2#" + TxtMa_Xe.Text.Trim.Replace("#", "") + "#"
        Dim _Process As Process = CyberSmlib.V_CallRun("Cyber.Input.dll", Me.Para, strAddParar)
        If Not _Process Is Nothing Then ProccessList.Add(_Process)
    End Sub

#End Region
#Region "Valid - Master"
    Private Sub V_Xac_nhan_I(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Mode.Trim = "M" Or M_Mode.Trim = "S" Then Return
    End Sub
    Private Sub V_E_Thue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        UpdateList()
    End Sub
    Private Sub V_Sua_Thue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Not ChkSua_Thue.Checked Then
            TxtT_Thue_Cong.BackColor = Drawing.Color.White
            TxtT_Thue_hang.BackColor = Drawing.Color.White
            TxtT_Thue_Nt.BackColor = Drawing.Color.White
            TxtT_Thue_hang.ReadOnly = True
            TxtT_Thue_Cong.ReadOnly = True
        Else
            TxtT_Thue_Cong.BackColor = Drawing.Color.Pink
            TxtT_Thue_hang.BackColor = Drawing.Color.Pink
            TxtT_Thue_Nt.BackColor = Drawing.Color.Pink

            TxtT_Thue_hang.ReadOnly = False
            TxtT_Thue_Cong.ReadOnly = False
            TxtT_Thue_hang.Focus()
        End If
        UpdateList()
    End Sub
#Region "Valid --- DMQuyen"
    Private Sub L_Ma_Quyen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Quyen.Text = "" Then Exit Sub
        DrReturn = Nothing
        CyberSmlistSys.Lookup(M_LAN, M_Para, osysvar, AppConn, M_DsLookUp, TxtMa_Quyen.Text, "ma_Quyen", "DmQuyen", DrReturn, "1=1", "1=1", "1")
        If DrReturn Is Nothing Then TxtMa_Quyen.Text = "" Else TxtMa_Quyen.Text = DrReturn.Item("ma_Quyen")
    End Sub
#End Region
#Region "Valid --- Ma_KH"
    Private Sub V_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        'TxtMa_Kh.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_kh", "DmKh", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        'If TxtMa_Kh.Text = "" Then
        TxtTen_kh.Text = ""
        Exit Sub
        'End If
        'DrReturn = TxtMa_Kh.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            'TxtMa_Kh.Text = DrReturn("Ma_kh").ToString.Trim
            If DrReturn("ten_kh").ToString.Trim <> "" Then TxtTen_kh.Text = DrReturn("ten_kh").ToString.Trim
            If DrReturn("Dia_Chi").ToString.Trim <> "" Then TxtDia_Chi.Text = DrReturn("Dia_Chi").ToString.Trim

            'If DrReturn("ten_khVat").ToString.Trim <> "" Then TxtTen_khVat.Text = DrReturn("ten_khVat").ToString.Trim
            'If DrReturn("Dia_ChiVat").ToString.Trim <> "" Then TxtDia_ChiVat.Text = DrReturn("Dia_ChiVat").ToString.Trim
            'If DrReturn("Ma_So_Thue").ToString.Trim <> "" Then TxtMa_So_Thue.Text = DrReturn("Ma_So_Thue").ToString.Trim

            'txtOng_ba.Text = IIf(txtOng_ba.Text.Trim = "", DrReturn("Ong_ba").ToString.Trim, txtOng_ba.Text)
            TxtHan_TT.Text = IIf(TxtHan_TT.Text.Trim = "0" Or TxtHan_TT.Text.Trim = "", DrReturn("Han_tt").ToString.Trim, TxtHan_TT.Text)
            'TxtTen_khVat.Text = IIf(TxtTen_khVat.Text.Trim = "", DrReturn("Ten_khVAT").ToString.Trim, TxtTen_khVat.Text.Trim)
            'TxtDia_ChiVat.Text = IIf(TxtDia_ChiVat.Text.Trim = "", DrReturn("Dia_ChiVAT").ToString.Trim, TxtDia_ChiVat.Text.Trim)
            'TxtMa_So_Thue.Text = IIf(TxtMa_So_Thue.Text.Trim = "", DrReturn("Ma_So_Thue").ToString.Trim, TxtMa_So_Thue.Text.Trim)

            'If TxtEmailHDDT.Text.Trim = "" Then If DrReturn.Table.Columns.Contains("E_Mail") Then TxtEmailHDDT.Text = DrReturn.Item("E_Mail").ToString.Trim

        Else
            'TxtMa_Kh.Text = ""
            TxtTen_kh.Text = ""
            TxtDia_Chi.Text = ""
        End If
    End Sub
#End Region
#Region "Valid --- Ma_BP_H"
    Private Sub V_Ma_BP_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtMa_Bp_H.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_BP", "DmBP", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_BP_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Bp_H.Text = "" Then
            txtTen_BP_H.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Bp_H.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Bp_H.Text = DrReturn.Item("Ma_BP")
            txtTen_BP_H.Text = DrReturn.Item("Ten_BP")
        Else
            TxtMa_Bp_H.Text = ""
            txtTen_BP_H.Text = ""
        End If
    End Sub
#End Region
#Region "Valid --- Ma_HS_H"
    Private Sub V_Ma_HS_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        TxtMa_Hs_H.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_HS", "DmHS", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_HS_H(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Hs_H.Text = "" Then
            TxtTen_Hs_H.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Hs_H.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Hs_H.Text = DrReturn.Item("Ma_HS")
            TxtTen_Hs_H.Text = DrReturn.Item("Ten_HS")
        Else
            TxtMa_Hs_H.Text = ""
            TxtTen_Hs_H.Text = ""
        End If
    End Sub
#End Region
#Region "Valid --- Ma_Nx"
    Private Sub V_Ma_Nx(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        sender.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "tk", "DmTK", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_Nx(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        'If txtMa_NX.Text = "" Then
        '    TxtTen_Nx.Text = ""
        Exit Sub
        'End If
        DrReturn = sender.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            'txtMa_NX.Text = DrReturn("Tk").ToString.Trim
            'TxtTen_Nx.Text = DrReturn("ten_tk").ToString.Trim
        Else
            'txtMa_NX.Text = ""
            'TxtTen_Nx.Text = ""
        End If

    End Sub
#End Region
#Region "Valid --- MaU_HD"
    Private Sub V_Mau_hd(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        sender.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Mau_HD", "DmMauHd", "1=1", "1=1")
    End Sub
    Private Sub L_Mau_hd(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        'If TxtMau_HD.Text = "" Then
        Exit Sub
        'End If
        DrReturn = sender.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            'TxtMau_HD.Text = DrReturn("Mau_HD").ToString.Trim

        Else
            'TxtMau_HD.Text = ""
        End If

    End Sub
#End Region
#Region "Lenh/SO/Po/Ro/Vt/So_Lenh"
    Private Sub L_Lenh_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_SO.Text = CyberVoucher.V_GetSo_SO(M_Ma_CT, CbbMa_GD.SelectedValue, CbbMa_Post.SelectedValue, _Dt, TxtLenh_SO.Text, M_Ma_Dvcs)
    End Sub
    Private Sub L_Lenh_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_PO.Text = CyberVoucher.V_GetSo_PO(M_Ma_CT, CbbMa_GD.SelectedValue, CbbMa_Post.SelectedValue, _Dt, TxtLenh_PO.Text, TxtMa_Dvcs.Text)
    End Sub
    Private Sub L_Lenh_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M") Then Exit Sub
        Dim _Ngay_CT As Date = TxtNgay_Ct.Value
        If TxtLenh_RO.Text = "" Then Exit Sub


        'TxtLenh_RO.Text = CyberVoucher.V_GetSo_Ro(M_Ma_CT, "S", M_Mode, _Ngay_CT, TxtLenh_RO.Text, TxtMa_Dvcs.Text)

        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_RO.Text = CyberVoucher.V_FormatSo_Ro(AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Dt, TxtLenh_RO.Text, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)

        V_Lenh_RO()

        'If TxtTien_HD.Double <> 0 Then
        'L_Tien_Hd()
        'End If

    End Sub
    Private Sub L_Lenh_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        TxtLenh_Vt.Text = CyberVoucher.V_GetSo_VT(M_Ma_CT, CbbMa_GD.SelectedValue, CbbMa_Post.SelectedValue, _Dt, TxtLenh_Vt.Text, TxtMa_Dvcs.Text)
    End Sub
#End Region
    Private Sub L_Ma_TT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If CbbMa_GD.SelectedValue.ToString.Trim <> "1" Then Exit Sub
        L_Lenh_Ro(sender, e)
        For i = 0 To tbDmSttHD.Rows.Count - 1
            If tbDmSttHD.Rows.Item(i).Item("Hd_Nb").ToString.Trim = "1" Then
                Exit For
            End If
        Next

    End Sub
    Private Sub L_Ma_Tang(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
    End Sub
    Private Sub L_So_seri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
        L_So_seri()
        L_Lenh_Ro(sender, e)
    End Sub
    Private Sub L_So_seri()
        Dim _dt As Date = TxtNgay_Ct.Value

        For i = 0 To tbDmSttHD.Rows.Count - 1
            If tbDmSttHD.Rows.Item(i).Item("HD_VAT").ToString.Trim = "1" Then
                Exit For
            Else
                Exit For
            End If

        Next
    End Sub
    Private Sub V_Lenh_RO()
        If TxtLenh_RO.Text = "" Then Exit Sub
        Dim _Ngay_CT As Date = TxtNgay_Ct.Value
        Dim nCount As Integer
        Dim strFiled = "", strValues As String = ""
        CyberSmodb.GetValueControler(Me, strFiled, strValues, "")

        Dim DsLenh_RO As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_GetdetailHPTDefault", "0#1#" & M_Stt_Rec & "#" & M_Ma_CT & "#" & _Ngay_CT.ToString("yyyyMMdd") & "#" & _Ngay_CT.ToString("yyyyMMdd") & "#" & M_Mode & "#" & strFiled & "#" & strValues & "#" & M_Ma_Dvcs & "#" & M_User_Name)

        nCount = DsLenh_RO.Tables.Count

        For i = 0 To nCount - 1
            CyberSmodb.SetNotNullTable(DsLenh_RO.Tables(i))
        Next

        If Not CyberSupport.V_MsgChk(DsLenh_RO.Tables(0), Me.SysVar, Me.Lan) Then
            TxtLenh_RO.Text = ""
            TxtLenh_RO.Focus()
            DsLenh_RO.Dispose()
            Dt_DetailTmp.Rows.Clear()
            Dt_DetailCvTmp.Rows.Clear()
            ChkSua_Thue.Checked = False
            UpdateList()
            Exit Sub
        End If
        ChkSua_Thue.Checked = False
        V_UpdateMaster(DsLenh_RO.Tables(0), DsLenh_RO.Tables(2), DsLenh_RO.Tables(3))
        DsLenh_RO.Dispose()
    End Sub
    Private Sub V_UpdateMaster(ByVal _Dt_Master As DataTable, ByVal _Dt_DetailCV As DataTable, ByVal _Dt_DetailVT As DataTable)
        If Not _Dt_Master Is Nothing Then
            If _Dt_Master.Rows.Count > 0 Then
                If _Dt_Master.Columns.Contains("Ten_kh") Then TxtTen_kh.Text = _Dt_Master.Rows(0).Item("Ten_kh")
                If _Dt_Master.Columns.Contains("Dia_Chi") Then TxtDia_Chi.Text = _Dt_Master.Rows(0).Item("Dia_Chi")

                If _Dt_Master.Columns.Contains("Dien_Giai") Then txtDien_giai.Text = _Dt_Master.Rows(0).Item("Dien_Giai")

                If _Dt_Master.Columns.Contains("Ma_Xe") Then TxtMa_Xe.Text = _Dt_Master.Rows(0).Item("Ma_Xe")
                If _Dt_Master.Columns.Contains("Ten_vtthue") Then TxtTen_vtthue.Text = _Dt_Master.Rows(0).Item("Ten_vtthue").ToString.Trim

                If _Dt_Master.Columns.Contains("ma_Hs_H") Then TxtMa_Hs_H.Text = _Dt_Master.Rows(0).Item("ma_Hs_H").ToString.Trim
                If _Dt_Master.Columns.Contains("ten_Hs_H") Then TxtTen_Hs_H.Text = _Dt_Master.Rows(0).Item("ten_Hs_H").ToString.Trim

                If _Dt_Master.Columns.Contains("ma_BP_H") Then TxtMa_Bp_H.Text = _Dt_Master.Rows(0).Item("ma_BP_H").ToString.Trim
                If _Dt_Master.Columns.Contains("ten_BP_H") Then txtTen_BP_H.Text = _Dt_Master.Rows(0).Item("ten_BP_H").ToString.Trim
                If _Dt_Master.Columns.Contains("SO_CT") Then txtSo_ct.Text = _Dt_Master.Rows(0).Item("So_CT")
            End If
        End If

        Dt_DetailTmp.Rows.Clear()
        Dt_DetailCvTmp.Rows.Clear()

        CyberSmodb.SQLTbToTb(_Dt_DetailCV, Dt_DetailCvTmp)
        CyberSmodb.SQLTbToTb(_Dt_DetailVT, Dt_DetailTmp)
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            CyberSupport.V_UpdateTTLN_TTCP(AppConn, osysvar, M_Ma_CT, M_Mode, TxtMa_Dvcs.Text.Trim, M_User_Name, Dv_DetailTmp, iRow, DetailGRV, CyberSmlib, CyberSmodb)
        Next
        For iRow As Integer = 0 To Dv_DetailCvTmp.Count - 1
            CyberSupport.V_UpdateTTLN_TTCP(AppConn, osysvar, M_Ma_CT, M_Mode, TxtMa_Dvcs.Text.Trim, M_User_Name, Dv_DetailCvTmp, iRow, DetailGRVCv, CyberSmlib, CyberSmodb)
        Next
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        UpdateList()
    End Sub
    Private Sub V_Loc_RO(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode.Trim = "M") Then Exit Sub
        Dim frm As New FrmLocRo
        frm._Ds_LoolUp = DsLookup
        frm.Lan = M_LAN
        frm.Para = M_Para
        frm.Sysvar = osysvar
        frm.AppConn = AppConn
        frm.CyberSmlib = CyberSmlib
        frm.CyberSupport = CyberSupport
        frm.CyberFill = CyberFill
        frm.CyberSmlistSys = CyberSmlistSys
        frm.CyberSmodb = CyberSmodb
        frm.CyberExport = Nothing
        frm.CyberVoucher = CyberVoucher
        frm.CyberLoading = CyberLoading
        frm.ShowInTaskbar = False
        frm.Stt_rec = M_Stt_Rec
        frm.Ma_Ct = M_Ma_CT
        frm.Mode = M_Mode
        frm.ShowDialog()
        If Not frm.Save_OK Then Exit Sub
        TxtLenh_RO.Text = ""
        'TxtMa_Xe.Text = frm.Ma_Xe.Trim

        V_UpdateMaster(frm.Master_Return, frm.CV_Return, frm.Vt_Return)
        '------------------------------------------------------------
        L_So_seri()
    End Sub
    Private Sub L_Tien_Hd()
        If Not (M_Mode = "M") Then Return

        Dim _dt As Date = TxtNgay_Ct.Value
        Dim nCount As Integer = Dt_DetailTmp.Rows.Count
        Dim nCountcv As Integer = Dt_DetailCvTmp.Rows.Count
        Dim DsTmp As New DataSet

        Dim _StrDetail As String = ""
        Dim _StrDetailCv As String = ""

        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            _StrDetail = _StrDetail + ";INSERT PBHD SELECT " + (i + 1).ToString.Trim
            _StrDetail = _StrDetail + ", N'" + Dt_DetailTmp.Rows(i).Item("Rec_Ro").ToString.Trim + "'"
            _StrDetail = _StrDetail + ", N'" + Dt_DetailTmp.Rows(i).Item("Rec0_Ro").ToString.Trim + "'"
            _StrDetail = _StrDetail + ", N'" + Dt_DetailTmp.Rows(i).Item("Tien_hang").ToString.Trim.Replace(",", ".").Replace(" ", "") + "'"
            _StrDetail = _StrDetail + ", N'" + Dt_DetailTmp.Rows(i).Item("Thue").ToString.Trim.Replace(",", ".").Replace(" ", "") + "'"
        Next


        For i As Integer = 0 To Dt_DetailCvTmp.Rows.Count - 1
            _StrDetailCv = _StrDetailCv + ";INSERT PBCVHD SELECT " + (i + 1).ToString.Trim
            _StrDetailCv = _StrDetailCv + ", N'" + Dt_DetailCvTmp.Rows(i).Item("Rec_Ro").ToString.Trim + "'"
            _StrDetailCv = _StrDetailCv + ", N'" + Dt_DetailCvTmp.Rows(i).Item("Rec0_Ro").ToString.Trim + "'"
            _StrDetailCv = _StrDetailCv + ", N'" + Dt_DetailCvTmp.Rows(i).Item("Tien_hang").ToString.Trim.Replace(",", ".").Replace(" ", "") + "'"
            _StrDetailCv = _StrDetailCv + ", N'" + Dt_DetailCvTmp.Rows(i).Item("Thue").ToString.Trim.Replace(",", ".").Replace(" ", "") + "'"
        Next
        Dim _Pb As String = "0"

        If _Pb = "0" Then
            For i As Integer = DsTmp.Tables(1).Rows.Count - 1 To Dt_DetailTmp.Rows.Count - 1
                If i >= 0 Then
                    If i = DsTmp.Tables(1).Rows.Count - 1 Then
                        If DsTmp.Tables(1).Columns.Contains("Tien_hang") And Dt_DetailTmp.Rows(i).Item("Tien_Hang") <> DsTmp.Tables(1).Rows(i).Item("Tien_hang") Then
                            If DsTmp.Tables(1).Columns.Contains("Tien_hang") Then Dt_DetailTmp.Rows(i).Item("Tien_Hang") = DsTmp.Tables(1).Rows(i).Item("Tien_hang")
                            If DsTmp.Tables(1).Columns.Contains("Thue") Then Dt_DetailTmp.Rows(i).Item("Thue") = DsTmp.Tables(1).Rows(i).Item("Thue")
                            Dt_DetailTmp.Rows(i).Item("Gia2") = 0
                        End If
                    Else
                        Dt_DetailTmp.Rows(i).Delete()
                    End If
                End If
            Next
            For i As Integer = DsTmp.Tables(2).Rows.Count - 1 To Dt_DetailCvTmp.Rows.Count - 1
                If i >= 0 Then
                    If i = DsTmp.Tables(2).Rows.Count - 1 Then
                        If DsTmp.Tables(2).Columns.Contains("Tien_hang") And Dt_DetailCvTmp.Rows(i).Item("Tien_Hang") <> DsTmp.Tables(2).Rows(i).Item("Tien_hang") Then
                            If DsTmp.Tables(2).Columns.Contains("Tien_hang") Then Dt_DetailCvTmp.Rows(i).Item("Tien_Hang") = DsTmp.Tables(2).Rows(i).Item("Tien_hang")
                            If DsTmp.Tables(2).Columns.Contains("Thue") Then Dt_DetailCvTmp.Rows(i).Item("Thue") = DsTmp.Tables(2).Rows(i).Item("Thue")
                        End If
                    Else
                        Dt_DetailCvTmp.Rows(i).Delete()
                    End If
                End If
            Next
            Dt_DetailTmp.AcceptChanges()
            Dt_DetailCvTmp.AcceptChanges()
        End If

        '----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        UpdateList()
        DsTmp.Dispose()
    End Sub
    Sub Enableloc_Ro()
        If Not (M_Mode = "M" Or M_Mode = "S") Then
            CmdDe_Nghi.Enabled = True
            Exit Sub
        End If
        CmdDe_Nghi.Enabled = False
        If CbbMa_GD.SelectedValue = "1" Then
        Else
        End If
        If M_Mode = "S" Then CbbMa_GD.Enabled = False
    End Sub
#End Region
#Region "Valid - Detail"
#Region "Valid - Detail - Core"
    Private Sub UpdateList()
        Dim i As Integer
        Dim nT_Thue_Cong As Decimal = 0
        Dim nT_Tien_Cong As Decimal = 0
        Dim nT_Tong_Cong As Decimal = 0

        Dim nT_Thue_Hang As Decimal = 0
        Dim nT_Tien_Hang As Decimal = 0
        Dim nT_Tong_Hang As Decimal = 0

        Dim nT_Tien_Nt2 As Decimal = 0
        Dim nT_Tien2 As Decimal = 0

        Dim nT_Thue_Nt As Decimal = 0
        Dim nT_Thue As Decimal = 0

        Dim nT_TT_Nt As Decimal = 0
        Dim nT_TT As Decimal = 0

        For i = 0 To Dt_DetailTmp.Rows.Count - 1
            nT_Tien_Hang = nT_Tien_Hang + Dt_DetailTmp.Rows(i).Item("Tien_hang")
            nT_Thue_Hang = nT_Thue_Hang + Dt_DetailTmp.Rows(i).Item("Thue")
        Next

        For i = 0 To Dt_DetailCvTmp.Rows.Count - 1
            nT_Tien_Cong = nT_Tien_Cong + Dt_DetailCvTmp.Rows(i).Item("Tien_Hang")
            nT_Thue_Cong = nT_Thue_Cong + Dt_DetailCvTmp.Rows(i).Item("Thue")
        Next

        If (M_Mode = "M" Or M_Mode = "S") Then
            If ChkSua_Thue.Checked And nT_Thue_Cong = 0 Then TxtT_Thue_Cong.Double = 0
            If ChkSua_Thue.Checked And nT_Thue_Hang = 0 Then TxtT_Thue_hang.Double = 0
        End If
        If ChkSua_Thue.Checked Then nT_Thue_Cong = TxtT_Thue_Cong.Double
        If ChkSua_Thue.Checked Then nT_Thue_Hang = TxtT_Thue_hang.Double

        nT_Tong_Cong = nT_Thue_Cong + nT_Tien_Cong
        nT_Tong_Hang = nT_Thue_Hang + nT_Tien_Hang

        '----
        TxtT_Tien_Cong.Double = nT_Tien_Cong
        TxtT_Thue_Cong.Double = nT_Thue_Cong
        TxtT_Tong_Cong.Double = nT_Tong_Cong
        '----
        TxtT_Tien_Hang.Double = nT_Tien_Hang
        TxtT_Thue_hang.Double = nT_Thue_Hang
        TxtT_Tong_Hang.Double = nT_Tong_Hang
        '----
        nT_Tien_Nt2 = nT_Tien_Hang + nT_Tien_Cong
        nT_Thue_Nt = nT_Thue_Hang + nT_Thue_Cong

        nT_Tien2 = nT_Tien_Nt2
        nT_Thue = nT_Thue_Nt

        '-------
        nT_TT_Nt = nT_Tien_Nt2 + nT_Thue_Nt
        nT_TT = nT_TT_Nt
        '-------
        TxtT_Tien2.Double = nT_Tien2
        TxtT_Tien_Nt2.Double = nT_Tien_Nt2
        '----
        TxtT_Thue.Double = nT_Thue
        TxtT_Thue_Nt.Double = nT_Thue_Nt
        '----
        TxtT_TT.Double = nT_TT.ToString
        TxtT_TT_NT.Double = nT_TT_Nt

    End Sub
    'Private Sub V_GetTiencoc()
    '    Dim Dt As Date
    '    Dim DsTTBH As DataSet
    '    Dt = TxtNgay_Ct.Value
    '    DsTTBH = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_HDSTiencoc", TxtLenh_RO.Text & "#" & M_Stt_Rec & "#" & Dt.ToString("yyyyMMdd") & "#" & _
    '    M_Ma_Dvcs + "#" + M_User_Name)


    '    TxtTien_coc.Double = DsTTBH.Tables(0).Rows(0).Item("Tien_coc")

    '    UpdateList()
    '    DsTTBH.Dispose()
    'End Sub
    Private Sub V_Tinh_Toan(ByVal iRow As Integer)
        'Dim nTy_Gia As Decimal = V_GetTyGia()
        ''--------------------------------------------------------------------------------
        'If Dv_DetailTmp.Item(iRow).Item("So_Luong") * Dv_DetailTmp.Item(iRow).Item("Gia_NT") <> 0 Then
        '    Dv_DetailTmp.Item(iRow).BeginEdit()
        '    Dv_DetailTmp.Item(iRow).Item("Tien_NT") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("So_Luong") * Dv_DetailTmp.Item(iRow).Item("Gia_NT"), M_R_TIEN_NT)
        '    Dv_DetailTmp.Item(iRow).EndEdit()
        'End If
        'Dv_DetailTmp.Item(iRow).BeginEdit()

        ''----------------
        'If nTy_Gia = 1 Then
        '    Dv_DetailTmp.Item(iRow).Item("Tien") = Dv_DetailTmp.Item(iRow).Item("Tien_NT")
        '    Dv_DetailTmp.Item(iRow).Item("Gia") = Dv_DetailTmp.Item(iRow).Item("Gia_NT")
        'Else
        '    Dv_DetailTmp.Item(iRow).Item("Tien") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Tien_NT") * nTy_Gia, M_R_TIEN)
        '    Dv_DetailTmp.Item(iRow).Item("Gia") = CyberSupport.V_Round(Dv_DetailTmp.Item(iRow).Item("Gia_NT") * nTy_Gia, M_R_GIA)
        'End If
        'Dv_DetailTmp.Item(iRow).EndEdit()

        CyberSupport.V_UpdateGRV(DetailGRV)
        UpdateList()
    End Sub
    Private Sub L_Tinh_Toan(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DetailGRV.PostEditor()
        Dim drvCurren As DataRowView
        drvCurren = DetailGRV.GetFocusedRow
        CyberSupport.V_UpdateGRV(DetailGRV)
        V_Tinh_Toan(iRow)
    End Sub
    Private Sub V_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_kh_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_kh_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_kh_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub E_Dien_Giaii(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
        'If Not (M_Mode = "M" Or M_Mode = "S") And (M_Is_Delete = "X") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Dv_DetailTmp.Item(iRow).Item("Dien_Giaii").ToString.Trim = "" Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Dien_Giaii") = txtDien_giai.Text
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
        DetailGRV.ShowEditor()

    End Sub
#End Region
#Region "Vat tu kho/Vitri - "
    Private Sub V_Ma_Lo(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Lo(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Lo(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Lo(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub
    Private Sub V_Ma_Vt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        DrReturn = Nothing
        DrReturn = CyberSupport.L_Ma_Vt(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        If DrReturn Is Nothing Then
            iRow = DetailGRV.GetFocusedDataSourceRowIndex
            If iRow < 0 Then Exit Sub
            If Dv_DetailTmp.Item(iRow).Item("MA_VT").ToString.Trim = "" Then
                If Not CyberSupport.V_NhapTiep(osysvar, M_LAN) Then
                    Dv_DetailTmp.Item(iRow).Delete()
                    Dv_DetailTmp.Table.AcceptChanges()
                    UpdateList()
                    SendKeys.Send("^{TAB}")
                End If
            End If
            Exit Sub
        End If

        'Dim _Ma_VT As String = DrReturn.Item("Ma_Vt")

        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _TK_VT As String = DrReturn.Item("TK_Vt")
        Dim _TK_DT As String = DrReturn.Item("TK_DT")
        Dim _Tk_Gv As String = DrReturn.Item("Tk_Gv")
        Dim _Tk_SPDD As String = DrReturn.Item("Tk_SPDD")
        Dim _ma_Nx_I As String = _Tk_SPDD

        Dv_DetailTmp.Item(iRow).BeginEdit()
        Dv_DetailTmp.Item(iRow).Item("Tk_VT") = IIf(Dv_DetailTmp.Item(iRow).Item("Tk_VT").ToString.Trim = "", _TK_VT, Dv_DetailTmp.Item(iRow).Item("Tk_VT").ToString.Trim)
        Dv_DetailTmp.Item(iRow).Item("Ma_Nx_I") = IIf(Dv_DetailTmp.Item(iRow).Item("Ma_Nx_I").ToString.Trim = "", _ma_Nx_I, Dv_DetailTmp.Item(iRow).Item("Ma_Nx_I").ToString.Trim)
        Dv_DetailTmp.Item(iRow).EndEdit()
        Dv_DetailTmp.Table.AcceptChanges()

        V_SetSD(iRow)
    End Sub
    Private Sub V_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kho_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kho_i(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub
    Private Sub V_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vitri(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vitri(M_Mode, M_Ma_CT, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        V_SetSD(iRow)
    End Sub
    Private Sub V_SetSD(ByVal iRow As Integer)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If iRow < 0 Then Exit Sub
        Dim _Ma_Vt As String = Dv_DetailTmp.Item(iRow).Item("Ma_Vt").ToString.Trim
        Dim _Ma_kho As String = Dv_DetailTmp.Item(iRow).Item("Ma_Kho_I").ToString.Trim
        Dim _Ma_Vitri As String = Dv_DetailTmp.Item(iRow).Item("Ma_Vitri").ToString.Trim
        Dim _Ma_Lo As String = If(Dt_DetailTmp.Columns.Contains("Ma_Lo"), Dv_DetailTmp.Item(iRow).Item("Ma_lo").ToString.Trim, "")
        Dim _Return As DataRow = CyberSupport.V_SetSD(StatusFooter1, AppConn, "VT", M_Mode, _Ma_Vt, _Ma_kho, _Ma_Vitri, _Ma_Lo, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib)
        If Dv_DetailTmp.Table.Columns.Contains("Ton13") Then
            Dv_DetailTmp.Item(iRow).BeginEdit()
            Dv_DetailTmp.Item(iRow).Item("Ton13") = If(_Return Is Nothing, 0, _Return("SL"))
            Dv_DetailTmp.Item(iRow).EndEdit()
        End If
    End Sub
#End Region
#Region "Tai khoan "
    Private Sub V_Tk_VT(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk_Vt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Tk_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Tk_Vt(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Nx_I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Nx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Nx_I(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Nx_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_GetSo_SO(Dv_DetailTmp, iRow, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, M_Ma_Dvcs)
    End Sub
    Private Sub L_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_GetSo_PO(Dv_DetailTmp, iRow, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, TxtMa_Dvcs.Text)
    End Sub
    Private Sub L_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_GetSo_RO(Dv_DetailTmp, iRow, M_Ma_CT, "S", M_Mode, _Ngay_Ct, TxtMa_Dvcs.Text)
    End Sub
    Private Sub L_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_GetSo_VT(Dv_DetailTmp, iRow, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, TxtMa_Dvcs.Text)
    End Sub
#End Region
#Region "Valid - Detail - Add On"
    Private Sub V_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vv_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vv_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vv_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Phi_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Phi_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Phi_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hd_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Sp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_SP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Sp_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ku_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KU_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ku_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTLN_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTLN_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTLN_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TTCP_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCP_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TTCP_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Bp_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Bp_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Bp_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Hs_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_HS_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Hs_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cd_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_CD_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cd_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Td1_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD1_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Td1_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD2_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD2_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD2_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD3_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD3_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD4_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD4_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD4_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Db_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Db_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Db_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Xe_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Xe_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Xe_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kx_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kx_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kx_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Tuyen_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Tuyen_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Tuyen_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Ts(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Ts(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Ts(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Ts(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Cc(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Cc(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Cc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Cc(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
#End Region
#End Region
#Region "Ngay ct, ngay lap chung tu,so chung tu"
    Private Sub V_Ngay_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub

        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Ngay_LCt(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_So_Ct(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If DrDmct.Item("M_Au_So_Ct").ToString.Trim = "1" Then Exit Sub
        If Not txtSo_ct.Text.Trim = "" Then Exit Sub
        Dim _Ngay_LCt As Date = TxtNgay_LCt.Value
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        txtSo_ct.Text = CyberSupport.V_GetNoVoucher(M_Mode, txtSo_ct.Text, M_Stt_Rec, _Ngay_Ct, _Ngay_LCt, M_Ma_CT, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
#End Region
#Region "Ty gia -  Ngoai te"
    Private Sub L_Ma_NT(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        DrReturn = Nothing
        CyberSmlistSys.Lookup(M_LAN, M_Para, osysvar, AppConn, DsLookup, TxtMa_NT.Text, "Ma_NT", "DmNT", DrReturn, "1=1", "1=1", "1")
        If Not DrReturn Is Nothing Then TxtMa_NT.Text = DrReturn.Item("Ma_NT") Else TxtMa_NT.Text = ""
        Dim Dt As Date = TxtNgay_Ct.Value
        TxtTy_Gia.Double = CyberSupport.GetRate(Dt, TxtMa_NT.Text, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        GetRound()
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next

        VisibleColumnMa_NT()
    End Sub
    Private Sub L_Ty_Gia(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_MA_NT0").ToString.Trim Then TxtTy_Gia.Double = 1
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dv_DetailTmp.Table.AcceptChanges()
    End Sub
    Private Function V_GetTyGia() As Decimal
        Dim nTy_Gia As Decimal = TxtTy_Gia.Double
        If nTy_Gia = 0 Then nTy_Gia = 1
        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_MA_NT0")
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_MA_NT0").ToString.ToUpper.Trim Then TxtTy_Gia.Double = 1
        TxtTy_Gia.Double = nTy_Gia
        V_GetTyGia = nTy_Gia
    End Function
#End Region
#Region "Mainform"
    Private Sub V_MainSystem()
        Dim mnItemsMail = New ContextMenu

        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItem, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItem, Keys.F8)

        Dim mnItemsSave As New MenuItem(If(M_LAN = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Keys.Control + Keys.Enter)
        Dim mnItemsPrint As New MenuItem(If(M_LAN = "V", "In chứng từ", "Print"), AddressOf V_ShortPrint, Keys.Control + Keys.P)

        mnItemsMail.MenuItems.Add(mnItemsF8)
        mnItemsMail.MenuItems.Add(mnItemsSave)
        mnItemsMail.MenuItems.Add(mnItemsPrint)
        Me.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItem, Nothing, True, False))
            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
    End Sub
    Private Sub V_MainSystemCv()
        Dim mnItemsMail = New ContextMenu
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItemCv, Keys.F8)
        mnItemsMail.MenuItems.Add(mnItemsF8)
        DetailGRVCv.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub V_ShortDeleteItemCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVCv.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailCvTmp, AppConn, DetailGRVCv) Then Exit Sub
        Dv_DetailCvTmp.Delete(iRow)
        Dv_DetailCvTmp.Table.AcceptChanges()
        UpdateList()
    End Sub
    Private Sub V_ShortAddItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        V_AddItem(iRow)
    End Sub
    Private Sub V_ShortDeleteItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_DetailTmp, AppConn, DetailGRV) Then Exit Sub
        Dv_DetailTmp.Delete(iRow)
        Dv_DetailTmp.Table.AcceptChanges()
        UpdateList()
    End Sub
    Private Sub V_ShortSAVE(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If Me.CmdSave.Enabled Then CmdSave.Focus()
        If Me.CmdSave.Enabled Then CmdSave.PerformClick()
    End Sub
    Private Sub V_ShortPrint(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not M_Mode = "X" Then Exit Sub
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Me.CmdPrint.Enabled Then V_Print(sender, e)
    End Sub
    Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If M_Mode.Trim = "X" Then If e.KeyValue = 27 Then V_Exit(sender, e)
        If M_Mode.Trim = "X" Then
            Select Case e.KeyValue
                Case 33 'Pageup
                    V_Prev(sender, e)
                Case 34 'PageDown
                    V_NEXT(sender, e)
                Case 35 'End
                    V_Bottom(sender, e)
                Case 36 'Home
                    V_Top(sender, e)
            End Select
        End If
    End Sub
    Private Function ChkRightsVoucher(ByVal _Mode As String) As Boolean
        Dim _Dt As Date = TxtNgay_Ct.Value
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        ChkRightsVoucher = CyberSupport.ChkRightsVoucher(_Dt, _Mode, _Ma_Post, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, M_LAN, AppConn, osysvar, CyberSmlib)
    End Function
#End Region
#Region "Button"
    Private Sub V_Save(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DetailGRV.PostEditor()
        Dv_DetailTmp.Table.AcceptChanges()
        If M_Mode.Trim = "M" Then TxtMa_Dvcs.Text = M_Ma_Dvcs
        If M_Mode.Trim = "M" Then TxtUser_id.Text = M_User_ID
        If TxtMa_NT.Text.Trim = "" Then V_GetTyGia()
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        Dim _Ngay_LCt As Date = TxtNgay_Ct.Value
        '----------------------------------------------------------------------------------------------------------------------
        V_GetDateVoucher(M_Mode, _Ngay_Ct, _Ngay_LCt)
        '----------------------------------------------------------------------------------------------------------------------
        If Not ChkRightsVoucher("L") Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        V_GetNoVoucherAuto() ' Tao So Chung tu tu dong
        '----------------------------------------------------------------------------------------------------------------------
        V_DelCtCv()
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri

        '----------------------------------------------------------------------------------------------------------------------
        Dim _strField As String = ""
        Dim _strvalue As String = ""

        'Dim CP_ChkInPut As String = "CP_SysChkVoucherInput" & M_Ma_CT.Trim
        'Dim CP_ChkInPut_CV As String = "CP_SysChkVoucherInput" & M_Ma_CT.Trim & "_CV"

        CyberSmodb.GetValueControler(Me, _strField, _strvalue)

        'If Dt_DetailTmp.Rows.Count > 0 Then If Not CyberSupport.ChkVoucherInput1(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailTmp, CP_ChkInPut, _strField, _strvalue, "Ten_NV,TEN_KH,TEN_KX,TEN_MAU,TEN_BH,TEN_SK,Ten_LHSC,TEN_LHKH", "TEN_VT,TEN_VT3,TEN_KHO_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub

        'If Dt_DetailCvTmp.Rows.Count > 0 Then If Not CyberSupport.ChkVoucherInput1(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailCvTmp, CP_ChkInPut_CV, _strField, _strvalue, "Ten_NV,TEN_KH,TEN_KX,TEN_MAU,TEN_BH,TEN_SK,Ten_LHSC,TEN_LHKH", "TEN_VT,TEN_VT3,TEN_KHO_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub

        'If Not ChkDetailHDS(_strField, _strvalue) Then Exit Sub

        '----------------------------------------------------------------------------------------------------------------------
        'If Not CyberSupport.ChkVoucherInput(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailTmp, "Ten_Tk,TEN_KH", "TEN_VT,TEN_KHO_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        ' If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, txtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        'If TxtSo_HD.Text.Trim = "" Then TxtSo_HD.Text = txtSo_ct.Text
        '----------------------------------------------------------------------------------------------------------------------

        V_Phan_Bo_Thue()

        '----------------------------------------------------------------------------------------------------------------------
        'TxtTien_HD.Double = TxtT_TT.Double
        '----------------------------------------------------------------------------------------------------------------------

        If Not Add2Database() Then Return
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        'CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")

        CyberSmlib.FlushMemorySave()
    End Sub
    Private Sub V_Phan_Bo_Thue()
        If ChkSua_Thue.Checked Then
            CyberSupport.Phan_Bo(Dt_DetailTmp, "Tien_Hang", "Thue", TxtT_Thue_hang.Double, M_R_TIEN_NT)
            CyberSupport.Phan_Bo(Dt_DetailCvTmp, "Tien_Hang", "Thue", TxtT_Thue_Cong.Double, M_R_TIEN)
        End If
    End Sub
    Private Function ChkVsave() As Boolean
        Dim iRow, nCount, nCountCV As Integer
        nCount = Dt_DetailTmp.Rows.Count
        'For iRow = nCount - 1 To 0 Step -1
        '    If Dt_DetailTmp.Rows(iRow).Item("Tk_I").ToString.Trim = "" Then
        '        Dt_DetailTmp.Rows(iRow).Delete()
        '        Dt_DetailTmp.AcceptChanges()
        '    End If
        'Next

        'nCount = Dt_DetailCvTmp.Rows.Count
        'For iRow = nCount - 1 To 0 Step -1
        '    If Dt_DetailCvTmp.Rows(iRow).Item("Ma_Cv").ToString.Trim = "" Then
        '        Dt_DetailCvTmp.Rows(iRow).Delete()
        '        Dt_DetailCvTmp.AcceptChanges()
        '    End If
        'Next
        'nCount = Dt_DetailVtTmp.Rows.Count
        'For iRow = nCount - 1 To 0 Step -1
        '    If Dt_DetailVtTmp.Rows(iRow).Item("Ma_VT").ToString.Trim = "" Then
        '        Dt_DetailVtTmp.Rows(iRow).Delete()
        '        Dt_DetailVtTmp.AcceptChanges()
        '    End If
        'Next        
        '---------------------------------------------------------------------------------
        ' Update Phan Dung Chung cua detail va Master
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(iRow).BeginEdit()
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec.Trim
            Dt_DetailTmp.Rows(iRow).Item("Ma_Ct") = M_Ma_CT.Trim
            If Dt_DetailTmp.Columns.Contains("Ma_Post") Then Dt_DetailTmp.Rows(iRow).Item("Ma_Post") = CbbMa_Post.SelectedValue.ToString.Trim
            'Dt_DetailTmp.Rows(iRow).Item("Ma_TT") = CbBMa_TT.SelectedValue.ToString.Trim
            Dt_DetailTmp.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
            Dt_DetailTmp.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
            If Dt_DetailTmp.Columns.Contains("Ma_Bp_I") Then If TxtMa_Bp_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_Bp_I") = TxtMa_Bp_H.Text.Trim
            If Dt_DetailTmp.Columns.Contains("Ma_HS_I") Then If TxtMa_Hs_H.Text.Trim <> "" Then Dt_DetailTmp.Rows(iRow).Item("Ma_HS_I") = TxtMa_Hs_H.Text.Trim

            If Dt_DetailTmp.Columns.Contains("Ma_Dvcs") Then Dt_DetailTmp.Rows(iRow).Item("Ma_Dvcs") = TxtMa_Dvcs.Text.Trim
            If Dt_DetailTmp.Columns.Contains("Ma_Post") Then Dt_DetailTmp.Rows(iRow).Item("Ma_Post") = CbbMa_Post.SelectedValue.ToString.Trim

            Dt_DetailTmp.Rows(iRow).EndEdit()
        Next
        Dt_DetailTmp.AcceptChanges()
        ' Update Phan Dung Chung cua detail va Master
        For iRow = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCvTmp.Rows(iRow).BeginEdit()
            Dt_DetailCvTmp.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec.Trim
            Dt_DetailCvTmp.Rows(iRow).Item("Ma_Ct") = M_Ma_CT.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ma_Post") Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_Post") = CbbMa_Post.SelectedValue.ToString.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ma_Post") Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_Dvcs") = TxtMa_Dvcs.Text
            'Dt_DetailCvTmp.Rows(iRow).Item("Ma_TT") = CbBMa_TT.SelectedValue.ToString.Trim
            Dt_DetailCvTmp.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
            Dt_DetailCvTmp.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailCvTmp.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
            If Dt_DetailCvTmp.Columns.Contains("Ma_Bp_I") Then If TxtMa_Bp_H.Text.Trim <> "" Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_Bp_I") = TxtMa_Bp_H.Text.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ma_HS_I") Then If TxtMa_Hs_H.Text.Trim <> "" Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_HS_I") = TxtMa_Hs_H.Text.Trim

            If Dt_DetailCvTmp.Columns.Contains("Ma_Dvcs") Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_Dvcs") = TxtMa_Dvcs.Text.Trim
            If Dt_DetailCvTmp.Columns.Contains("Ma_Post") Then Dt_DetailCvTmp.Rows(iRow).Item("Ma_Post") = CbbMa_Post.SelectedValue.ToString.Trim

            Dt_DetailCvTmp.Rows(iRow).EndEdit()
        Next
        Dt_DetailCvTmp.AcceptChanges()
        'If Not CyberSupport.ChkDetail(Dv_DetailTmp.Count, M_Ma_CT, M_LAN, osysvar) Then Return False
        '---------------------------------------------------------------------------------
        If Dt_DetailTmp.Rows.Count < 1 And Dt_DetailCvTmp.Rows.Count < 1 Then
            MsgBox("bạn chưa nhập chi tiết!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, osysvar("M_CYBER_VER"))
            Return False
        End If
        '---------------------------------------------------------------------------------
        '---Update: So_RO/So_PO/So_SO
        'CyberSupport.V_SaveLenh(Dv_DetailTmp, "", TxtLenh_PO.Text, TxtLenh_SO.Text, TxtLenh_Vt.Text)
        UpdateList()

        ChkVsave = True
    End Function
    Function ChkDetailHDS(Optional ByRef _StrFieldMaster As String = "", Optional ByRef _strValueMaster As String = "") As Boolean
        Dim nCountVt, nCountCv, i As Integer

        Dim strCVRec_RO As String = ""
        Dim strCVRec0_RO As String = ""
        Dim strCVSo_RO As String = ""
        Dim strCVMa_CV As String = ""
        Dim strCVMa_TT As String = ""
        Dim strCVTk_DT As String = ""
        Dim strCVTk_Thue As String = ""
        Dim strCVTien_CV As String = ""
        Dim strCVThue_CV As String = ""

        Dim strVTRec_RO As String = ""
        Dim strVTRec0_RO As String = ""
        Dim strVTSo_RO As String = ""
        Dim strVTMa_Vt As String = ""
        Dim strVTMa_TT As String = ""
        Dim strVTTk_DT As String = ""
        Dim strVTTk_Thue As String = ""
        Dim strVTSo_luong As String = ""
        Dim strVTTien2 As String = ""
        Dim strVTThue_VT As String = ""

        nCountCv = Dt_DetailCvTmp.Rows.Count
        nCountVt = Dt_DetailTmp.Rows.Count
        For i = 0 To nCountCv - 1
            strCVRec_RO = strCVRec_RO + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Rec_RO").ToString.Trim
            strCVRec0_RO = strCVRec0_RO + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Rec0_RO").ToString.Trim
            strCVSo_RO = strCVSo_RO + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("So_RO").ToString.Trim
            strCVMa_CV = strCVMa_CV + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Ma_CV").ToString.Trim
            strCVMa_TT = strCVMa_TT + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Ma_TT").ToString.Trim
            strCVTk_DT = strCVTk_DT + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Tk_DT").ToString.Trim
            strCVTk_Thue = strCVTk_Thue + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Tk_Thue").ToString.Trim
            strCVTien_CV = strCVTien_CV + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Tien_Hang").ToString.Trim.Replace(",", "").Replace(" ", "")
            strCVThue_CV = strCVThue_CV + IIf(i = 0, "", "!~!") + Dt_DetailCvTmp.Rows(i).Item("Thue").ToString.Trim.Replace(",", "").Replace(" ", "")
        Next
        For i = 0 To nCountVt - 1
            strVTRec_RO = strVTRec_RO + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Rec_RO").ToString.Trim
            strVTRec0_RO = strVTRec0_RO + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Rec0_RO").ToString.Trim
            strVTSo_RO = strVTSo_RO + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("So_RO").ToString.Trim
            strVTMa_Vt = strVTMa_Vt + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Ma_Vt").ToString.Trim
            strVTMa_TT = strVTMa_TT + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Ma_TT").ToString.Trim
            strVTTk_DT = strVTTk_DT + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Tk_DT").ToString.Trim
            strVTTk_Thue = strVTTk_Thue + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Tk_Thue").ToString.Trim
            strVTSo_luong = strVTSo_luong + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("So_luong").ToString.Trim.Replace(",", "").Replace(" ", "")
            strVTTien2 = strVTTien2 + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Tien_hang").ToString.Trim.Replace(",", "").Replace(" ", "")
            strVTThue_VT = strVTThue_VT + IIf(i = 0, "", "!~!") + Dt_DetailTmp.Rows(i).Item("Thue").ToString.Trim.Replace(",", "").Replace(" ", "")
        Next
        '------------------------------------------------------------------------------------------------------------------
        Dim DstmChk As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_ChkDetailHPT", M_Ma_CT + "#" + M_Stt_Rec + "#" + M_Mode + "#" + M_Ma_GD + "#" + CbbMa_Post.SelectedValue.ToString.Trim + "#" + _
        nCountVt.ToString.Trim.Replace(" ", "") + "#" + nCountCv.ToString.Trim.Replace(" ", "") + "#" + _
        strCVRec_RO + "#" + strCVRec0_RO + "#" + strCVSo_RO + "#" + strCVMa_CV + "#" + strCVMa_TT + "#" + strCVTk_DT + "#" + strCVTk_Thue + "#" + strCVTien_CV + "#" + strCVThue_CV + "#" + _
        strVTRec_RO + "#" + strVTRec0_RO + "#" + strVTSo_RO + "#" + strVTMa_Vt + "#" + strVTMa_TT + "#" + strVTTk_DT + "#" + strVTTk_Thue + "#" + strVTSo_luong + "#" + strVTTien2 + "#" + strVTThue_VT + "#" + M_Ma_Dvcs + "#" + M_User_Name)

        If Not CyberSupport.V_MsgChk(DstmChk.Tables(0), Me.SysVar, Me.Lan) Then
            DstmChk.Dispose()
            ChkDetailHDS = False
            Exit Function
        End If
        DstmChk.Dispose()
        ChkDetailHDS = True
    End Function
    Private Function Add2Database() As Boolean
        Dim drMaster As DataRow
        Dim CrrRow As Integer = -1
        If M_Mode.Trim = "M" Then
            drMaster = Dt_Master.NewRow
            CyberSmodb.SetValueBlankRow(drMaster)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.Item("Stt_Rec") = M_Stt_Rec
            drMaster.Item("Ma_Dvcs") = M_Ma_Dvcs
        Else
            CrrRow = Dt_Master.Rows.IndexOf(Dt_Master.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(0))
            drMaster = Dt_Master.Rows(CrrRow)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        '--------------drMaster.Item("User_Id") = M_User_ID.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailCv, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        For i As Integer = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCv.ImportRow(Dt_DetailCvTmp.Rows(i))
        Next

        '-----------------------------------------------------------------------------------------------------
        Return CyberSmodb.V_Add2Database(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_DetailCvTmp}, {M_Ct, M_Ph, "CTHPTCV"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport)

        ''---Save: History
        'CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        ''-----------------------------------------------------------------------------------------------------
        ''---Save: TO SQL
        'CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        'CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        'CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailCvTmp, "CTHPTCVCV", M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        '-----------------------------------------------------------------------------------------------------
        '---Save: Post
        CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Function
    Private Sub Add2Database_Luu()
        Dim drMaster As DataRow
        Dim CrrRow As Integer = -1
        If M_Mode.Trim = "M" Then
            drMaster = Dt_Master.NewRow
            CyberSmodb.SetValueBlankRow(drMaster)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.Item("Stt_Rec") = M_Stt_Rec
            drMaster.Item("Ma_Dvcs") = M_Ma_Dvcs
        Else
            CrrRow = Dt_Master.Rows.IndexOf(Dt_Master.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(0))
            drMaster = Dt_Master.Rows(CrrRow)
            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        '--------------drMaster.Item("User_Id") = M_User_ID.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_DetailCv, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        For i As Integer = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCv.ImportRow(Dt_DetailCvTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        '---Save: History
        CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        '-----------------------------------------------------------------------------------------------------
        '---Save: TO SQL
        CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailCvTmp, "CTHPTCVCV", M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        '-----------------------------------------------------------------------------------------------------
        '---Save: Post
        CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Copy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("C") Then Exit Sub

        M_Stt_RecOld = M_Stt_Rec
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)

        Dim Frm As Cyber.From.FrmCopy
        Frm = New FrmCopy
        Frm.Para = M_Para
        Frm.Lan = M_LAN
        Frm.Sysvar = osysvar
        Frm.DrDmct = Me.DrDmct
        Frm.So_CT = ""
        Frm.Ngay_CT = Now.Date
        Frm.Ngay_LCT = Now.Date
        Frm.SysApp = AppConn
        Frm.Ma_Dvcs = TxtMa_Dvcs.Text
        Frm.Stt_Rec = M_Stt_Rec
        Frm.ShowDialog()

        If Not Frm.Ok_Copy Then
            M_Stt_Rec = M_Stt_RecOld
            Exit Sub
        End If

        Dim _Ngay_Ct_Copy As Date = Frm.TxtNgay_Ct.Value
        Dim _Ngay_LCt_Copy As Date = Frm.TxtNgay_LCt.Value
        Dim _So_Ct_Copy As String = Frm.txtSo_ct.Text
        Dim _Ma_Quyen_Copy As String = Frm.TxtMa_Quyen.Text

        Dim I As Integer
        For I = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(I).BeginEdit()
            Dt_DetailTmp.Rows(I).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(I).Item("Ngay_Ct") = _Ngay_Ct_Copy
            Dt_DetailTmp.Rows(I).Item("So_Ct") = _So_Ct_Copy
            Dt_DetailTmp.Rows(I).EndEdit()
        Next

        TxtStt_Rec.Text = M_Stt_Rec
        TxtNgay_Ct.Value = _Ngay_Ct_Copy
        TxtNgay_LCt.Value = _Ngay_LCt_Copy
        TxtMa_Quyen.Text = _Ma_Quyen_Copy.Trim
        txtSo_ct.Text = _So_Ct_Copy.Trim
        M_Mode = "M"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()

        'TxtNgay_CtHD.Value = TxtNgay_Ct.Value
        'TxtnoteHDDT.Text = ""
        'TxtMau_VATHD.Text = ""
        'TxtSo_seriHD.Text = ""
        'TxtSo_HDDT.Text = ""
        'Txtma_tra_cuu.Text = ""
        'TxtEmailHDDT.Text = ""

    End Sub
    Private Sub V_Huy_HD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("C") Then Exit Sub

        M_Stt_RecOld = M_Stt_Rec
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)

        Dim Frm As Cyber.From.FrmCopy
        Frm = New FrmCopy
        Frm.Para = M_Para
        Frm.Lan = M_LAN
        Frm.Sysvar = osysvar
        Frm.DrDmct = Me.DrDmct
        Frm.So_CT = ""
        Frm.Ngay_CT = Now.Date
        Frm.Ngay_LCT = Now.Date
        Frm.SysApp = AppConn
        Frm.Ma_Dvcs = TxtMa_Dvcs.Text
        Frm.Stt_Rec = M_Stt_Rec
        Frm.ShowDialog()

        If Not Frm.Ok_Copy Then
            M_Stt_Rec = M_Stt_RecOld
            Exit Sub
        End If

        Dim _Ngay_Ct_Copy As Date = Frm.TxtNgay_Ct.Value
        Dim _Ngay_LCt_Copy As Date = Frm.TxtNgay_LCt.Value
        Dim _So_Ct_Copy As String = Frm.txtSo_ct.Text
        Dim _Ma_Quyen_Copy As String = Frm.TxtMa_Quyen.Text

        Dim I As Integer
        For I = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(I).BeginEdit()
            Dt_DetailTmp.Rows(I).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(I).Item("Ngay_Ct") = _Ngay_Ct_Copy
            Dt_DetailTmp.Rows(I).Item("So_Ct") = _So_Ct_Copy
            Dt_DetailTmp.Rows(I).Item("So_Luong") = -1 * Dt_DetailTmp.Rows(I).Item("So_Luong")
            Dt_DetailTmp.Rows(I).Item("Tien_Hang") = -1 * Dt_DetailTmp.Rows(I).Item("Tien_Hang")
            Dt_DetailTmp.Rows(I).Item("Thue") = -1 * Dt_DetailTmp.Rows(I).Item("Thue")
            Dt_DetailTmp.Rows(I).EndEdit()
        Next

        For I = 0 To Dt_DetailCvTmp.Rows.Count - 1
            Dt_DetailCvTmp.Rows(I).BeginEdit()
            Dt_DetailCvTmp.Rows(I).Item("Tien_Hang") = -1 * Dt_DetailCvTmp.Rows(I).Item("Tien_Hang")
            Dt_DetailCvTmp.Rows(I).Item("Thue") = -1 * Dt_DetailCvTmp.Rows(I).Item("Thue")
            Dt_DetailCvTmp.Rows(I).EndEdit()
        Next

        TxtStt_Rec.Text = M_Stt_Rec
        TxtNgay_Ct.Value = _Ngay_Ct_Copy
        TxtNgay_LCt.Value = _Ngay_LCt_Copy
        TxtMa_Quyen.Text = _Ma_Quyen_Copy.Trim
        txtSo_ct.Text = _So_Ct_Copy.Trim
        M_Mode = "M"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()

        'TxtNgay_CtHD.Value = TxtNgay_Ct.Value
        'TxtnoteHDDT.Text = ""
        'TxtMau_VATHD.Text = ""
        'TxtSo_seriHD.Text = ""
        'TxtSo_HDDT.Text = ""
        'Txtma_tra_cuu.Text = ""
        'TxtEmailHDDT.Text = ""
        'TxtSo_HD.Text = TxtSo_HD.Text + "H"
        UpdateList()
    End Sub
    Private Sub V_New(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        'Dim M_ma_tangOld As String = CbBMa_tang.SelectedValue.ToString.Trim
        If Not ChkRightsVoucher("M") Then Exit Sub
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)
        M_Mode = "M"
        V_Databing()
        '--------------
        TxtStt_Rec.Text = M_Stt_Rec
        TxtMa_Dvcs.Text = M_Ma_Dvcs
        'txtMa_NX.Text = M_Tk_No
        'TxtTen_Nx.Text = M_Ten_Tk_No
        If txtDien_giai.Text.Trim = "" Then txtDien_giai.Text = M_Dien_Giai
        'If TxtHT_TT.Text.Trim = "" Then TxtHT_TT.Text = M_HT_TT

        ChkSua_Thue.Checked = False
        'ChkHD_VAT.Checked = True
        'CbBMa_TT.SelectedValue = M_Ma_TT

        V_New()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        'TxtHT_TT.Text = IIf(TxtHT_TT.Text = "", "TM/CK", TxtHT_TT.Text)
        V_Setstatus()
        V_SetFocus("M")
        Enableloc_Ro()

        '-------------------------------------------------------------
        V_GetSo_seri()
        L_So_seri()
        TxtNgay_Dn.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        TxtGio_Dn.Text = ""
        'CbBMa_tang.Enabled = False

    End Sub
    Private Sub V_GetSo_seri()
        If Not (M_Mode = "M") Then Exit Sub
        Dim _dt As Date = TxtNgay_Ct.Value

        'Dim DsSeri = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_Get_So_seriHDS", M_Mode.Trim & "#" & CbbSo_Seri.SelectedValue.Trim & "#" & _dt.ToString("yyyyMMdd") & "#" & TxtMa_Dvcs.Text.Trim + "#" + M_User_Name)
        'Dim tbSeri As New DataTable
        'tbSeri = DsSeri.Tables(0).Copy()
        'If tbSeri.Rows.Count > 0 Then
        '    If tbSeri.Columns.Contains("So_Seri") Then CbbSo_Seri.SelectedValue = tbSeri.Rows(0).Item("So_Seri").ToString.Trim
        'End If
        'DsSeri.Dispose()

    End Sub
    Private Sub V_New()
        'If Dt_DetailTmp.Rows.Count < 1 Then
        '    Dim DrCurren As DataRow
        '    Dt_DetailTmp.NewRow()
        '    DrCurren = Dt_DetailTmp.NewRow
        '    CyberSmodb.SetValueBlankRow(DrCurren)
        '    DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
        '    DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
        '    DrCurren.Item("Ngay_Ct") = TxtNgay_Ct.Value
        '    DrCurren.Item("Stt_Rec0") = "0001"

        '    Dt_DetailTmp.Rows.Add(DrCurren)
        '    Dt_DetailTmp.AcceptChanges()
        'End If
    End Sub
    Private Sub V_Edit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        If Not ChkRightsVoucher("S") Then Exit Sub
        M_Mode = "S"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("S")
    End Sub
    Private Sub V_Delete(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("D") Then Exit Sub
        'If Not chkCherDeleteHDDT("D") Then Exit Sub

        Dim iMasterRow As Integer = -1
        For iRow As Integer = 0 To Dv_Master.Count - 1
            If Dv_Master.Item(iRow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                iMasterRow = iRow
                Exit For
            End If
        Next
        If Not CyberSupport.V_DeleteVoucher(AppConn, osysvar, M_LAN, M_Stt_Rec, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub
        CyberSupport.V_DeleteTableVoucher(Dt_Master, M_Stt_Rec)
        CyberSupport.V_DeleteTableVoucher(Dt_Detail, M_Stt_Rec)
        CyberSupport.V_DeleteTableVoucher(Dt_DetailCv, M_Stt_Rec)

        M_Count = Dt_Master.Rows.Count

        If M_Count < 0 Then iMasterRow = -1
        If iMasterRow >= M_Count Then iMasterRow = M_Count - 1

        If iMasterRow >= 0 Then M_Stt_Rec = Dv_Master.Item(iMasterRow).Item("Stt_Rec").ToString.Trim Else M_Stt_Rec = ""

        M_Mode = "X"
        V_Databing()

        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("D")
    End Sub
    'Function chkCherDeleteHDDT(ByVal Status As String) As Boolean
    '    If DrDmct.Table.Columns.Contains("HDDT") = False Then Return True
    '    If DrDmct("HDDT").ToString.Trim <> "1" Then Return True

    '    Dim dsReturn As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "Cp_InvoiceChekDeleteVoucher", M_Ma_CT & "#" & M_Stt_Rec & "#" & M_Ma_Dvcs & "#" & M_User_Name)
    '    If dsReturn.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper = "N" Then
    '        MsgBox(dsReturn.Tables(0).Rows(0)("Note").ToString.Trim, MsgBoxStyle.Critical, osysvar("M_CYBER_VER"))
    '        dsReturn.Dispose()
    '        Return False
    '    End If
    '    dsReturn.Dispose()
    '    Return True
    'End Function
    Private Sub V_Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not ChkRightsVoucher("P") Then Exit Sub
        If M_Stt_Rec.Trim = "" Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        CyberVoucher.V_PrintVocuher(AppConn, osysvar, Nothing, M_Stt_Rec, _Dt, _Ma_Post, M_LAN, M_Para, DrDmct, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib, CyberSupport)
    End Sub
    Private Sub V_Cancel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = "X"
        M_Stt_Rec = M_Stt_RecOld
        V_Databing()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("X")
    End Sub
    Private Sub V_View(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = "X"
        If M_Stt_Rec = "" Then Exit Sub
        M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)
        V_Databing()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
    End Sub
    Private Sub V_Search(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CyberVoucher.V_FilterVocuher(AppConn, osysvar, Me.DsLookup, M_LAN, M_Para, DrDmct, M_strFilter, M_Ma_CT, M_Ma_Dvcs, M_User_Name) Then Exit Sub
        Dim DsRefresh As DataSet = CyberSupport.V_FilterData(AppConn, M_strFilter, CyberSmlib, CyberSmodb, DsData)
        If Not CyberSupport.MsgFilterData(DsRefresh.Tables(1), M_LAN, osysvar) Then Exit Sub

        If DsRefresh.Tables(1).Rows.Count = 1 Then M_Stt_Rec = DsRefresh.Tables(1).Rows(0).Item("Stt_Rec")
        If DsRefresh.Tables(1).Rows.Count > 1 Then M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, Me.DsData, Me.DsHead, Me.DsLookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, False, True)

        V_Databing()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        M_Mode = "X"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CyberSupport.V_ExitVoucher(osysvar, M_LAN) Then Exit Sub
        Me.Close()
    End Sub
    Private Sub V_DeNghi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _strField As String = ""
        Dim _strValue As String = ""

        CyberSmodb.GetValueControler(Me, _strField, _strValue)

        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_RoDeNghiXuatPT", M_Stt_Rec.Trim & "#" & M_Ma_CT.Trim & "#" & M_Ma_Dvcs.Trim & "#" & M_User_Name.Trim)

        If Not CyberSupport.V_MsgChk(DsTmp.Tables(0), Me.SysVar, Me.Lan) Then
            DsTmp.Dispose()
            Exit Sub
        End If

        If DsTmp.Tables(0).Rows(0)("Status").ToString.Trim.ToUpper = "N" Then
            MsgBox(DsTmp.Tables(0).Rows(0)("Note").ToString.Trim, MsgBoxStyle.Critical, osysvar("M_CYBER_VER"))
        Else
            If DsTmp.Tables(0).Columns.Contains("Ngay_Dn") Then TxtNgay_Dn.Value = DsTmp.Tables(0).Rows(0).Item("Ngay_Dn")
            If DsTmp.Tables(0).Columns.Contains("Gio_Dn") Then TxtGio_Dn.Text = DsTmp.Tables(0).Rows(0).Item("Gio_Dn").ToString.Trim

            For iRow As Integer = 0 To Dt_Master.Rows.Count - 1
                If Dt_Master.Rows(iRow).Item("Stt_Rec").ToString.Trim = M_Stt_Rec Then
                    Dt_Master.Rows(iRow).BeginEdit()
                    If Dt_Master.Columns.Contains("Ngay_Dn") Then Dt_Master.Rows(iRow).Item("Ngay_Dn") = DsTmp.Tables(0).Rows(0).Item("Ngay_Dn").ToString.Trim
                    If Dt_Master.Columns.Contains("Gio_Dn") And Dt_Master.Columns.Contains("Gio_Dn") Then Dt_Master.Rows(iRow).Item("Gio_Dn") = DsTmp.Tables(0).Rows(0).Item("Gio_Dn").ToString.Trim

                    Dt_Master.Rows(iRow).EndEdit()
                    Dt_Master.AcceptChanges()
                    Exit For
                End If
            Next
        End If
        DsTmp.Dispose()
    End Sub
    Private Sub V_DelIsCv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        V_DelCtCv()
        UpdateList()
    End Sub
    Private Sub V_DelCtCv()
        For iRow As Integer = Dt_DetailCvTmp.Rows.Count - 1 To 0 Step -1
            Dt_DetailCvTmp.Rows(iRow).BeginEdit()
            If Dt_DetailCvTmp.Rows(iRow).Item("IS_CV") <> 1 Then
                Dt_DetailCvTmp.Rows(iRow).Delete()
                Dt_DetailCvTmp.Rows(iRow).EndEdit()
                Dt_DetailCvTmp.AcceptChanges()
            End If
        Next
    End Sub
#End Region
#Region "Add Or Detete Item"
    Private Sub MasterGRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = DetailGRV.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailGRV.RowCount - 1
        Dim iRowRowFocus As Integer = DetailGRV.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailGRV.VisibleColumns.IndexOf(DetailGRV.FocusedColumn)
        Dim iRowOld As Integer = DetailGRV.GetFocusedDataSourceRowIndex
        'If e.KeyCode = Keys.Enter And iRowVisible = iRowRowFocus And iCoumnVisible = iColumnRowFocus Then V_AddItem(iRowOld) '' Cot cuoi cung them dong
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            V_AddItem(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Sub V_AddItem(Optional ByVal iRow As Integer = -1)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim DrvOld As DataRowView
        If iRow >= 0 Then DrvOld = Dv_DetailTmp.Item(iRow) Else DrvOld = Nothing
        Dv_DetailTmp.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1), New DataView(M_DsHead.Tables(1)))
        CarrOn(Dv_DetailTmp.Table.Rows(Dv_DetailTmp.Table.Rows.Count - 1))
        UpdateList()
        iRow = Dv_DetailTmp.Count - 1
        CyberFill.V_ForcusCell(DetailGRV, iRow, 0)

    End Sub
    Private Sub CarrOn(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = M_Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_Ma_CT.Trim
        DvNew.Item("Ngay_Ct") = Me.TxtNgay_Ct.Value
    End Sub
#End Region
#Region "Sms - Import"
    Private Sub V_Import(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TbImport As New DataTable
        TbImport = CyberExport.V_ImportDataToGridview(AppConn, osysvar, M_Para, DetailGRV, Dt_DetailTmp, M_LAN)
        If TbImport Is Nothing Then Exit Sub
        '==================== Xu ly du lieu được Import vào
        Dt_DetailTmp.Clear()
        Dt_DetailTmp.AcceptChanges()
        For i = 0 To TbImport.Rows.Count - 1
            Dt_DetailTmp.ImportRow(TbImport.Rows(i))
        Next
        Dt_DetailTmp.AcceptChanges()
    End Sub
    Private Sub SetTxt()

        TxtT_Tien_Cong.ReadOnly = True
        TxtT_Thue_Cong.ReadOnly = True
        TxtT_Tong_Cong.ReadOnly = True

        TxtT_Tien_Hang.ReadOnly = True
        TxtT_Thue_hang.ReadOnly = True
        TxtT_Tong_Hang.ReadOnly = True

        TxtT_Tien_Nt2.ReadOnly = True
        TxtT_Thue_Nt.ReadOnly = True
        TxtT_TT_NT.ReadOnly = True
        'TxtTien_coc.ReadOnly = False
        TxtMa_Xe.ReadOnly = True
        If M_Mode = "M" Or M_Mode = "S" Then
            'If ChkSua_Thue.Checked Then TxtT_Thue_Nt.ReadOnly = False
            If ChkSua_Thue.Checked Then TxtT_Thue_hang.ReadOnly = False
            If ChkSua_Thue.Checked Then TxtT_Thue_Cong.ReadOnly = False
        End If
        If ChkSua_Thue.Checked Then

            TxtT_Thue_Cong.BackColor = Drawing.Color.Pink
            TxtT_Thue_hang.BackColor = Drawing.Color.Pink
            TxtT_Thue_Nt.BackColor = Drawing.Color.Pink
        Else
            TxtT_Thue_Cong.BackColor = Drawing.Color.White
            TxtT_Thue_hang.BackColor = Drawing.Color.White
            TxtT_Thue_Nt.BackColor = Drawing.Color.White
        End If

        'TxtNgay_CtHD.ReadOnly = True
        'TxtnoteHDDT.ReadOnly = True
        'TxtMau_VATHD.ReadOnly = True
        'TxtSo_seriHD.ReadOnly = True
        'TxtSo_HDDT.ReadOnly = True
        'Txtma_tra_cuu.ReadOnly = True


        'TxtEmailHDDT.ReadOnly = True
        'If M_Mode = "S" Then
        '    TxtTien_HD.Enabled = False
        'Else
        '    TxtTien_HD.Enabled = True
        'End If
    End Sub
#End Region
    Dim ProccessList As New Collection
    Private Sub KillProce()
        Try
            Dim op As Process
            For i As Integer = ProccessList.Count To 1 Step -1
                op = ProccessList(i)
                If Not op Is Nothing Then
                    If Not op.HasExited() Then
                        op.Kill()
                        ProccessList.Remove(i)
                    End If
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmRepports_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        KillProce()
    End Sub
End Class

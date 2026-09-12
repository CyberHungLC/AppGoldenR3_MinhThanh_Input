Imports System.Data.SqlClient
Public Class PCS
#Region "Khai bao bien Property----------------------"
    Dim M_strFilter As String = "1=1"
    Dim M_DrDmct As DataRow
    Dim osysvar As Collection
    Dim M_Para As String() = Me.Para
    Dim M_AppConn As SqlConnection
    Dim M_DsData, M_DsHead, M_DsLookUp As DataSet

    Dim Dt_Detailkhac, Dt_Detailtmpkhac As New DataTable
    Dim Dv_Detailkhac, Dv_Detailtmpkhac As New DataView

#End Region
#Region "Khai bao bien Paramater----------------------"

#End Region
#Region "Khai bao bien Dll"
    Dim CyberInput As New Cyber.Input.Sys
    Dim CyberMe As New Cyber.From.Frmvoucher
    Dim CyberFrom As New Cyber.From.Sys

#End Region
#Region "Columns Edit"
    Dim EditTk_i, EditMa_kh_I As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditMa_VT, EditMa_Vitri, EditMa_Kho_I, EditMa_Vv_I, EditMa_phi_i, EditMa_HD_I, EditMa_Sp_I, EditMa_ku_I, EditMa_TTLN_i, EditMa_TTCP_i, EditMa_BP_I, EditMa_HS_I, EditMa_CD_I, EditMa_TD1_I, EditMa_TD2_I, EditMa_TD3_I, EditMa_TD4_I, EditMa_TD5_I As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim Editma_Db_I, EditMa_Xe_I, EditMa_KX_I, EditMa_Tuyen_I, EditMa_Ts, EditMa_Cc As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditTien_NT, EditTien, EditDien_Giaii, EditSo_So, EditSo_Po, EditSo_Ro, EditSo_VT As New Cyber.Fill.CyberColumnGridView 'DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Dim EditCl_Pb, EditTen_Tk_i, EditTen_kh_i, EditSo_hd, EditNgay_HD, EditTien_Hd, EditTien_Hd_NT, EditDa_PB, EditDa_PB_NT, EditCl_Pb_NT, EditTy_Gia_HT As New Cyber.Fill.CyberColumnGridView 'DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
#End Region
#Region "Columns Edit"
    Dim EditkhacMa_phi_i, EditkhacMa_HD_I, EditkhacMa_Sp_I, EditkhacMa_ku_I, EditkhacMa_TTLN_i, EditkhacMa_TTCP_i, EditkhacMa_BP_I, EditkhacMa_HS_I, EditkhacMa_CD_I, EditkhacMa_TD1_I, EditkhacMa_TD2_I, EditkhacMa_TD3_I, EditkhacMa_TD4_I, EditkhacMa_TD5_I, EditkhacCLAIM_NMKhac, EditkhacCLAIM_NM_PinKhac As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
    Dim EditMa_KH, EditCLAIM_NM, EditCLAIM_NM_Pin, EditQuy_Doi_TM, EditT_Can_Tru As New Cyber.Fill.CyberColumnGridView 'Cyber.SmLists.EditLookUp
#End Region
#Region "Khai bao bien Private"
    Dim M_Ct, M_Ph As String
    Dim DrReturn As DataRow
    Dim M_Count As Integer = 1
    Dim DtPost, DtMaGD As DataTable
    Dim DSMaTT As New DataSet
    Dim M_Ma_TT As String = "C"

#End Region
    Private Sub PT5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        V_Load()
        V_GetColumn()
        V_GetColumnKhac()
        V_AddHandler()
        V_Databing()
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_MainSystem()
        V_MainSystemkhac()
        GetRound()
        CmdNew.Focus()
    End Sub
#Region "Load And Set And Default"
    Private Sub V_Load()
        V_Getdefault()
        Dt_Detail = M_DsData.Tables(0)
        Dt_DetailTmp = Dt_Detail.Clone
        Dt_Master = M_DsData.Tables(1)

        Dt_DetailKhac = M_DsData.Tables(2)
        Dt_Detailtmpkhac = Dt_Detailkhac.Clone

        Dv_Detail = New DataView(Dt_Detail)
        Dv_DetailTmp = New DataView(Dt_DetailTmp)
        Dv_Master = New DataView(Dt_Master)

        Dv_DetailKhac = New DataView(Dt_DetailKhac)
        Dv_Detailtmpkhac = New DataView(Dt_Detailtmpkhac)

        Detail.DataSource = Dv_DetailTmp
        Me.DetailGRV.GridControl = Me.Detail
        CyberFill.V_FillVoucher(DetailGRV, M_LAN, New DataView(M_DsHead.Tables(1)), Dv_DetailTmp, Me.DrDmct)

        '-------------
        DetailKhac.DataSource = Dv_Detailtmpkhac
        Me.DetailGRVkhac.GridControl = Me.Detailkhac
        CyberFill.V_FillVoucher(DetailGRVkhac, M_LAN, New DataView(M_DsHead.Tables(2)), Dv_Detailtmpkhac, Me.DrDmct)

        V_SetProperty()
        CyberSupport.Translaste(Me, M_LAN, True)
        ' M_Stt_Rec = CyberFrom.V_ViewVoucher(AppConn, osysvar, M_LAN, M_Para, DrDmct, DsData, DsHead, Dslookup, Dv_Master, Dv_Detail, M_Stt_Rec, strFilter, CyberFill, CyberSmlib, CyberSupport, True, True)
        TxtTy_Gia.InputMask = IIf(DrDmct.Item("M_IP_MK_TG").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TG").ToString.Trim, TxtTy_Gia.InputMask)

        TxtT_Tien_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_NT.InputMask)
        TxtT_Tien.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien.InputMask)


        TxtT_thue_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_thue_NT.InputMask)
        TxtT_Thue.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Thue.InputMask)

        TxtT_TT_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_TT_NT.InputMask)
        TxtT_TT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_TT.InputMask)

        TxtT_TT_I_C_W_N.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_TT_I_C_W_N.InputMask)
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

        'M_Stt_Rec = M_Para(M_Para.Length - 1).Trim
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

        DtPost = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmPost", "Ma_Post", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)
        DtMaGD = CyberSmodb.OpenTableKey(AppConn, Nothing, "DmMaGd", "Ma_GD", "Ma_Ct =N'" + M_Ma_CT + "'", CyberSmlib)


        CyberFill.V_FillComBoxValue(Me.CbbMa_Post, DtPost, "Ma_Post", If(M_LAN = "V", "Ten_Post", "Ten_Post2"), M_Ma_Post)
        CyberFill.V_FillComBoxValue(Me.CbbMa_GD, DtMaGD, "Ma_GD", If(M_LAN = "V", "Ten_GD", "Ten_GD2"), M_Ma_GD)


        '---------------------------------------------------------------------------------------------'
        V_LoadDefault()
        '---------------------------------------------------------------------------------------------'
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
        '---HD
        EditSo_hd.GetColumn(DetailGRV, "So_HD")
        EditNgay_HD.GetColumn(DetailGRV, "Ngay_HD")
        EditTien_Hd.GetColumn(DetailGRV, "Tien_HD")
        EditTien_Hd_NT.GetColumn(DetailGRV, "Tien_HD_NT")
        EditDa_PB.GetColumn(DetailGRV, "Da_Pb")
        EditDa_PB_NT.GetColumn(DetailGRV, "Da_Pb_NT")
        EditCl_Pb.GetColumn(DetailGRV, "CL_PB")
        EditCl_Pb_NT.GetColumn(DetailGRV, "CL_PB_NT")
        '---
        EditTy_Gia_HT.GetColumn(DetailGRV, "TY_GIA_HT")

        '---
        EditTk_i.GetColumn(DetailGRV, "TK_I")
        EditTen_Tk_i.GetColumn(DetailGRV, "TEN_TK_I")
        EditMa_kh_I.GetColumn(DetailGRV, "Ma_kh_I")
        EditTen_kh_i.GetColumn(DetailGRV, "TEN_KH_I")
        EditDien_Giaii.GetColumn(DetailGRV, "DIEN_GIAII")
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

        EditT_Can_Tru.GetColumn(DetailGRV, "T_Can_Tru")

    End Sub
    Private Sub V_GetColumnKhac()
        '---
        EditMa_KH.GetColumn(DetailGRVkhac, "Ma_KH")
        EditkhacMa_TD5_I.GetColumn(DetailGRVkhac, "Ma_TD5_I")
        '---
    End Sub
    Private Sub V_SetFocus(ByVal _Loai As String)
        _Loai = _Loai.Trim.ToUpper

        Select Case _Loai
            Case "M"
                'If DrDmct.Item("M_Ngay_CT").ToString.Trim <> "1" Then TxtNgay_Ct.Focus() Else If CbbMa_GD.SelectedValue.ToString.Trim = "3" Then txtOng_ba.Focus() Else TxtMa_Kh.Focus()
            Case "S"
                If DrDmct.Item("M_Ngay_CT").ToString.Trim <> "1" Then TxtNgay_Ct.Focus() Else txtDien_giai.Focus()
                txtDien_giai.Focus()
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
        V_AddHandler_Detailkhac()
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
        '---
        AddHandler DetailGRV.PopupMenuShowing, AddressOf MasterGRV_PopupMenuShowing
        AddHandler DetailGRV.KeyDown, AddressOf MasterGRV_KeyDown
        '---
        AddHandler CbbMa_GD.SelectedValueChanged, AddressOf L_Ma_GD
        'AddHandler txtPT_KHAC.Leave, AddressOf V_PT_Khac
        '----------------------------------------------------------------------------------------------------------
    End Sub
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
    Private Sub V_AddHandler_Master()
        AddHandler TxtMa_Quyen.Leave, AddressOf L_Ma_Quyen
        AddHandler TxtNgay_Ct.Leave, AddressOf V_Ngay_Ct
        AddHandler TxtNgay_LCt.Leave, AddressOf V_Ngay_LCt
        AddHandler txtSo_ct.Enter, AddressOf V_So_Ct
        AddHandler TxtMa_NT.Leave, AddressOf L_Ma_NT
        AddHandler TxtTy_Gia.Leave, AddressOf L_Ty_Gia
        '--KH
        AddHandler TxtMa_Kh.CyberValiting, AddressOf V_Ma_KH
        AddHandler TxtMa_Kh.CyberLeave, AddressOf L_Ma_KH

        AddHandler CmdLoc_PCS.Click, AddressOf V_Loc_RO
        '----------------------------------------------------------------------------------------------------------

    End Sub
    Private Sub V_AddHandler_Detail()
        If Not EditTien_NT.Column Is Nothing Then AddHandler EditTien_NT.EditColumn.Leave, AddressOf L_Tinh_Toan
        If Not EditTien.Column Is Nothing Then AddHandler EditTien.EditColumn.Leave, AddressOf L_Tinh_Toan

        If Not EditDien_Giaii.Column Is Nothing Then AddHandler EditDien_Giaii.EditColumn.Enter, AddressOf E_Dien_Giaii
        EditTk_i.V_ActiLookUpColumn(AddressOf V_Tk_I, AddressOf L_Tk_I)
        EditMa_kh_I.V_ActiLookUpColumn(AddressOf V_Ma_kh_i, AddressOf L_Ma_kh_i)
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
        EditMa_KH.V_ActiLookUpColumn(AddressOf V_Ma_KH_C, AddressOf L_Ma_KH_C)

        If Not EditSo_So.Column Is Nothing Then AddHandler EditSo_So.EditColumn.Leave, AddressOf L_So_So
        If Not EditSo_Po.Column Is Nothing Then AddHandler EditSo_Po.EditColumn.Leave, AddressOf L_So_Po
        If Not EditSo_Ro.Column Is Nothing Then AddHandler EditSo_Ro.EditColumn.Leave, AddressOf L_So_Ro
        If Not EditSo_VT.Column Is Nothing Then AddHandler EditSo_VT.EditColumn.Leave, AddressOf L_So_VT
        AddHandler DetailGRV.RowCellStyle, AddressOf DetailGRV_RowCellStyle
    End Sub
    Private Sub V_AddHandler_Detailkhac()
        EditkhacMa_TD5_I.V_ActiLookUpColumn(AddressOf V_Ma_TD5_i, AddressOf L_Ma_TD5_i)
    End Sub

    Dim CyberColor As New Cyber.Color.Sys
    Private Sub DetailGRV_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        CyberSupport.DetailGRV_RowCellStyle2(sender, e, DetailGRV, Dt_DetailTmp, Me.Font, "Bold", "BackColor", "BackColor2", "Forecolor", "Underline", "Italic", CyberColor)
    End Sub

    Private Sub VisibleColumnMa_NT()
        If TxtMa_NT.Text.Trim = "" Or TxtMa_NT.Text.Trim.ToUpper = osysvar("M_Ma_NT0").ToString.Trim.ToUpper Then
            EditTien.Visible = False
            EditTy_Gia_HT.Visible = False
            TxtT_TT.Visible = False
        Else
            EditTien.Visible = True
            EditTy_Gia_HT.Visible = True
            TxtT_TT.Visible = True
        End If
        CyberFill.SetFoCusGRV(DetailGRV, M_Mode)
    End Sub
    Private Sub VisibleColumnMa_GD()

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

        Dt_Detailtmpkhac.Clear()
        Dt_Detailtmpkhac.AcceptChanges()
        For i = 0 To Dt_Detailkhac.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'").Length - 1
            Dt_Detailtmpkhac.ImportRow(Dt_Detailkhac.Select("Stt_Rec ='" + M_Stt_Rec.Trim + "'")(i))
        Next

        If TxtMa_NT.Text.Trim = "" Then TxtMa_NT.Text = osysvar("M_Ma_NT0").ToString.Trim.ToUpper
        '---------------------------------------------------------
        'Tính thanh toán của các lệnh
        '---------------------------------------------------------
        UpdateList()
        VisibleColumnMa_NT()
        VisibleColumnMa_GD()
    End Sub
    Private Sub V_Setstatus()
        If (M_Mode = "M" Or M_Mode = "S") Then
            DetailGRV.OptionsBehavior.ReadOnly = False
            If DrDmct.Item("M_Ngay_LCT").ToString.Trim = "1" Then TxtNgay_LCt.ReadOnly = False Else TxtNgay_LCt.ReadOnly = True 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Ngay_CT").ToString.Trim = "1" Then TxtNgay_Ct.ReadOnly = True Else TxtNgay_Ct.ReadOnly = False 'Ngay chu tu nhap: vao hoac tu dong lay theo may chu
            If DrDmct.Item("M_Au_So_CT").ToString.Trim = "1" Then txtSo_ct.ReadOnly = True Else txtSo_ct.ReadOnly = False 'Tu dong danh so chung tu
        Else
            DetailGRV.OptionsBehavior.ReadOnly = True
        End If
        If M_Mode = "S" Then CbbMa_GD.Enabled = False
        If M_Mode = "M" Then CbbMa_GD.Enabled = True
        CyberFill.SetFoCusGRV(DetailGRV, M_Mode)
        SetTxt()
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
    Private Sub L_Ma_GD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        VisibleColumnMa_GD()
    End Sub
#End Region

    Dim ProccessList As New Collection
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
        TxtMa_Kh.V_LookUp(M_LAN, M_Para, osysvar, AppConn, DsLookup, "Ma_kh", "DmKh", "1=1", "1=1")
    End Sub
    Private Sub L_Ma_KH(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        If TxtMa_Kh.Text = "" Then
            TxtTen_kh.Text = ""
            Exit Sub
        End If
        DrReturn = TxtMa_Kh.GetRowsSelectData(True)
        If Not DrReturn Is Nothing Then
            TxtMa_Kh.Text = DrReturn.Item("Ma_KH")
            TxtTen_kh.Text = DrReturn.Item("Ten_KH")
            TxtTen_kh.Text = ""
            Exit Sub
        End If
    End Sub
#End Region

    Private Sub V_Loc_RO(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Mode = M_Mode.Trim
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim Frm As FrmLocPCS
        Frm = New FrmLocPCS
        Frm.Sysvar = Me.osysvar
        Frm.Para = Me.M_Para
        Frm.AppConn = Me.AppConn
        Frm.Stt_Rec = M_Stt_Rec
        Frm.ma_Ct = M_Ma_CT

        Frm.ShowDialog()
        If Not Frm.Save_OK Then Exit Sub
        Dim _Dt_Return1 As DataTable = Frm.Return_Tb2
        Dim _Dt_Return2 As DataTable = Frm.Return_Tb1
        Dim _Ma_kh As String = Frm.Ma_KH
        Dim _Ten_KH As String = Frm.Ten_KH
        'Dim _Dia_chi As String = ""
        L_Lenh_PO_Update(_Dt_Return1, _Dt_Return2, _Ma_kh, _Ten_KH)

    End Sub
    Private Sub L_Lenh_PO_Update(ByVal _Tb_Master As DataTable, ByVal _Dt_Detail As DataTable, ByVal _Ma_kh As String, ByVal _Ten_KH As String)
        If _Tb_Master.Rows.Count > 0 Then
            If TxtMa_Kh.Text.Trim = "" And _Tb_Master.Columns.Contains("Ma_kh") Then TxtMa_Kh.Text = _Ma_kh
            If TxtTen_kh.Text.Trim = "" And _Tb_Master.Columns.Contains("Ten_kh") Then TxtTen_kh.Text = _Ten_KH
        End If
        Dt_DetailTmp.Clear()
        Dim _Dt_Update As DataTable = _Dt_Detail.Clone

        For iRow As Integer = 0 To _Dt_Detail.Rows.Count - 1
            If _Dt_Detail.Rows(iRow).Item("Tag").ToString.ToUpper.Trim = "1" Or _Dt_Detail.Rows(iRow).Item("Tag").ToString.ToUpper.Trim = "TRUE".ToUpper.Trim Then

                _Dt_Update.ImportRow(_Dt_Detail.Rows(iRow))
            End If
        Next
        CyberSmodb.SQLTbToTb(_Dt_Update, Dt_DetailTmp)
        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            V_Tinh_Toan(iRow)
        Next
        UpdateList()
    End Sub

#Region "Valid - Detail"
#Region "Valid - Detail - Core"
    Private Sub UpdateList()
        'Dim nT_Tien_NT As Decimal = 0
        Dim nT_Tien As Decimal = 0

        Dim nT_Thue_NT As Decimal = 0
        Dim nT_Thue As Decimal = 0
        Dim nT_CT As Decimal = 0

        For iRow As Integer = 0 To Dv_DetailTmp.Count - 1
            'nT_Tien_NT = nT_Tien_NT + Dv_DetailTmp.Item(iRow).Item("Tien_NT")
            'nT_Tien = nT_Tien + Dv_DetailTmp.Item(iRow).Item("Tien")

            nT_CT = nT_CT + Dv_DetailTmp.Item(iRow).Item("T_Can_Tru")
        Next

    End Sub
    Private Sub V_Tinh_Toan(ByVal iRow As Integer)
        Dim nTy_Gia As Decimal = V_GetTyGia()
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
    Private Sub V_Tk_I(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk_I(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Tk_I(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = CyberSupport.L_Tk_I(M_Mode, M_Ma_CT, sender, DetailGRV)
        If DrReturn Is Nothing Then
            Dim iRow As Integer = -1
            iRow = DetailGRV.GetFocusedDataSourceRowIndex
            If iRow < 0 Then Exit Sub
            If Dv_DetailTmp.Item(iRow).Item("TK_I").ToString.Trim = "" Then
                If Not CyberSupport.V_NhapTiep(osysvar, M_LAN) Then
                    Dv_DetailTmp.Item(iRow).Delete()
                    Dv_DetailTmp.Table.AcceptChanges()
                    UpdateList()
                    SendKeys.Send("^{TAB}")
                End If
            End If
        End If
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
#Region "Vat tu kho - "
    Private Sub V_Ma_Vt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vt(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = Nothing
        DrReturn = CyberSupport.L_Ma_Vt(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Kho_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kho_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Kho_i(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vitri(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vitri(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_So(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_PO(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_Ro(Dv_DetailTmp, iRow, AppConn, osysvar, M_Ma_CT, "S", M_Mode, _Ngay_Ct, CbbMa_TTCP_H, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib)
    End Sub
    Private Sub L_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = TxtNgay_Ct.Value
        CyberVoucher.V_FormatSo_VT(Dv_DetailTmp, iRow, AppConn, SysVar, M_Ma_CT, CbbMa_GD.SelectedValue, M_Mode, _Ngay_Ct, CbbMa_TTCP_H, M_Ma_Dvcs, M_User_Name, CyberSmlib)

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
    Private Sub V_Ma_KH_C(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        CyberSupport.V_Lookup("Ma_KH", "DmKH", "1=1", "1=1", M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_KH_C(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = -1
        iRow = DetailGRVkhac.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        DrReturn = CyberSupport.L_Lookup(M_Mode, M_Ma_CT, sender, True)
        If DrReturn Is Nothing Then
            Dv_Detailtmpkhac.Item(iRow).BeginEdit()
            Dv_Detailtmpkhac.Item(iRow).Item("Ma_KH") = ""
            Dv_Detailtmpkhac.Item(iRow).Item("Ten_KH") = ""
            Dv_Detailtmpkhac.Item(iRow).EndEdit()
            Exit Sub
        Else
            Dv_Detailtmpkhac.Item(iRow).BeginEdit()
            Dv_Detailtmpkhac.Item(iRow).Item("Ma_KH") = DrReturn("Ma_KH").ToString.Trim
            Dv_Detailtmpkhac.Item(iRow).Item("Ten_KH") = DrReturn("Ten_KH").ToString.Trim
            Dv_Detailtmpkhac.Item(iRow).EndEdit()

        End If
        Dv_Detailtmpkhac.Table.AcceptChanges()
        DetailGRVkhac.UpdateCurrentRow()
    End Sub
#End Region
#Region "Valid - Detail - Add On Khac"
    Private Sub V_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_TD5_i(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5_i(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_TD5_i(M_Mode, M_Ma_CT, sender, DetailGRVkhac)
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

    Private Sub CbbMa_GD_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CbbMa_GD.SelectedIndexChanged

    End Sub
#End Region
#Region "Mainform"
    Private Sub V_MainSystem()
        Dim mnItemsMail = New ContextMenu

        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItem, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItem, Keys.F8)

        Dim mnItemsSave As New MenuItem(If(M_LAN = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Keys.Control + Keys.Enter)
        Dim mnItemsPrint As New MenuItem(If(M_LAN = "V", "In chứng từ", "Print"), AddressOf V_ShortPrint, Keys.Control + Keys.P)

        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)

        mnItemsMail.MenuItems.Add(mnItemsSave)
        mnItemsMail.MenuItems.Add(mnItemsPrint)
        Me.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_ShortAddItem, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItem, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Import", "Delete item"), AddressOf V_Import, Nothing, True, True))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Nothing, True, True))
            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
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
        DetailGRV.PostEditor()
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
#Region "Mainform Phụ kiện"
    Private Sub V_MainSystemkhac()
        Dim mnItemsMail = New ContextMenu
        Dim mnItemsF4 As New MenuItem(If(M_LAN = "V", "Thêm dòng", "New row"), AddressOf V_ShortAddItemkhac, Keys.F4)
        Dim mnItemsF8 As New MenuItem(If(M_LAN = "V", "Xóa dòng", "Delete row"), AddressOf V_ShortDeleteItemkhac, Keys.F8)
        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)
        DetailGRVkhac.GridControl.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRVPK_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim rowHandle As Integer = e.HitInfo.RowHandle
        If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            PopupMenuMasterGrid.ItemLinks.Clear()
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_ShortAddItemkhac, Nothing, True, False))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItemkhac, Nothing, True, False))
            'PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Import", "Delete item"), AddressOf V_Importkhac, Nothing, True, True))
            PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Nothing, True, True))
            PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        End If
    End Sub
    Private Sub V_ShortAddItemkhac(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVkhac.FocusedRowHandle
        V_AddItemkhac(iRow)
        iRow = Dv_Detailtmpkhac.Count - 1
        CyberFill.V_ForcusCell(DetailGRVkhac, iRow, 0)
    End Sub
    Private Sub V_ShortDeleteItemkhac(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = DetailGRVkhac.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(osysvar, M_LAN, M_Ma_CT, iRow, Dv_Detailtmpkhac, AppConn) Then Exit Sub
        Dv_Detailtmpkhac.Delete(iRow)
        Dv_Detailtmpkhac.Table.AcceptChanges()
        UpdateList()
    End Sub
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
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri
        CyberInput.V_Save_Default_TTCP(Dt_DetailTmp, M_Is_Visible_TTCP, CbbMa_TTCP_H, M_Ma_CT, CyberSmodb)
        If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, txtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        '----------------------------------------------------------------------------------------------------------------------
        Dim DrMasterOld As DataRow
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
            DrMasterOld = CyberSmodb.V_CopyDataRow(drMaster)

            CyberSmodb.AddValueToRow(drMaster, Me)
            drMaster.BeginEdit()
        End If
        drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
        drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
        drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
        '---Save Post
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        '---------------------------------------------------
        Dim DsSave As DataSet
        If Not CyberSmodb.V_SysCheckSaveVoucher(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster), Dt_Detailtmpkhac}, {M_Ct, M_Ph, "CT99KHAC"}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, CbbMa_GD.SelectedValue, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport, DsSave) Then
            If M_Mode = "S" And Not DrMasterOld Is Nothing Then CyberSmodb.V_UpdateRowtoRow(DrMasterOld, Dt_Master, CrrRow)
            Return
        End If
        '---------------------------------------------------
        '---Update Head
        If DsSave.Tables.Count >= 2 Then
            If DsSave.Tables(1).Rows.Count > 0 Then
                CyberSmodb.SetValueTObj_1(Me, DsSave.Tables(1).Rows(0)) '----Chi set Những trường có dữ liệu
                CyberSmodb.AddValueToRow(drMaster, Me)
                drMaster.Item("Stt_Rec") = M_Stt_Rec.Trim
                drMaster.Item("Ma_Ct") = M_Ma_CT.Trim
                drMaster.Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
            End If
        End If
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '---Update Chi tiet
        If DsSave.Tables.Count >= 3 Then
            For iRow As Integer = 0 To DsSave.Tables(2).Rows.Count - 1
                Try
                    CyberSmodb.V_UpdateRowtoRow(DsSave.Tables(2).Rows(iRow), Dt_DetailTmp, iRow)
                Catch ex As Exception
                End Try
            Next
        End If
        '---Xoa trong Detail`   12
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        Dt_Detail.Load(Dt_DetailTmp.CreateDataReader)
        '----------------------------------------------------------------------------------------------------------------------
        '---Update Khac
        If DsSave.Tables.Count >= 4 Then
            For iRow As Integer = 0 To DsSave.Tables(3).Rows.Count - 1
                Try
                    CyberSmodb.V_UpdateRowtoRow(DsSave.Tables(3).Rows(iRow), Dt_Detailtmpkhac, iRow)
                Catch ex As Exception
                End Try
            Next
        End If
        '---------------------------------------------------
        '---Xoa trong DetailKhac
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detailkhac, "Stt_Rec = '" + M_Stt_Rec + "'")
        Dt_Detailkhac.Load(Dt_Detailtmpkhac.CreateDataReader)
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        M_Count = Dt_Master.Rows.Count
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()
    End Sub
    Private Sub V_Save_Luu(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        If Not ChkVsave() Then Exit Sub 'Kiem tra va Update du lieu chuong tri
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.ChkVoucherInput(Me, AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Ma_CT, _Ngay_Ct, CbbMa_GD.SelectedValue, M_Stt_Rec, CbbMa_Post.SelectedValue, M_Ma_Dvcs, M_User_Name, Dt_DetailTmp, "Ten_Tk,TEN_KH", "TEN_KH_I", CyberSmlib, CyberSupport, CyberSmodb, CyberLoading) Then Exit Sub
        '----------------------------------------------------------------------------------------------------------------------
        If Not CyberSupport.V_ChkExistNovoucher(AppConn, osysvar, M_LAN, DrDmct, M_Mode, M_Stt_Rec, M_Ma_CT, txtSo_ct.Text.Trim, _Ngay_Ct, _Ngay_LCt, M_Ma_Dvcs, M_User_Name, CyberSmlib) Then Exit Sub '---Kiem tra trung so chung tu
        '----------------------------------------------------------------------------------------------------------------------

        If Not Add2Database() Then Return
        '----------------------------------------------------------------------------------------------------------------------
        M_Mode = "X"
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("L")
        CyberSmlib.FlushMemorySave()

    End Sub
    Private Function ChkVsave() As Boolean
        Dim iRow, nCount As Integer
        nCount = Dt_DetailTmp.Rows.Count

        'For iRow = nCount - 1 To 0 Step -1
        '    If Dt_DetailTmp.Rows(iRow).Item("Ma_TD5_I").ToString.Trim = "" Then
        '        Dt_DetailTmp.Rows(iRow).Delete()
        '        Dt_DetailTmp.AcceptChanges()
        '    End If
        'Next

        'nCount = Dt_Detailtmpkhac.Rows.Count
        'For iRow = nCount - 1 To 0 Step -1
        '    If Dt_Detailtmpkhac.Rows(iRow).Item("Ma_TD5_I").ToString.Trim = "" Then
        '        Dt_Detailtmpkhac.Rows(iRow).Delete()
        '        Dt_Detailtmpkhac.AcceptChanges()
        '    End If
        'Next

        '---------------------------------------------------------------------------------
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec
            Dt_DetailTmp.Rows(iRow).Item("Ma_Ct") = M_Ma_CT
            Dt_DetailTmp.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_DetailTmp.Rows(iRow).Item("So_Ct") = CyberSupport.V_soct(txtSo_ct.Text.Trim)
            Dt_DetailTmp.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1)
        Next
        Dt_DetailTmp.AcceptChanges()


        For iRow = 0 To Dt_Detailtmpkhac.Rows.Count - 1
            Dt_Detailtmpkhac.Rows(iRow).Item("Stt_Rec") = M_Stt_Rec.Trim
            Dt_Detailtmpkhac.Rows(iRow).Item("Ma_Ct") = M_Ma_CT.Trim
            Dt_Detailtmpkhac.Rows(iRow).Item("Ngay_Ct") = TxtNgay_Ct.Value
            Dt_Detailtmpkhac.Rows(iRow).Item("Stt_Rec0") = CyberSupport.GetStt_Rec0(iRow + 1) 'Smvoucherlib.Sys.ClsVoucher.GetStt_Rec0(iRow + 1)
        Next

        'If Not CyberSupport.ChkDetail(Dv_DetailTmp.Count, M_Ma_CT, M_LAN, osysvar) Then Return False
        'CyberSupport.V_SaveLenh(Dv_DetailTmp, TxtLenh_Ro.Text, TxtLenh_PO.Text, TxtLenh_SO.Text, TxtLenh_Vt.Text)
        UpdateList()
        ChkVsave = True
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
        CyberSupport.V_SavePost(AppConn, drMaster, CbbMa_Post.SelectedValue, M_Ma_CT, M_User_Name, M_User_Name, CyberSmlib)
        If M_Mode.Trim = "M" Then Dt_Master.Rows.Add(drMaster) Else Dt_Master.Rows(CrrRow).EndEdit()
        Dt_Master.AcceptChanges()
        '-----------------------------------------------------------------------------------------------------
        '---Xoa trong Detail
        If M_Mode.Trim = "S" Then CyberSmodb.DeleteDatatable(Dt_Detail, "Stt_Rec = '" + M_Stt_Rec + "'")
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        Return CyberSmodb.V_Add2Database(AppConn, osysvar, {Dt_DetailTmp, CyberSmodb.V_ConvertDrToTb(drMaster)}, {M_Ct, M_Ph}, M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_LAN, TxtMa_Dvcs.Text, M_User_Name, CyberSmlib, CyberSupport)

        ''---Save: History
        'CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        ''-----------------------------------------------------------------------------------------------------
        ''---Save: TO SQL
        'If M_Ph.Trim <> "" Then CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        'If M_Ct.Trim <> "" Then CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        ''-----------------------------------------------------------------------------------------------------
        ''---Save: Post
        'CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
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
        '+Import To Detail 
        For i As Integer = 0 To Dt_DetailTmp.Rows.Count - 1
            Dt_Detail.ImportRow(Dt_DetailTmp.Rows(i))
        Next
        '-----------------------------------------------------------------------------------------------------
        '---Save: History
        CyberSupport.V_HistoryVoucher(M_Mode, CbbMa_Post.SelectedValue.ToString.Trim, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
        '-----------------------------------------------------------------------------------------------------
        '---Save: TO SQL
        If M_Ph.Trim <> "" Then CyberSmodb.V_SaveToSQL(AppConn, osysvar, M_User_Name, drMaster, M_Ph, M_Mode, "Stt_Rec = N'" + M_Stt_Rec + "'", IIf(M_Mode.Trim = "S", True, False))
        If M_Ct.Trim <> "" Then CyberSmodb.V_CyberSaveToSQL(AppConn, osysvar, M_User_Name, Dt_DetailTmp, M_Ct, M_Mode, "Stt_Rec =N'" + M_Stt_Rec + "'")
        '-----------------------------------------------------------------------------------------------------
        '---Save: Post
        CyberSupport.V_PostVoucher(M_Mode, M_Ma_CT, M_Stt_Rec, M_Ma_Dvcs, M_User_Name, AppConn, CyberSmlib)
    End Sub
    Private Sub V_Copy(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If M_Stt_Rec.Trim = "" Then Exit Sub
        If Not ChkRightsVoucher("C") Then Exit Sub
        If CbbMa_GD.SelectedValue.ToString.Trim = "1" Then
            Dim _Title As String = If(M_LAN = "V", "Chứng từ thanh toán theo hóa đơn không copy được", "Payment vouchers are invoiced not copy")
            MsgBox(_Title, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, osysvar("M_CYBER_VER"))
            Exit Sub '---KHong Copy thanh toan theo hoa don
        End If
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

    End Sub
    Private Sub V_New(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_RecOld = M_Stt_Rec
        If Not ChkRightsVoucher("M") Then Exit Sub
        M_Stt_Rec = CyberSmlib.V_Get_Stt_Rec(M_Ma_CT, AppConn)

        M_Mode = "M"
        V_Databing()
        '--------------
        TxtStt_Rec.Text = M_Stt_Rec
        TxtMa_Dvcs.Text = M_Ma_Dvcs
        If txtDien_giai.Text.Trim = "" Then txtDien_giai.Text = M_Dien_Giai

        V_New()
        CyberMe.V_SetEnabled(Me, M_Mode, Dt_Master)
        V_Setstatus()
        V_SetFocus("M")
        '----------------------------------------------------------------------------
        CyberSmodb.SetValueFromCombox(CbbMa_TTCP_H, M_Ma_TTCP_H)
        '----------------------------------------------------------------------------
    End Sub
    Private Sub V_New()
        If Dt_DetailTmp.Rows.Count < 1 Then
            Dim DrCurren As DataRow
            Dt_DetailTmp.NewRow()
            DrCurren = Dt_DetailTmp.NewRow
            CyberSmodb.SetValueBlankRow(DrCurren)


            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Ngay_Ct") = TxtNgay_Ct.Value
            DrCurren.Item("Stt_Rec0") = "0001"

            Dt_DetailTmp.Rows.Add(DrCurren)
            Dt_DetailTmp.AcceptChanges()
        End If

        If Dt_Detailtmpkhac.Rows.Count < 1 Then
            Dim DrCurren As DataRow
            Dt_Detailtmpkhac.NewRow()
            DrCurren = Dt_Detailtmpkhac.NewRow
            CyberSmodb.SetValueBlankRow(DrCurren)


            DrCurren.Item("Stt_Rec") = M_Stt_Rec.Trim
            DrCurren.Item("Ma_Ct") = M_Ma_CT.Trim
            DrCurren.Item("Ngay_Ct") = TxtNgay_Ct.Value
            DrCurren.Item("Stt_Rec0") = "0001"

            Dt_Detailtmpkhac.Rows.Add(DrCurren)
            Dt_Detailtmpkhac.AcceptChanges()
        End If

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
    Private Sub V_Print(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not ChkRightsVoucher("P") Then Exit Sub
        If M_Stt_Rec.Trim = "" Then Exit Sub
        Dim _Dt As Date = TxtNgay_Ct.Value
        Dim _Ma_Post As String = CbbMa_Post.SelectedValue.ToString.Trim
        CyberVoucher.V_PrintVocuher(AppConn, osysvar, Nothing, M_Stt_Rec, _Dt, _Ma_Post, M_LAN, M_Para, DrDmct, M_Ma_CT, M_Ma_Dvcs, M_User_Name, CyberSmlib, CyberSupport)
    End Sub
    Private Sub V_Cancel(ByVal sender As System.Object, ByVal e As System.EventArgs)
        M_Stt_Rec = M_Stt_RecOld
        V_Databing()
        M_Mode = "X"
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
        '------Khong cho them dong khi ma_Gd =1: Thu theo hoa don
        If CbbMa_GD.SelectedValue.ToString.Trim.ToUpper = "1" Then Exit Sub
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
#Region "Add Or Detete Item Khac"
    Private Sub MasterGRVKhac_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = sender.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = sender.RowCount - 1
        Dim iRowRowFocus As Integer = sender.FocusedRowHandle
        Dim iColumnRowFocus As Integer = sender.VisibleColumns.IndexOf(sender.FocusedColumn)
        Dim iRowOld As Integer = sender.GetFocusedDataSourceRowIndex
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub
        If e.KeyCode = Keys.Enter Then
            V_AddItemkhac(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Sub V_AddItemkhac(Optional ByVal iRow As Integer = -1)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim DrvOld As DataRowView
        '===================================
        Dim vTbAdd As New DataView
        Dim TbHeader As New DataTable
        vTbAdd = Dv_Detailtmpkhac
        TbHeader = M_DsHead.Tables(2)
        '===================================
        If iRow > 0 Then DrvOld = vTbAdd.Item(iRow) Else DrvOld = Nothing
        vTbAdd.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1), New DataView(TbHeader))
        CarrOnkhac(vTbAdd.Table.Rows(vTbAdd.Table.Rows.Count - 1))
        UpdateList()
    End Sub
    Private Sub CarrOnkhac(ByVal DvNew As DataRow)
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
        For iRow = 0 To Dt_DetailTmp.Rows.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dt_DetailTmp.AcceptChanges()
    End Sub
    Private Sub SetTxt()

    End Sub
#End Region
#Region "TTCP Default and New/Save _TTCP"
    Dim M_Is_Visible_TTCP As Boolean = False
    Dim DtTTCP As DataTable
    Dim M_Ma_TTCP_H As String = ""
    Dim M_Ten_TTCP_H As String = ""
    Dim M_Ten_TTCP2_H As String = ""

    Dim M_Ma_TTLN_H As String = ""
    Dim M_Ten_TTLN_H As String = ""
    Dim M_Ten_TTLN2_H As String = ""

    Dim M_Ma_HS_H As String = ""
    Dim M_Ten_HS_H As String = ""
    Dim M_Ten_HS2_H As String = ""

    Dim M_Ma_BP_H As String = ""
    Dim M_Ten_BP_H As String = ""
    Dim M_Ten_BP2_H As String = ""
    Private Sub V_LoadDefault()
        If DrDmct.Table.Columns.Contains("Is_Visible_TTCP") Then M_Is_Visible_TTCP = (DrDmct.Item("Is_Visible_TTCP").ToString.Trim = "1")
        LabMa_TTCP_H.Visible = M_Is_Visible_TTCP
        CbbMa_TTCP_H.Visible = M_Is_Visible_TTCP
        If M_Is_Visible_TTCP And DrDmct.Table.Columns.Contains("CaptionTTCP") Then If DrDmct.Item("CaptionTTCP").ToString.Trim <> "" Then LabMa_TTCP_H.Text = DrDmct.Item("CaptionTTCP").ToString.Trim

        If M_Is_Visible_TTCP Then
            Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_SysGetDefaultVoucher", M_Ma_CT.Trim & "#" & M_Ma_Dvcs.ToString().Trim() & "#" & M_User_Name.ToString().Trim())

            If DsTmp.Tables.Count = 0 Then
                M_Is_Visible_TTCP = False
                DsTmp.Dispose()
                Return
            End If

            If DsTmp.Tables(0).Columns.Contains("Ma_TTCP_H") Then M_Ma_TTCP_H = DsTmp.Tables(0).Rows(0).Item("Ma_TTCP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTCP_H") Then M_Ten_TTCP_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTCP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTCP2_H") Then M_Ten_TTCP2_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTCP2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_TTLN_H") Then M_Ma_TTLN_H = DsTmp.Tables(0).Rows(0).Item("Ma_TTLN_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTLN_H") Then M_Ten_TTLN_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTLN_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_TTLN2_H") Then M_Ten_TTLN2_H = DsTmp.Tables(0).Rows(0).Item("Ten_TTLN2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_HS_H") Then M_Ma_HS_H = DsTmp.Tables(0).Rows(0).Item("Ma_HS_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_HS_H") Then M_Ten_HS_H = DsTmp.Tables(0).Rows(0).Item("Ten_HS_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_HS2_H") Then M_Ten_HS2_H = DsTmp.Tables(0).Rows(0).Item("Ten_HS2_H").ToString.Trim

            If DsTmp.Tables(0).Columns.Contains("Ma_BP_H") Then M_Ma_BP_H = DsTmp.Tables(0).Rows(0).Item("Ma_BP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_BP_H") Then M_Ten_BP_H = DsTmp.Tables(0).Rows(0).Item("Ten_BP_H").ToString.Trim
            If DsTmp.Tables(0).Columns.Contains("Ten_BP2_H") Then M_Ten_BP2_H = DsTmp.Tables(0).Rows(0).Item("Ten_BP2_H").ToString.Trim

            If DsTmp.Tables.Count > 1 Then
                DtTTCP = DsTmp.Tables(1).Copy
                CyberFill.V_FillComBoxValue(Me.CbbMa_TTCP_H, DtTTCP, "Ma_TTCP", If(M_LAN = "V", "Ten_TTCP", "Ten_TTCP2"), M_Ma_TTCP_H)
            Else
                M_Is_Visible_TTCP = False
            End If

            DsTmp.Dispose()
        End If
    End Sub


#End Region
End Class
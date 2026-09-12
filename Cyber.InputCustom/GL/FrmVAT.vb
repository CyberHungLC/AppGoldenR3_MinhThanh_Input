Imports System.Data.SqlClient
Imports System.Windows.Forms
Public Class FrmVAT
#Region "Khai bao bien Dll"
    Dim CyberVoucher As New Cyber.Voucher.Sys
    Dim CyberFill As New Cyber.Fill.Sys
    Dim CyberMe As New Cyber.From.Frmvoucher
    Dim CyberFrom As New Cyber.From.Sys
    Dim CyberSmlib As New Cyber.SmLib.Sys
    Dim CyberSmlistSys As New Cyber.SmLists.Sys
    Dim CyberSmodb As New Cyber.Smodb.Sys
    Dim CyberSupport As New Cyber.Support.Sys
    Dim oSysvar As Collection
    Dim M_LAN, M_ma_Ct, M_Ma_NT, M_Ma_Dvcs, M_User_name, M_Ma_Post As String
    Dim M_Ngay_Ct, M_Ngay_LCT As Date
    Dim M_Ty_Gia As Decimal = 1

    Dim M_R_TIEN As Decimal = 0
    Dim M_R_TIEN_NT As Decimal = 0
    Dim M_R_GIA As Decimal = 0
    Dim M_R_GIA_NT As Decimal = 0

    Dim M_DsLookup As DataSet
    Dim M_Mode As String
    Dim M_Para As String()
#End Region
#Region "Columns Edit"
    Dim EditMa_Thue, EditMau_BC, EditTk, EditTk_Thue_No, EditTk_Du, EditMa_kh As New Cyber.Fill.CyberColumnGridView
    Dim EditMa_VT, EditMa_Vitri, EditMa_Kho, EditMa_Vv, EditMa_phi, EditMa_HD, EditMa_Sp, EditMa_ku, EditMa_TTLN, EditMa_TTCP, EditMa_BP, EditMa_HS, EditMa_CD, EditMa_TD1, EditMa_TD2, EditMa_TD3, EditMa_TD4, EditMa_TD5 As New Cyber.Fill.CyberColumnGridView
    Dim Editma_Db, EditMa_Xe, EditMa_KX, EditMa_Tuyen, EditMa_Ts, EditMa_Cc As New Cyber.Fill.CyberColumnGridView
    Dim EditSua_Thue, EditT_Tien_NT, EditT_Tien, EditT_Thue_NT, EditT_Thue, EditThue_Suat, EditT_TT_NT, EditT_TT, EditSo_Luong, EditGia, EditGia_NT, EditGhi_Chu, EditTen_kh, EditDia_Chi, EditMa_So_Thue As New Cyber.Fill.CyberColumnGridView
    Dim EditTen_Tk, EditSo_SO, EditSo_PO, EditSo_Ro, EditSo_VT As New Cyber.Fill.CyberColumnGridView
#End Region
    Dim M_Ma_TTCP As String = ""
    Private Sub HDK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ReturnOk = False
        oSysvar = Me.Sysvar
        M_LAN = Me.Lan
        M_ma_Ct = Me.Ma_CT
        M_Ma_Dvcs = Me.Ma_Dvcs
        M_User_name = Me.User_name
        M_Ma_NT = Me.Ma_NT
        M_Ngay_Ct = Me.Ngay_Ct
        M_Ngay_LCT = Me.Ngay_lCt
        M_Ty_Gia = Me.Ty_Gia
        M_Ma_Post = Me.Ma_Post
        M_Para = Me.Para()
        M_DsLookup = Me.DsLooKUp
        M_Mode = Me.Mode
        V_Load()
        V_GetColumn()
        V_AddHandler()
        V_SetProperty()
        V_MainSystem()
        UpdateList()
        M_Ma_TTCP = CyberSupport.V_GetDefault_TTCP(Ma_CT, M_Ma_Dvcs, M_User_name, AppConn, CyberSmlib)
        If DrDmct.Table.Columns.Contains("Import") Then If DrDmct.Item("Import").ToString.Trim = "1" Then CmdImport.Visible = True Else CmdImport.Visible = False Else CmdImport.Visible = False

    End Sub
#Region "Load..."
    Private Sub V_Load()
        Detail.DataSource = Me.Dv_Vat
        Me.DetailGRV.GridControl = Me.Detail
        CyberFill.V_FillVoucher(DetailGRV, Me.Lan, New DataView(Me.DsHead.Tables(2)), Dv_Vat)

        TxtT_Tien_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_Tien_NT.InputMask)
        TxtT_Tien.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Tien.InputMask)

        TxtT_thue_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_thue_NT.InputMask)
        TxtT_Thue.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_Thue.InputMask)

        TxtT_TT_NT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN_NT").ToString.Trim, TxtT_TT_NT.InputMask)
        TxtT_TT.InputMask = IIf(DrDmct.Item("M_IP_MK_TIEN").ToString.Trim <> "", DrDmct.Item("M_IP_MK_TIEN").ToString.Trim, TxtT_TT.InputMask)

        M_R_TIEN = DrDmct.Item("M_R_Tien")
        M_R_TIEN_NT = DrDmct.Item("M_R_Tien_NT")
        M_R_GIA = DrDmct.Item("M_R_GIA")
        M_R_GIA_NT = DrDmct.Item("M_R_GIA_NT")
        If M_Ma_NT.ToString.Trim = "" Or M_Ma_NT.ToString.Trim.ToUpper = Me.Sysvar("M_MA_NT0").ToString.Trim.ToUpper Then
            M_R_TIEN_NT = M_R_TIEN
            M_R_GIA_NT = M_R_GIA
        End If

        For iRow As Integer = 0 To Me.Dv_Vat.Count - 1
            V_Tinh_Toan(iRow)
        Next

        If M_Mode.Trim = "S" Then Exit Sub
        For iRow As Integer = 0 To Me.Dv_Vat.Count - 1

            Dim _Ma_kh As String = Me.Dv_Vat(iRow).Item("MA_KH")
            Dim _Return As DataRow = GetDrDmkh(_Ma_kh)
            If _Return Is Nothing Then Continue For

            Dim _ten_KhVat As String = _Return("Ten_khVAT")
            If _ten_KhVat.Trim = "" Then _ten_KhVat = _Return("Ten_kh")
            Dim _Dia_ChiVat As String = _Return("Dia_ChiVat")
            If _Dia_ChiVat.Trim = "" Then _Dia_ChiVat = _Return("Dia_Chi")

            Dim _Ma_So_ThueVat As String = _Return("Ma_So_Thue")
            Dim _ten_Kh As String = Dv_Vat.Item(iRow).Item("Ten_Kh")
            Dim _Dia_Chi As String = Dv_Vat.Item(iRow).Item("Dia_Chi")
            Dim _Ma_So_THue As String = Dv_Vat.Item(iRow).Item("Ma_So_Thue")
            Dv_Vat.Item(iRow).BeginEdit()
            If _ten_KhVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ten_kh") = _ten_KhVat
            If _Dia_ChiVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Dia_Chi") = _Dia_ChiVat
            If _Ma_So_ThueVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ma_So_Thue") = _Ma_So_ThueVat

            Dv_Vat.Item(iRow).EndEdit()
        Next
    End Sub
    Private Sub V_SetProperty()
        '---
        Dim FixCol As Integer = -1
        FixCol = DrDmct.Item("ColFrozen_DetailVAT")
        If FixCol < DetailGRV.Columns.Count And FixCol > 0 Then
            For iCol = 0 To FixCol
                DetailGRV.Columns(iCol).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Next
        End If
        DetailGRV.OptionsNavigation.EnterMoveNextColumn = True
        Me.DetailGRV.Appearance.SelectedRow.BackColor = System.Drawing.Color.Brown
        If Me.Ma_NT.Trim = "" Or Me.Ma_NT.Trim.ToUpper = oSysvar("M_MA_NT0").ToString.Trim.ToUpper Then
            EditT_Tien.Visible = False
            EditT_Thue.Visible = False
            EditT_TT.Visible = False
            EditGia.Visible = False

            TxtT_Tien.Visible = False
            TxtT_Thue.Visible = False
            TxtT_TT.Visible = False
        Else
            EditT_Tien.Visible = True
            EditT_Thue.Visible = True
            EditT_TT.Visible = True
            EditGia.Visible = True

            TxtT_Tien.Visible = True
            TxtT_Thue.Visible = True
            TxtT_TT.Visible = True
        End If
    End Sub
    Private Sub V_GetColumn()
        EditTk.GetColumn(DetailGRV, "TK")
        EditTen_Tk.GetColumn(DetailGRV, "TEN_TK")
        EditTk_Thue_No.GetColumn(DetailGRV, "TK_Thue_No")
        EditTk_Du.GetColumn(DetailGRV, "TK_Du")

        EditMau_BC.GetColumn(DetailGRV, "Mau_BC")
        EditMa_Kho.GetColumn(DetailGRV, "Ma_kho")
        EditMa_VT.GetColumn(DetailGRV, "Ma_VT")

        EditMa_kh.GetColumn(DetailGRV, "Ma_kh")
        EditTen_kh.GetColumn(DetailGRV, "TEN_KH")
        EditDia_Chi.GetColumn(DetailGRV, "Dia_Chi")
        EditMa_So_Thue.GetColumn(DetailGRV, "Ma_So_Thue")
        EditGhi_Chu.GetColumn(DetailGRV, "Ghi_Chu")

        EditSua_Thue.GetColumn(DetailGRV, "Sua_Thue")
        EditT_Tien_NT.GetColumn(DetailGRV, "T_TIEN_NT")
        EditT_Tien.GetColumn(DetailGRV, "T_TIEN")
        EditT_Thue_NT.GetColumn(DetailGRV, "T_Thue_NT")
        EditT_Thue.GetColumn(DetailGRV, "T_Thue")
        EditT_TT_NT.GetColumn(DetailGRV, "T_TT_NT")
        EditT_TT.GetColumn(DetailGRV, "T_TT")

        EditMa_Thue.GetColumn(DetailGRV, "Ma_THue")
        EditThue_Suat.GetColumn(DetailGRV, "Thue_Suat")
        EditSo_Luong.GetColumn(DetailGRV, "So_Luong")
        EditGia.GetColumn(DetailGRV, "Gia")
        EditGia_NT.GetColumn(DetailGRV, "Gia_NT")

        EditMa_Vv.GetColumn(DetailGRV, "Ma_Vv")
        EditMa_phi.GetColumn(DetailGRV, "Ma_Phi")
        EditMa_HD.GetColumn(DetailGRV, "Ma_HD")
        EditMa_Sp.GetColumn(DetailGRV, "Ma_SP")
        EditMa_ku.GetColumn(DetailGRV, "Ma_KU")
        EditMa_TTLN.GetColumn(DetailGRV, "Ma_TTLN")
        EditMa_TTCP.GetColumn(DetailGRV, "Ma_TTCP")
        EditMa_BP.GetColumn(DetailGRV, "Ma_BP")
        EditMa_HS.GetColumn(DetailGRV, "Ma_Hs")
        EditMa_CD.GetColumn(DetailGRV, "Ma_CD")

        EditMa_TD1.GetColumn(DetailGRV, "Ma_TD1")
        EditMa_TD2.GetColumn(DetailGRV, "Ma_TD2")
        EditMa_TD3.GetColumn(DetailGRV, "Ma_TD3")
        EditMa_TD4.GetColumn(DetailGRV, "Ma_TD4")
        EditMa_TD5.GetColumn(DetailGRV, "Ma_TD5")

        EditSo_SO.GetColumn(DetailGRV, "SO_SO")
        EditSo_PO.GetColumn(DetailGRV, "SO_PO")
        EditSo_RO.GetColumn(DetailGRV, "SO_RO")
        EditSo_VT.GetColumn(DetailGRV, "SO_VT")

        Editma_Db.GetColumn(DetailGRV, "Ma_Db")
        EditMa_Xe.GetColumn(DetailGRV, "MA_XE")
        EditMa_Tuyen.GetColumn(DetailGRV, "Ma_TUYEN")
        EditMa_Ts.GetColumn(DetailGRV, "Ma_Ts")
        EditMa_Cc.GetColumn(DetailGRV, "Ma_Cc")
    End Sub
    Private Sub V_AddHandler()
        AddHandler CmdOK.Click, AddressOf V_Save
        AddHandler CmdImport.Click, AddressOf V_Import

        AddHandler CmdExit.Click, AddressOf V_Exit
        AddHandler DetailGRV.KeyDown, AddressOf MasterGRV_KeyDown

        If Not EditSo_Luong Is Nothing Then AddHandler EditSo_Luong.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditGia_NT.Column Is Nothing Then AddHandler EditGia_NT.EditColumn.Leave, AddressOf L_Tien_NT
        If Not EditGia.Column Is Nothing Then AddHandler EditGia.EditColumn.Leave, AddressOf L_Tien_NT


        If Not EditSua_Thue.Column Is Nothing Then AddHandler EditSua_Thue.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditT_Tien_NT.Column Is Nothing Then AddHandler EditT_Tien_NT.EditColumn.Leave, AddressOf L_Tien_NT
        If Not EditT_Tien.Column Is Nothing Then AddHandler EditT_Tien.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditThue_Suat.Column Is Nothing Then AddHandler EditThue_Suat.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditT_Thue_NT.Column Is Nothing Then AddHandler EditT_Thue_NT.EditColumn.Leave, AddressOf L_Tien_NT
        If Not EditT_Thue.Column Is Nothing Then AddHandler EditT_Thue.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditT_TT_NT.Column Is Nothing Then AddHandler EditT_TT_NT.EditColumn.Leave, AddressOf L_Tien_NT
        If Not EditT_TT.Column Is Nothing Then AddHandler EditT_TT.EditColumn.Leave, AddressOf L_Tien_NT

        If Not EditGhi_Chu.Column Is Nothing Then AddHandler EditGhi_Chu.EditColumn.Enter, AddressOf E_Ghi_Chu
        If Not EditTen_kh.Column Is Nothing Then AddHandler EditTen_kh.EditColumn.Leave, AddressOf L_Ten_kh
        If Not EditDia_Chi.Column Is Nothing Then AddHandler EditDia_Chi.EditColumn.Leave, AddressOf L_Ten_kh
        If Not EditMa_So_Thue.Column Is Nothing Then AddHandler EditMa_So_Thue.EditColumn.Leave, AddressOf L_Ten_kh

        EditMa_Thue.V_ActiLookUpColumn(AddressOf V_Ma_Thue, AddressOf L_Ma_Thue)
        EditMau_BC.V_ActiLookUpColumn(AddressOf V_Mau_BC, AddressOf L_Mau_BC)
        EditTk.V_ActiLookUpColumn(AddressOf V_Tk, AddressOf L_Tk)
        EditTk_Thue_No.V_ActiLookUpColumn(AddressOf V_Tk_Thue_No, AddressOf L_Tk_Thue_No)
        EditTk_Du.V_ActiLookUpColumn(AddressOf V_Tk_DU, AddressOf L_Tk_DU)
        EditMa_kh.V_ActiLookUpColumn(AddressOf V_Ma_Kh, AddressOf L_Ma_kh)
        '--Vat tu-kho
        EditMa_VT.V_ActiLookUpColumn(AddressOf V_Ma_Vt, AddressOf L_Ma_Vt)
        EditMa_Kho.V_ActiLookUpColumn(AddressOf V_Ma_Kho, AddressOf L_Ma_Kho)
        EditMa_Vitri.V_ActiLookUpColumn(AddressOf V_Ma_Vitri, AddressOf L_Ma_Vitri)
        EditMa_Vv.V_ActiLookUpColumn(AddressOf V_Ma_Vv, AddressOf L_Ma_Vv)
        EditMa_phi.V_ActiLookUpColumn(AddressOf V_Ma_Phi, AddressOf L_Ma_Phi)
        EditMa_HD.V_ActiLookUpColumn(AddressOf V_Ma_Hd, AddressOf L_Ma_Hd)
        EditMa_Sp.V_ActiLookUpColumn(AddressOf V_Ma_Sp, AddressOf L_Ma_Sp)
        EditMa_ku.V_ActiLookUpColumn(AddressOf V_Ma_Ku, AddressOf L_Ma_Ku)
        EditMa_TTLN.V_ActiLookUpColumn(AddressOf V_Ma_TTLN, AddressOf L_Ma_TTLN)
        EditMa_TTCP.V_ActiLookUpColumn(AddressOf V_Ma_TTCP, AddressOf L_Ma_TTCP)
        EditMa_BP.V_ActiLookUpColumn(AddressOf V_Ma_Bp, AddressOf L_Ma_Bp)
        EditMa_HS.V_ActiLookUpColumn(AddressOf V_Ma_HS, AddressOf L_Ma_HS)
        EditMa_CD.V_ActiLookUpColumn(AddressOf V_Ma_CD, AddressOf L_Ma_CD)
        EditMa_TD1.V_ActiLookUpColumn(AddressOf V_Ma_TD1, AddressOf L_Ma_TD1)
        EditMa_TD2.V_ActiLookUpColumn(AddressOf V_Ma_TD2, AddressOf L_Ma_TD2)
        EditMa_TD3.V_ActiLookUpColumn(AddressOf V_Ma_TD3, AddressOf L_Ma_TD3)
        EditMa_TD4.V_ActiLookUpColumn(AddressOf V_Ma_TD4, AddressOf L_Ma_TD4)
        EditMa_TD5.V_ActiLookUpColumn(AddressOf V_Ma_TD5, AddressOf L_Ma_TD5)
        Editma_Db.V_ActiLookUpColumn(AddressOf V_Ma_DB, AddressOf L_Ma_DB)
        EditMa_Xe.V_ActiLookUpColumn(AddressOf V_Ma_Xe, AddressOf L_Ma_Xe)
        EditMa_KX.V_ActiLookUpColumn(AddressOf V_Ma_Kx, AddressOf L_Ma_Kx)
        EditMa_Tuyen.V_ActiLookUpColumn(AddressOf V_Ma_Tuyen, AddressOf L_Ma_Tuyen)
        EditMa_Ts.V_ActiLookUpColumn(AddressOf V_Ma_Ts, AddressOf L_Ma_Ts)
        EditMa_Cc.V_ActiLookUpColumn(AddressOf V_Ma_Cc, AddressOf L_Ma_Cc)

        If Not EditSo_SO.Column Is Nothing Then AddHandler EditSo_SO.EditColumn.Leave, AddressOf L_So_So
        If Not EditSo_PO.Column Is Nothing Then AddHandler EditSo_PO.EditColumn.Leave, AddressOf L_So_Po
        If Not EditSo_Ro.Column Is Nothing Then AddHandler EditSo_Ro.EditColumn.Leave, AddressOf L_So_Ro
        If Not EditSo_VT.Column Is Nothing Then AddHandler EditSo_VT.EditColumn.Leave, AddressOf L_So_VT

    End Sub
#End Region
#Region "Valid - Detail - Core"
    Private Sub UpdateList()
        Dim nT_Tien_NT As Decimal = 0
        Dim nT_Tien As Decimal = 0

        Dim nT_Thue_NT As Decimal = 0
        Dim nT_Thue As Decimal = 0

        Dim nT_TT_NT As Decimal = 0
        Dim nT_TT As Decimal = 0

        For iRow = 0 To Dv_Vat.Count - 1
            nT_Thue_NT = nT_Thue_NT + Dv_Vat.Item(iRow).Item("T_Thue_nt")
            nT_Thue = nT_Thue + Dv_Vat.Item(iRow).Item("T_Thue")
            nT_Tien_NT = nT_Tien_NT + Dv_Vat.Item(iRow).Item("T_Tien_NT")
            nT_Tien = nT_Tien + Dv_Vat.Item(iRow).Item("T_Tien")
        Next
        nT_TT_NT = nT_Tien_NT + nT_Thue_NT
        nT_TT = nT_Tien + nT_Thue

        TxtT_Tien_NT.Double = nT_Tien_NT
        TxtT_Tien.Double = nT_Tien

        TxtT_thue_NT.Double = nT_Thue_NT
        TxtT_Thue.Double = nT_Thue

        TxtT_TT_NT.Double = nT_TT_NT
        TxtT_TT.Double = nT_TT

    End Sub
    Private Sub L_Tien_NT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim drvCurren As DataRowView
        drvCurren = DetailGRV.GetFocusedRow
        CyberSupport.V_UpdateGRV(DetailGRV)
        V_Tinh_Toan(iRow)
    End Sub
    Private Sub V_Tinh_Toan(ByVal iRow)
        '----------------------------------------------------------------------------------------------------------
        '----------ToanLC: 2019.11.01
        Dim _Sua_Thue As Boolean = False
        If Dv_Vat.Table.Columns.Contains("Sua_Thue") Then
            If Dv_Vat.Item(iRow).Item("Sua_Thue").ToString.Trim = "1" Then
                _Sua_Thue = True
            End If
        End If
        '----------------------------------------------------------------------------------------------------------
        If Dv_Vat.Item(iRow).Item("So_Luong") * Dv_Vat.Item(iRow).Item("Gia") <> 0 Then
            Dv_Vat.Item(iRow).BeginEdit()
            Dv_Vat.Item(iRow).Item("T_Tien") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("So_Luong") * Dv_Vat.Item(iRow).Item("Gia"), M_R_TIEN_NT)
            Dv_Vat.Item(iRow).EndEdit()
        End If
        '-----------------------------------------------
        If Dv_Vat.Item(iRow).Item("So_Luong") * Dv_Vat.Item(iRow).Item("Gia_NT") <> 0 Then
            Dv_Vat.Item(iRow).BeginEdit()
            Dv_Vat.Item(iRow).Item("T_Tien_NT") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("So_Luong") * Dv_Vat.Item(iRow).Item("Gia_NT"), M_R_TIEN_NT)
            Dv_Vat.Item(iRow).EndEdit()
        End If
        '----------------------------------------------------------------------------------------------------------
        If Dv_Vat.Item(iRow).Item("T_Thue_NT") = 0 And Not _Sua_Thue Then
            Dv_Vat.Item(iRow).BeginEdit()
            Dv_Vat.Item(iRow).Item("T_Thue_NT") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Tien_NT") * Dv_Vat.Item(iRow).Item("Thue_Suat") / 100, M_R_TIEN_NT)
            Dv_Vat.Item(iRow).EndEdit()
        End If
        '-----------------------------------------------
        If Dv_Vat.Item(iRow).Item("T_Thue") = 0 And Not _Sua_Thue Then
            Dv_Vat.Item(iRow).BeginEdit()
            Dv_Vat.Item(iRow).Item("T_Thue") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Tien") * Dv_Vat.Item(iRow).Item("Thue_Suat") / 100, M_R_TIEN_NT)
            Dv_Vat.Item(iRow).EndEdit()
        End If
        '----------------------------------------------------------------------------------------------------------
        'If Dv_Vat.Item(iRow).Item("T_Tien_NT") * Dv_Vat.Item(iRow).Item("Thue_Suat") <> 0 Then
        '    Dim _T_Thue_NT_1 As Decimal = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Tien_NT") * Dv_Vat.Item(iRow).Item("Thue_Suat") / 100)
        '    Dim _T_Thue_NT_2 As Decimal = Dv_Vat.Item(iRow).Item("T_Thue_NT")
        '    If Not (_T_Thue_NT_2 >= _T_Thue_NT_1 - 2 And _T_Thue_NT_2 <= _T_Thue_NT_1 + 2) Then
        '        Dv_Vat.Item(iRow).BeginEdit()
        '        Dv_Vat.Item(iRow).Item("T_Thue_NT") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Tien_NT") * Dv_Vat.Item(iRow).Item("Thue_Suat") / 100)
        '        Dv_Vat.Item(iRow).EndEdit()

        '    End If
        'End If
        '----------------------------------------------------------------------------------------------------------
        Dv_Vat.Item(iRow).BeginEdit()
        If M_Ma_NT.Trim = "" Or M_Ma_NT.ToUpper.Trim = oSysvar("M_Ma_NT0").ToString.Trim.ToUpper Then
            'If Dv_Vat.Item(iRow).Item("T_Tien_NT") <> 0 Then Dv_Vat.Item(iRow).Item("T_Tien") = Dv_Vat.Item(iRow).Item("T_Tien_NT")
            'If Dv_Vat.Item(iRow).Item("T_Thue_NT") <> 0 Then Dv_Vat.Item(iRow).Item("T_Thue") = Dv_Vat.Item(iRow).Item("T_Thue_NT")
            Dv_Vat.Item(iRow).Item("T_Tien") = Dv_Vat.Item(iRow).Item("T_Tien_NT")
            Dv_Vat.Item(iRow).Item("T_Thue") = Dv_Vat.Item(iRow).Item("T_Thue_NT")

            Dv_Vat.Item(iRow).Item("Gia") = Dv_Vat.Item(iRow).Item("Gia_NT")
        Else
            If Dv_Vat.Item(iRow).Item("T_Tien_NT") <> 0 Then Dv_Vat.Item(iRow).Item("T_Tien") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Tien_NT") * M_Ty_Gia, M_R_TIEN)
            If Dv_Vat.Item(iRow).Item("T_Thue_NT") <> 0 Then Dv_Vat.Item(iRow).Item("T_Thue") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("T_Thue_NT") * M_Ty_Gia, M_R_TIEN)
            Dv_Vat.Item(iRow).Item("Gia") = CyberSupport.V_Round(Dv_Vat.Item(iRow).Item("Gia_NT") * M_Ty_Gia, M_R_GIA)
        End If

        Dv_Vat.Item(iRow).EndEdit()
        '----------------------------------------------------------------------------------------------------------
        Dv_Vat.Item(iRow).BeginEdit()
        Dv_Vat.Item(iRow).Item("T_TT") = Dv_Vat.Item(iRow).Item("T_Tien") + Dv_Vat.Item(iRow).Item("T_Thue")
        Dv_Vat.Item(iRow).Item("T_TT_NT") = Dv_Vat.Item(iRow).Item("T_Tien_NT") + Dv_Vat.Item(iRow).Item("T_Thue_NT")
        Dv_Vat.Item(iRow).EndEdit()
        '----------------------------------------------------------------------------------------------------------
        UpdateList()
    End Sub
    Private Sub V_Ma_Thue(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Thue", "DmThue", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, Me.AppConn, Me.DsLooKUp, sender)
    End Sub
    Private Sub L_Ma_Thue(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim _Return As DataRow = CyberSupport.L_Ma("Ma_Thue", "Ma_Thue", "Ten_Thue", "Ten_Thue", M_Mode, M_ma_Ct, sender, DetailGRV)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dv_Vat.Item(iRow).BeginEdit()
        If _Return Is Nothing Then
            Dv_Vat.Item(iRow).Item("Thue_Suat") = 0
        Else
            Dv_Vat.Item(iRow).Item("Thue_Suat") = _Return.Item("Thue_Suat")
        End If
        Dv_Vat.Item(iRow).EndEdit()
        V_Tinh_Toan(iRow)
    End Sub
    Private Sub V_Mau_BC(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Mau_BC", "DmMauVAT", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, Me.AppConn, Me.DsLooKUp, sender)
    End Sub
    Private Sub L_Mau_BC(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Mau_BC", "Mau_BC", "Ten_MauBC", "Ten_MauBC", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Tk(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Tk(M_Mode, M_Ma_CT, M_LAN, M_Para, osysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Tk(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Tk(M_Mode, M_Ma_CT, sender, DetailGRV)
    End Sub
    Private Sub V_Tk_Thue_No(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("TK", "DmTk", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Tk_Thue_No(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Tk_Thue_No", "TK", "", "Ten_Tk", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Tk_DU(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("TK", "DmTk", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLooKUp, sender)
    End Sub
    Private Sub L_Tk_DU(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Tk_Du", "TK", "", "Ten_Tk", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kh(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Kh", "DmKh", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLooKUp, sender)
    End Sub
    Public Sub L_Ma_kh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim drvCurren As DataRowView
        drvCurren = DetailGRV.GetFocusedRow
        If drvCurren Is Nothing Then Exit Sub
        If drvCurren("Ma_kh").ToString.Trim = "" Then Exit Sub
        Dim DrReturn As DataRow = sender.GetRowsSelectData(True)


        If Not DrReturn Is Nothing Then
            drvCurren("Ma_kh") = DrReturn("Ma_kh")
            'If drvCurren("Ten_kh").ToString.Trim = "" Then drvCurren("Ten_kh") = IIf(DrReturn("Ten_KhVAT").ToString.Trim <> "", DrReturn("Ten_KhVAT"), DrReturn("Ten_Kh"))
            'If drvCurren("Dia_Chi").ToString.Trim = "" Then drvCurren("Dia_Chi") = IIf(DrReturn("Dia_ChiVAT").ToString.Trim <> "", DrReturn("Dia_ChiVAT"), DrReturn("Dia_Chi"))
            'If drvCurren("Ma_So_Thue").ToString.Trim = "" Then drvCurren("Ma_So_Thue") = IIf(drvCurren("Ma_So_Thue").ToString.Trim = "", DrReturn("Ma_So_Thue"), drvCurren("Ma_So_Thue"))

            If Not DrReturn("Ten_KhVAT").ToString.Trim = "" Then drvCurren("Ten_kh") = DrReturn("Ten_KhVAT")
            If Not DrReturn("Dia_ChiVAT").ToString.Trim = "" Then drvCurren("Dia_Chi") = DrReturn("Dia_ChiVAT")

            If DrReturn("Ten_KhVAT").ToString.Trim = "" And Not DrReturn("Ten_Kh").ToString.Trim = "" Then drvCurren("Ten_kh") = DrReturn("Ten_Kh")
            If DrReturn("Dia_ChiVAT").ToString.Trim = "" And Not DrReturn("Dia_Chi").ToString.Trim = "" Then drvCurren("Dia_Chi") = DrReturn("Dia_Chi")

            If Not DrReturn("Ma_So_Thue").ToString.Trim = "" Then drvCurren("Ma_So_Thue") = DrReturn("Ma_So_Thue")
            'If Not DrReturn("url_hddt").ToString.Trim = "" Then drvCurren("url_hddt") = DrReturn("url_hddt")

        End If
    End Sub
    Public Sub L_Ten_kh(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ma_kh As String = Dv_Vat.Item(iRow).Item("Ma_Kh")

        If _Ma_kh.Trim = "" Then Exit Sub
        '----------------------------------------------------------------------------------
        Dim _Return As DataRow = GetDrDmkh(_Ma_kh)
        If _Return Is Nothing Then Exit Sub
        Dim _ten_KhVat As String = _Return("Ten_khVAT").ToString.Trim
        If _ten_KhVat.Trim = "" Then _ten_KhVat = _Return("Ten_kh").ToString.Trim
        Dim _Dia_ChiVat As String = _Return("Dia_ChiVat").ToString.Trim
        If _Dia_ChiVat.Trim = "" Then _Dia_ChiVat = _Return("Dia_Chi").ToString.Trim
        Dim _Ma_So_ThueVat As String = _Return("Ma_So_Thue").ToString.Trim

        Dim _ten_Kh As String = _Return.Item("Ten_Kh").ToString.Trim
        Dim _Dia_Chi As String = _Return.Item("Dia_Chi").ToString.Trim

        If _ten_KhVat.Trim = "" Then _ten_KhVat = _ten_Kh
        If _Dia_ChiVat.Trim = "" Then _Dia_ChiVat = _Dia_Chi

        '----------------------------------------------------------------------------------
        'Dim _ten_Kh As String = Dv_Vat.Item(iRow).Item("Ten_Kh")
        'Dim _Dia_Chi As String = Dv_Vat.Item(iRow).Item("Dia_Chi")
        'Dim _Ma_So_THue As String = Dv_Vat.Item(iRow).Item("Ma_So_Thue")

        Dv_Vat.Item(iRow).BeginEdit()

        Dv_Vat.Item(iRow).Item("Ten_kh") = If(Dv_Vat.Item(iRow).Item("Ten_kh").ToString.Trim = "", _ten_KhVat, Dv_Vat.Item(iRow).Item("Ten_kh"))
        Dv_Vat.Item(iRow).Item("Dia_Chi") = If(Dv_Vat.Item(iRow).Item("Dia_Chi").ToString.Trim = "", _Dia_ChiVat, Dv_Vat.Item(iRow).Item("Dia_Chi"))
        Dv_Vat.Item(iRow).Item("Ma_So_Thue") = If(Dv_Vat.Item(iRow).Item("Ma_So_Thue").ToString.Trim = "", _Ma_So_ThueVat, Dv_Vat.Item(iRow).Item("Ma_So_Thue"))

        'If _ten_Kh.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ten_kh") = _ten_KhVat
        'If _Dia_Chi.Trim <> "" Then Dv_Vat.Item(iRow).Item("Dia_Chi") = _Dia_ChiVat
        'If _Ma_So_THue.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ma_So_Thue") = _Ma_So_ThueVat

        'If _ten_KhVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ten_kh") = _ten_KhVat
        'If _Dia_ChiVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Dia_Chi") = _Dia_ChiVat
        'If _Ma_So_ThueVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ma_So_Thue") = _Ma_So_ThueVat

        'If _ten_KhVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ten_kh") = If(_ten_Kh = "", _ten_KhVat, _ten_Kh)
        'If _Dia_ChiVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Dia_Chi") = If(_Dia_Chi = "", _Dia_ChiVat, _Dia_Chi)
        'If _Ma_So_ThueVat.Trim <> "" Then Dv_Vat.Item(iRow).Item("Ma_So_Thue") = If(_Ma_So_THue = "", _Ma_So_ThueVat, _Ma_So_THue)

        Dv_Vat.Item(iRow).EndEdit()
    End Sub
    Private Function GetDrDmkh(ByVal _Ma_Kh As String) As DataRow
        Dim _ReturnDr As DataRow
        Dim DsTmp As DataSet = CyberSmlib.SQLExcuteStoreProcedure(AppConn, "CP_SysListoDirF3F4", "Ma_kh =N'" + _Ma_Kh.Replace("#", "").Replace("'", "") + "'" + "#" + "DmKh" + "#" + M_Ma_Dvcs + "#" + M_User_name)
        If DsTmp.Tables(0).Rows.Count > 0 Then _ReturnDr = DsTmp.Tables(0).Copy.Rows(0) Else _ReturnDr = Nothing
        GetDrDmkh = _ReturnDr
    End Function
    Private Sub E_Ghi_Chu(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M") Then Exit Sub
    End Sub
#End Region
#Region "Vat tu kho - "
    Dim DrReturn As DataRow
    Private Sub V_Ma_Vt(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vt(M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DrReturn = Nothing
        DrReturn = CyberSupport.L_Ma_Vt(M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kho(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Kho", "DmKho", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kho(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Kho", "Ma_Kho", "Ten_Kho", "ten_Kho", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma_Vitri(M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vitri(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma_Vitri(M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
#End Region
#Region "So_So/So_PO/So_RO/So_VT"
    Private Sub L_So_So(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = Now.Date
        Dim _ma_GD As String = "S"
        If Dv_Vat.Table.Columns.Contains("Ngay_Ct") Then _Ngay_Ct = Dv_Vat.Item(iRow).Item("Ngay_Ct")
        If Dv_Vat.Table.Columns.Contains("ma_GD") Then _ma_GD = Dv_Vat.Item(iRow).Item("ma_GD").ToString


        CyberVoucher.V_GetSo_SO(Dv_Vat, iRow, M_ma_Ct, _ma_GD, M_Mode, _Ngay_Ct, M_Ma_Dvcs)
    End Sub
    Private Sub L_So_Po(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = Now.Date
        Dim _ma_GD As String = "S"
        If Dv_Vat.Table.Columns.Contains("Ngay_Ct") Then _Ngay_Ct = Dv_Vat.Item(iRow).Item("Ngay_Ct")
        If Dv_Vat.Table.Columns.Contains("ma_GD") Then _ma_GD = Dv_Vat.Item(iRow).Item("ma_GD").ToString

        CyberVoucher.V_GetSo_PO(Dv_Vat, iRow, M_ma_Ct, _ma_GD, M_Mode, _Ngay_Ct, M_Ma_Dvcs)
    End Sub
    Private Sub L_So_Ro(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = Now.Date
        Dim _ma_GD As String = "S"
        If Dv_Vat.Table.Columns.Contains("Ngay_Ct") Then _Ngay_Ct = Dv_Vat.Item(iRow).Item("Ngay_Ct")
        If Dv_Vat.Table.Columns.Contains("ma_GD") Then _ma_GD = Dv_Vat.Item(iRow).Item("ma_GD").ToString

        CyberVoucher.V_FormatSo_Ro(Dv_Vat, iRow, AppConn, oSysvar, M_ma_Ct, "S", M_Mode, _Ngay_Ct, M_Ma_TTCP, M_Ma_Dvcs, M_User_name, CyberSmlib)
    End Sub
    Private Sub L_So_VT(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iRow As Integer = -1
        iRow = DetailGRV.GetFocusedDataSourceRowIndex
        If iRow < 0 Then Exit Sub
        Dim _Ngay_Ct As Date = Now.Date
        Dim _ma_GD As String = "S"
        If Dv_Vat.Table.Columns.Contains("Ngay_Ct") Then _Ngay_Ct = Dv_Vat.Item(iRow).Item("Ngay_Ct")
        If Dv_Vat.Table.Columns.Contains("ma_GD") Then _ma_GD = Dv_Vat.Item(iRow).Item("ma_GD").ToString

        CyberVoucher.V_GetSo_VT(Dv_Vat, iRow, M_ma_Ct, _ma_GD, M_Mode, _Ngay_Ct, M_Ma_Dvcs)
    End Sub
#End Region
#Region "Valid - Detail - Add On"
    Private Sub V_Ma_Vv(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_VV", "Dmvv", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Vv(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_VV", "Ma_VV", "Ten_VV", "ten_VV", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Phi(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Phi", "DmPhi", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Phi(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Phi", "Ma_Phi", "Ten_Phi", "ten_Phi", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Hd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Hd", "DmHd", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Hd(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Hd", "Ma_Hd", "Ten_Hd", "ten_Hd", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Sp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Sp", "DmSp", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Sp(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Sp", "Ma_Sp", "Ten_Sp", "ten_Sp", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Ku(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Ku", "DmKu", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Ku(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Ku", "Ma_Ku", "Ten_Ku", "ten_Ku", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TTLN(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TTLN", "DmTTLN", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTLN(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TTLN", "Ma_TTLN", "Ten_TTLN", "ten_TTLN", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TTCP(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TTCP", "DmTTCP", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TTCP(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TTCP", "Ma_TTCP", "Ten_TTCP", "ten_TTCP", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Bp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Bp", "DmBp", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Bp(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Bp", "Ma_Bp", "Ten_Bp", "ten_Bp", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_HS(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_HS", "DmHS", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_HS(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_HS", "Ma_HS", "Ten_HS", "ten_HS", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_CD(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_CD", "DmCD", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_CD(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_CD", "Ma_CD", "Ten_CD", "ten_CD", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TD1", "DmTD1", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TD1", "Ma_TD1", "Ten_TD1", "ten_TD1", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TD2", "DmTD2", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TD2", "Ma_TD2", "Ten_TD2", "ten_TD2", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD3(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TD3", "DmTD3", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TD3", "Ma_TD3", "Ten_TD3", "ten_TD3", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD4(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TD4", "DmTD4", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TD4", "Ma_TD4", "Ten_TD4", "ten_TD4", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_TD5(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_TD5", "DmTD5", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_TD5(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_TD5", "Ma_TD5", "Ten_TD5", "ten_TD5", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_DB(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_DB", "DmDB", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_DB(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_DB", "Ma_DB", "Ten_DB", "ten_DB", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Xe(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Xe", "DmXe", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Xe(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Xe", "Ma_Xe", "Ten_Xe", "ten_Xe", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Kx(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Kx", "DmKx", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Kx(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Kx", "Ma_Kx", "Ten_Kx", "ten_Kx", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Tuyen(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Tuyen", "DmTuyen", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Tuyen(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Tuyen", "Ma_Tuyen", "Ten_Tuyen", "ten_Tuyen", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Ts(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Ts", "DmTs", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Ts(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Ts", "Ma_Ts", "Ten_Ts", "ten_Ts", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
    Private Sub V_Ma_Cc(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        CyberSupport.V_Ma("Ma_Cc", "DmCc", "1=1", "1=1", M_Mode, M_ma_Ct, M_LAN, M_Para, oSysvar, AppConn, Me.DsLookup, sender)
    End Sub
    Private Sub L_Ma_Cc(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CyberSupport.L_Ma("Ma_Cc", "Ma_Cc", "Ten_Cc", "ten_Cc", M_Mode, M_ma_Ct, sender, DetailGRV)
    End Sub
#End Region
#Region "Button"
    Private Sub MasterGRV_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Not (M_Mode = "M" Or M_Mode = "S") Then Exit Sub
        Dim iCoumnVisible As Integer = DetailGRV.VisibleColumns.Count - 1
        Dim iRowVisible As Integer = DetailGRV.RowCount - 1
        Dim iRowRowFocus As Integer = DetailGRV.FocusedRowHandle
        Dim iColumnRowFocus As Integer = DetailGRV.VisibleColumns.IndexOf(DetailGRV.FocusedColumn)
        Dim iRowOld As Integer = DetailGRV.GetFocusedDataSourceRowIndex
        'If e.KeyCode = Keys.Enter And iRowVisible = iRowRowFocus And iCoumnVisible = iColumnRowFocus Then
        '    V_AddItem(iRowOld) '' Cot cuoi cung them dong
        'End If
       
        If iRowVisible <> iRowRowFocus Or iCoumnVisible <> iColumnRowFocus Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            V_AddItem(iRowOld) '' Cot cuoi cung them dong
        ElseIf e.KeyCode = Keys.End Then
            SendKeys.Send("^{Tab}")
        End If
    End Sub
    Private Function ChkSave() As Boolean
        Dim _Return As Boolean = True
        Dim nCount As Integer = Dt_Vat.Rows.Count - 1
        Dim iRow As Integer
        For iRow = nCount To 0 Step -1
            If Dt_Vat.Rows(iRow).Item("So_Ct0").ToString.Trim = "" Then Dt_Vat.Rows(iRow).Delete()
        Next
        Dt_Vat.AcceptChanges()
        nCount = Dt_Vat.Rows.Count - 1
        For iRow = nCount To 0 Step -1
            If Dt_Vat.Rows(iRow).Item("Ngay_Ct0") Is DBNull.Value Then
                Dt_Vat.Rows(iRow).Delete()
            End If
        Next
        Dt_Vat.AcceptChanges()
        nCount = Dt_Vat.Rows.Count - 1
        Dim _Dt As Date
        For iRow = nCount To 0 Step -1
            _Dt = Dt_Vat.Rows(iRow).Item("Ngay_Ct0")
            If _Dt.ToString("yyyyMMdd") = "19000101" Then Dt_Vat.Rows(iRow).Delete()
        Next

        Dt_Vat.AcceptChanges()
        '---------------------------------------------------------------------------------------------
        For iRow = 0 To Dt_Vat.Rows.Count - 1
            If Dt_Vat.Rows(iRow).Item("Tk_Thue_No").ToString.Trim = "" Then
                MsgBox(IIf(M_LAN = "V", "Bạn chưa nhập tài khoản thuế", "You did not enter a tax account"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, oSysvar("M_CYBER_VER"))
                _Return = False
                UpdateList()
                Return _Return
                Exit Function
            End If
            'If Dt_Vat.Rows(iRow).Item("Tk_Du").ToString.Trim = "" Then
            '    MsgBox(IIf(M_LAN = "V", "Bạn chưa nhập tài khoản đối ứng", "You did not enter a tax account"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, oSysvar("M_CYBER_VER"))
            '    _Return = False
            '    UpdateList()
            '    Return _Return
            '    Exit Function
            'End If
            If Dt_Vat.Rows(iRow).Item("Ten_Kh").ToString.Trim = "" Then
                MsgBox(IIf(M_LAN = "V", "Bạn chưa nhập tên khách hàng", "You did not enter a tax account"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, oSysvar("M_CYBER_VER"))
                _Return = False
                UpdateList()
                Return _Return
                Exit Function
            End If
            'If Dt_Vat.Rows(iRow).Item("Dia_Chi").ToString.Trim = "" Then
            '    MsgBox(IIf(M_LAN = "V", "Bạn chưa nhập địa chỉ khách hàng", "You did not enter a tax account"), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, oSysvar("M_CYBER_VER"))
            '    _Return = False
            '    UpdateList()
            '    Return _Return
            '    Exit Function
            'End If
        Next
        '---------------------------------------------------------------------------------------------
        UpdateList()
        ChkSave = _Return
    End Function
    Private Sub V_Save(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dv_Vat.Table.AcceptChanges()
        If Not ChkSave() Then Exit Sub
        Me.ReturnOk = True
        Me.Close()
    End Sub
    Private Sub V_Exit(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dv_Vat.Table.AcceptChanges()
        Me.ReturnOk = False
        Me.Close()
    End Sub
    Public CyberExport As New Cyber.Export.Sys
    Private Sub V_Import(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TbImport As New DataTable
        TbImport = CyberExport.V_ImportDataToGridview(AppConn, oSysvar, M_Para, DetailGRV, Dt_Vat, M_LAN)
        If TbImport Is Nothing Then Exit Sub
        '==================== Xu ly du lieu được Import vào
        Dt_Vat.Clear()
        Dt_Vat.AcceptChanges()
        For i = 0 To TbImport.Rows.Count - 1
            Dt_Vat.ImportRow(TbImport.Rows(i))
        Next
        For iRow = 0 To Dt_Vat.Rows.Count - 1
            V_Tinh_Toan(iRow)
        Next
        Dt_Vat.AcceptChanges()
    End Sub
#End Region
#Region "Add/Delete-Item"
    Private Sub V_ShortAddItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        V_AddItem(iRow)
    End Sub
    Private Sub V_ShortDeleteItem(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim iRow As Integer = DetailGRV.FocusedRowHandle
        If iRow < 0 Then Exit Sub
        If Not CyberSupport.V_DeleteItemVoucher(oSysvar, M_LAN, M_ma_Ct, iRow, Me.Dv_Vat, AppConn, DetailGRV) Then Exit Sub
        Me.Dv_Vat.Delete(iRow)
        Me.Dv_Vat.Table.AcceptChanges()
        UpdateList()
    End Sub
    Private Sub V_AddItem(Optional ByVal iRow As Integer = -1)
        Dim DrvOld As DataRowView
        If iRow >= 0 Then DrvOld = Dv_Vat.Item(iRow) Else DrvOld = Nothing
        Dv_Vat.Table.Rows.Add()
        CyberSmodb.SetValueBlankRow(Dv_Vat.Table.Rows(Dv_Vat.Table.Rows.Count - 1))
        CyberSupport.SetCarryOn(DrvOld, Dv_Vat.Table.Rows(Dv_Vat.Table.Rows.Count - 1), New DataView(DsHead.Tables(2)))
        CarrOn(Dv_Vat.Table.Rows(Dv_Vat.Table.Rows.Count - 1))
        UpdateList()
        iRow = Dv_Vat.Count - 1
        CyberFill.V_ForcusCell(DetailGRV, iRow, 0)
    End Sub
    Private Sub CarrOn(ByVal DvNew As DataRow)
        DvNew.Item("Stt_Rec") = Me.Stt_Rec.Trim
        DvNew.Item("Ma_Ct") = M_ma_Ct.Trim
        DvNew.Item("Ngay_Ct") = Ngay_Ct
        DvNew.Item("Ma_NT") = M_Ma_NT
        DvNew.Item("Ty_Gia") = M_Ty_Gia


        If DvNew.Table.Columns.Contains("Ma_Post") Then DvNew.Item("Ma_Post") = M_Ma_Post
        If DvNew.Table.Columns.Contains("Ngay_CT") Then DvNew.Item("Ngay_Ct") = M_Ngay_Ct
        If DvNew.Table.Columns.Contains("Ngay_LCT") Then DvNew.Item("Ngay_LCt") = M_Ngay_LCT
        DvNew.Item("Ma_Post") = M_Ma_Post
    End Sub
#End Region
#Region "Mainform"
    Private Sub V_MainSystem()

        Dim mnItemsMail = New ContextMenu
        Dim mnItemsF4 As New MenuItem("Thêm dòng", AddressOf V_ShortAddItem, Keys.F4)
        Dim mnItemsF8 As New MenuItem("Xóa dòng", AddressOf V_ShortDeleteItem, Keys.F8)
        Dim mnItemsSave As New MenuItem("Lưu ", AddressOf V_Save, Keys.Control + Keys.Enter)

        mnItemsMail.MenuItems.Add(mnItemsF4)
        mnItemsMail.MenuItems.Add(mnItemsF8)
        mnItemsMail.MenuItems.Add(mnItemsSave)
        Me.ContextMenu = mnItemsMail
    End Sub
    Private Sub MasterGRV_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        'Dim rowHandle As Integer = e.HitInfo.RowHandle
        'If e.MenuType <> DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
        '    PopupMenuMasterGrid.ItemLinks.Clear()
        '    PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Thêm dòng", "Add item"), AddressOf V_ShortAddItem, Nothing, True, False))
        '    PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Xóa dòng", "Delete item"), AddressOf V_ShortDeleteItem, Nothing, True, False))
        '    PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Import", "Delete item"), AddressOf V_Import, Nothing, True, True))
        '    PopupMenuMasterGrid.ItemLinks.Add(New Cyber.SmLib.CyberMenuPopup(sender, rowHandle, IIf(Lan = "V", "Lưu chứng từ", "Save"), AddressOf V_ShortSAVE, Nothing, True, True))
        '    PopupMenuMasterGrid.ShowPopup(Control.MousePosition)
        'End If
    End Sub
    Private Sub FrmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 27 Then V_Exit(sender, e)
    End Sub
#End Region
End Class
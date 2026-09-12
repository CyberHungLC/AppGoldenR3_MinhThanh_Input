Imports System
Imports System.IO
Imports System.Data
Imports Excels = Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices
Public Class ExportExcel
    Public _MsgBox As String = ""
    Public Sub GetValueControler(ByVal dr As DataRow, ByRef StrField As String, ByRef strValue As String, ByRef strLoaitru As String)
        Dim Exc As String = "!~!"
        Dim ClmName As String = ""
        Dim lLoaitru As String() = strLoaitru.Split(",")
        StrField = ""
        strValue = ""
        For Each dc As DataColumn In dr.Table.Columns
            ClmName = dc.ColumnName.Trim
            StrField &= Exc & ClmName
            strValue &= Exc & dr(ClmName)
        Next
    End Sub
    Public Function ExportExcel(ByVal xlApp As Excels.Application, ByVal xlWorkBook As Excels.Workbook, ByVal FullPath As String, ByVal SheetName As String, ByVal Ds As DataSet) As Object
        'Dim w As Excels.Application
        'Dim wb As Excels.Workbook
        Dim _ObjecReturn As New Excels.Worksheet

        _ObjecReturn = Nothing
        If Not File.Exists(FullPath) Then
            _MsgBox &= vbNewLine & "File " & FullPath & " Không tồn tại"
            Return _ObjecReturn
        End If
        If Ds.Tables.Count < 4 Then
            _MsgBox &= vbNewLine & "Cấu trúc dữ liệu thủ tục  Không đủ 3 bảng để xử lý"
            Return _ObjecReturn
        End If
        Dim tbMaster As New DataTable
        Dim tbDetail As New DataTable
        Dim tbDetail1 As New DataTable
        Dim tbDetail2 As New DataTable
        tbMaster = Ds.Tables(0)
        tbDetail = Ds.Tables(1)
        tbDetail1 = Ds.Tables(2)
        tbDetail2 = Ds.Tables(3)
        tbMaster.TableName = "TABLE0"
        tbDetail.TableName = "TABLE1"
        tbDetail1.TableName = "TABLE2"
        tbDetail2.TableName = "TABLE3"
        If Not tbMaster.Columns.Contains("Field_Name") Then
            _MsgBox &= vbNewLine & "Dữ liệu bảng 0 không có trường ""Field_Name"" để thực hiện xử lý "
            Return _ObjecReturn
        End If

        If Not tbMaster.Columns.Contains("Value") Then
            _MsgBox &= vbNewLine & "Dữ liệu bảng 0 không có trường ""Value"" để thực hiện xử lý "
            Return _ObjecReturn
        End If
        Excel(xlApp, xlWorkBook, FullPath, SheetName, tbMaster, tbDetail, tbDetail1, tbDetail2)
        Return _ObjecReturn
    End Function
    Private Function Excel(ByVal xlApp As Excels.Application, ByVal _xlWorkBook As Excels.Workbook, ByVal FullPath As String, ByVal SheetName As String, ByVal TbDataMaster As DataTable, ByVal TbDetail As DataTable, ByVal TbDetail1 As DataTable, ByVal TbDetail2 As DataTable) As Object
        '1 Doc File Tmp

        Dim xlWorkBook As Excels.Workbook
        Dim xlWorkSheet As New Excels.Worksheet
        Dim _xlWorkSheet As New Excels.Worksheet
        xlWorkBook = xlApp.ActiveWorkbook
        xlWorkBook = xlApp.Workbooks.Open(FullPath)

        xlWorkSheet = xlWorkBook.Worksheets("sheet1")
        xlApp.DisplayAlerts = False
        For Each dr As DataRow In TbDataMaster.Rows
            If dr("Field_Name").ToString.Trim = "" Then Continue For
            xlWorkSheet.Cells.Replace(dr("Field_Name").ToString.Trim, dr("Value").ToString.Trim)
        Next
        Dim iDetail As Integer = TbDetail.Rows.Count
        Dim iDetail1 As Integer = TbDetail1.Rows.Count
        Dim iDetail2 As Integer = TbDetail2.Rows.Count

        Dim FindRange As Excels.Range
        Dim FindRange1 As Excels.Range
        Dim FindRange2 As Excels.Range

        FindRange = xlWorkSheet.Cells.Find("<Detail>")
        FindRange1 = xlWorkSheet.Cells.Find("<Detail1>")
        FindRange2 = xlWorkSheet.Cells.Find("<Detail2>")

        Dim IsBold As Boolean = False
        If TbDetail.Columns.Contains("Bold") Then IsBold = True
        If TbDetail1.Columns.Contains("Bold") Then IsBold = True
        If TbDetail2.Columns.Contains("Bold") Then IsBold = True

        If Not FindRange Is Nothing Then
            FindRange.Cells.Replace("<Detail>", "")
            For i As Integer = 0 To iDetail - 1
                xlWorkSheet.Rows(FindRange.Row + i + 1).Insert()
                xlWorkSheet.Rows(FindRange.Row).Copy()
                xlWorkSheet.Rows(FindRange.Row + i + 1).PasteSpecial()
                For Each dc As DataColumn In TbDetail.Columns
                    If TbDetail.Rows(i)(dc.ColumnName).ToString <> "0" Then
                        xlWorkSheet.Rows(FindRange.Row + i + 1).Replace("<" & dc.ColumnName.Trim.ToUpper & ">", TbDetail.Rows(i)(dc.ColumnName))
                    Else
                        xlWorkSheet.Rows(FindRange.Row + i + 1).Replace("<" & dc.ColumnName.Trim.ToUpper & ">", "")
                    End If
                Next
                If IsBold Then If TbDetail.Rows(i)("Bold") = "1" Then xlWorkSheet.Rows(FindRange.Row + i + 1).Font.Bold = True
            Next
            xlWorkSheet.Rows(FindRange.Row).delete()
        End If

        If Not FindRange1 Is Nothing Then
            FindRange1.Cells.Replace("<Detail1>", "")
            For i As Integer = 0 To iDetail1 - 1
                xlWorkSheet.Rows(FindRange1.Row + i + 1).Insert()
                xlWorkSheet.Rows(FindRange1.Row).Copy()
                xlWorkSheet.Rows(FindRange1.Row + i + 1).PasteSpecial()
                For Each dc As DataColumn In TbDetail1.Columns
                    If TbDetail1.Rows(i)(dc.ColumnName).ToString <> "0" Then
                        xlWorkSheet.Rows(FindRange1.Row + i + 1).Replace("<" & dc.ColumnName.Trim.ToUpper & ">", TbDetail1.Rows(i)(dc.ColumnName))
                    Else
                        xlWorkSheet.Rows(FindRange1.Row + i + 1).Replace("<" & dc.ColumnName.Trim.ToUpper & ">", "")
                    End If
                Next
                If IsBold Then If TbDetail1.Rows(i)("Bold") = "1" Then xlWorkSheet.Rows(FindRange1.Row + i + 1).Font.Bold = True
            Next
            xlWorkSheet.Rows(FindRange1.Row).delete()
        End If

        If Not FindRange2 Is Nothing Then
            FindRange2.Cells.Replace("<Detail2>", "")
            For i As Integer = 0 To iDetail2 - 1
                xlWorkSheet.Rows(FindRange2.Row + i + 1).Insert()
                xlWorkSheet.Rows(FindRange2.Row).Copy()
                xlWorkSheet.Rows(FindRange2.Row + i + 1).PasteSpecial()
                For Each dc As DataColumn In TbDetail2.Columns
                    xlWorkSheet.Rows(FindRange2.Row + i + 1).Replace("<" & dc.ColumnName.Trim.ToUpper & ">", TbDetail2.Rows(i)(dc.ColumnName))
                Next
                'If IsBold Then If TbDetail1.Rows(i)("Bold") = "1" Then xlWorkSheet.Rows(FindRange1.Row + i + 1).Font.Bold = True
            Next
            xlWorkSheet.Rows(FindRange2.Row).delete()
        End If

        xlWorkSheet.Name = SheetName

        xlWorkSheet.Copy(_xlWorkBook.Worksheets(_xlWorkBook.Sheets.Count))
        xlWorkBook.Close(False)
        ReleaseComObject(xlWorkSheet)
        ReleaseComObject(xlWorkBook)
        xlWorkSheet = Nothing
        Return _xlWorkSheet
    End Function
    Public Sub ReleaseComObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            obj = Nothing
        End Try
    End Sub
    Private Function GetExcelColumnName(ByVal columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = [String].Empty
        Dim modulo As Integer
        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While
        Return columnName
    End Function
End Class

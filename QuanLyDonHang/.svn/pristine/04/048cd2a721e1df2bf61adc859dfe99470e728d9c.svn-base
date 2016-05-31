using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using ClosedXML.Excel;

namespace Controller.Common
{
    public class Office_Function
    {
        private static XLWorkbook workbook;
        private static IXLWorksheet ws;

        public static void SaveExcel(string path)
        {
            try
            {
                workbook.SaveAs(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InitWorkBook()
        {
            workbook = new XLWorkbook();
        }

        public static void InitWorkBook(string fileName, string sheetName)
        {
            try
            {
                workbook = new XLWorkbook(fileName);
                ws = workbook.Worksheet(sheetName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InitWorkBook(string fileName, int sheetIndex)
        {
            try
            {
                workbook = new XLWorkbook(fileName);
                ws = workbook.Worksheet(sheetIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetTable()
        { 
            DataTable table = new DataTable();

            try
            {
                if (ws != null)
                {
                    int firstRow = ws.FirstRowUsed().RowNumber();
                    int lastRow = ws.RowsUsed().Count();
                    int firstCol = ws.FirstColumnUsed().ColumnNumber();
                    int lastCol = ws.ColumnsUsed().Count();

                    //create header
                    for (int i = firstCol; i <= lastCol; i++)
                    {
                        string header = ws.Cell(firstRow, i).Value.ToString();

                        if (!table.Columns.Contains("Brand") && header.ToLower().StartsWith("thành tiền sản xuất"))
                        {
                            table.Columns.Add("Brand");
                        }

                        if (table.Columns.Contains(header))
                        {
                            table.Columns.Add(header + i.ToString());
                        }
                        else
                        {
                            table.Columns.Add(header);
                        }
                    }

                    for (int rowCount = firstRow + 1; rowCount <= lastRow; rowCount++)
                    {
                        DataRow row = table.NewRow();

                        for (int colCount = 0; colCount < lastCol; colCount++)
                        {
                            row[colCount] = ws.Cell(rowCount, colCount + 1).Value;
                        }

                        table.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }
    }
}

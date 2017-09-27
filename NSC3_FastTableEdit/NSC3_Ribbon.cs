using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{

    public partial class NSC3_Ribbon
    {

        private void NSC3_Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button_LoadTableHeader_Click(object sender, RibbonControlEventArgs e)
        {
            Form_TableColumnsLoad loadHeaderForm = new Form_TableColumnsLoad();
            if (loadHeaderForm.ShowDialog() == DialogResult.OK)
            {
                CreateTableHeader(loadHeaderForm.Columns());
                //GetTableInfo to class TableInfo
            }
        }

        // Clear entire header row and set new header cells
        private static void CreateTableHeader(List<string> headerList)
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            activeWorksheet.UsedRange.EntireColumn.EntireRow.Clear();
            for (int i = 0; i < headerList.Count; i++)
            {
                object cell = (char)(65 + i) + "1";
                activeWorksheet.Range[cell, cell].Value2 = headerList[i];
                activeWorksheet.Range[cell, cell].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
                activeWorksheet.Range[cell, cell].ColumnWidth = 15;
                activeWorksheet.UsedRange.EntireColumn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
        }

        private void button_SendToNAV_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Range usedRange = activeWorksheet.UsedRange.Rows;
            usedRange.Columns.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

        }

        private void buttonSetConnection_Click(object sender, RibbonControlEventArgs e)
        {
            Form_Connection connectionForm = new Form_Connection();
            if (connectionForm.ShowDialog() == DialogResult.OK)
            {
                connectionForm.SetConnectionParams();
            }
        }
    }
}

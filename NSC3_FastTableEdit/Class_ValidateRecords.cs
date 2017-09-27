using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace NSC3_FastTableEdit
{
    static class Class_ValidateRecords
    {
        static public void SelectRows()
        {
            Excel.Worksheet activeWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            Excel.Range usedRange = activeWorksheet.UsedRange.Rows;
            usedRange.Columns.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
        }
    }
}

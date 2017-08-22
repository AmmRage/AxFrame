using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace AxDependencyDemo
{
    public class AxDependencyLib
    {
        public void LibMethod()
        {
            var xlapp = new Application();
            var workbook = xlapp.Workbooks.Add();
            var sheet = (Worksheet)workbook.Sheets[1];
            sheet.Range["A1"].Value = "value";
            workbook.SaveAs(@"test.xlsx");
            workbook.Close();
            xlapp.Quit();
        }
    }
}

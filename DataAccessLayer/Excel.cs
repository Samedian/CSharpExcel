using Entities;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using System.Runtime.CompilerServices;

using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace DataAccessLayer
{
    public class Excel
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;

        public Excel()
        {
            
        }

        public void Open(string path,int Sheet)
        {

            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
     
        public void WriteRange(int starti, int starty, int endi, int endy, string[,] writeData)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writeData;
        }
        public void Save()
        {

            wb.Save();
        }

        public void Close()
        {
            wb.Close();
        }

        public string ReadCell(int row,int col)
        {
            row++;
            col++;
            if (ws.Cells[row, col].Value2 != null)
            {
                return ws.Cells[row, col].Value2;
            }
            return null;
        }
        public string[,] ReadRange(int starti, int starty, int endi, int endy)
        {

            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];

            object[,] holder = range.Value2;
            string[,] returnString = new string[endi, endy];

            for (int p = 1; p <= endi; p++)
            {
                for (int q = 1; q <= endy; q++)
                {
                    returnString[p - 1, q - 1] = holder[p, q].ToString();
                }
            }


            return returnString;
        }

        public void WriteCell(int row, int col, int seats)
        {
            row++;
            col++;
            ws.Cells[row, col].Value2 = Convert.ToString(seats - 1);
        }
    }


}

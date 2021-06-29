using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using DAL;
using DTO;
using System.Net;

namespace BL
{
    public class UserBL
    {
        public static string AddUser(UserDTO userDTO, ChildrenDTO[] childrenDTOs)
        {
            Children[] children = new Children[0];
            if (childrenDTOs != null)
            {
                children = new Children[childrenDTOs.Length];
                for (int i = 0; i < childrenDTOs.Length; i++)
                {
                    children[i] = Converters.ChildrenConverter.ConvertChildren(childrenDTOs[i]);
                }
            }
           return new UserDAL().AddUser(Converters.UserConverter.ConvertUser(userDTO), children);
        }
        public static Excel.Workbook CreateExcel(UserDTO user,string path)
        {
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                return null;
            }
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Type t = user.GetType();
            PropertyInfo[] property = t.GetProperties();
            for (int i = 0; i < property.Length - 1; i++)
            {
                xlWorkSheet.Cells[1, i + 1] = property[i].Name;
                string s = property[i].Name;
                xlWorkSheet.Cells[2, i + 1] = property[i].GetValue(user);
            }
            // string x = HttpContext.Current.Server.MapPath("TextFiles/" + user.FirstName + ".txt"));
            xlWorkBook.SaveAs(path+ user.FirstName+ ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return xlWorkBook;
        }
    }
}

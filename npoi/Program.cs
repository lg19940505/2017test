using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi
{
    class Program
    {
        static void Main(string[] args)
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            hssfworkbook.CreateSheet("Sheet1");

            hssfworkbook.CreateSheet("Sheet2");

            hssfworkbook.CreateSheet("Sheet3");

            FileStream file = new FileStream(@"test.xls", FileMode.Create);

            hssfworkbook.Write(file);

            file.Close();
            Console.WriteLine("sucess");
        }
    }
}

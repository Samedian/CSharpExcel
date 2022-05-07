using DataAccessLayer;
using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Week2Assignment2;

namespace Week2Assignment1
{
    class StudentRight
    {

        public static void StudentLogin()
        {

            string[,] data = SHowCollege();

            Console.WriteLine("Enter College Id :");
            int id = Input.PositiveInteger();

            Console.WriteLine("Enter Name :");
            string name = Input.StringInput();

            Console.WriteLine("Enter Percentage :");
            double perc = Input.PositiveDouble();

            DataAccessLayer.Excel excel = new Excel();
            excel.Open(".//ClgExcel.xlsx", 1);


            for (int i = 1; i < AdminRights.total + 1; i++)
            {
                int excelId = int.Parse(excel.ReadCell(i, 0));
                if (excelId == id)
                {


                    if (double.Parse(excel.ReadCell(i, 3)) <= perc)
                    {
                        try
                        {


                            int seats = int.Parse(excel.ReadCell(i, 4));
                            excel.WriteCell(i, 4, seats);
                            excel.Save();
                            excel.Close();

                        }
                        catch (Exception)
                        {

                        }
                    }
                    else
                        break;

                    Console.WriteLine();
                }


            }
        }
        public static string[,] SHowCollege()
        {

            Excel excel = new Excel();
            excel.Open(".//ClgExcel.xlsx", 1);


            string[,] read = excel.ReadRange(1, 1, AdminRights.total + 1, 5);

            excel.Save();
            excel.Close();

            for (int i = 0; i < AdminRights.total + 1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                        Console.Write(read[i, j] + "\t");
                }
                Console.WriteLine();
            }

            return read;

        }
    }
}

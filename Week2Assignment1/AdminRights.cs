using Entities;
using Exceptions;
using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2Assignment2;

namespace Week2Assignment1
{
    class AdminRights
    {
        public static int total;
        public static void AdminLogin()
        {
            char ch;
            int choice=-1;
            do
            {
                Console.WriteLine("1.Add College");
                Console.WriteLine("2.Display Student Details based on College Id");
                Console.WriteLine("3.Login Page");

                try
                {
                    choice = Input.PositiveInteger();
                    if (choice < 0)
                        throw new NegativeNumberException("Number Can't be negative");
                }catch(NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }catch(System.FormatException exception)
                {
                    Console.WriteLine(exception);
                }catch(Exception exception)
                {
                    Console.WriteLine(exception);
                }

                switch(choice)
                {
                    case 1: 
                        AddCollege();
                        break;
                    case 2:
                        DisplayStudent();
                        break;
                    case 3:
                        Console.Clear();
                        Program.Login();
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;
                }

                Console.WriteLine("Do you want to continue :");
                ch = Convert.ToChar(Console.ReadLine());
            } while (ch == 'Y' || ch == 'y');
        }

        private static void DisplayStudent()
        {

            Console.WriteLine("Enter Clg Id :");
            int id = Input.PositiveInteger();
            Excel excel = new Excel();
            excel.Open(".//ClgExcel.xlsx", 1);
         

            string[,] read = excel.ReadRange(1, 1, total+1, 5);

            excel.Save();
            excel.Close();
           
            for (int i = 0; i < total+1; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(read[i,0].Equals(id))
                        Console.Write(read[i,j]+"\t");
                }
                Console.WriteLine();
            }

        }

        private static void AddCollege()
        {
            Console.WriteLine("Enter total clg :");
            total = Input.PositiveInteger();

            string[,] data = new string[total, 5];
            string collegeName, location;
            double cutOff=0;
            int seats = 0;

            Console.Clear();

            for (int i = 0; i < total; i++)
            {
                Console.SetCursorPosition(30, 5);
                Console.WriteLine("Enter College Name      :");

                Console.SetCursorPosition(30, 7);
                Console.WriteLine("Enter College Location  :");

                Console.SetCursorPosition(30, 9);
                Console.WriteLine("Enter Cutoff Percentage :");

                Console.SetCursorPosition(30, 11);
                Console.WriteLine("Enter No of Seats       :");

                Console.SetCursorPosition(55, 5);
                collegeName = Input.StringInput();

                Console.SetCursorPosition(55, 7);
                location = Input.StringInput();

                Console.SetCursorPosition(55, 9);
                try
                {
                    cutOff = Convert.ToDouble(Console.ReadLine());
                    if (cutOff < 0)
                        throw new NegativeNumberException("Cut Off Can't be negative");
                }
                catch (NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                Console.SetCursorPosition(55, 11);

                try
                {
                    seats = Convert.ToInt32(Console.ReadLine());
                    if (seats < 0)
                        throw new NegativeNumberException("Cut Off Can't be negative");
                }
                catch (NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }

                College college = new College(collegeName, location, cutOff, seats);
                data[i, 0] = Convert.ToString(college.CollegeId);
                data[i, 1] = collegeName;
                data[i, 2] = location;
                data[i, 3] = Convert.ToString(cutOff);
                data[i, 4] = Convert.ToString(seats);
                Excel excel = new Excel();

                 excel.Open(".//ClgExcel.xlsx", 1);
                excel.WriteRange(2, 1, total+1, 5, data);

                excel.Save();
                excel.Close();

                Console.Clear();
            }
        }

        
    }
}

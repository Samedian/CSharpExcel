using Exceptions;
using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Week2Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {

            Login();
            Console.ReadKey();
        }

        public static void Login()
        {
            string loginId, password;
            Console.SetCursorPosition(30, 5);
            Console.WriteLine("COLLEGE MANAGEMENT SYSTEM");

            Console.SetCursorPosition(35, 7);
            Console.WriteLine("Login Id   :");

            Console.SetCursorPosition(35, 9);
            Console.WriteLine("Password  :");

            Console.SetCursorPosition(50, 7);
            loginId = Console.ReadLine();

            Console.SetCursorPosition(50, 9);
            password = Console.ReadLine();

            Console.Clear();
            try
            {
                if (loginId.Equals("Admin") && password.Equals("Admin"))
                    AdminRights.AdminLogin();
                else
                    if (loginId.Equals("Student") && password.Equals("Student"))
                    StudentRight.StudentLogin();
                else
                    throw new LoginFailed("Invalid UserId or Password");
            }catch(LoginFailed exception)
            {
                Console.WriteLine(exception);
            }catch(Exception exception)
            {
                Console.WriteLine(exception);
            }

        }


       
    }
}

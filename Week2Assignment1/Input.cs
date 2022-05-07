using System;
using Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Week2Assignment2
{
    class Input
    {
        public static int PositiveInteger()
        {
            int num = -1;
            do
            {
                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                    if (num < 0)
                        throw new NegativeNumberException("Number is Negative Enter Again");
                }
                catch (NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine("Incorrect data type Enter Again " + exception);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Enter Again " + exception);
                }
            } while (num <= 0);
            return num;

        }

        public static double PositiveDouble()
        {
            double num = -1;
            do
            {
                try
                {
                    num = Convert.ToDouble(Console.ReadLine());
                    if (num < 0)
                        throw new NegativeNumberException("Number is Negative Enter Again");
                }
                catch (NegativeNumberException exception)
                {
                    Console.WriteLine(exception);
                }
                catch (System.FormatException exception)
                {
                    Console.WriteLine("Incorrect data type Enter Again " + exception);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Enter Again " + exception);
                }
            } while (num <= 0);
            return num;
        }

        public static string StringInput()
        {
            string str = null;

            do
            {
                try
                {
                    str = Console.ReadLine();
                    str = ConvertTitlecase(str);
                    if (str == null)
                        throw new StringContainDigit("String Contain Digit");
                }
                catch (StringContainDigit exception)
                {
                    Console.WriteLine(exception);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);

                }
            } while (str == null);

            return str;
        }

        private static string ConvertTitlecase(string name)
        {
            if (name.Any(char.IsDigit))
                return null;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            name = textInfo.ToTitleCase(name);
            return name;
        }
    }
}
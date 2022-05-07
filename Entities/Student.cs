using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Student
    {
        public static int Counter = 1000;

        public Student()
        {

        }
        public Student(string StudentName,College MyCollege,double Percentage)
        {
            this.StudentId = "SID" + Counter++;
            this.StudentName = StudentName;
            this.MyCollege = MyCollege;
            this.Percentage = Percentage;
        }
        public string StudentId { get; }

        public  string StudentName { get; set; }

        public College MyCollege { get; set; }

        public double Percentage { get; set; }

    }
}

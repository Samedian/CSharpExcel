using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class College
    {
        public static int Counter= 1000;

        public College(string CollegeName ,string Location,double CutOff,int Seats)
        {
            this.CollegeId = Counter++;
            this.CollegeName = CollegeName;
            this.Location = Location;
            this.CutOff = CutOff;
            this.Seats = Seats;
        }
        
        public int CollegeId { get;  }
        public string CollegeName { get; set; }

        public string Location { get; set; }

        public double CutOff { get; set; }
        public int Seats { get; set; }



    }
}

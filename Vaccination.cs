using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class Vaccination
    {
        public int DogID { get; set; }  
        public DateTime Date { get; set; }

        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }
        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }

        public Vaccination(int dogID, DateTime date)
        {
            DogID = dogID;
            Date = date;
        }
    }
}

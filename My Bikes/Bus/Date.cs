using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }

     
        public Date()
        {
            this.year = 1999;
            this.month = 01;
            this.day = 01;
        }
        public Date(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public override string ToString()
        {
            string stat;

            stat = Year + "/" + Month + "/" + Day;

            return stat;
        }
    }
}

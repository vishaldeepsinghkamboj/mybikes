using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
   
   public class Roadbike : Bike
    {
        private double seatheight;

        public double Seatheight { get => seatheight; set => seatheight = value; }


        public Roadbike() : base()
        {
            this.seatheight = 00;
        }

        public Roadbike(double seatheight, string biketype, int sn, double price, string brand,
            string model, EnumStyle age, EnumColor color, EnumSpeed speed, Date madedate) : base(biketype, sn, price, brand, model, age, color, speed, madedate)
        {
            this.Seatheight= seatheight;
          

        }

        

        public override string ToString()
        {
            string stat;
            stat = base.Biketype + "\t    " + base.Sn + "     " + base.Brand + "    " + base.Model + "    "
                + base.Speed + "    " + base.Color + "    " + base.Style + "    " + base.Price +
                "    " + base.Madedate + "    " + "    " + "     " + seatheight;

            return stat;
        }
    }
}

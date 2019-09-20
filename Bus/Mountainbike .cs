using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybikes.Bus
{
    [Serializable]
    public class Mountainbike : Bike
    {
        private double heightfg;
        private EnumType typefs;

        public double Heightfg { get => heightfg; set => heightfg = value; }
        public EnumType Typefs { get => typefs; set => typefs = value; }

        public Mountainbike() : base()
        {
            this.heightfg = 00;
            this.typefs = EnumType.Undefined;
        }

        public Mountainbike(double heightfg, EnumType typefs, string biketype , int sn, double price, string brand,
            string model, EnumStyle style, EnumColor color, EnumSpeed speed, Date madedate) : base(biketype, sn, price, brand, model, style, color, speed, madedate)
        {
            this.heightfg = heightfg;
            this.typefs = typefs;

        }

        public override string ToString()
        {
            string stat;
            stat = base.Biketype + "\t   " + base.Sn + "\t       " + base.Brand + "\t   " + base.Model + "\t " 
                + base.Speed + "\t     " + base.Color + "\t     " + base.Style + "\t   " + base.Price +
                "    " + base.Madedate + "\t         " + typefs + "\t      " + heightfg;

            return stat;
        }


    }
}

   

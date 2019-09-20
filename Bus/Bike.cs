using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace Mybikes.Bus
{
    [XmlInclude(typeof(Roadbike))]
    [XmlInclude(typeof(Mountainbike))]
    public class Bike
    {
        private string biketype;
        private int sn;
        private double price;
        private string brand;
        private string model;
        private EnumStyle style;
        private EnumColor color;
        private EnumSpeed speed;
        private Date madedate;


        public string Biketype { get => biketype; set => biketype = value; }
        public int Sn { get => sn; set => sn = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public double Price { get => price; set => price = value; }
        public EnumColor Color { get => color; set => color = value; }
        public EnumSpeed Speed { get => speed; set => speed = value; }
        public EnumStyle Style { get => style; set => style = value; }
        public Date Madedate { get => madedate; set => madedate = value; }


        public Bike()
        {
            this.biketype = "Undefined";
            this.sn = 0000;
            this.price = 000.00;
            this.brand = "Undefined";
            this.model = "Undefined";
            this.style = EnumStyle.Undefined;
            this.color = EnumColor.Undefined;
            this.speed = EnumSpeed.Undefined;
        }

        public Bike(string biketype, int sn, double price, string brand, string model, EnumStyle style, EnumColor color, EnumSpeed speed, Date madedate)
        {
            this.biketype = biketype;
            this.sn = sn;
            this.price = price;
            this.brand = brand;
            this.model = model;
            this.style = style;
            this.color = color;
            this.speed = speed;
            this.madedate = madedate;
        }

        public override string ToString()
        {
            string state;
            state = biketype + "\t    " + sn + "\t    " + brand + "\t  " + model + "\t  " 
                + speed + "\t  " + color + "\t  " + style + "\t  " +  price + "\t  "
                + madedate;
            return state;
        }
    }
}


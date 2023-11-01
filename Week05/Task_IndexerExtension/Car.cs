using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_IndexerExtension
{
    public class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }
        //public int ProducedTime { get; set; } // amount of seconds from Feb 28 of year 2004. (~620,859,836 seconds)
        public string ProducedYear { get; set; } // lame version of date :<

        public override string ToString()
        {
            return "Name: " + this.Name + "; Color: " + this.Color;
        }
    }
    public class Gallery
    {
        public string Name { get; set; }
        public Car[] Cars = new Car[0];

        public Car this[int index]
        {
            get
            {
                if (index >= this.Cars.Length) return null;
                return Cars[index];
            }
        }
        public Car this[string value]
        {
            get
            {
                for (int i = 0; i < Cars.Length; i++)
                {
                    if (value == Cars[i].Name) return Cars[i];
                }
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculator.Entity
{
    public class Pokemon
    {
        public string Name { get; set; }
        public string[] Types { get; set; }
        public double Kg { get; set; }
        public int H { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int S { get; set; }
        public string Img { get; set; }
        public string Moves { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}

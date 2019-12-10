using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculator.Entity
{
    public class Nature
    {
        public string Name { get; set; }
        public string Up { get; set; }
        public string Down { get; set; }
        public override string ToString()
        {
            return String.Format("{0}↑{1}↓", Up, Down);
        }
    }
}

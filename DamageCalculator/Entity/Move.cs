using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculator.Entity
{
    public class Move
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Power { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}

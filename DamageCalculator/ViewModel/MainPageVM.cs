using DamageCalculator.Util;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;

namespace DamageCalculator.ViewModel
{
    public class MainPageVM : NotificationBase
    {
        private List<int> sideA_Lv = new List<int>
        {
            50,100
        };

        public List<int> SideA_Lv
        {
            get { return this.sideA_Lv; }
            set { this.SetProperty(ref this.sideA_Lv, value); }
        }

        public class Pokemon
        {
            public string Name { get; set; }
            public string[] Ability { get; set; }
            public string[] Type { get; set; }
            public string Weight { get; set; }
            public string[] Move { get; set; }
            public override string ToString()
            {
                return this.Name;
            }
        }


        public MainPageVM()
        {
            

            var exePath = Assembly.GetEntryAssembly().Location;
            var dirName = Directory.GetParent(exePath).ToString();
            var srcPath = Path.Combine(dirName, "src", "PokemonData.csv");
            var sr = new StreamReader(srcPath);

            var pokemonList = new List<Pokemon>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(",");

                var abilities = values[4].Split("/");
                var types = values[5].Split("/");
                var moves = values[8].Split("/");

                var pokemon = new Pokemon()
                {
                    Name = values[0],
                    Ability = abilities,
                    Type = types,
                    Weight = values[7],
                    Move = moves
                };
                pokemonList.Add(pokemon);
            }
        }

        private double Calc()
        {
            double result = 0;
            return result;
        }
    }
}
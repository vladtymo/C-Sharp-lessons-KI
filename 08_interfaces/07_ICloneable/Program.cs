using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ICloneable
{
    class Statistic : ICloneable
    {
        public int Goals { get; set; }
        public int Games { get; set; }
        public float AverageGoalsPerGame => (float)Goals / Games;

        public Statistic(int goals, int games)
        {
            Goals = goals;
            Games = games;
        }

        public override string ToString()
        {
            return $"Statistics: {Goals} / {Games} - Koef: {AverageGoalsPerGame}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class FootbalPlayer : IComparable<FootbalPlayer>, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Statistic Stats { get; set; }

        // clone the instance of itself, including copy of all reference values
        public object Clone()
        {
            // MemberwiseClone - shallow copy (copy only value types)
            var copy = (FootbalPlayer)this.MemberwiseClone();

            // deep copy - copy all properties and references
            copy.FirstName = (string)this.FirstName.Clone();
            copy.LastName = (string)this.LastName.Clone();
            copy.Stats = (Statistic)this.Stats.Clone();
            //copy.Stats = new Statistic(this.Stats.Goals, this.Stats.Games);

            return copy;
        }

        public int CompareTo(FootbalPlayer other)
        {
            return this.Stats.AverageGoalsPerGame.CompareTo(other.Stats.AverageGoalsPerGame);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {BirthDate.ToShortDateString()}\n" +
                   $"{Stats}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var player = new FootbalPlayer()
            {
                FirstName = "Yevhen",
                LastName = "Konoplyanka",
                BirthDate = new DateTime(1989, 9, 29),
                Stats = new Statistic(78, 120),
            };

            FootbalPlayer other = (FootbalPlayer)player.Clone();
            other.BirthDate = DateTime.Now;
            other.Stats.Goals = 0;

            Console.WriteLine(player);
        }
    }
}

using System;

namespace BL.Models.Game
{
    public class Dice
    {
        private static readonly Random rand = new Random();
        private readonly int _edges;

        public Dice(int edges)
        {
            if (edges < 0) throw new ArgumentException("Граней должно быть 1-20");
            _edges = edges;
        }

        public int Roll() => rand.Next(1, _edges + 1);
    }
}
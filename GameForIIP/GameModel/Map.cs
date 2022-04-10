using System;
using System.Drawing;

namespace GameForIIP
{
    public class Map
    { 
        //map is sqare
        public IEntity[][] Mapp;

        public MapCell[][] WasBeforePlayer;
        public int LengthX { get => Mapp.Length; }
        public int LengthY { get => Mapp[0].Length; }
        public int MinLength { get => Math.Min(Mapp.Length, Mapp[0].Length); }

        public Map(IEntity[][] mapCells)
        {
            Mapp = mapCells;
        }

        public IEntity this[int i, int j]
        {
            get 
            {
                if (i < Mapp.Length && j < Mapp[i].Length)
                    return Mapp[i][j];
                return null;
            }
            set
            {
                if (i < Mapp.Length && j < Mapp[i].Length)
                    Mapp[i][j] = value;
            }
        }

        public void SwapCells(Point CurrentPos, int dx, int dy)
        {
            var sup = Mapp[CurrentPos.X][CurrentPos.Y];
            Mapp[CurrentPos.X][CurrentPos.Y] = Mapp[CurrentPos.X + dx][CurrentPos.Y + dy];
            Mapp[CurrentPos.X + dx][CurrentPos.Y + dy] = sup;
        }
    }
}

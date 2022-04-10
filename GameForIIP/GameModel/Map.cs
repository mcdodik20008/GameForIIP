using System;
namespace GameForIIP
{
    public class Map
    { 
        //map is sqare
        public MapCell[][] Mapp;

        public MapCell[][] WasBeforePlayer;
        public int LengthX { get => Mapp.Length; }
        public int LengthY { get => Mapp[0].Length; }
        public int MinLength { get => Math.Min(Mapp.Length, Mapp[0].Length); }

        public Map(MapCell[][] mapCells)
        {
            Mapp = mapCells;
        }

        public MapCell this[int i, int j]
        {
            get => Mapp[i][j];
        }
    }
}

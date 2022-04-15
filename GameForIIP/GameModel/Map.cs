using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameForIIP
{
    public class Map
    {
        //map is sqare
        public IEntity[][] Mapp;
        public int LengthX { get => Mapp.Length; }
        public int LengthY { get => Mapp[0].Length; }
        public int MinLength { get => Math.Min(Mapp.Length, Mapp[0].Length); }

        public Map(int size)
        {
            Mapp = new IEntity[size][];
            for (int i = 0; i < Mapp.Length; i++)
                Mapp[i] = new IEntity[size];
        }

        public Map(IEntity[][] mapCells) =>
            Mapp = mapCells;


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
    }

    public static class MapExtention
    {
        public static void GetSubMap(this Map thisMap, Map otherMap, Point point)
        {
            var x = GameModell.SubMapSize;
            int ii = 0;
            for (int i = point.X - x / 2; i < point.X + x / 2 + x % 2; i++)
            {
                int jj = 0;
                for (int j = point.Y - x / 2; j < point.Y + x / 2 + x % 2; j++)
                {
                    thisMap[ii, jj++] = i < otherMap.LengthX && i > 0 && j < otherMap.LengthY && j > 0 ?
                        otherMap[i, j] : new EndMap();
                }
                ii++;
            }
        }

        public static Point FindPlayerPos(this Map map)
        {
            for (int i = 0; i < map.LengthX; i++)
                for (int j = 0; j < map.LengthY; j++)
                    if (map[i, j] is Player)
                        return new Point(i, j);
            throw new Exception("На поле нет игрока");
        }

        public static List<Machine> GetAllMacine(this Map map)
        {
            var lM = new List<Machine>();
            for (int i = 0; i < map.LengthX; i++)
                for (int j = 0; j < map.LengthY; j++)
                    if (map[i, j] is Machine m)
                        lM.Add(m);
            return lM;
        }
    }
}

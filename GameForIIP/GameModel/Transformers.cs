using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameForIIP
{
    public static class Transformers
    {
        public static char[][] GetMapChar(string[] stringMap) =>
    stringMap.Select(x => x.Select(y => y).ToArray()).ToArray();

        public static Dictionary<char, IEntity> charToIEntity = new Dictionary<char, IEntity>()
        {
            ['F'] = new Floor(),
            ['E'] = new EndMap(),
            ['P'] = new Player(),
            ['W'] = new Wall(),
            ['C'] = new Chest(),
            ['S'] = new EShop()
        };

        public static IEntity[][] GetMapIEntity(char[][] charCell)
        {
            var iEnt = new IEntity[charCell.Length][];
            for (int i = 0; i < charCell.Length; i++)
            {
                iEnt[i] = new IEntity[charCell[0].Length];
                for (int j = 0; j < charCell[0].Length; j++)
                {
                    iEnt[i][j] = charCell[i][j] != 'M' ? charToIEntity[charCell[i][j]] : new MacineLevel1(i, j);
                }
            }
            return iEnt;
        }
    }
}

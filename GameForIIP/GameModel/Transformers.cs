using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GameForIIP
{
    public static class Transformers
    {
        public static List<List<char>> GetMapChar(string[] stringMap) =>
    stringMap.Select(x => x.Select(y => y).ToList()).ToList();

        public static Dictionary<char, MapCell> charToMapCell = new Dictionary<char, MapCell>()
        {
            ['F'] = MapCell.Foolr,
            ['E'] = MapCell.EndMap,
            ['P'] = MapCell.Player,
            ['W'] = MapCell.Wall,
        };

        public static MapCell[][] GetMapCell(List<List<char>> charCell) =>
            charCell.Select(x => x.Select(y => charToMapCell[y]).ToArray()).ToArray();

        public static Dictionary<char, IEntity> charToIEntity = new Dictionary<char, IEntity>()
        {
            ['F'] = new Floor(),
            ['E'] = new EndMap(),
            ['P'] = new Player(),
            ['W'] = new Wall(),
            ['M'] = new MacineLevel1(),
            ['C'] = new Chest()
        };

        public static IEntity[][] GetMapIEntity(List<List<char>> charCell) =>
            charCell.Select(x => x.Select(y => charToIEntity[y]).ToArray()).ToArray();
    }
}

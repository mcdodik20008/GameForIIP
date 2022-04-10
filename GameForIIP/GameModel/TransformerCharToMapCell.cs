using System.Collections.Generic;
using System.Linq;

namespace GameForIIP
{
    public static class TransformerCharToMapCell
    {
        public static Dictionary<char, MapCell> charToMapCell = new Dictionary<char, MapCell>()
        {
            ['F'] = MapCell.Foolr,
            ['E'] = MapCell.EndMap,
            ['P'] = MapCell.Player,
            ['W'] = MapCell.Wall,
        };

        public static MapCell[][] GetMap(List<List<char>> charCell) => 
            charCell.Select(x => x.Select(y => charToMapCell[y]).ToArray()).ToArray();
    }
}

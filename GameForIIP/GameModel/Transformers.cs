using System;
using System.Collections.Generic;
using System.Linq;

namespace GameForIIP
{
    public static class Transformers
    {
        public static IEnumerable<IEnumerable<char>> GetMapChar(string[] stringMap) =>
                    stringMap.Select(x => x.Select(y => y));

        public static Dictionary<char, Func<IEntity>> charToIEntity = new Dictionary<char, Func<IEntity>>()
        {
            ['F'] = Floor.Create,
            ['E'] = EndMap.Create,
            ['P'] = Player.Create,
            ['W'] = Wall.Create,
            ['C'] = Chest.Create,
            ['M'] = Machine.Create
        };

        public static IEntity[][] GetMapIEntity(IEnumerable<IEnumerable<char>> charCell) =>
            charCell.Select(x => x.Select(y => charToIEntity[y]()).ToArray()).ToArray();
    }
}

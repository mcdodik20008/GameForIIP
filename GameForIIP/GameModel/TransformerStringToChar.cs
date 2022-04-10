using System.Collections.Generic;
using System.Linq;

namespace GameForIIP
{
    public static class TransformerStringToChar
    {
        public static List<List<char>> GetMap(string[] stringMap) =>
            stringMap.Select(x => x.Select(y => y).ToList()).ToList();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public static class MapCreator
    {
        private static readonly Dictionary<string, Func<IObject>> factory = new Dictionary<string, Func<IObject>>();
        public static IObject[,] CreateMap(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var result = new IObject[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            {
                for (var y = 0; y < rows.Length; y++)
                {
                    result[x, y] = CreateBysimpol(rows[y][x]);
                }
            }
            return result;
        }

        private static IObject CreateBysimpol(char c)
        {
            switch (c)
            {
                case 'P':
                    return CreateCreatureByTypeName("Player");
                case 'W':
                    return CreateCreatureByTypeName("Warier");
                case 'S':
                    return CreateCreatureByTypeName("Shooter");
                case 'B':
                    return CreateCreatureByTypeName("BasicResourse");
                case 'C':
                    return CreateCreatureByTypeName("ConverterResourses");
                case 'F':
                    return CreateCreatureByTypeName("Floor");
                case 'T':
                    return CreateCreatureByTypeName("TheWall");
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {c}");
            }
        }

        private static IObject CreateCreatureByTypeName(string name)
        {
            if (!factory.ContainsKey(name))
            {
                var type = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(z => z.Name == name);
                if (type == null)
                    throw new Exception($"Can't find type '{name}'");
                factory[name] = () => (IObject)Activator.CreateInstance(type);
            }
            return factory[name]();
        }
    }
}

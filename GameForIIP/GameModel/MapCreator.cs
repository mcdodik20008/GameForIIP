using System.IO;

namespace GameForIIP
{
    public static class MapCreator
    {
        public static Map Create()
        {
            string FileNameOrPath = @"..\..\GameModel\Map.txt";
            return new Map(
                Transformers.GetMapIEntity(
                    Transformers.GetMapChar(
                        File.ReadAllLines(FileNameOrPath)
                    )
                )
             );
        }
    }
}

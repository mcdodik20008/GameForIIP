using System.IO;

namespace GameForIIP
{
    public static class MapCreator
    {
        public static Map Create()
        {
            string FileNameOrPath = @"C:\Users\Админ\source\repos\GameForIIP\GameForIIP\GameModel\Map.text";
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

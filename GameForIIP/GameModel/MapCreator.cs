using System.IO;

namespace GameForIIP
{
    public static class MapCreator
    {
        public static Map Create()
        {
            string FileNameOrPath = @"C:\Users\Админ\source\repos\GameForIIP\GameForIIP\GameModel\Map2.text";
            return new Map(
                TransformerCharToMapCell.GetMap(
                    TransformerStringToChar.GetMap(
                        File.ReadAllLines(FileNameOrPath)
                    )
                )
             );
        }
    }
}

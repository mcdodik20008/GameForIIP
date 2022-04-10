using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameForIIP
{
    public class Animations
    {   
        public List<CreatureAnimation> AnimationList = new List<CreatureAnimation>();

        public void BeginAct()
        {

            AnimationList.Clear();
            for (var x = 0; x < GameModell.Map.LengthX; x++)
                for (var y = 0; y < GameModell.Map.LengthY; y++)
                {
                    var creature = GameModell.Map[x, y];
                    if (creature == null) continue;
                    var command = creature.Act(x, y);

                    if (x + command.DeltaX < 0 || x + command.DeltaX >= GameModell.Map.LengthX || y + command.DeltaY < 0 ||
                        y + command.DeltaY >= GameModell.Map.LengthY)
                        throw new Exception($"The object {creature.GetType()} falls out of the game field");

                    AnimationList.Add(
                        new CreatureAnimation
                        {
                            Command = command,
                            Creature = creature,
                            Location = new Point(x * GameModell.ElementSize, y * GameModell.ElementSize),
                            TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY)
                        });
                }

            AnimationList = AnimationList.OrderByDescending(z => z.Creature.GetLayer()).ToList();
        }
        
        public void EndAct()
        {
            for (var x = 0; x < GameModell.LengthX; x++)
                for (var y = 0; y < GameModell.LengthY; y++)
                    if (GameModell.Map.SwapElementOnMap(x, y))
                        return;          
        }
    }
}

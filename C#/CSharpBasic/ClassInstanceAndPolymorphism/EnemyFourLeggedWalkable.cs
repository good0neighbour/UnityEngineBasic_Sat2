using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInterinstanceAndPolymorphism
{
    internal class EnemyFourLeggedWalkable : Enemy, IFourLeggedWalkable
    {
        public void FourLeggedWalk()
        {
            Console.WriteLine($"Enemy {name}(이)가 네 발로 걸었다");
        }
    }
}

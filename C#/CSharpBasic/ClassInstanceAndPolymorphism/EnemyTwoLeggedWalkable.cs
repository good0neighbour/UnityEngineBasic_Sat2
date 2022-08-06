using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInterinstanceAndPolymorphism
{
    internal class EnemyTwoLeggedWalkable : Enemy, ITwoLeggedWalkable
    {
        public void TwoLeggedWalk()
        {
            Console.WriteLine($"Enemy {name}(이)가 두 발로 걸었다");
        }
    }
}

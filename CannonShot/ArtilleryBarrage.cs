using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonShot
{
    class ArtilleryBarrage : HeavyCannon, IWeapon
    {
        public ArtilleryBarrage()
        {
            name = "Artillery Barrage";
            clipSize = 6;
            firePower = 1;
            accuracy = 0.25;
        }

        public override double Fire()
        {
            if (clipSize == 0)
                return 0;
            else
            {
                Random rnd = new Random();
                double shift = rnd.Next(0, 10);
                clipSize--;
                return aim * Math.Sqrt(2) + (shift / 10);
            }
        }
        public override void Reload()
        {
            clipSize += 3;
        }
    }
}

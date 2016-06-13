using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonShot
{
    class HeavyCannon : Weapon, IWeapon
    {
        public HeavyCannon()
        {
            name = "Heavy Cannon";
            clipSize = 1;
            firePower = 3;
            accuracy = 0.5;
        }

        public virtual double Fire()
        {
            if (clipSize == 0)
                return 0;
            else
            {
                clipSize--;
                return Math.Pow(10, 2) * Math.Sin(2 * aim * Math.PI / 180) / 10;
            }
        }
        public virtual void Reload()
        {
            clipSize++;
        }

    }
}

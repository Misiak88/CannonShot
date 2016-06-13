using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CannonShot
{
    class Target
    {

        private double health;
        private double armor;
        private double xPosition;
        private bool isDestroyed;

        public Target()
        {
            Random rnd = new Random();
            health = rnd.Next(1, 10);
            armor = 10;
            xPosition = rnd.Next(750, 1250)/100;
            isDestroyed = false;
        }

        public double Health
        {
            get
            {
                return health;
            }

            set
            {
                health = value;
            }
        }
        public double Aromor
        {
            get
            {
                return armor;
            }
            set
            {
                armor = value;
            }
        }
        public double XPosition
        {
            get
            {
                return xPosition;
            }
            set
            {
                xPosition = value;
            }
        }
        public bool IsDestroyed
        {
            get
            {
                return isDestroyed;
            }
            set
            {
                isDestroyed = value;
            }
        }
    }
}

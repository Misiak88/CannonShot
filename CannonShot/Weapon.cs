using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonShot
{
    abstract class Weapon
    {
        protected string name;
        protected int clipSize;
        protected double firePower;
        protected double accuracy;
        protected double aim;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }       
        public int ClipSize
        {
            get
            {
                return clipSize;
            }
            set
            {
                clipSize = value;
            }
        }
        public double FirePower
        {
            get
            {
                return firePower;
            }
            set
            {
                firePower = value;
            }
        }
        public double Accuracy
        {
            get
            {
                return accuracy;
            }
            set
            {
                accuracy = value;
            }
        }
        public double Aim
        {
            get
            {
                return aim;
            }
            set
            {
                aim = value;
            }
        }
 
    }
}

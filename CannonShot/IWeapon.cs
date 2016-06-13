using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CannonShot
{
    public interface IWeapon
    {
        double Fire();
        void Reload();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMe.Core
{
    internal class RemoteWeapon:Weapon
    {
        //子弹编号
        public int BulletId { get; set; }
        //子弹的射程
        public float BulletRange { get; set; }
        //子弹速度
        public float BulletSpeed { get; set; }


        public RemoteWeapon() { }

    }
}

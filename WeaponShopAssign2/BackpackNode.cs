using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BackpackNode
    {
        public Weapon weapon;
        public BackpackNode next;
        public BackpackNode(Weapon weapon)
        {
            this.weapon = weapon;
            next = null;
        }
    }
}

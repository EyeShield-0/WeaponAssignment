using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BSTNode
    {
        public Weapon weapon;
        public BSTNode weaponLeft, weaponRight;
        
        public BSTNode(Weapon weapon)
        {
            this.weapon = weapon;
            weaponLeft = null;
            weaponRight = null;
        }
    }
}

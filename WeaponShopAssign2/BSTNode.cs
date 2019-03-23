using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class BSTNode
    {
        public Weapon weapon;
        public BSTNode weaponLeft, weaponRight;
        public int quantity;

        public BSTNode(Weapon weapon)
        {
            this.weapon = weapon;
            quantity = 1;
            weaponLeft = null;
            weaponRight = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Weapon
    {
        public string name;
        public int range;
        public int damage;
        public double weight;
        public double cost;
        public int quantity;

        public Weapon(string name, int range, int damage, double weight, double cost, int quantity)
        {
            this.name = name;
            this.range = range;
            this.damage = damage;
            this.weight = weight;
            this.cost = cost;
            this.quantity = quantity;
        }
    }
}

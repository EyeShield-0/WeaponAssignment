using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        public BackpackNode head;
        public double maxWeight;
        public double presentWeight;

        public Backpack(double maxWeight)
        {
            head = null;
            this.maxWeight = maxWeight;
            presentWeight = 0;
        }
        
        public bool addWeapon(Weapon newWeapon)
        {
            if (head == null)
            {
                head = new BackpackNode(newWeapon);
            }
            else
            {
                BackpackNode curr = head;
                while (curr.next != null)
                {
                    curr = curr.next;
                }
                curr.next = new BackpackNode(newWeapon);
            }
            presentWeight += newWeapon.weight;
            return true;

        }

        public void listWeapons()
        {
            BackpackNode curr = head;
            while(curr != null)
            {
                Console.WriteLine("\nWeapon Name: \t{0}\nDamage: \t{1}\nRange:  \t{2}\nWeight: \t{3}\n", curr.weapon.name, curr.weapon.damage, curr.weapon.range, curr.weapon.weight);
                curr = curr.next;
            }
            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public Backpack backpack;
        public double money;
        public double maxWeight;

        public Player(string name, double money, double maxWeight)
        {
            this.name = name;
            this.money = money;
            this.maxWeight = maxWeight;
            backpack = new Backpack(maxWeight);
        }

        public void buyWeapon(Weapon weapon)
        {
            if (inventoryFull(weapon))
            {
                backpack.addWeapon(weapon);
                Console.WriteLine("\nSuccessfully bought the weapon {0} for {1} coins!!\n", weapon.name, weapon.cost);
            }
            else
            {
                Console.WriteLine("\nYou're going to exceed the weight limit, please discard an item before you add this one!\n");
            }

        }
        public void withdraw(double amt)
        {
            money -= amt;
        }

        public bool inventoryFull(Weapon weapon)
        {
            return (backpack.presentWeight + weapon.weight) <= maxWeight;
        }

        public void printCharacter()
        {
            Console.WriteLine("----- DISPLAYING PLAYER INFO -----");
            Console.WriteLine("\nPlayer Name: {0}\nMoney: {1}\nMax Weight: {2}\n", name, money, maxWeight);
            printBackpack();
        }

        public void printBackpack()
        {
            Console.WriteLine("\n"+ name + ", your backpack weighs " + backpack.presentWeight + "\n\nWeapons:");
            backpack.listWeapons();
        }
    }
}

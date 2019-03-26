using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class MyBST
    {
        BSTNode root;

        public MyBST()
        {
            root = null;
        }

        // CODE FOR ADDING WEAPON TO THE SHOP STARTS HERE
        public void addWeapon(string name, int range, int damage, double weight, double cost, int quantity)
        {
            Weapon newWeapon = new Weapon(name, range, damage, weight, cost, quantity);
            root = insertWorker(root, newWeapon);
        }

        private BSTNode insertWorker(BSTNode curr, Weapon newWeapon)
        {
            if (curr == null) return new BSTNode(newWeapon);
            if (string.Compare(newWeapon.name, curr.weapon.name) < 0) curr.weaponLeft = insertWorker(curr.weaponLeft, newWeapon);
            if (string.Compare(newWeapon.name, curr.weapon.name) > 0) curr.weaponRight = insertWorker(curr.weaponRight, newWeapon);
            if (string.Compare(newWeapon.name, curr.weapon.name) == 0) curr.weapon.quantity += newWeapon.quantity;
            return curr;
        }


        // CODE FOR DISPLAYING ALL WEAPONS IN ORDER
        public void displayWeapons()
        {
            inOrderTrav(root);
            Console.WriteLine();
        }

        private void inOrderTrav(BSTNode curr)
        {
            if (curr == null) return;
            inOrderTrav(curr.weaponLeft);
            if (curr.weapon.quantity > 0)
            {
                Console.Write("Weapon Name: {0} \tPrice:{1} \tQuantity:{2}\n", curr.weapon.name, curr.weapon.cost, curr.weapon.quantity);
            }
            inOrderTrav(curr.weaponRight);
        }


        // CODE FOR SEARCHING A SPECIFIC WEAPON
        public BSTNode search(string name)
        {
            return searchWorker(root, name);
        }

        private BSTNode searchWorker(BSTNode curr, string name)
        {
            if (curr == null) return null;
            if (curr.weapon.name == name) return curr;
            if (string.Compare(name, curr.weapon.name) < 0) return searchWorker(curr.weaponLeft, name);
            else {return  searchWorker(curr.weaponRight, name); }
        }


        // CODE FOR DELETE

        public void deleteWeapon(string name)
        {
            BSTNode w = search(name);
            if(w != null)
            {
                root = deleteHelper(root, w.weapon);
                Console.WriteLine("\nSuccessfully deleted {0} from the shop!\n", w.weapon.name);
            }
            else
            {
                Console.WriteLine("\nWeapon does not exist on this shop\n");
            }

        }

        private BSTNode deleteHelper(BSTNode curr, Weapon key)
        {
            if (curr == null) return null;

            if (key.name.CompareTo(curr.weapon.name) < 0) curr.weaponLeft = deleteHelper(curr.weaponLeft, key);
            if (key.name.CompareTo(curr.weapon.name) > 0) curr.weaponRight = deleteHelper(curr.weaponRight, key);

            if(curr.weapon.name == key.name)
            {
                if (curr.weaponLeft == null) return curr.weaponRight;
                if (curr.weaponRight == null) return curr.weaponLeft;

                BSTNode successor = curr.weaponRight;

                while(successor.weaponLeft != null)
                {
                    successor = successor.weaponLeft;
                }
                curr.weapon = successor.weapon;
                curr.weaponRight = deleteHelper(curr.weaponRight, successor.weapon);
            }
            return curr;
        }
       

    }
}

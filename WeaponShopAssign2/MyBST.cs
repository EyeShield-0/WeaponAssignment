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
        public void addWeapon(string name, int range, int damage, double weight, double cost)
        {
            Weapon newWeapon = new Weapon(name, range, damage, weight, cost);
            root = insertWorker(root, newWeapon);
        }

        private BSTNode insertWorker(BSTNode curr, Weapon newWeapon)
        {
            if (curr == null) return new BSTNode(newWeapon);
            if (string.Compare(newWeapon.name.ToLower(), curr.weapon.name.ToLower()) < 0) curr.weaponLeft = insertWorker(curr.weaponLeft, newWeapon);
            if (string.Compare(newWeapon.name.ToLower(), curr.weapon.name.ToLower()) > 0) curr.weaponRight = insertWorker(curr.weaponRight, newWeapon);
            if (string.Compare(newWeapon.name.ToLower(), curr.weapon.name.ToLower()) == 0) curr.quantity++;
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
            Console.Write("Weapon Name: {0} \tPrice:{1} \tQuantity:{2}\n", curr.weapon.name, curr.weapon.cost, curr.quantity);
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
            if (curr.weapon.name.ToLower() == name.ToLower()) return curr;
            if (string.Compare(name.ToLower(), curr.weapon.name.ToLower()) < 0) curr.weaponLeft = searchWorker(curr.weaponLeft, name);
            return searchWorker(curr.weaponRight, name);
        }


        // CODE FOR DELETING ITEM FROM THE SHOP (INCOMPLETE)
        public void delete(string name)
        {
            BSTNode key = search(name);
            if(key != null)
            {
                deleteHelper(root, key);
            }
            else
            {
                Console.WriteLine("\nThat weapon does not exist!\n");
            }
        }

        private BSTNode deleteHelper(BSTNode curr, BSTNode key)
        {
            if (curr == null) return curr;

            if (string.Compare(key.weapon.name.ToLower(), curr.weapon.name.ToLower()) < 0)
            {
                curr.weaponLeft = deleteHelper(curr.weaponLeft, key);
            }
            else if (string.Compare(key.weapon.name.ToLower(), curr.weapon.name.ToLower()) > 0)
            {
                curr.weaponRight = deleteHelper(curr.weaponRight, key);
            }
            else
            {
                if(curr.weaponLeft == null)
                {
                    return curr.weaponRight;
                }
                else if (curr.weaponRight == null)
                {
                    return curr.weaponLeft;
                }

                BSTNode min = getMin(curr.weaponRight);

                curr.weaponRight = deleteHelper(curr.weaponRight, min);
            }
            return curr;
        }

        private BSTNode getMin(BSTNode curr)
        {
            while(curr.weaponLeft != null)
            {
                curr = curr.weaponLeft;
            }
            return curr;
        }

    }
}

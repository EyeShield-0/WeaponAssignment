using System;

namespace WeaponShopAssign2
{
    class Program
    {
        static MyBST shop = new MyBST();
        static Player player;

        //prints the starting menu
        static void getPlayerInfo()
        {
            Console.WriteLine("----- GETTING PLAYER INFO -----");
            string playerName = getStringInput("\nPlease Enter Your Name: ");
            int playerMoney = getIntInput("Enter how much gold you have: ");
            double playerMaxWeight = getDoubleInput("How much weight can you carry: ");
            player = new Player(playerName, playerMoney, playerMaxWeight);
        }

        //prints the player information
        static void printPlayerInfo()
        {
            Console.Clear();
            player.printCharacter();
        }

        //view player backpack
        static void viewBackpack()
        {
            Console.WriteLine("----- VIEWING PLAYER BACKPACK -----");
            player.printBackpack();
        }

        //buy weapon from the shop
        static void buyWeapon()
        {
            Console.WriteLine("----- BUYING WEAPON FROM THE SHOP -----\n");
            Console.WriteLine("Weapon List:");

            shop.displayWeapons();
            string name = getStringInput("Enter the Weapon name that you would like to buy: ");
            
            if (shop.search(name) != null)
            {
                Weapon w = shop.search(name).weapon;
                if (w.quantity > 0)
                {
                    player.buyWeapon(w);
                    player.money -= w.cost;
                }
            }
            else
            {
                Console.WriteLine("{0} does not exist in this shop!", name);
            }
            
        }

        //method that adds weapon to the shop
        static void addShopMerchandise()
        {
            string choice = getStringInput("------ ADDING WEAPON TO THE SHOP ------\nEnter('end') to exit weapon addition menu: ");
            while(choice.ToLower() != "end")
            {
                Console.Clear();
                Console.WriteLine("------ ADDING WEAPON TO THE SHOP ------");
                string weaponName = getStringInput("\nEnter the weapon name: ");
                int weaponRange = getIntInput("Enter the weapon range: ");
                int weaponDamage = getIntInput("Enter the weapon damage: ");
                double weaponWeight = getDoubleInput("Enter the weapon weight: ");
                double weaponCost = getDoubleInput("Enter the weapon price: ");
                int weaponQuantity = getIntInput("Enter the weapon quantity: ");
                shop.addWeapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost, weaponQuantity);
                Console.WriteLine("\nSuccessfully added the weapon to the shop!\n");
                choice = getStringInput("Enter('end') to exit weapon addition menu: ");
            }
        }

        //delete weapon from the shop
        static void deleteWeapon()
        {
            Console.WriteLine("----- WEAPON DELETION -----\nWeapon List:\n");
            shop.displayWeapons();
            string name = getStringInput("Enter the name of the weapon you would like to delete: ");
            shop.deleteWeapon(name);
        }

        //starting menu
        static void menu()
        {
            Console.Clear();
            Console.WriteLine("----- WELCOME TO THE WORLD OF RAGNAROK -----");
            Console.WriteLine("\n1.) Add items to the shop\n2.) Delete item from the shop\n3.) Buy from the shop\n4.) View Backpack\n5.) View Player\n6.) Exit\n");
        }

        //gets int input from the user
        static int getIntInput(string prompt)
        {
            int input;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out input));
            return input;
        }

        //get double input from the user
        static double getDoubleInput(string prompt)
        {
            double input;
            do
            {
                Console.Write(prompt);
            } while (!double.TryParse(Console.ReadLine(), out input));
            return input;
        }

        //gets string input from the user
        static string getStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine().ToLower();
        }
        
        //gets a choice from the user from 1-6
        static int getChoice()
        {
            int choice;
            do
            {
                menu();
                choice = getIntInput("Input: ");
            } while (choice > 6 || choice < 1);
            return choice;
        }

        //run the program while user has not chosen to quit
        static void start()
        {
            int choice = getChoice();
            while (choice != 6)
            {
                run(choice);
                choice = getChoice();
            }
        }

        //the runs the function depending on the choice chosen by the user
        static void run(int choice)
        {
            Console.Clear();
            switch (choice)
            {
                case 1:
                    addShopMerchandise();
                    break;
                case 2:
                    deleteWeapon();
                    break;
                case 3:
                    buyWeapon();
                    break;
                case 4:
                    viewBackpack();
                    break;
                case 5:
                    printPlayerInfo();
                    break;
            }
            Console.WriteLine("\nPress any key to go back to the menu.");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            
            getPlayerInfo();
            start();
            Console.WriteLine("\nGOODBYE!");
            Console.ReadKey();
        }
    }
}

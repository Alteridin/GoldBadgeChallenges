using CafeLib;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Cafe
{
    class ProgramUI
    {
        private readonly MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenuList();
            RunTitle();
            RunProgram();
        }
        private void RunTitle()
        {
            string welcome = "Welcome to Komodo Cafe Menu Updating system...";
            string version = "Version: 1.0";
            string system = "...System Loaded...";
            string enter = "Press Enter to continue...";
            Console.Write("\n\n\n\n\n\n");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (welcome.Length / 2)) + "}", welcome));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (version.Length / 2)) + "}", version));
            Console.Write("\n\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Thread.Sleep(1000);
            foreach (char loadTyping in system)
            {
                Thread.Sleep(10);
                Console.Beep();
                Thread.Sleep(10);
                Console.Write(loadTyping);
            }
            Thread.Sleep(1000);
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(enter);
            Console.ReadKey();
            Console.Beep();
        }
        private void RunProgram()
        {
            bool loopTillExit = true;
            while (loopTillExit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Main Menu \n\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("1: Show All Current Meals \n" +
                    "2: Find Meal By Combo Number \n" +
                    "3: Add New Meal \n" +
                    "4: Remove Meal \n" +
                    "Exit: Closes Program \n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter your selection now: ");
                string userSelect = Console.ReadLine().ToLower();
                Console.Beep();
                switch (userSelect)
                {
                    case "1":
                        {
                            ShowAll();
                            break;
                        }
                    case "2":
                        {
                            FindMealByNumber();
                            break;
                        }
                    case "3":
                        {
                            AddMeal();
                            break;
                        }
                    case "4":
                        {
                            DeleteMeal();
                            break;
                        }
                    case "exit":
                        {
                            loopTillExit = false;
                            Console.Beep();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\n");
                            Console.WriteLine("Invalid Option. \n" + "Press any key to try again...");
                            Console.ReadKey();
                            Console.Beep();
                            break;
                        }
                }
            }
        }
        private void ShowAll()
        {
            Console.Clear();
            List<Menu> listOfContent = _menuRepo.GetContent();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All Current Meals \n\n");
            foreach (Menu menuItems in listOfContent)
            {
                DisplayContent(menuItems);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.Beep();
        }
        private void DisplayContent(Menu content)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Meal Number: {content.MealNumber}, Meal Name: {content.MealName}, Meal Price: ${content.MealPrice} \n" +
                $"Meal Description: {content.MealDescription} \n" +
                $"Comes w/Fries: {content.HasFries} \n" +
                $"Comes w/Drink: {content.HasDrink} \n" +
                $"Ingredients: ");
            foreach (string ingredients in content.ListIngredients)
            {
                Console.WriteLine($"\t -{ingredients}");
            }
        }
        private void FindMealByNumber()
        {
            bool findMealExit = true;
            while (findMealExit)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Find Meal By Combo Number \n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter the number of the meal you are searching for (0 to return to Main Menu): ");
                int comboNumber = int.Parse(Console.ReadLine());
                Console.Beep();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (comboNumber == 0)
                {
                    findMealExit = false;
                }
                else
                {
                    Menu foundContent = _menuRepo.GetContentByMenuNumber(comboNumber);
                    if (foundContent != null)
                    {
                        DisplayContent(foundContent);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Press any key to search for another Meal...");
                        Console.ReadKey();
                        Console.Beep();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Find Meal By Combo Number \n\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Selection. Could not retrieve Meal. \n\n" + "Press any key to try again...");
                        Console.ReadKey();
                        Console.Beep();
                    }
                }
            }
        }
        private void AddMeal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Add A Meal \n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Menu content = new Menu();
            Console.Write("Please enter a New Meal Number: ");
            content.MealNumber = int.Parse(Console.ReadLine());
            Console.Beep();
            Console.WriteLine();
            Console.Write("Please enter the Name of the New Meal: ");
            content.MealName = Console.ReadLine();
            Console.Beep();
            Console.WriteLine();
            Console.Write("Please enter a Description of the New Meal: ");
            content.MealDescription = Console.ReadLine();
            Console.Beep();
            bool addIngredient = true;
            List<string> emptyList = new List<string>();
            while (addIngredient)
            {
                Console.WriteLine();
                Console.Write("Do you want to add an Ingredient? (Yes or No): ");
                string ingredientYesOrNo = Console.ReadLine().ToLower();
                Console.Beep();
                if (ingredientYesOrNo == "yes")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("What Ingredient do you want to add to this New Meal? ");
                    string answer = Console.ReadLine();
                    Console.Beep();
                    emptyList.Add(answer);
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("You have chosen to end adding Ingredients. \n" + "Press any key to continue... \n");
                    Console.ReadKey();
                    Console.Beep();
                    content.ListIngredients = emptyList;
                    addIngredient = false;
                }
            }
            Console.WriteLine();
            Console.Write("Does the New Meal come with Fries (Yes or No): ");
            string wFries = Console.ReadLine().ToLower();
            Console.Beep();
            switch (wFries)
            {
                case "yes":
                    {
                        content.HasFries = true;
                        break;
                    }
                case "no":
                    {
                        content.HasFries = false;
                        break;
                    }
            }
            Console.WriteLine();
            Console.Write("Does the New Meal come with a Drink (Yes or No): ");
            string wDrink = Console.ReadLine().ToLower();
            Console.Beep();
            switch (wDrink)
            {
                case "yes":
                    {
                        content.HasDrink = true;
                        break;
                    }
                case "no":
                    {
                        content.HasDrink = false;
                        break;
                    }
            }
            Console.WriteLine();
            Console.Write("What is the Price of the New Meal (ex. 02.50): ");
            content.MealPrice = decimal.Parse(Console.ReadLine());
            Console.Beep();
            Console.WriteLine();
            bool added = _menuRepo.AddContentToDirectory(content);
            if (added)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add A Meal \n\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Your New Meal has been added successfully... \n\n" + "Press any key to return to the Main Menu");
                Console.ReadKey();
                Console.Beep();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add A Meal \n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("An error has occurred while adding your New Meal. Nothing has been changed. \n\n" + "Press any key to return to the Main Menu...");
                Console.ReadKey();
                Console.Beep();
            }
        }
        private void DeleteMeal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Delete a Saved Meal \n\n");
            Console.ForegroundColor = ConsoleColor.White;
            List<Menu> menuList = _menuRepo.GetContent();
            int count = 0;
            foreach (Menu content in menuList)
            {
                count++;
                Console.WriteLine($"{count} - {content.MealName} | {content.MealDescription}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Which Meal would you like to Delete: ");
            int targetMeal = int.Parse(Console.ReadLine());
            Console.Beep();
            int targetMenu = targetMeal - 1;
            Console.ForegroundColor = ConsoleColor.White;
            if (targetMenu >= 0 && targetMenu < menuList.Count)
            {
                Menu desiredMeal = menuList[targetMenu];
                if (_menuRepo.DeleteExistingContent(desiredMeal))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Delete a Saved Meal \n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{desiredMeal.MealName} has been removed \n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Press any key to return to the Main Menu...");
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Delete a Saved Meal \n\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error has occurred while trying to Delete Meal. Nothing has been changed. \n" + "Press any key to return to the Main Menu...");
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Delete a Saved Meal \n\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No content had that ID. \n" + "Press any key to return to the Main Menu...");
            }
            Console.ReadKey();
        }
        private void SeedMenuList()
        {
            Menu spaghetti = new Menu(1, "Spaghetti", "Noodles", testIngredients, false, true, 2.50m);
            _menuRepo.AddContentToDirectory(spaghetti);
        }
        private readonly List<string> testIngredients = new List<string>()
        {
            "Red Sauce", "Noodles", "salt"
        };
    }
}
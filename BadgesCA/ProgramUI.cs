using BadgesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BadgesCA
{
    class ProgramUI
    {
        private readonly BadgesRepository _badgesRepo = new BadgesRepository();
        public void Run()
        {
            SeedContent();
            RunTitle();
            RunProgram();
        }
        private void RunTitle()
        {
            string welcome = "Welcome to Komodo Insurance Badge Updating system...";
            string version = "Version: 1.0";
            string system = "...Welcome Security Agent 113...\n" + "Access Granted";
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
                Console.Write("1: Add a New Badge\n" +
                    "2: Edit a Badge\n" +
                    "3: View a Full List of Active Badges\n" +
                    "Exit: Closes Program \n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Agent 113, enter your selection now: ");
                string userSelect = Console.ReadLine().ToLower();
                Console.ResetColor();
                switch (userSelect)
                {
                    case "1":
                        {
                            AddBadge();
                            break;
                        }
                    case "2":
                        {
                            EditBadge();
                            break;
                        }
                    case "3":
                        {
                            ShowAll();
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
        private void AddBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();
            Console.Write("Please enter the Badge ID Number (Recommended: 5-Digits): ");
            newBadge.BadgeId = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Please Note the layout of the Komodo Insurance Doors. One letter followed by a number with sections A-F and up to 30 doors per section (ex. A25).");
            bool doorLoop = true;
            List<string> doorList = new List<string>();
            while (doorLoop)
            {
                Console.WriteLine();
                Console.Write("Do you want to give this Badge access to a Door (Yes/No): ");
                string accesYesorNo = Console.ReadLine().ToLower();
                if (accesYesorNo == "yes")
                {
                    Console.WriteLine();
                    Console.Write("Which Door should this Badge have Access to: ");
                    string whichDoor = Console.ReadLine();
                    doorList.Add(whichDoor);
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("You have chosen to end adding Access to Doors. \n" + "Press any key to continue... \n");
                    Console.ReadKey();
                    newBadge.DoorNames = doorList;
                    doorLoop = false;
                }
            }
            bool added = _badgesRepo.NewBadge(newBadge);
            if (added)
            {
                Console.WriteLine();
                Console.Write("Your New Badge has been added successfully... \n\n" + "Press any key to return to the Main Menu");
                Console.ReadKey();
            }
            else
            {
                Console.Write("An error has occurred while adding your New Badge. Nothing has been changed. \n\n" + "Press any key to return to the Main Menu...");
                Console.ReadKey();
            }
        }
        private void EditBadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> editBadge = _badgesRepo.FullAccessList();
            Console.WriteLine("Here is a list of all Active Badges:");
            Console.WriteLine();
            int counter = 1;
            foreach (KeyValuePair<int, List<string>> listBadges in editBadge)
            {
                Console.WriteLine($"{counter}: {listBadges.Key}");
                counter++;
            }
            Console.WriteLine();
            Console.Write("Select the Badge would you like to Edit by entering the Badge's order number now: ");
            int userSelect = int.Parse(Console.ReadLine());
            Console.WriteLine();
            _badgesRepo.ShowOneBadge(userSelect);
            Console.WriteLine();
            bool doorLoop = true;
            while (doorLoop)
            {
                Console.WriteLine();
                Console.Write("1. Remove a Door\n" + "2. Add a Door\n" + "3. Return to Main Menu\n");
                Console.WriteLine();
                Console.Write("What would you like to do? ");
                string addOrRemove = Console.ReadLine().ToLower();
                Console.WriteLine();
                if (addOrRemove == "1")
                {
                    Console.Write("Which Door do you want to remove? ");
                    string userDoor = Console.ReadLine();
                    _badgesRepo.RemoveDoorFromID(userSelect, userDoor);
                    Console.WriteLine();
                    Console.Write("The Door has been removed! Press any key to continue...");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                if (addOrRemove == "2")
                {
                    Console.Write("Which Door do you want to add? ");
                    string userDoor = Console.ReadLine();
                    _badgesRepo.AddDoorToID(userSelect, userDoor);
                    Console.WriteLine();
                    Console.Write("The Door has been added! Press any key to continue...");
                    Console.ReadKey();
                    Console.WriteLine();
                }
                if (addOrRemove == "3")
                {
                    doorLoop = false;
                }
            }
        }
        private void ShowAll()
        {
            Console.Clear();
            Dictionary<int, List<string>> listOfBadgesAndDoors = _badgesRepo.FullAccessList();
            foreach (KeyValuePair<int, List<string>> listBadges in listOfBadgesAndDoors)
            {
                Console.Write($"The Badge: {listBadges.Key} has access to the following doors: ");
                foreach (string listDoors in listBadges.Value)
                {
                    Console.Write($"{listDoors} | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            Badges idBadge = new Badges(12345, new List<string> { "A1", "A2", "A3", "A7", "A13" });
            Badges idBadge2 = new Badges(12346, new List<string> { "A1", "A2", "A7", "A13", "B2", "B4" });
            Badges idBadge3 = new Badges(12347, new List<string> { "A1", "A4", "A5", "A7", "A13", "B1" });
            Badges idBadge4 = new Badges(12348, new List<string> { "A1", "A2", "A3", "A7", "A13" });
            _badgesRepo.NewBadge(idBadge);
            _badgesRepo.NewBadge(idBadge2);
            _badgesRepo.NewBadge(idBadge3);
            _badgesRepo.NewBadge(idBadge4);
        }
    }
}

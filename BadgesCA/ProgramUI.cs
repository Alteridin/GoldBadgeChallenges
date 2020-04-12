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
        private void SeedContent()
        {
            List<string> doorAccessTest = new List<string>() { "A1", "A2", "A5", "A6", "A13" };
            List<string> doorAccessTest2 = new List<string>() { "A2", "A4", "A6", "A13" };
            Badges badgeId = new Badges(12345, doorAccessTest);
            Badges badgeId2 = new Badges(12346, doorAccessTest2);
            _badgesRepo.NewBadge(badgeId.BadgeId, badgeId.DoorNames);
            _badgesRepo.NewBadge(badgeId2.BadgeId, badgeId2.DoorNames);
        }
    }
}

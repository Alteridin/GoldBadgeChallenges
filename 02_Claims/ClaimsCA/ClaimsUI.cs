using KomodoClaims;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimsCA
{
    class ClaimsUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();
        public void Run()
        {
            SeedClaimsQueue();
            RunTitle();
            RunProgram();
        }
        private void RunTitle()
        {
            Console.SetWindowSize(180, 50);
            Console.SetWindowPosition(0, 0);
            string welcome = "Welcome to Komodo Insurance Claims system...";
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
                Console.ResetColor();
                Console.Write("1: See all claims \n" + "2: Take care of next claim \n" + "3: Enter a new claim \n" + "Exit: Closes program \n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter your selection now: ");
                Console.ResetColor();
                string userSelect = Console.ReadLine().ToLower();
                switch (userSelect)
                {
                    case "1":
                        {
                            ShowAll();
                            break;
                        }
                    case "2":
                        {
                            NextClaim();
                            break;
                        }
                    case "3":
                        {
                            NewClaim();
                            break;
                        }
                    case "exit":
                        {
                            loopTillExit = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\n\n\n");
                            Console.WriteLine("Invalid Option. \n" + "Press any key to try again...");
                            Console.ReadKey();
                            break;
                        }
                }
            }
        }
        private void ShowAll()
        {
            Console.Clear();
            DataClaimsTable();
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DataClaimsTable()
        {
            Console.Clear();
            Queue<Claims> allInQueue = _claimsRepo.GetClaims();
            DataTable claimsDT = new DataTable("Komodo Insurance Claims");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (claimsDT.TableName.Length / 2)) + "}", claimsDT));
            Console.ResetColor();
            DataColumn idColumn = new DataColumn("Claim ID", typeof(int));
            DataColumn typeColumn = new DataColumn("Claim Type", typeof(Enum));
            DataColumn amountColumn = new DataColumn("Amount", typeof(decimal));
            DataColumn accidentColumn = new DataColumn("Date of Accident", typeof(DateTime));
            DataColumn claimColumn = new DataColumn("Date of Claim", typeof(DateTime));
            DataColumn validColumn = new DataColumn("Valid Claim", typeof(bool));
            DataColumn descriptionColumn = new DataColumn("Description", typeof(string));
            claimsDT.Columns.Add(idColumn);
            claimsDT.Columns.Add(typeColumn);
            claimsDT.Columns.Add(amountColumn);
            claimsDT.Columns.Add(accidentColumn);
            claimsDT.Columns.Add(claimColumn);
            claimsDT.Columns.Add(validColumn);
            claimsDT.Columns.Add(descriptionColumn);
            DataRow idRow;
            Console.WriteLine(idColumn);
            foreach (Claims idPrint in allInQueue)
            {
                idRow = claimsDT.NewRow();
                idRow["Claim ID"] = idPrint.ClaimID;
                idRow["Claim Type"] = idPrint.ClaimType;
                idRow["Amount"] = idPrint.ClaimAmount;
                idRow["Date of Accident"] = idPrint.DateOfAccident;
                idRow["Date of Claim"] = idPrint.DateOfClaim;
                idRow["Valid Claim"] = idPrint.IsValid;
                idRow["Description"] = idPrint.ClaimDescription;
                claimsDT.Rows.Add(idRow);
            }
            PrintDataTable(claimsDT);
            Console.WriteLine();
        }

        private static void PrintDataTable(DataTable claimPrint)
        {
            Console.WriteLine("{0,10}\t{1,10}\t{2,10}\t{3,25}\t{4,25}\t{5,12}\t{6,10}",
               "Claim ID",
               "Claim Type",
               "Amount",
               "Date of Accident",
               "Date of Claim",
               "Valid Claim",
               "Description"
               );
            foreach (DataRow row in claimPrint.Rows)
            {
                Console.WriteLine("{0,10}\t{1,10}\t{2,10}\t{3,25}\t{4,25}\t{5,12}\t{6,15}",
                    row["Claim ID"],
                    row["Claim Type"],
                    row["Amount"],
                    row["Date of Accident"],
                    row["Date of Claim"],
                    row["Valid Claim"],
                    row["Description"]
                    );
            }
        }
        private void NextClaim()
        {
            Console.Clear();
            Queue<Claims> nextClaim = _claimsRepo.GetClaims();
            Console.WriteLine("Below is the next claim needing to be handled:");
            Console.WriteLine();
            Console.WriteLine($"Claim ID: {nextClaim.Peek().ClaimID}");
            Console.WriteLine($"Claim Type: {nextClaim.Peek().ClaimType}");
            Console.WriteLine($"Amount: {nextClaim.Peek().ClaimAmount}");
            Console.WriteLine($"Date of Accident: {nextClaim.Peek().DateOfAccident}");
            Console.WriteLine($"Date of Claim: {nextClaim.Peek().DateOfClaim}");
            Console.WriteLine($"Valid Claim: {nextClaim.Peek().IsValid}");
            Console.WriteLine($"Description: {nextClaim.Peek().ClaimDescription}");
            Console.WriteLine();
            Console.Write("Do you want to handle this claim now (y/n): ");
            string handleClaim = Console.ReadLine().ToLower();
            if (handleClaim == "y")
            {
                nextClaim.Dequeue();
                Console.WriteLine();
                Console.WriteLine("The Claim has been removed from the queue...\n" + "Press any key to return to the Main Menu...");
            }
            if (handleClaim == "n")
            {
                Console.WriteLine();
                Console.Write("Press any key to return to the Main Menu...");
            }
            Console.ReadKey();
        }
        private void NewClaim()
        {
            Console.Clear();
            Claims content = new Claims();
            Console.Write("Please enter a Claim ID: ");
            content.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the Type of Claim (Car, Home, or Theft): ");
            string claimEnum = Console.ReadLine().ToLower();
            if (claimEnum == "car")
            {
                content.ClaimType = ClaimTypes.Car;
            }
            if (claimEnum == "home")
            {
                content.ClaimType = ClaimTypes.Home;
            }
            if (claimEnum == "theft")
            {
                content.ClaimType = ClaimTypes.Theft;
            }
            Console.WriteLine();
            Console.Write("What is the amount of this claim: $");
            content.ClaimAmount = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the Date of the Accident (ex. mm/dd/yyyy): ");
            content.DateOfAccident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Please enter the Date of the Claim (ex. mm/dd/yyyy): ");
            content.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Is this claim valid (True/False): ");
            content.IsValid = bool.Parse(Console.ReadLine().ToLower());
            Console.WriteLine();
            Console.Write("Please enter a description of the claim: ");
            content.ClaimDescription = Console.ReadLine();
            Console.WriteLine();
            bool added = _claimsRepo.AddContentToQueue(content);
            if (added)
            {
                Console.Write("The Claim was successfully added... \n\n" + "Press any key to return to the Main Menu");
                Console.ReadKey();
            }
            else
            {
                Console.Write("An error has occurred while adding your New Meal. Nothing has been changed. \n\n" + "Press any key to return to the Main Menu...");
                Console.ReadKey();
            }
        }
        private void SeedClaimsQueue()
        {
            Claims testClaim = new Claims(1, ClaimTypes.Car, "Rear bumper hit at traffic light.", 3000.00m, DateTime.Parse("04/09/2020"), DateTime.Parse("04/09/2020"), true);
            Claims testClaim2 = new Claims(2, ClaimTypes.Home, "Burned down due to unsupervised child.", 12000.00m, DateTime.Parse("03/12/2020"), DateTime.Parse("04/14/2020"), false);
            _claimsRepo.AddContentToQueue(testClaim);
            _claimsRepo.AddContentToQueue(testClaim2);
        }
    }
}

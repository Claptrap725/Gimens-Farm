using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assesment_1
{
    class Program
    {
        static bool temp = false;//this is just a variable that is always false
        static int actions = 7;
        static bool gameToClose = false;
        static int week = 1;
        static int day = 1;
        static int[,] dayData = new int[7,5];//[week, type of plant] stores how many days were speant in that field
        static bool[] endingsUnlocked = new bool[8];

        static int wheatField = 0;
        static int cabbageField = 0;
        static int potatoesField = 0;
        static int cornField = 0;
        static int multipleFields = 0;

        

        static void Main()
        {
            //--------------------LOAD SAVED DATA--------------------//
            StreamReader streamReader = new StreamReader(@"SaveData.txt");
            int streamCount = 0;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (line == "1")
                {
                    endingsUnlocked[streamCount] = true;
                }
                else
                {
                    endingsUnlocked[streamCount] = false;
                }

                streamCount++;
            }
            streamReader.Close();

            //--------------------MAIN MENU--------------------//
            Console.WriteLine("Thanks for playing Gimen's Farming Simulator!");
            string input = "";


            //--------------------MAIN MENU LOOP--------------------//
            while (true)
            {
                Console.WriteLine("To Start a new game enter \"start\"   \nTo View all Previous Endings enter \"endings\"    \nTo exit enter \"exit\"");
                input = Console.ReadLine();
                input = input.ToLower();

                if (input == "start" || input == "s")
                {
                    break;
                }
                else if (input == "endings")
                {
                    ChooseToViewEnding();
                    Console.Clear();
                }
                else if (input == "exit")
                {
                    goto CloseApp;
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again.\n\n");
                }
            }

            //--------------------NEW GAME INITILIZATION--------------------//
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n--------------------------------------------------------------------------------------------------------\nHello! Thank you for buying the Gimen Farm! You will be pleased with your purchase! (Press Enter)");
            Console.ReadLine();
            Console.WriteLine("As a bit of a disclaimer: Most people don't survive here long enough to even see the Sowthon.");
            Console.ReadLine();
            Console.WriteLine("And the ones that do... Well, they don't make it much longer after that.");
            Console.ReadLine();
            Console.WriteLine("You should start your first week by planting some crops and watering them! I\'ll give you some seeds to start off.");
            Console.ReadLine();


            //--------------------GAME LOOP--------------------//
            while (true)
            {
                if (actions > 0) { DayUpdate(); }
                else
                {
                    Console.Clear();
                    if (week == 6)
                    {
                        Yaug();
                    }
                    else
                    {
                        EndOfWeek();
                        week++;

                        Player.PlantUpdateAll();

                        //Reset weekly variables---------
                        actions = 7;
                        //dayData = new int[7, 5];
                        day = 1;
                    }
                }

                if (temp)break; //This is only here so VS won't tell me my code is unreachable

                if (gameToClose) goto CloseApp;
            }


        
        //-------------------------CLOSE OR RESTART-------------------------//
        CloseApp:
            Console.WriteLine("Type \"R\" to play again.");
            if (Console.ReadLine().ToLower() == "r")
            {
                Main();
                gameToClose = false;
            }

            
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nThank You for Playing!");
            Console.Read();
            return;
        }

        static void DayUpdate()
        {
            string input = "";
            Console.WriteLine($"\n\n\n\n\n\nWhat would you like to do today? WEEK {week} {GetDay()}");
            Console.WriteLine("(Type \"H\" to see a list of commands.)");
            input = Console.ReadLine();
            input = input.ToLower();

            if (input == "h" || input == "help" || input == "commands")
            {
                Console.WriteLine("\nList of commands: \nH : help \nE : end game \nP : plant new plant \nW : water \nC : colect produce \nL : list all plants \nB : goes back to this menu at any time");
            }
            else if (input == "e" || input == "end" || input == "exit")
            {
                gameToClose = true;
            }
            else if (input == "p" || input == "plant")
            {
                PlantCrop();
            }
            else if (input == "p1" || input == "plant1")
            {
                PlantCrop(1);
            }
            else if (input == "p2" || input == "plant2")
            {
                PlantCrop(2);
            }
            else if (input == "p3" || input == "plant3")
            {
                PlantCrop(3);
            }
            else if (input == "p4" || input == "plant4")
            {
                PlantCrop(4);
            }
            else if (input == "w" || input == "water")
            {
                WaterCrop();
            }
            else if (input == "w1" || input == "water1")
            {
                WaterCrop(1);
            }
            else if (input == "w2" || input == "water2")
            {
                WaterCrop(2);
            }
            else if (input == "w3" || input == "water3")
            {
                WaterCrop(3);
            }
            else if (input == "w4" || input == "water4")
            {
                WaterCrop(4);
            }
            else if (input == "c" || input == "collect" || input == "hravest")
            {
                CollectCrop();
            }
            else if (input == "c1" || input == "collect1" || input == "hravest1")
            {
                CollectCrop(1);
            }
            else if (input == "c1" || input == "collect1" || input == "hravest1")
            {
                CollectCrop(2);
            }
            else if (input == "c1" || input == "collect1" || input == "hravest1")
            {
                CollectCrop(3);
            }
            else if (input == "c1" || input == "collect1" || input == "hravest1")
            {
                CollectCrop(4);
            }
            else if (input == "l" || input == "list" || input == "all")
            {
                Player.PrintAllPlants();
                Console.WriteLine("\n\nCeller Stock - ");
                Console.WriteLine($"Bundles of wheat: {Player.wheatProduce}.");
                Console.WriteLine($"Barrels of Cabbage: {Player.cabbageProduce}.");
                Console.WriteLine($"Sacks of Potatoes: {Player.potatoesProduce}.");
                Console.WriteLine($"Barrows of corn ears: {Player.cornProduce}.");
            }
            else if (input == "b" || input == "back" || input == "menu")
            {
                //continue
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again. Type \"help\" for a list of commands.\n\n");
            }
        }

        static void PlantCrop()
        {
            Console.WriteLine("Which type of plant would you like to plant? Please choose from the list.");
            Console.WriteLine("\"1\" for Wheat\n\"2\" for Cabbage\n\"3\" for Potatoes\n\"4\" for Corn\n");
            string input = "";
            input = Console.ReadLine();
            input = input.ToLower();
            if (input == "b" || input == "back" || input == "menu") return;
            
            if (input == "1")//Wheat
            {
                int pos = Wheat.PlantsCreated;
                Player.wheat[pos] = new Wheat(pos);
                UseAction(1);
                Console.WriteLine("You planted a wheat seed.");
            }
            else if (input == "2")//Cabbage
            {
                int pos = Cabbage.PlantsCreated;
                Player.cabbage[pos] = new Cabbage(pos);
                UseAction(2);
                Console.WriteLine("You planted a cabbage seed.");
            }
            else if (input == "3")//Potatoes
            {
                int pos = Potatoes.PlantsCreated;
                Player.potatoes[pos] = new Potatoes(pos);
                UseAction(3);
                Console.WriteLine("You planted a potato.");
            }
            else if (input == "4")//Corn
            {
                int pos = Corn.PlantsCreated;
                Player.corn[pos] = new Corn(pos);
                UseAction(4);
                Console.WriteLine("You planted a corn seed.");
            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
                PlantCrop();
            }
        }
        static void PlantCrop(int plantType)
        {
            
            if (plantType == 1)//Wheat
            {
                int pos = Wheat.PlantsCreated;
                Player.wheat[pos] = new Wheat(pos);
                UseAction(1);
                Console.WriteLine("You planted a wheat seed.");
            }
            else if (plantType == 2)//Cabbage
            {
                int pos = Cabbage.PlantsCreated;
                Player.cabbage[pos] = new Cabbage(pos);
                UseAction(2);
                Console.WriteLine("You planted a cabbage seed.");
            }
            else if (plantType == 3)//Potatoes
            {
                int pos = Potatoes.PlantsCreated;
                Player.potatoes[pos] = new Potatoes(pos);
                UseAction(3);
                Console.WriteLine("You planted a potato.");
            }
            else if (plantType == 4)//Corn
            {
                int pos = Corn.PlantsCreated;
                Player.corn[pos] = new Corn(pos);
                UseAction(4);
                Console.WriteLine("You planted a corn seed.");
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                return;
            }
        }

        static void WaterCrop()
        {
            Console.WriteLine("Which type of plant would you like to water? Please choose from the list.");
            Console.WriteLine("\"1\" for Wheat\n\"2\" for Cabbage\n\"3\" for Potatoes\n\"4\" for Corn\n");
            string input = "";
            input = Console.ReadLine();
            input = input.ToLower();
            if (input == "b" || input == "back" || input == "menu") return;

            if (input == "1")//Wheat
            {
                bool anyPlants = false;
                foreach (var i in Player.wheat)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no wheat to water.");
                    return;
                }
                int pos = - 1;
                Console.WriteLine("Which Wheat plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllWheat();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.wheat[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(1);
                Console.WriteLine(pos);
                Player.wheat[pos].Water();
                Console.WriteLine("You watered the wheat plant.");
            }
            else if (input == "2")//Cabbage
            {
                bool anyPlants = false;
                foreach (var i in Player.cabbage)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no cabbage to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Cabbage plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllCabbage();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.cabbage[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(2);
                Console.WriteLine(pos);
                Player.cabbage[pos].Water();
                Console.WriteLine("You watered the cabbage plant.");
            }
            else if (input == "3")//Potatoes
            {
                bool anyPlants = false;
                foreach (var i in Player.potatoes)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no potatoes to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Potato plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllPotatoes();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.potatoes[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(3);
                Console.WriteLine(pos);
                Player.potatoes[pos].Water();
                Console.WriteLine("You watered the potato plant.");
            }
            else if (input == "4")//Corn
            {
                bool anyPlants = false;
                foreach (var i in Player.corn)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no corn to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Corn plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllCorn();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.corn[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(4);
                Console.WriteLine(pos);
                Player.corn[pos].Water();
                Console.WriteLine("You watered the corn plant.");

            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
                WaterCrop();
            }
        }

        static void WaterCrop(int plantType)
        {
            string input = "";
            if (plantType == 1)//Wheat
            {
                bool anyPlants = false;
                foreach (var i in Player.wheat)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no wheat to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Wheat plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllWheat();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.wheat[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(1);
                Console.WriteLine(pos);
                Player.wheat[pos].Water();
                Console.WriteLine("You watered the wheat plant.");
            }
            else if (plantType == 2)//Cabbage
            {
                bool anyPlants = false;
                foreach (var i in Player.cabbage)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no cabbage to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Cabbage plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllCabbage();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.cabbage[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(2);
                Console.WriteLine(pos);
                Player.cabbage[pos].Water();
                Console.WriteLine("You watered the cabbage plant.");
            }
            else if (plantType == 3)//Potatoes
            {
                bool anyPlants = false;
                foreach (var i in Player.potatoes)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no potatoes to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Potato plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllPotatoes();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.potatoes[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(3);
                Console.WriteLine(pos);
                Player.potatoes[pos].Water();
                Console.WriteLine("You watered the potato plant.");
            }
            else if (plantType == 4)//Corn
            {
                bool anyPlants = false;
                foreach (var i in Player.corn)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no corn to water.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which Corn plant would you like to water? Please type a plant number from the list.");
                Player.PrintAllCorn();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.corn[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                UseAction(4);
                Console.WriteLine(pos);
                Player.corn[pos].Water();
                Console.WriteLine("You watered the corn plant.");

            }
            else
            {
                Console.WriteLine("Invalid Input. Try again.");
                WaterCrop();
            }
        }

        static void CollectCrop()
        {
            Console.WriteLine("Which type of plant would you like to harvest? Please choose from the list.");
            Console.WriteLine("\"1\" for Wheat\n\"2\" for Cabbage\n\"3\" for Potatoes\n\"4\" for Corn\n");
            string input = "";
            input = Console.ReadLine();
            input = input.ToLower();
            if (input == "b" || input == "back" || input == "menu") return;

            if (input == "1")//Wheat
            {
                bool anyPlants = false;
                foreach (var i in Player.wheat)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no wheat to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which wheat plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllWheat();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.wheat[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(1);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the wheat plant, destroying it.\nYou collected {Player.wheat[pos].produce} wheat");
                Player.wheatProduce += Player.wheat[pos].produce;
                Player.wheat[pos].Die();

            }
            else if (input == "2")//cabbage
            {
                bool anyPlants = false;
                foreach (var i in Player.cabbage)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no cabbage to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which cabbage plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllCabbage();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.cabbage[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(2);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the cabbage plant, destroying it.\nYou collected {Player.cabbage[pos].produce} cabbage");
                Player.cabbageProduce += Player.cabbage[pos].produce;
                Player.cabbage[pos].Die();
            }
            else if (input == "3")//potatoes
            {
                bool anyPlants = false;
                foreach (var i in Player.potatoes)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no potatoes to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which potato plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllPotatoes();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.potatoes[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(3);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the potatoes plant, destroying it.\nYou collected {Player.potatoes[pos].produce} potatoes");
                Player.potatoesProduce += Player.potatoes[pos].produce;
                Player.potatoes[pos].Die();
            }
            else if (input == "4")//corn
            {
                bool anyPlants = false;
                foreach (var i in Player.corn)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no corn to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which corn plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllCorn();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.corn[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(4);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the corn plant, destroying it.\nYou collected {Player.corn[pos].produce} corn");
                Player.cornProduce += Player.corn[pos].produce;
                Player.corn[pos].Die();
            }
        }

        static void CollectCrop(int plantType)
        {
            string input = "";

            if (plantType == 1)//Wheat
            {
                bool anyPlants = false;
                foreach (var i in Player.wheat)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no wheat to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which wheat plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllWheat();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.wheat[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(1);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the wheat plant, destroying it.\nYou collected {Player.wheat[pos].produce} wheat");
                Player.wheatProduce += Player.wheat[pos].produce;
                Player.wheat[pos].Die();

            }
            else if (plantType == 2)//cabbage
            {
                bool anyPlants = false;
                foreach (var i in Player.cabbage)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no cabbage to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which cabbage plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllCabbage();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.cabbage[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(2);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the cabbage plant, destroying it.\nYou collected {Player.cabbage[pos].produce} cabbage");
                Player.cabbageProduce += Player.cabbage[pos].produce;
                Player.cabbage[pos].Die();
            }
            else if (plantType == 3)//potatoes
            {
                bool anyPlants = false;
                foreach (var i in Player.potatoes)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no potatoes to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which potato plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllPotatoes();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.potatoes[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(3);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the potatoes plant, destroying it.\nYou collected {Player.potatoes[pos].produce} potatoes");
                Player.potatoesProduce += Player.potatoes[pos].produce;
                Player.potatoes[pos].Die();
            }
            else if (plantType == 4)//corn
            {
                bool anyPlants = false;
                foreach (var i in Player.corn)
                {
                    if (i != null)
                    {
                        anyPlants = true;
                        break;
                    }
                }
                if (!anyPlants)
                {
                    Console.WriteLine("You have no corn to harvest.");
                    return;
                }
                int pos = -1;
                Console.WriteLine("Which corn plant would you like to harvest? Please type a plant number from the list.");
                Player.PrintAllCorn();
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "b" || input == "back" || input == "menu") return;

                if (!int.TryParse(input, out pos))
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }
                pos--;
                if (pos < 0 || pos > 50 || Player.corn[pos] == null)
                {
                    Console.WriteLine("Invalid Input.");
                    return;
                }

                if (Player.freeHarvesting && !Player.freeHarvestedThisDay)
                {
                    Player.freeHarvestedThisDay = true;
                }
                else
                {
                    UseAction(4);
                }
                Console.WriteLine(pos);
                Console.WriteLine($"You harvested the corn plant, destroying it.\nYou collected {Player.corn[pos].produce} corn");
                Player.cornProduce += Player.corn[pos].produce;
                Player.corn[pos].Die();
            }
        }

        static string GetDay()
        {
            switch (day)
            {
                case 1:
                    return "MONDAY";
                case 2:
                    return "TUESDAY";
                case 3:
                    return "WEDNESDAY";
                case 4:
                    return "THURSDAY";
                case 5:
                    return "FRIDAY";
                case 6:
                    return "SATURDAY";
                case 7:
                    return "SUNDAY";
            }
            return "";
        }

        static void UseAction(int plantType)
        {
            actions--;
            day++;
            Player.freeHarvestedThisDay = false;

            if (Player.autoPlant)
            {
                Random random = new Random();
                int rand = random.Next(1, 16);
                if (rand == 1)
                {
                    int pos = Wheat.PlantsCreated;
                    Player.wheat[pos] = new Wheat(pos);
                }
                else if (rand == 2)
                {
                    int pos = Cabbage.PlantsCreated;
                    Player.cabbage[pos] = new Cabbage(pos);
                }
                else if (rand == 3)
                {
                    int pos = Potatoes.PlantsCreated;
                    Player.potatoes[pos] = new Potatoes(pos);
                }
                else if (rand == 4)
                {
                    int pos = Corn.PlantsCreated;
                    Player.corn[pos] = new Corn(pos);
                }
            }

            switch (plantType)
            {
                case 1:
                    dayData[week, 1] += 1;
                    break;
                case 2:
                    dayData[week, 2] += 1;
                    break;
                case 3:
                    dayData[week, 3] += 1;
                    break;
                case 4:
                    dayData[week, 4] += 1;
                    break;
            }
        }
        

        static void EndOfWeek()
        {
            Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n===================================================================================================\n\nEND OF WEEK {week}...\n(Press Enter to continue)");
            //Console.WriteLine($"1: {dayData[1,1]} \n2: {dayData[1, 2]} \n3: {dayData[1, 3]} \n4: {dayData[1, 4]}");
            Console.ReadLine();

            if (wheatField >= 4)
            {
                Ending4();
            }
            else if (cabbageField >= 4)
            {
                Ending5();
            }
            else if (potatoesField >= 4)
            {
                Ending6();
            }
            else if (cornField >= 4)
            {
                Ending7();
            }

            else if (dayData[week, 1] >= 4)
            {
                WheatField();
            }
            else if (dayData[week, 2] >= 4)
            {
                CabbageField();
            }
            else if (dayData[week, 3] >= 4)
            {
                PotatoesField();
            }
            else if (dayData[week, 4] >= 4)
            {
                CornField();
            }
            else
            {
                MultipleFields();
            }

            Console.ReadLine();
            if (!gameToClose)
            {
                Console.WriteLine("\nTime to start the next week.");
                Console.ReadLine();
            }
            
        }

        static void WheatField()
        {
            wheatField++;
            Console.WriteLine("\nYou spend a lot of time in the WHEAT field this week.\n");
            
            if (wheatField == 1)
            {
                Console.WriteLine("While working the wheat land, you notice sharp bits of metal keep popping up in the ground.");
                Console.ReadLine();
                Console.WriteLine("Worried they might effect the crops, you pile them up on the end of the field.");
            }
            else if (wheatField == 2)
            {
                Console.WriteLine("Tending the field, you notice that the pile of metal you stacked is gone!");
                Console.ReadLine();
                Console.WriteLine("Pondering where it went, you search around the field finding no remenants of it.");
                Console.ReadLine();
                Console.WriteLine("It walked off... I guess?");
            }
            else if (wheatField == 3)
            {
                Console.WriteLine("Thoughout the week, you notice the ground occasionally shaking. Those weird meatl pieces start popping up again.");
                Console.ReadLine();
                Console.WriteLine("As you start to pile them up again your hands start glowing with power.");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You can now summon water with your hands, giving the plants water that lasts longer.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.waterPower++;
            }
            else if (wheatField == 4)
            {
                Console.WriteLine("This week the ground shaking is significatly worse.");
                Console.ReadLine();
                Console.WriteLine("You fear the Earth is gonna split open in this very spot!");
            }
            else if (wheatField == 5)
            {
                Ending4();
            }
        }
        static void CabbageField()
        {
            cabbageField++;
            Console.WriteLine("\nYou spend a lot of time in the CABBAGE patch this week.\n");

            if (cabbageField == 1)
            {
                Console.WriteLine("While out in the field, you notice some of the cabbage plants have little holes in them.");
                Console.ReadLine();
                Console.WriteLine("Try and look for what might be causing them, but you can't come to a solution.");
            }
            else if (cabbageField == 2)
            {
                Console.WriteLine("This week, you discover the culprit of the you holl filled cabbage.");
                Console.ReadLine();
                Console.WriteLine("You squash a locust that was resting on a head of cabbage.");
                Console.ReadLine();
                Console.WriteLine("Hopefully these won't multiply.");
            }
            else if (cabbageField == 3)
            {
                Console.WriteLine("Tending the patch this week you notice that weeds have been very sparse.");
                Console.ReadLine();
                Console.WriteLine("It seems that the locust prefer eating the weeds over your cabbage.");
                Console.ReadLine();
                Console.WriteLine("Turns out they are more help than harm!");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Plants now grow produce faster!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.produceProduction = 2;
            }
            else if (cabbageField == 4)
            {
                Console.WriteLine("By the end of this week, all the weeds on the farm are non-existant.");
                Console.ReadLine();
                Console.WriteLine("And the locusts... are very, very existant.");
                Console.ReadLine();
                Console.WriteLine("This many buzzing around with no food can't be good.");
            }
            else if (cabbageField == 5)
            {
                Ending5();
            }
        }
        static void PotatoesField()
        {
            potatoesField++;
            Console.WriteLine("\nYou spend a lot of time in the POTATOES field this week.\n");

            if (potatoesField == 1)
            {
                Console.WriteLine("While you are tending your potato field, a travelling merchant passes through your farm this week!");
                Console.ReadLine();
                Console.WriteLine("He offers you a purple potato to eat. Do you accept? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("You choose to accept his gracius offer!");
                    Console.ReadLine();
                    Console.WriteLine("Only after taking a huge bite do you realize that the potato has mold on it.");
                    Console.ReadLine();
                    Console.WriteLine("You spit it out on the ground, almost vomiting.");
                    Console.ReadLine();
                    Console.WriteLine("When you look up again the merchant is gone. I'm not sure if he was a merchant anymore.");
                    Console.ReadLine();
                    Console.WriteLine("What a jerk!");
                }
                else
                {
                    Console.WriteLine("You decide not to accept food from this stranger. Probably for the better.");
                    Console.ReadLine();
                    Console.WriteLine("The merchant throws the potato at the ground in rage and storms off.");
                    Console.ReadLine();
                    Console.WriteLine("The potato smells awful! Like mold. I'm not sure if he was a merchant anymore.");
                    Console.ReadLine();
                    Console.WriteLine("What was his problem?");
                }
            }
            else if (potatoesField == 2)
            {
                Console.WriteLine("This week in the potato field you notice some of the mold that was on that merchant potato has spread to your potatos.");
                Console.ReadLine();
                Console.WriteLine("This can't be good.");
            }
            else if (potatoesField == 3)
            {
                Console.WriteLine("The mold is spreading more and more.");
                Console.ReadLine();
                Console.WriteLine("This is actually helpful!");
                Console.ReadLine();
                Console.WriteLine("The mold causes the plant to wither but the produce is left just lying on/in the ground for you to pick up!");
                Console.ReadLine();
                Console.WriteLine("This helps you with harveting all over the farm.");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You can now collect produce from a plant once a day, and then continue to do something else that same day.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadLine();
                Console.WriteLine("Who would've thought this mold would be so helpful?");
            }
            else if (potatoesField == 4)
            {
                Console.WriteLine("The mold problem is getting out of hand...");
                Console.ReadLine();
                Console.WriteLine("As it continues to spread into the surrounding forrest and affect it, you worry about the life of the ecosystem here.");
                Console.ReadLine();
                Console.WriteLine("What is to come next?");
            }
            else if (potatoesField == 5)
            {
                Ending6();
            }
        }
        static void CornField()
        {
            cornField++;
            Console.WriteLine("\nYou spend a lot of time in the CORN field this week.\n");

            if (cornField == 1)
            {
                Console.WriteLine("Corn takes a long time to grow. So it will be a good investment in the long run.");
                Console.ReadLine();
                Console.WriteLine("You feel satisfied with your work.");
            }
            else if (cornField == 2)
            {
                Console.WriteLine("While in the corn field you see a shadow pass bye you.");
                Console.ReadLine();
                Console.WriteLine("Looking up you notice a crow.");
                Console.ReadLine();
                Console.WriteLine("You chuck a rock up at it.");
                Console.ReadLine();
                Console.WriteLine("It misses, but the crow squaks and flies off.");
                Console.ReadLine();
            }
            else if (cornField == 3)
            {
                Console.WriteLine("Throughout this week you notice that there is more and more crows.");
                Console.ReadLine();
                Console.WriteLine("They start pecking at you corn seeds and other plants.");
                Console.ReadLine();
                Console.WriteLine("Fortunatly the seeds pass right through their system causing random free plants to appear.");
                Console.ReadLine();
                Console.WriteLine("How useful!");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("On some mornings a new plant will appear now.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (cornField == 4)
            {
                Console.WriteLine("It seems that all of the crow from last week, invited their extended families.");
                Console.ReadLine();
                Console.WriteLine("There is much more.");
                Console.ReadLine();
                Console.WriteLine("This is getting out of hand.");
                Console.ReadLine();
                Console.WriteLine("Perhaps you can make a scarecrow?");
            }
            else if (cornField == 5)
            {
                Ending7();
            }
        }
        static void MultipleFields()
        {
            multipleFields++;
            Console.WriteLine("\nYou spend a lot of time in MULTIPLE fields this week.\n");

            if (multipleFields == 1)
            {
                Console.WriteLine("Exploring your fields of land you notice a small village far in the distance.");
                Console.ReadLine();
                Console.WriteLine("You think to yourself that maybe you should check out the place sometime.");
            }
            else if (multipleFields == 2)
            {
                Console.WriteLine("This week you decide to go into the village.");
                Console.ReadLine();
                Console.WriteLine("The people there are quite welcoming!");
                Console.ReadLine();
                Console.WriteLine("Except for one of the children who throws and egg at your head.");
                Console.ReadLine();
                Console.WriteLine("A lady smacks him, says, \"I'm so sorry,\" and drags him off.");
                Console.ReadLine();
                Console.WriteLine("The egg gets in your hair and you decide to head home to shower.");
            }
            else if (multipleFields == 3)
            {
                Console.WriteLine("You head into town again this week.");
                Console.ReadLine();
                Console.WriteLine("This time you find a merchant who's yelling something about a new farming tool!");
                Console.ReadLine();
                Console.WriteLine("You are immediatly intriged!");
                Console.ReadLine();
                Console.WriteLine("\"Avaible only from my shop is the all new Miricle Grow 3000!\"");
                Console.ReadLine();
                Console.WriteLine("\"It only costs $3000!\"");
                Console.ReadLine();
                Console.WriteLine("Without a second thought, you spend all the money you had in your savings for it!");
                Console.ReadLine();
                Console.WriteLine("After buying it you think about how this might have been an impulse buy.");
                Console.ReadLine();
                Console.WriteLine("But you rationalize that by thinking, There was only one left! And you needed it!");
                Console.ReadLine();
                Console.WriteLine("Weather you're satified or not it makes the plants much healthier.");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Plants will now live one week longer than before!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Player.miricleGrow = true;
            }
            else if (multipleFields == 4)
            {
                Console.WriteLine("While working the varius fields you see a horse.");
                Console.ReadLine();
                Console.WriteLine("Then another horse.");
                Console.ReadLine();
                Console.WriteLine("And another.");
                Console.ReadLine();
                Console.WriteLine("A few seconds later and you can see a stampede of horses coming over a hill going straight towards your field!");
                Console.ReadLine();
                Console.WriteLine("This can't be good for the crops!");
                Console.ReadLine();
                Random random = new Random();
                bool plantKilled = false;
                foreach (var i in Player.allPlants)
                {
                    if (i != null)
                    {
                        if (random.Next(1, 5) == 1)
                        {
                            i.Die();
                            plantKilled = true;
                        }
                    }
                }
                if (plantKilled)
                {
                    Console.WriteLine("The horses come runnig through the field trampling some crops!");
                    Console.ReadLine();
                    Console.WriteLine("Well that was unfortunate.");
                    Console.ReadLine();
                    Console.WriteLine("Replant I guess?");
                }
                else
                {
                    Console.WriteLine("The horses come running through the field...");
                    Console.ReadLine();
                    Console.WriteLine("Wow. They missed every plant");
                    Console.ReadLine();
                    Console.WriteLine("You are one lucky person!");
                }

            }
            else if (multipleFields == 5)
            {
                Console.WriteLine("While working in the fields you notice some very dark clouds in the distance.");
                Console.ReadLine();
                Console.WriteLine("It doesn't look like they will reach the farm today.");
                Console.ReadLine();
                Console.WriteLine("Maybe the rain will help with the watering efforts!");
                Console.ReadLine();
                Console.WriteLine("Then again, it might wash some plants out of their soil!");
                Console.ReadLine();
                Console.WriteLine("Only time will tell.");
            }
        }

        static void Yaug()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n#################################################################################\n\nEnd of week 6");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("The next week is filled with constant stormy weather.");
            Console.ReadLine();
            Console.WriteLine("It only seems to worsen with time.");
            Console.ReadLine();
            Console.WriteLine("After part of your roof caves in, you decide hide your the celler with your food stores that you've been working so hard for.");
            Console.ReadLine();
            Console.WriteLine("This \"Sowthon\" feels like the worst storm you've ever even heard of.");
            Console.ReadLine();
            Console.WriteLine("Will your food be enough to last it?");
            Console.ReadLine();
            Console.WriteLine("In the end...");
            Console.ReadLine();


            int winRating = 0;
            if (Player.wheatProduce >= 1)
            {
                if (Player.wheatProduce >= 4)
                {
                    winRating++;
                }
                winRating++;
            }
            if (Player.cabbageProduce >= 1)
            {
                if (Player.cabbageProduce >= 4)
                {
                    winRating++;
                }
                winRating++;
            }
            if (Player.potatoesProduce >= 1)
            {
                if (Player.potatoesProduce >= 4)
                {
                    winRating++;
                }
                winRating++;
            }
            if (Player.cornProduce >= 1)
            {
                if (Player.cornProduce >= 4)
                {
                    winRating++;
                }
                winRating++;
            }


            if (winRating >= 8)//plenty of all food
            {
                Ending0();
            }
            else if (winRating >= 4)//some food
            {
                Ending1();
            }
            else if (winRating >= 2)//lacking food
            {
                Ending2();
            }
            else if (winRating >= 0)//almost no food
            {
                Ending3();
            }
            
        }

        static void Ending0()//plenty of food
        {
            endingsUnlocked[0] = true;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("You Thrived.");
            Console.ReadLine();
            Console.WriteLine("With plenty of food stores from various types of plants surviving the Sowthon was a brease.");
            Console.ReadLine();
            Console.WriteLine("Your you didn't even eat half your food during the storm and the variety of nutrients keeps you strong.");
            Console.ReadLine();
            Console.WriteLine("Once it finally calmed, you emerged from you celler to find your home destroyed.");
            Console.ReadLine();
            Console.WriteLine("But this does not discourage you.");
            Console.ReadLine();
            Console.WriteLine("You are an experienced and hard worker. Within a week your roof rises again and you start to mark out you farm fields again.");
            Console.ReadLine();
            Console.WriteLine("Even new sprouts of potatoes and corn emerge by themselves.");
            Console.ReadLine();
            Console.WriteLine("A month later, a nearby town asked you for vital food supplies, paying you a healthy sum in return for the help.");
            Console.ReadLine();
            Console.WriteLine("With your new money you provide jobs to some of the people in that town, having them work your farm.");
            Console.ReadLine();
            Console.WriteLine("This allows you to focus on the house and you build it up to be a very nice homestead.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You settle down early and live a long life.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending1()//some food
        {
            endingsUnlocked[1] = true;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("You sustain.");
            Console.ReadLine();
            Console.WriteLine("With a variety of food you stay in good health and your food is enough to outlast the storm.");
            Console.ReadLine();
            Console.WriteLine("When you emerge from your celler to witness the destruction of your home you are discouraged.");
            Console.ReadLine();
            Console.WriteLine("Regaurdless you begin to rebuild.");
            Console.ReadLine();
            Console.WriteLine("In 2 weeks you have a roof over your head again.");
            Console.ReadLine();
            Console.WriteLine("You start making your farm again and have to resort to half rations worried you might not make it to the next harvest.");
            Console.ReadLine();
            Console.WriteLine("But you do.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("And you continue on to live a long life on your new farm.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending2()//lacking food
        {
            endingsUnlocked[2] = true;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("You suffer.");
            Console.ReadLine();
            Console.WriteLine("Your food stores are little and invariable.");
            Console.ReadLine();
            Console.WriteLine("Malnutrition leaves you weak and you force yourself to eat quarter rations to make it through out the storm.");
            Console.ReadLine();
            Console.WriteLine("When the Sowthon finally dies down you renter what used to be your home.");
            Console.ReadLine();
            Console.WriteLine("Rubble surrounds you and your farm is no more.");
            Console.ReadLine();
            Console.WriteLine("Being to frail to rebuild it you decide to start your farm again.");
            Console.ReadLine();
            Console.WriteLine("As time goes on you trade with a nearby town to get the essintials you need to live.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("You continue life having learned from Sowthon. Maybe next time you will be more prepared.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending3()//almost no food
        {
            endingsUnlocked[3] = true;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("You starve.");
            Console.ReadLine();
            Console.WriteLine("You have extreamly little food and no variety.");
            Console.ReadLine();
            Console.WriteLine("You run out of food in the first week though the Sowthon.");
            Console.ReadLine();
            Console.WriteLine("The storm never ends for you as your stomatch screams to you for more food.");
            Console.ReadLine();
            Console.WriteLine("The sound from your gut is almost enough drowns out the sound of your house falling apart outside.");
            Console.ReadLine();
            Console.WriteLine("In your last moments you wonder if anyone will ever find you here. Maybe they will learn from your mistakes.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player staved.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending4()//iron giant
        {
            endingsUnlocked[4] = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("This evening, an IRON GIANT BURSTS OUT OF THE GROUND!");
            Console.ReadLine();
            Console.WriteLine("!!!");
            Console.ReadLine();
            Console.WriteLine("!!!");
            Console.ReadLine();
            Console.WriteLine("He doesn't appear to be freindly either, considering how he is destroying all of the wheat field!");
            Console.ReadLine();
            foreach (var i in Player.wheat)
            {
                if (i != null) i.Die();
            }

            Console.ReadLine();
            Console.WriteLine("Uh oh.");
            Console.ReadLine();
            Console.WriteLine("He's looking at you now.");
            Console.ReadLine();
            Console.WriteLine("He takes a swing at you!");
            Console.WriteLine("Do you try to dodge? (Press D to dodge)");
            if (Console.ReadLine().ToLower() == "d")
            {
                Console.WriteLine("You dodge out of the way of his massive fist!");
                Console.ReadLine();
                Console.WriteLine("And get clobered by the second one...");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player was pummeled");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("...");
                Console.ReadLine();
                GameOver();
            }
            else
            {
                Console.WriteLine("Really? You don't dodge... Alright then. You stand there.");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Player was pummeled");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("...");
                Console.ReadLine();
                GameOver();
            }
        }
        static void Ending5()//Locusts eat cabbage and house
        {
            endingsUnlocked[5] = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("You can't sleep tonight with the awful sound of buzzing outside.");
            Console.ReadLine();
            Console.WriteLine("Occasionally you find a locust crawling on you in your bed and you have to smack it off.");
            Console.ReadLine();
            Console.WriteLine("When morning comes, you look out your door to see your massive cabbage patch completely barren!");
            Console.ReadLine();
            foreach (var i in Player.cabbage)
            {
                if (i != null) i.Die();
            }
            Console.ReadLine();
            Console.WriteLine("Well they need more food...");
            Console.ReadLine();
            Console.WriteLine("And they seem to be enjoying your house...");
            Console.ReadLine();
            Console.WriteLine("Half your house is gone!");
            Console.ReadLine();
            Console.WriteLine("The next night is extreamly cold, and you have no way to heat yourself.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player froze to death.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending6()//Mold kills all plant, player starves
        {
            endingsUnlocked[6] = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("The mold...");
            Console.ReadLine();
            Console.WriteLine("Is everywhere...");
            Console.ReadLine();
            Console.WriteLine("Killing every plant in its wake...");
            Console.ReadLine();
            foreach (var i in Player.allPlants)
            {
                if (i != null)
                    i.Die();
            }
            Console.ReadLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Tree Died.");
            }
            Console.ReadLine();
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Bush Died.");
            }
            Console.ReadLine();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Grass Died.");
            }
            Console.ReadLine();
            Console.WriteLine("There is not a plant left in sight.");
            Console.ReadLine();
            Console.WriteLine("The mold is spreading as far as you can see.");
            Console.ReadLine();
            Console.WriteLine("What is even the point in trying to farm for food?");
            Console.ReadLine();
            Console.WriteLine("End of week.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player Starved.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }
        static void Ending7()//Crows swarm corn field and player
        {
            endingsUnlocked[7] = true;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n\n\n\n\n\n\n\n\n\n********************************************************************************************************\n");
            Console.WriteLine("The next day you wake up, but its still dark outside.");
            Console.ReadLine();
            Console.WriteLine("Investigating further, you look outside to see the sun blocked out by black birds.");
            Console.ReadLine();
            Console.WriteLine("The murder devovers your corn field.");
            Console.ReadLine();
            Console.WriteLine("The murder then turns to swarm you...");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Player was pecked to death.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("...");
            Console.ReadLine();
            GameOver();
        }

        static void GameOver()
        {
            Console.WriteLine("\n\n\nGAMEOVER!");
            SaveGame();
            Console.WriteLine("Maybe next time try doing something else to get a different ending!");
            gameToClose = true;
        }
        static void SaveGame()
        {
            StreamWriter streamWriter = new StreamWriter(@"SaveData.txt");
            foreach (var i in endingsUnlocked)
            {
                if (i)
                {
                    streamWriter.WriteLine("1");
                }
                else
                {
                    streamWriter.WriteLine("0");
                }
            }
            streamWriter.Close();
            Console.WriteLine("STREAM: Game saved.");
        }
        static void ChooseToViewEnding()
        {
            int totalUnlocked = 0;
            foreach(var i in endingsUnlocked)
            {
                if (i) totalUnlocked++;
            }

            Console.Clear();
            Console.WriteLine($"You have {totalUnlocked}/{endingsUnlocked.Length} endings unlocked.");
            Console.WriteLine("Please pick an unlocked ending to view from the list:");
            for (int i = 0; i < endingsUnlocked.Length; i++)
            {
                if (endingsUnlocked[i]) Console.WriteLine(i + 1);
            }

            string input = Console.ReadLine().ToLower();

            if (input == "b")
            {
                return;
            }
            else if (input == "1" && endingsUnlocked[0])
            {
                Ending0();
            }
            else if (input == "2" && endingsUnlocked[1])
            {
                Ending1();
            }
            else if (input == "3" && endingsUnlocked[2])
            {
                Ending2();
            }
            else if (input == "4" && endingsUnlocked[3])
            {
                Ending3();
            }
            else if (input == "5" && endingsUnlocked[4])
            {
                Ending4();
            }
            else if (input == "6" && endingsUnlocked[5])
            {
                Ending5();
            }
            else if (input == "7" && endingsUnlocked[6])
            {
                Ending6();
            }
            else if (input == "8" && endingsUnlocked[7])
            {
                Ending7();
            }
            else
            {
                Console.WriteLine("Invalid input. Try again. To exit type \"b\"");
                ChooseToViewEnding();
            }
        }
    }
}

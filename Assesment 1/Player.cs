using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    class Player
    {
        public static Wheat[] wheat = new Wheat[50];//Array that stores all wheat plants in the farm
        public static Cabbage[] cabbage = new Cabbage[50];//Array that stores all cabbage plants in the farm
        public static Potatoes[] potatoes = new Potatoes[50];//Array that stores all potatoes plants in the farm
        public static Corn[] corn = new Corn[50];//Array that stores all corn plants in the farm

        public static int wheatProduce = 0;//how much wheat produce the player has collected and stored
        public static int cabbageProduce = 0;//how much cabbage produce the player has collected and stored
        public static int potatoesProduce = 0;//how much potatoes produce the player has collected and stored
        public static int cornProduce = 0;//how much corn produce the player has collected and stored

        public static int waterPower = 2;//how skilled the player is at watering
        public static int produceProduction = 1;//how fast plants make produce
        public static bool freeHarvesting = false;//does the player have the skill to harvest a free plant
        public static bool freeHarvestedThisDay = false;//has the player not used free harvesting today
        public static bool autoPlant = false;//is the autoPlant skills enabled
        public static bool miricleGrow = false;//does the player have the miricle grow skill

        public static Plant[] allPlants//returns an array with every plant on the farm in one array that is properly sized
        {
            get
            {
                Plant[] plants = new Plant[200];
                int count = 0;
                foreach(var i in wheat)
                {
                    if (i == null) continue;
                    plants[count] = i;
                    count++;
                }
                foreach (var i in cabbage)
                {
                    if (i == null) continue;
                    plants[count] = i;
                    count++;
                }
                foreach (var i in potatoes)
                {
                    if (i == null) continue;
                    plants[count] = i;
                    count++;
                }
                foreach (var i in corn)
                {
                    if (i == null) continue;
                    plants[count] = i;
                    count++;
                }
                Array.Resize<Plant>(ref plants, count);

                return plants;
            }
        }
        public static void PrintAllPlants()//prints all plants on the farm
        {
            PrintAllWheat();
            PrintAllCabbage();
            PrintAllPotatoes();
            PrintAllCorn();
        }
        public static void PlantUpdateAll()//calls the PlantUpdate method on all plants in the farm
        {
            Plant[] plants = allPlants;
            foreach(var i in plants)
            {
                i.PlantUpdate();
            }
        }
        
        public static void PrintAllWheat()//prints all wheat plants
        {
            foreach (var i in wheat)
            {
                if (i == null)
                {
                    continue;
                }
                
                Console.WriteLine($"\n\n--------------------WHEAT {i.pos + 1}:--------------------");
                if (i.age == 0) 
                {
                    Console.WriteLine("Hasn't sprouted,");
                    if (i.hydration == 0) Console.WriteLine("The Ground Looks Dry.");
                    else Console.WriteLine("The Ground Looks Wet.");
                }
                else
                {
                    if (i.hydration < 1 || i.age >= i.deathAge) Console.WriteLine("Looks droopy,");
                    else Console.WriteLine("Looks Perky,");
                    Console.WriteLine($"Is {i.age} weeks old now,");
                    if (i.produce > 0) Console.WriteLine("And has seed.");
                    else Console.WriteLine("And has no seed.");
                }
                

            }
        }
        public static void PrintAllCabbage()//prints all cabbage plants
        {
            foreach (var i in cabbage)
            {
                if (i == null)
                {
                    continue;
                }
                
                Console.WriteLine($"\n\n--------------------CABBAGE {i.pos + 1}:--------------------");
                if (i.age == 0)
                {
                    Console.WriteLine("Hasn't sprouted,");
                    if (i.hydration == 0) Console.WriteLine("The Ground Looks Dry.");
                    else Console.WriteLine("The Ground Looks Wet.");
                }
                else
                {
                    if (i.hydration < 1 || i.age >= i.deathAge) Console.WriteLine("Looks droopy,");
                    else Console.WriteLine("Looks Perky,");
                    Console.WriteLine($"Is {i.age} weeks old now,");
                    if (i.produce > 0) Console.WriteLine("And has a large head.");
                    else Console.WriteLine("And has small head.");
                }

            }
        }
        public static void PrintAllPotatoes()//prints all potato plants
        {
            foreach (var i in potatoes)
            {
                if (i == null)
                {
                    continue;
                }
                
                Console.WriteLine($"\n\n--------------------POTATO {i.pos + 1}:--------------------");
                if (i.age == 0)
                {
                    Console.WriteLine("Hasn't sprouted,");
                    if (i.hydration == 0) Console.WriteLine("The Ground Looks Dry.");
                    else Console.WriteLine("The Ground Looks Wet.");
                }
                else
                {
                    if (i.hydration < 1 || i.age >= i.deathAge) Console.WriteLine("Looks droopy,");
                    else Console.WriteLine("Looks Perky,");
                    Console.WriteLine($"Is {i.age} weeks old now.");
                }

            }
        }
        public static void PrintAllCorn()//prints all corn plants
        {
            foreach (var i in corn)
            {
                if (i == null)
                {
                    continue;
                }
                
                Console.WriteLine($"\n\n--------------------CORN {i.pos + 1}:--------------------");
                if (i.age == 0)
                {
                    Console.WriteLine("Hasn't sprouted,");
                    if (i.hydration == 0) Console.WriteLine("The Ground Looks Dry.");
                    else Console.WriteLine("The Ground Looks Wet.");
                }
                else
                {
                    if (i.hydration < 1 || i.age >= i.deathAge) Console.WriteLine("Looks droopy,");
                    else Console.WriteLine("Looks Perky,");
                    Console.WriteLine($"Is {i.age} weeks old now,");
                    if (i.produce > 0) Console.WriteLine("And has husks.");
                    else Console.WriteLine("And has no husks.");
                }

            }
        }
    }
}
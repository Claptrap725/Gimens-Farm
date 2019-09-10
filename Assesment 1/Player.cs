using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    class Player
    {
        public static Wheat[] wheat = new Wheat[50];
        public static Cabbage[] cabbage = new Cabbage[50];
        public static Potatoes[] potatoes = new Potatoes[50];
        public static Corn[] corn = new Corn[50];

        public static int wheatProduce = 0;
        public static int cabbageProduce = 0;
        public static int potatoesProduce = 0;
        public static int cornProduce = 0;
        public static int waterPower = 2;
        public static int produceProduction = 1;
        public static bool freeHarvesting = false;
        public static bool freeHarvestedThisDay = false;
        public static bool autoPlant = false;
        public static bool miricleGrow = false;

        public static Plant[] allPlants
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
        public static void PrintAllPlants()
        {
            PrintAllWheat();
            PrintAllCabbage();
            PrintAllPotatoes();
            PrintAllCorn();
        }
        public static void PlantUpdateAll()
        {
            Plant[] plants = allPlants;
            foreach(var i in plants)
            {
                i.PlantUpdate();
            }
        }
        
        public static void PrintAllWheat()
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
        public static void PrintAllCabbage()
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
        public static void PrintAllPotatoes()
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
        public static void PrintAllCorn()
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
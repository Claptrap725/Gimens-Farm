using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    class Plant
    {
        public int hydration;
        public int age;
        public int produce;
        public int pos;
        public int produceAge;
        public int deathAge;


        public Plant()
        {
            hydration = 1;
            age = 0;
            produce = 0;
            pos = -1;//default rogue val
        }
        public Plant(int _pos)
        {
            hydration = 1;
            age = 0;
            produce = 0;
            pos = _pos;
        }

        public void Water()
        {
            hydration += Player.waterPower;
        }

        public void PlantUpdate()
        {
            if (age == 0 && hydration == 0) { }//seed doesn't sprout
            else
            {
                age++;
                hydration--;
            }
            
            if (age >= produceAge)
            {
                produce += 1 * Player.produceProduction;
            }
            if (Player.miricleGrow)
            {
                if (age >= deathAge + 1)
                {
                    Die();
                }
            }
            else
            {
                if (age >= deathAge)
                {
                    Die();
                }
            }
            if (hydration < 0)
            {
                Die();
            }
        }

        public void ChangePos(int num)
        {
            pos += num;
        }

        public virtual void Die()
        {
            Console.WriteLine("Plant Died");
            //Delete References so GC removes this object
        }
        
    }

    class Wheat : Plant
    {
        public static int PlantsCreated = 0;
        public Wheat(int _pos)
        {
            hydration = 0;
            age = 0;
            produce = 0;
            pos = _pos;
            produceAge = 2;
            deathAge = 4;
            PlantsCreated++;
        }

        public override void Die()
        {
            Console.WriteLine("Wheat Plant Died");
            Player.wheat[pos] = null;
        }
    }

    class Cabbage : Plant
    {
        public static int PlantsCreated = 0;
        public Cabbage(int _pos)
        {
            hydration = 0;
            age = 0;
            produce = 0;
            pos = _pos;
            produceAge = 1;
            deathAge = 2;
            PlantsCreated++;
        }

        public override void Die()
        {
            Console.WriteLine("Cabbage Plant Died");
            Player.cabbage[pos] = null;
            //Player.SortCabbage();
        }
    }

    class Potatoes : Plant
    {
        public static int PlantsCreated = 0;
        public Potatoes(int _pos)
        {
            hydration = 0;
            age = 0;
            produce = 0;
            pos = _pos;
            produceAge = 3;
            deathAge = 6;
            PlantsCreated++;
        }

        public override void Die()
        {
            Console.WriteLine("Potatoes Plant Died");
            Player.potatoes[pos] = null;
            //Player.SortPotatoes();
        }
    }

    class Corn : Plant
    {
        public static int PlantsCreated = 0;
        public Corn(int _pos)
        {
            hydration = 0;
            age = 0;
            produce = 0;
            pos = _pos;
            produceAge = 5;
            deathAge = 7;
            PlantsCreated++;
        }

        public override void Die()
        {
            Console.WriteLine("Corn Plant Died");
            Player.corn[pos] = null;
            //Player.SortCorn();
        }
    }
}

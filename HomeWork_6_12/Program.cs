using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_6_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Zoopark
    {

    }

    class Aviary
    {

    }

    abstract class Animal
    {

        static string WomanSex = "Женский";
        static string MenSex = "Мужской";

        protected string Name;
        protected string Sex;
        protected string AnimalHowl;

        public static string RandomSex()
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 2;
            int sex = random.Next(minValue, maxValue);

            if (sex == 1)
            {
                return WomanSex;
            }
            else
            {
                return MenSex;
            }
        }
    }

    class Lions : Animal
    {
        public Lions()
        {
            Name = "Лев";
            Sex = RandomSex();
            AnimalHowl = "РЫЫЫЫЫЫЫЫЫЫ";
        }
    }

    class Cows : Animal
    {
        public Cows()
        {
            Name = "Корова";
            Sex = RandomSex();
            AnimalHowl = "Мууу-муууу";
        }
    }

    class Monkees : Animal
    {
        public Monkees()
        {
            Name = "Обезьяна";
            Sex = RandomSex();
            AnimalHowl = "УАА - УААА";
        }
    }

    class Dogs:Animal
    {
        public Dogs()
        {
            Name = "Собака";
            Sex = RandomSex();
            AnimalHowl = "Гав - гав";
        }

    }
}



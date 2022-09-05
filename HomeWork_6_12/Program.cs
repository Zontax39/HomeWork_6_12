using System;
using System.Collections.Generic;

namespace HomeWork_6_12
{
    internal static class UserUtils
    {
        public static int GetNumber()
        {
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    isWork = false;
                    return number;
                }
                else
                {
                    Console.WriteLine("Попробуйте ещё раз!");
                    isWork = true;
                }
            }
            return 0;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Zoopark zoopark = new Zoopark();
        }
    }

    internal class Zoopark
    {
        private List<Aviary> _aviaries;

        public Zoopark()
        {
            _aviaries = new List<Aviary>();
            _aviaries.Add(new Aviary(new Lions()));
            _aviaries.Add(new Aviary(new Cows()));
            _aviaries.Add(new Aviary(new Dogs()));
            _aviaries.Add(new Aviary(new Monkees()));
        }

        public void Start()
        {
            bool isOpen = true;
            Console.WriteLine("Добро подаловать в зоопарк!");

            while (isOpen)
            {
                Console.Write("Выбирите вальер к которому хотите подойти:");
                ShowAllAviaries();
                int userInput = UserUtils.GetNumber();



            }
        }

        private void ShowAllAviaries()
        {
            int countAviaries = 0;
            foreach (Aviary aviary in _aviaries)
            {
                countAviaries++;
                Console.WriteLine($"{countAviaries}.{aviary.Name}");
            }
        }

        private void 
    }

    internal class Aviary
    {
        private List<Animal> _animals;
        private int _countAnimals;
        private Random _random;
        private string _sound;

        public string Name { get; private set; }

        public Aviary(Animal animal)
        {
            _random = new Random();
            FillingAviary(animal);
            _countAnimals = _animals.Count;
            Name = $"Загон для {animal.Name}";
            _sound = animal.AnimalHowl;
        }

        private void FillingAviary(Animal animal)
        {
            int minAnimals = 1;
            int maxAnimals = 20;
            _animals = new List<Animal>();
            int countMount = _random.Next(minAnimals, maxAnimals);
            int numberAnimalSpecies = 5;
            int speciesAnimal = _random.Next(1, numberAnimalSpecies);

            for (int i = 0; i < countMount; i++)
            {
                if (animal is Lions)
                {
                    _animals.Add(new Lions());
                }
                else if (animal is Cows)
                {
                    _animals.Add(new Cows());
                }
                else if (animal is Monkees)
                {
                    _animals.Add(new Monkees());
                }
                else if (animal is Dogs)
                {
                    _animals.Add(new Dogs());
                }
            }
        }
    }

    internal abstract class Animal
    {
        private static string MenGender = "Мужской";
        private static string WomanGender = "Женский";

        protected string Gender { get; private set; }
        public string AnimalHowl { get; protected set; }
        public string Name { get; protected set; }

        public static string RandomSex()
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 3;
            int gender = random.Next(minValue, maxValue);

            if (gender == 1)
            {
                return WomanGender;
            }
            else
            {
                return MenGender;
            }
        }
    }

    internal class Cows : Animal
    {
        public Cows()
        {
            Name = "Корова";
            Gender = RandomSex();
            AnimalHowl = "Мууу-муууу";
        }
    }

    internal class Dogs : Animal
    {
        public Dogs()
        {
            Name = "Собака";
            Gender = RandomSex();
            AnimalHowl = "Гав - гав";
        }
    }

    internal class Lions : Animal
    {
        public Lions()
        {
            Name = "Лев";
            Gender = RandomSex();
            AnimalHowl = "РЫЫЫЫЫЫЫЫЫЫ";
        }
    }

    internal class Monkees : Animal
    {
        public Monkees()
        {
            Name = "Обезьяна";
            Gender = RandomSex();
            AnimalHowl = "УАА - УААА";
        }
    }
}
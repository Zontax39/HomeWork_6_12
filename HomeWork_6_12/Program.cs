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
            Zoo zoopark = new Zoo();
            zoopark.Start();
        }
    }

    internal class Zoo
    {
        private List<Aviary> _aviaries;

        public Zoo()
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
                Console.Clear();
                Console.WriteLine("Выбирите вальер к которому хотите подойти:");
                ShowAllAviaries();
                int userInput = UserUtils.GetNumber();

                if (userInput <= _aviaries.Count && userInput > 0)
                {
                    _aviaries[userInput - 1].ShowInfo();
                }
                else
                {
                    Console.WriteLine("Не верный вальер!");
                }
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
            Fill(animal);
            _countAnimals = _animals.Count;
            Name = $"Загон для {animal.Name}";
            _sound = animal.Howl;
        }

        public void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine($"Количество животных: {_countAnimals}");
            Console.WriteLine($"Звук: {_sound}");

            int numberOfMale = 0;
            int numberOfFemale = 0;

            foreach (Animal animal in _animals)
            {
                if (animal.Gender == "Мужской")
                {
                    numberOfMale++;
                }
                else
                {
                    numberOfFemale++;
                }
            }
            Console.WriteLine($"Особей  мужского пола в вальере: {numberOfMale}");
            Console.WriteLine($"Особей женского пола в вальере: {numberOfFemale}");
            Console.ReadKey();
        }

        private void Fill(Animal animal)
        {
            int minAnimals = 1;
            int maxAnimals = 20;
            _animals = new List<Animal>();
            int countMount = _random.Next(minAnimals, maxAnimals);

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
        public string Gender { get; protected set; }
        public string Howl { get; protected set; }
        public string Name { get; protected set; }

        public string GetGender()
        {
            List<string> genders = new List<string>();
            genders.Add("Мужской");
            genders.Add("Женский");
            Random random = new Random();
            int maxValue = 2;
            int index = random.Next(maxValue);
            return genders[index];
        }
    }

    internal class Cows : Animal
    {
        public Cows()
        {
            Name = "Коров";
            Gender = GetGender();
            Howl = "Мууу-муууу";
        }
    }

    internal class Dogs : Animal
    {
        public Dogs()
        {
            Name = "Собак";
            Gender = GetGender();
            Howl = "Гав - гав";
        }
    }

    internal class Lions : Animal
    {
        public Lions()
        {
            Name = "Львов";
            Gender = GetGender();
            Howl = "РЫЫЫЫЫЫЫЫЫЫ";
        }
    }

    internal class Monkees : Animal
    {
        public Monkees()
        {
            Name = "Обезьян";
            Gender = GetGender();
            Howl = "УАА - УААА";
        }
    }
}
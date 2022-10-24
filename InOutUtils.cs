using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Dogs
{

    internal class InOutUtils
    {

        public static DogsContainer ReadDogs(string fileName)
        {
            DogsContainer dogs = new DogsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender);

                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!dogs.Contains(dog))
                {
                    dogs.Add(dog);
                }
            }
            return dogs;
        }

        public static void PrintDogs(DogsContainer dogs, string label)                                         
        {
            Console.WriteLine(label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |",
            "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i =0;  i< dogs.Count; i ++)
            {
                Dog dog = dogs.Get(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static void PrintByBreed (DogsContainer dogs, string breed)
        {
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < dogs.Count; i++)
            {
                Dog dog = dogs.Get(i);
                    if (dogs.Get(i).Breed.ToString() == breed)
                  {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |",
                dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                    }

            }
            Console.WriteLine(new string('-', 74)); 
        }
     
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {

                Console.WriteLine(breed);
            }
        }

        public static void PrintDogsToCSVFile(string fileName, DogsContainer dogs, string breed)
        {
            string[] lines = new string[dogs.Count + 1];
            for (int i = 0; i < dogs.Count; i++)
            {
                if (dogs.Get(i).Breed == breed)
                {
                    Dog dog = dogs.Get(i);
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4}",
                    dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                }
            }
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
    }
}

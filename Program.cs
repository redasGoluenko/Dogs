using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DogsContainer container = InOutUtils.ReadDogs(@"Dogs.csv");  
            Dog dog = new Dog(666,"Juozas","Aviganis",new DateTime(2001-09-11),Gender.Female);
            container.Put(dog,3);
            container.Insert(dog,3);
            container.Remove(dog);
            container.RemoveAt(3);
            Console.WriteLine("^ 1 savarankiskas ^ \n");                    // 1 savarankiskas
            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            allDogs.Sort();
            Console.InputEncoding = Encoding.GetEncoding(1257);
            Console.OutputEncoding = Encoding.UTF8;

          
           InOutUtils.PrintDogs(container, "Registro informacija:");

          /*  Console.WriteLine("Iš viso šunų: {0}", container.Count);
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Console.WriteLine();
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}",
            oldest.Name, oldest.Breed, oldest.Age);
            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            InOutUtils.PrintByBreed(register, selectedBreed);
            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, register, selectedBreed);
            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);
            Console.WriteLine();
            Console.WriteLine("Šunys, kuriuos reikia paskiepyti:");
            DogsRegister Filtered = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogs(Filtered); */
            

        }
    }
}

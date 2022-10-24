
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
   
{
    
    class DogsRegister
    {

        private List<Dog> AllDogs;

        public DogsRegister()
        {
            AllDogs = new List<Dog>();
        }

        public DogsRegister(List<Dog> Dogs)
        {
            AllDogs = new List<Dog>();
            foreach (Dog dog in Dogs)
            {
                this.AllDogs.Add(dog);
            }
        }

        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
         
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public List<Dog> FilterByBreed(string breed)
        {
            List<Dog> Filtered = new List<Dog>();
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.Breed.Equals(breed))
                {
                    Filtered.Add(dog);
                }
            }
            return Filtered;
        }

        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }

        public Dog FindOldestDog(string breed)
        {
            List<Dog> Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }

        private Dog FindOldestDog(List<Dog> Dogs)
        {
            Dog oldest = Dogs[0];
            for(int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(oldest.BirthDate, Dogs[i].BirthDate) > 0)
                {
                    oldest = Dogs[i];
                }
            }
            return oldest;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Dog dog in this.AllDogs)
            {
                string breed = dog.Breed;
                if (!Breeds.Contains(breed))
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public Dog TakeByIndex(int index)
        {                                                                                  
            return this.AllDogs[index];                                                    
        }                                                                                  

        private Dog FindDogByID(int ID)
        {
            foreach (Dog dog in this.AllDogs)
            {
                if (dog.ID == ID)
                {
                    return dog;
                }
            }
            return null;         
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null)          
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }
            }
        }

        public DogsRegister FilterByVaccinationExpired()                       
        {
            DogsRegister Filtered = new DogsRegister();
            foreach(Dog dog in this.AllDogs)
            {              
                    if (dog.RequiresVaccination)
                    {
                        Filtered.Add(dog);
                    }               
            }
            return Filtered;
        }

        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
    }
}

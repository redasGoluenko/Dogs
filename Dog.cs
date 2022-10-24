using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class Dog
    {       
            public int ID { get; set; }
            public string Name { get; set; }
            public string Breed { get; set; }
            public DateTime BirthDate { get; set; }
            public Gender Gender { get; set; }
            public DateTime LastVaccinationDate { get; set; }

        public int CompareTo(Dog other)                                // 2 savarankiskas
        {
            if(this.Breed.CompareTo(other.Breed) == 0)
            {
                return this.Gender.CompareTo(other.Gender);            
            }
            else
            {
                return this.Breed.CompareTo(other.Breed);
            }            
        }

        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    
        public bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration)
                .CompareTo(DateTime.Now) < 0;
            }
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
 
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
            {
                this.ID = id;
                this.Name = name;
                this.Breed = breed;
                this.BirthDate = birthDate;
                this.Gender = gender;
            }

        private const int VaccinationDuration = 1;
    }
   



}


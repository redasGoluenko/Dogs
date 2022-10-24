using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class DogsContainer
    {
        private Dog[] dogs;
        private int Capacity;
        public int Count { get; private set; }

        public DogsContainer()
        {
            this.dogs = new Dog[16];
        }

        public void Add(Dog dog)
        {
            if(this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }
        public void Put(Dog dog, int index)                      //1 Savarankiskas
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            if (index > this.Count)
            {
                this.dogs[this.Count++] = dog;
            }
            else
            {
                this.dogs[index] = dog;
            }
        }

        public void Insert(Dog dog, int index)                 //1 Savarankiskas
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            if (index > this.Count)
            {
                this.dogs[this.Count++] = dog;
            }
            else
            {           
                for (int i=this.Count+1; i>index;i--)
                {
                    this.dogs[i] = this.dogs[i-1];
                }             
                this.dogs[index] = dog;
                this.Count++;
            }         
        }

        public void RemoveAt(int index)                      //1 Savarankiskas
        {         
            for(int i=index;i<this.Count;i++)
            {
                this.dogs[i] = this.dogs[i+1];
            }
            this.Count--;
        }
        public void Remove(Dog dog)                          //1 Savarankiskas
        { 
 
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i] == dog)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        this.dogs[j] = this.dogs[j + 1];
                    }
                    this.Count--;
                }
            }
           
        }

        public Dog Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dog dog)
        {
            for(int i=0;i<this.Count;i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }
        public DogsContainer(int capacity = 16)
        {
            this.dogs = new Dog[capacity];
            this.Capacity = capacity;
        }    
        private void EnsureCapacity(int minimumCapacity)
        {
            if(minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for(int i=0;i<this.Count;i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public DogsContainer(DogsContainer container) : this() //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}

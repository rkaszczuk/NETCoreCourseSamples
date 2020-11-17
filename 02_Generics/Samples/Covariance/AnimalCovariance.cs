using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Generics.Samples.Covariance
{
    public abstract class Animal
    {
        public void Feed() { }
    }
    public class Dog : Animal 
    {
        public void Bark() { }
    }
    public class Chihuahua : Dog 
    { 
    }

    public class AnimalCovariance
    {
        public void FeedAllAnimalsList(List<Animal> animals) 
        { 
            foreach(var animal in animals)
            {
                animal.Feed();
            }
        }
        public void FeedAllAnimalsIEnumerable(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.Feed();
            }
        }

        public void DogsBark(List<Dog> dogs)
        {
            foreach (var dog in dogs)
            {
                dog.Bark();
            }
        }

        public void Test()
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Chihuahua());
            FeedAllAnimalsList(animals);
            
            List<Dog> dogs = new List<Dog>();
            dogs.Add(new Dog());
            animals.Add(new Chihuahua());
            //FeedAllAnimalsList(dogs);
            FeedAllAnimalsIEnumerable(dogs);











            //ERROR
            //Lista jest invariance - jak jest List<Animal> to musi być List<Animal>
            //FeedAllAnimalsList(dogs);

            //IEnumerable jest covariance - jak jest IEnumerable<Animal>
            //to może być dowolna klasa dziedzicząca np. IEnumerable<Dog>
            FeedAllAnimalsIEnumerable(dogs);
        }
    }
}

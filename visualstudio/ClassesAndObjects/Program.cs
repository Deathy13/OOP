using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
   /* class Color
    {
        public float r, g, b;
    }
    */

    class Dog
    {
        public string name;
        public int size;
        public string breed;
        public ConsoleColor color;
        public void Walk()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + "is Walking.");
        }
        public void Eat(string food)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + "is eating " + food);
        }
        public void Shit(string food)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + "is shiting " + food);
        }
        public void sleep()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is Sleeping.");
        }
        public void Wag()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " is wagging it tail");
        }
        public void Speak(string whatHeMean)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(name + " says:" + whatHeMean);
        }
        class Program
        {
            static void Main(string[] args)
            {
                
              
                Dog dog1 = new Dog();
                dog1.name = " Lassie";
                dog1.size = 5;
                dog1.breed = " Cavoodle";
                dog1.color = ConsoleColor.Green;

                dog1.Speak("im walking when im shiting and eating");
                dog1.Walk();
                dog1.Eat("meat");
                dog1.Shit("meat");
             

                

                Dog dog2 = new Dog();
                dog2.name = " fido";
                dog2.size = 5;
                dog2.breed = " Cavoodle";
                dog2.color = ConsoleColor.DarkMagenta;

                dog2.Speak("sombody touch my spagety");
                dog2.Walk();
                dog2.Eat("spagety");
                dog2.Shit("spagety");
                Console.ReadLine();

            }
        }
    }
}
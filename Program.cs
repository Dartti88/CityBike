using System;

namespace Game_api_programmin_course
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new Exception("Must have args");
            }

            
            Console.WriteLine("Hello World!" + args[0]);

            //Zoo.Animal animal = new Zoo.Animal("Pertti");
            INameable animal = new Zoo.Animal("Pertti");
            Console.WriteLine(animal.Name);
            PrintName(animal);
        }

        static void PrintName(INameable nameable)
        {
             Console.WriteLine(nameable.Name);
        }
    }
}


namespace Zoo
{
    public class Animal : INameable
    {
        public string Name {get;set;}

        public Animal(string name)
        {
            Name = name;
        }
    }

        public class Human : INameable
    {
        public string Name {get;set;}

        public Human(string name)
        {
            Name = name;
        }
    }
}
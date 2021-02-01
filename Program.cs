using System;

namespace ZdarzeniaMojPrzyklad
{
    public delegate void EventHandler(Person sender, EventArgs e); 
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public event EventHandler Scream;

        public int LevelOfAngry;

        public void Squeeze()
        {
            /*
            LevelOfAngry++;
            if(LevelOfAngry > 5)
                System.Console.WriteLine("Krzyczy!!!");
                */
            Scream?.Invoke(this, EventArgs.Empty);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Osoba Jacek";

            /*multiemisja - dodanie kolejnego delegata*/
            person.Scream += Person_Scream; 
            person.Scream += Person_Walks;
            
            for (int i = 0; i < 10; i++)
            {
                person.Squeeze();
            }
        }

        public static void Person_Scream(Person sender, System.EventArgs e)
        {
            sender.LevelOfAngry++;

            
            System.Console.WriteLine($"{sender.Name} szturchnięta {sender.LevelOfAngry} raz");

            if(sender.LevelOfAngry > 5)
                System.Console.WriteLine("Krzyczy!!!");
        }

        public static void Person_Walks(Person sender, System.EventArgs e)
        {
            System.Console.WriteLine($"{sender.Name} idzie");
        }
    }
}

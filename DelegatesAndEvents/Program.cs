using DelegatesAndEvents.Extensions;

namespace DelegatesAndEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var persons = PersonGenerator.GeneratePersonCollection(20).ToList();

            var resultMax = persons.GetMax(x=>x.Age);

            Console.WriteLine(resultMax);

            Console.ReadKey();
        }
    }
}

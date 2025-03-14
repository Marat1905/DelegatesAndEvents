using DelegatesAndEvents.Models;

namespace DelegatesAndEvents.Extensions;
public static class PersonGenerator
{
    public static IEnumerable<Person> GeneratePersonCollection(int sizeCollection)
    {
        var collection = new List<Person>();

        for (int i = 0; i < sizeCollection; i++)
        {
            var id = Guid.NewGuid();
            var name = $"Имя {i}";
            var age = new Random().Next(1, 100);

            Person person = new(id, name, age);
            yield return person;
        }
    }
}


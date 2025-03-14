namespace DelegatesAndEvents.Models
{
    /// <summary>Сущность</summary>
    public  class Person
    {
        /// <summary>Идентификатор пользоватля</summary>
        public Guid Id { get; set; }

        /// <summary>Имя </summary>
        public string Name { get; set; }

        /// <summary>Возраст</summary>
        public int Age { get; set; }

        public Person(Guid id, string name,int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"id: {Id}; name: {Name} ; age: {Age}";
        }
    }
}

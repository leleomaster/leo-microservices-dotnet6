using RestWithAspNetUdemy_Calculadora.Model;
using System;

namespace RestWithAspNetUdemy_Calculadora.Services.Implementation
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }
            return persons;
        }

        public Person FindId(long id)
        {
            return MockPerson(Convert.ToInt32(id));
        }

        public Person Update(Person person)
        {
            return person;
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        private Person MockPerson(int value)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person name",
                LastName = "campos " + value,
                Gender = "Male",
                Address = "Rua XYZ, 1697 " + value
            };
        }
    }
}

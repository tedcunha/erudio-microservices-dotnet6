using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public PersonServiceImplementation()
        {

        }

        public Person Create(Person person)
        {
            return person;
        }

        public Person FindById(long Id)
        {
            return new Person { Id = IncrementAndGet(),
                                Name = "Ricardo",
                                Sobrenome = " da Cunha",
                                Endereco = "Rua Wenceslau Bras, 89",
                                Genero = "Masculino"};
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }


        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
            return;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                Name = $"Preson Nome {i}" ,
                Sobrenome = $"Preson Sobrenome {i}",
                Endereco = $"Person Endereco {i}",
                Genero = $"Masculino {i}" 
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}


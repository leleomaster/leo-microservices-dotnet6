using RestWithAspNetUdemy_Calculadora.Model;

namespace RestWithAspNetUdemy_Calculadora.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindId(long id);
        Person Update(Person person);
        List<Person> FindAll();
        void Delete(long id);
    }
}

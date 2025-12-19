using System.Collections.Generic;

namespace AssecorAssessment;

public interface IPersonService
{
    IEnumerable<Person> GetAll();
    Person? GetById(int id);
    IEnumerable<Person> GetByColor(string color);
    void Add(Person person);
}
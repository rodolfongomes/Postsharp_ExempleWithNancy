using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using Logging.Attributes;

[assembly: Logging(AttributePriority = 0)]

namespace Repository
{
    public class Person
    {
        private static Dictionary<int, Model.Person> people = new Dictionary<int, Model.Person>();

        public List<Model.Person> GetAll()
        {
            return people.Values.ToList();
        }

        public Model.Person Get(int id)
        {
            return people.GetValueOrDefault(id);
        }

        public void Add(Model.Person person)
        {
            people.Add(person.Id, person);
        }

        public void Edit(Model.Person person)
        {
            people.Remove(person.Id);
            people.Add(person.Id, person);
        }

        public void Delete(int id)
        {
            people.Remove(id);
        }
    }
}

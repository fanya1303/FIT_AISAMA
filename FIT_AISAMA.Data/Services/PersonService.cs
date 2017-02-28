using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services.Interfaces;

namespace FIT_AISAMA.Data.Services
{
    public class PersonService : BaseService, IPersonService
    {
        public List<Person> GetAllPersons()
        {
            return dbContext.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return dbContext.Persons.FirstOrDefault(o => o.Id == id);
        }

        public void SavePerson(Person person)
        {
            if (person != null)
            {
                if (person.Id == 0)
                {
                    dbContext.Persons.Add(person);
                }
                else
                {
                    var curPerson = dbContext.Persons.Single(o => o.Id == person.Id);
                    curPerson.FullName = person.FullName;
                    curPerson.Position = person.Position;
                }
                dbContext.SaveChanges();
            }
        }

        public void DeletePerson(Person delPerson)
        {
            dbContext.Persons.Remove(delPerson);
            dbContext.SaveChanges();
        }

        public List<Person> SearchPersons(string search)
        {
            search = search.ToLower();
            var list = dbContext.Persons.Where(o => o.FullName.ToLower().Contains(search) ||
                                                    o.Position.ToLower().Contains(search)).ToList();
            return list;

        }

        public void SetAsReponsiblePerson(int id)
        {
            var newResponsible = dbContext.Persons.FirstOrDefault(o => o.Id == id);
            if (newResponsible != null)
            {
                //На всякий случай ищет любое количество ответственных (хотя всего возможен один), чтобы избежать случайных дублей
                var curResponsible =
                    dbContext.Persons.Where(o => o.ResponsiblePerson.HasValue && o.ResponsiblePerson.Value).ToList();
                foreach (var pers in curResponsible)
                {
                    pers.ResponsiblePerson = false;
                }
                newResponsible.ResponsiblePerson = true;
                dbContext.SaveChanges();
            }
        }

    }
}

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
        public List<Person> GetAllPersons(bool withDeleted = false)
        {
            var result = dbContext.Persons.ToList();
            if (!withDeleted)
            {
                result = result.Where(o => o.IsDeleted == false).ToList();
            }
            return result;
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
                    curPerson.IsDeleted = person.IsDeleted;
                }
                dbContext.SaveChanges();
            }
        }

        public void DeletePerson(int delId)
        {
            var delPerson = dbContext.Persons.FirstOrDefault(o => o.Id == delId);
            
            if (delPerson != null)
            {
                delPerson.IsDeleted = true;
                dbContext.SaveChanges();
            }
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

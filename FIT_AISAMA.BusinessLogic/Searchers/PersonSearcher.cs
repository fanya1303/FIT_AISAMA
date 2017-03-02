using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services;
using FIT_AISAMA.Data.Services.Interfaces;

namespace FIT_AISAMA.BusinessLogic.Searchers
{
    public static class PersonSearcher
    {
        static IPersonService personService = new PersonService();

        public static List<Person> SearchPersons(PersonSearchModel searchModel)
        {
            var result = personService.GetAllPersons(searchModel.ShowDeletedPerson);

            if (!string.IsNullOrEmpty(searchModel.SearchPersonText))
            {
                var searchText = searchModel.SearchPersonText.ToLower();
                result = result.Where(o => o.FullName.ToLower().Contains(searchText) || o.Position.ToLower().Contains(searchText)).ToList();
            }
            return result;
        }
    }
}

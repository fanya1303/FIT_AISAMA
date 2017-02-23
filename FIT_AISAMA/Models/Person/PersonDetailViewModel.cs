using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Models.Person
{
    public class PersonDetailViewModel
    {
        public int Id { get; set; }
        [Display(Name = "ФИО сотрудника")]
        public string FullName { get; set; }
        [Display(Name = "Должность сотрудника")]
        public string Position { get; set; }
        [Display(Name = "Список материальных активов сотрудника")]
        public List<MaterialActive> MaterialActives { get; set; }

        public PersonDetailViewModel(Data.Entities.Person source)
        {
            Id = source.Id;
            FullName = source.FullName;
            Position = source.Position;
            MaterialActives = source.MaterialActives != null
                ? source.MaterialActives.ToList()
                : new List<MaterialActive>();
        }
    }
}
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
        public PersonDetailViewModel(){}

        public int Id { get; set; }

        [Display(Name = "ФИО сотрудника")]
        public string FullName { get; set; }

        [Display(Name = "Должность сотрудника")]
        public string Position { get; set; }

        [Display(Name = "Список материальных активов сотрудника")]
        public List<Data.Entities.MaterialActive> MaterialActives { get; set; }

        public bool? ResponsiblePerson { get; set; }

        public bool IsDeleted { get; set; }

        /// <summary>
        /// Признак возможности удаления
        /// </summary>
        public bool CanDeletePerson { get; set; }

        /// <summary>
        /// Информация о причине запрета на удаление
        /// </summary>
        public string DeleteMessage { get; set; }

        public PersonDetailViewModel(Data.Entities.Person source)
        {
            Id = source.Id;
            FullName = source.FullName;
            Position = source.Position;
            ResponsiblePerson = source.ResponsiblePerson;
            IsDeleted = source.IsDeleted;
            MaterialActives = source.MaterialActives != null
                ? source.MaterialActives.ToList()
                : new List<Data.Entities.MaterialActive>();
        }
    }
}
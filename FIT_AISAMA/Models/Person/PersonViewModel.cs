using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.Person
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [Display(Name = "ФИО сотрудника")]
        public string FullName { get; set; }
        [Display(Name = "Должность сотрудника")]
        public string Position { get; set; }

        public PersonViewModel(Data.Entities.Person source)
        {
            Id = source.Id;
            FullName = source.FullName;
            Position = source.Position;
        }
    }
}
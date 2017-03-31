using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;
using FIT_AISAMA.Models.ActiveSpecificationType;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class MaterialActiveRegisterModel
    {
        public int Id { get; set; }

        [Display(Name = "Код МЦ")]
        public string Code { get; set; }

        [Display(Name = "Тип МЦ")]
        public int ActiveTypeId { get; set; }

        [Display(Name = "Наименование МЦ")]
        [MinLength(5, ErrorMessage = "Наименование должно содержать не меньше 5 символов")]
        [Required(ErrorMessage = "Поле Наименование обязательно для заполнения")]
        public string Name { get; set; }

        [Display(Name = "Производитель")]
        [MinLength(5, ErrorMessage = "Производитель должен содержать не меньше 5 символов")]
        [Required(ErrorMessage = "Поле Производитель обязательно для заполнения")]
        public string Manufacturer { get; set; }

        [Display(Name = "Источник поступления")]
        [Required(ErrorMessage = "Поле Источник обязательно для заполнения")]
        public int IncomeSourceId { get; set; }

        [Display(Name = "Дата поступления")]
        public DateTime IncomeDate { get; set; }

        [Display(Name = "Дата начала использования")]
        public DateTime StartUseDate { get; set; }

        [Display(Name = "Дата амортизации")]
        public DateTime AmmortizateDate { get; set; }

        [Display(Name = "Дата окончания использования")]
        public DateTime StopUseDate { get; set; }

        [Display(Name = "Материально ответственный")]
        public Data.Entities.Person ResponsiblePerson { get; set; }
        public int ResponsiblePersonId { get; set; }

        [Display(Name = "Владелец")]
        public int OwnerPersonId { get; set; }

        [Display(Name = "Место использования")]
        public int LocationPlaceId { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле Цена обязательно для заполнения")]
        public int Price { get; set; }

        public StatusState Status { get; set; }
        
        public bool IsDeleted { get; set; }

        public List<ActiveSpecification> Specifications { get; set; }

        public List<SelectListItem> MaterialActiveTypeItems { get; set; }

        public List<SelectListItem> IncomeSourceItems { get; set; }

        public List<SelectListItem> PersonItems { get; set; }

        public List<SelectListItem> LocationItems { get; set; }

        public MaterialActiveRegisterModel()
        {
            Specifications = new List<ActiveSpecification>();
            MaterialActiveTypeItems = new List<SelectListItem>();
            IncomeSourceItems = new List<SelectListItem>();
            PersonItems = new List<SelectListItem>();
            LocationItems = new List<SelectListItem>();
        }

        public MaterialActiveRegisterModel(List<Data.Entities.ActiveType> activeTypes, List<Data.Entities.IncomeSource> incomeSources,
            List<Data.Entities.Person> persons, List<Data.Entities.LocationPlace> locations)
        {
            ResponsiblePerson = persons.FirstOrDefault(o => o.ResponsiblePerson.HasValue && o.ResponsiblePerson.Value);

            Specifications = new List<ActiveSpecification>();
            MaterialActiveTypeItems = new List<SelectListItem>();
            IncomeSourceItems = new List<SelectListItem>();
            PersonItems = new List<SelectListItem>();
            LocationItems = new List<SelectListItem>();

            foreach (var item in activeTypes)
            {
                MaterialActiveTypeItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.TypeCode + " (" + item.TypeName + ")"
                });
            }

            foreach (var item in incomeSources)
            {
                IncomeSourceItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Source
                });
            }

            foreach (var item in persons)
            {
                PersonItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.FullName
                });
            }

            foreach (var item in locations)
            {
                LocationItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.LocationName
                });
            }
        }

    }
}
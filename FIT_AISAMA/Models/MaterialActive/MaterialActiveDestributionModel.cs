using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class MaterialActiveDestributionModel
    {
        public MaterialActiveDestributionModel(){}

        public int Id { get; set; }

        [Display(Name = "Код МЦ")]
        public string FullCode { get; set; }

        [Display(Name = "Наименование МЦ")]
        public string Name { get; set; }

        [Display(Name = "Дата начала использования")]
        [Required(ErrorMessage = "Необходимо указать дату начала использования")]
        public DateTime? StartUseDate { get; set; }

        [Display(Name = "Владелец")]
        [Required(ErrorMessage = "Необходимо указать Владельца")]
        public int OwnerPersonId { get; set; }

        [Display(Name = "Место использования")]
        [Required(ErrorMessage = "Необходимо указать Место использования")]
        public int LocationPlaceId { get; set; }

        [Display(Name = "Статус")]
        public StatusState Status { get; set; }


        public List<SelectListItem> PersonItems { get; set; }
        public List<SelectListItem> LocationPlaceItems { get; set; }

        public MaterialActiveDestributionModel(Data.Entities.MaterialActive source, List<Data.Entities.Person> persons, 
            List<Data.Entities.LocationPlace> locationPlaces)
        {
            Id = source.Id;
            FullCode = source.ActiveType.TypeCode + source.Code;
            Name = source.Name;
            Status = source.Status;

            PersonItems = new List<SelectListItem>();
            foreach (var item in persons)
            {
                PersonItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.FullName
                });
            }

            LocationPlaceItems = new List<SelectListItem>();
            foreach (var item in locationPlaces)
            {
                LocationPlaceItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.LocationName
                });
            }
        }
    }
}
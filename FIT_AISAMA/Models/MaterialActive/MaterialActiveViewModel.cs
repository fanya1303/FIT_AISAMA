using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class MaterialActiveViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Код МЦ")]
        public string Code { get; set; }

        [Display(Name = "Тип МЦ")]
        public Data.Entities.ActiveType ActiveType { get; set; }

        [Display(Name = "Наименование МЦ")]
        public string Name { get; set; }

        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }

        [Display(Name = "Источник поступления")]
        public Data.Entities.IncomeSource IncomeSource { get; set; }

        [Display(Name = "Дата поступления")]
        public DateTime? IncomeDate { get; set; }

        [Display(Name = "Дата начала использования")]
        public DateTime? StartUseDate { get; set; }

        [Display(Name = "Дата амортизации")]
        public DateTime? AmmortizateDate { get; set; }

        [Display(Name = "Дата окончания использования")]
        public DateTime? StopUseDate { get; set; }

        [Display(Name = "Материально ответственный")]
        public Data.Entities.Person ResponsiblePerson { get; set; }

        [Display(Name = "Владелец")]
        public Data.Entities.Person OwnerPerson { get; set; }

        [Display(Name = "Место использования")]
        public Data.Entities.LocationPlace LocationPlace { get; set; }

        [Display(Name = "Стоимость")]
        public int Price { get; set; }

        [Display(Name = "Статус")]
        public StatusState Status { get; set; }

        public string StatusString
        {
            get
            {
                switch (Status)
                {
                        case StatusState.Active:
                        return "Активный";

                        case StatusState.Warehouse:
                        return "На складе";

                        case StatusState.Repair:
                        return "В ремонте";

                        case StatusState.IsUsed:
                        return "Списано";
                }
                return "";
            }
        }

        public bool IsDeleted { get; set; }


        public string FullCode
        {
            get { return ActiveType.TypeCode + Code; }
        }

        public string FullActiveTypeName
        {
            get
            {
                if (ActiveType != null)
                {
                    return ActiveType.TypeCode + " (" + ActiveType.TypeName + ") ";
                }
                return "Не указан тип МЦ";
            }
        }

        public string FullOwnerPerosnName
        {
            get
            {
                if (OwnerPerson != null)
                {
                    return OwnerPerson.FullName + " (" + OwnerPerson.Position + ")";
                }
                return "Владелец не указан";
            }
        }

        public string FullResponsiblePersonName
        {
            get
            {
                if (ResponsiblePerson != null)
                {
                    return ResponsiblePerson.FullName + " (" + ResponsiblePerson.Position + ")";
                }
                return "Материально ответственный не указан";
            }
        }

        /// <summary>
        /// Характеристики
        /// </summary>
        [Display(Name = "Характеристики")]
        public List<ActiveSpecification> Specifications { get; set; }

        public MaterialActiveViewModel(Data.Entities.MaterialActive source)
        {
            Id = source.Id;
            ActiveType = source.ActiveType;
            Code = source.Code;
            Name = source.Name;
            Manufacturer = source.Manufacturer;
            IncomeSource = source.IncomeSource;
            IncomeDate = source.IncomeDate;
            StartUseDate = source.StartUseDate;
            AmmortizateDate = source.AmmortizateDate;
            StopUseDate = source.StopUseDate;
            ResponsiblePerson = source.ResponsiblePerson;
            OwnerPerson = source.OwnerPerson;
            Price = source.Price;
            LocationPlace = source.LocationPlace;
            Status = source.Status;
            IsDeleted = source.IsDeleted;

            Specifications = source.ActiveSpecifications.ToList();
        }
    }
}
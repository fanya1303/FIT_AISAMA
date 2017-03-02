﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.ActiveSpecificationType
{
    public class ActiveSpecificationTypeModel
    {
        public ActiveSpecificationTypeModel (){}

        public int Id { get; set; }

        [Display(Name = "Тип МЦ")]
        public string ActiveTypeCode { get; set; }

        [Display(Name = "Характеристика")]
        public string TypeName { get; set; }

        public ActiveSpecificationTypeModel(Data.Entities.ActiveSpecificationType source)
        {
            Id = source.Id;
            ActiveTypeCode = source.ActiveType.TypeCode;
            TypeName = source.TypeName;
        }
    }
}
using System;
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

        [Display(Name = "Единицы измерения")]
        public string MeasureType { get; set; }

        public bool IsDeleted { get; set; }

        public string ShortMeasureType
        {
            get
            {
                string result = "";
                if (!string.IsNullOrEmpty(MeasureType))
                {
                    result =  MeasureType;
                    if (MeasureType.Length > 4)
                        result = MeasureType.Substring(0, 4) + ".";
                    
                }
                return string.IsNullOrEmpty(result)? String.Empty : "("+result.ToLower()+")";
            }
        }

        public ActiveSpecificationTypeModel(Data.Entities.ActiveSpecificationType source)
        {
            Id = source.Id;
            ActiveTypeCode = source.ActiveType.TypeCode;
            TypeName = source.TypeName;
            MeasureType = source.MeasureType;
            IsDeleted = source.IsDeleted;
        }
    }
}
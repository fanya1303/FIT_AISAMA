using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Models
{
    public class MaterialActiveSearchModel
    {
        /// <summary>
        /// Наименование или производитель
        /// </summary>
        public string NameOrManufacturer { get; set; }
        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime? IncomeDate { get; set; }

        /// <summary>
        /// Период даты поступления
        /// </summary>
        public DateTime? SinceIncomeDate { get; set; }
        public DateTime? ToIncomeDate { get; set; }

        /// <summary>
        /// Тип МЦ
        /// </summary>
        public int[] ActiveTypeIds { get; set; }

        /// <summary>
        /// Статусы
        /// </summary>
        public StatusState[] Statuses { get; set; }
        /// <summary>
        /// Показыватьудаленные
        /// </summary>
        public bool ShowDeleted { get; set; }
    }
}

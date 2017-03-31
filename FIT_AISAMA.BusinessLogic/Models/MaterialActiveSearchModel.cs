using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Показыватьудаленные
        /// </summary>
        public bool ShowDeleted { get; set; }
    }
}

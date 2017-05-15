using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class WriteOffMaterialActiveModel
    {

        [Required]
        public int Id { get; set; }

        
        [Required(ErrorMessage = "Необходимо указать дату списания")]
        public DateTime? StopUseDate { get; set; }

        /// <summary>
        /// Причина списания
        /// </summary>
        [Required(ErrorMessage = "Необходимо указать причину списания")]
        public string WriteOffReason { get; set; }

        public List<MaterialActiveViewModel> MaterialActives { get; set; }

        

        public WriteOffMaterialActiveModel(List<Data.Entities.MaterialActive>  materialActives)
        {
            BasicInitiation();

            MaterialActives.AddRange(materialActives.Select(o=> new MaterialActiveViewModel(o)));
        }

        public WriteOffMaterialActiveModel()
        {
            BasicInitiation();
        }

        void BasicInitiation()
        {
            MaterialActives = new List<MaterialActiveViewModel>();
        }
    }
}
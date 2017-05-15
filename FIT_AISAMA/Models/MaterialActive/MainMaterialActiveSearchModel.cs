using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class MainMaterialActiveSearchModel
    {
        /// <summary>
        /// Список типов МЦ
        /// </summary>
        public List<SelectListItem> MaterialActiveTypeItems { get; set; }

        /// <summary>
        /// Состояние МЦ
        /// </summary>
        public List<SelectListItem> StatusItems { get; set; }

        public MainMaterialActiveSearchModel()
        {
            InitialCollections();
        }

        public MainMaterialActiveSearchModel(List<Data.Entities.ActiveType> activeTypes, List<SelectListItem> statuses)
        {
            InitialCollections();
            foreach (var item in activeTypes)
            {
                MaterialActiveTypeItems.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.TypeCode + " (" + item.TypeName + ")"
                });
            }
            StatusItems = statuses;
        }

        private void InitialCollections()
        {
            MaterialActiveTypeItems = new List<SelectListItem>();
            StatusItems = new List<SelectListItem>();
        }
    }
}
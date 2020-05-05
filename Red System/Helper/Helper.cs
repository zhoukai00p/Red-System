using Red_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Red_System.Helper
{
    public class Helper
    {
        public static List<SelectListItem> PrendiClassi(List<Classi> classi)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();
            for(int i=0; i<classi.Count; i++)
            {
                listItems.Add(new SelectListItem
                {

                    Text = classi[i].Numero + " " + classi[i].Sezione + " " + classi[i].Indirizzo + " " + classi[i].ID,
                    Value = classi[i].ID.ToString()
                }) ;
            }
            return listItems;
        }
    }
}
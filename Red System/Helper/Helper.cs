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
        public static List<SelectListItem> PrendiClasse()
        {
            List<Classi> classi = DatabaseHelper.GetAllClasse();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for(int i=0; i<classi.Count; i++)
            {
                listItems.Add(new SelectListItem
                {

                    Text = classi[i].Numero + classi[i].Sezione.ToString() + " " + classi[i].Indirizzo,
                    Value = classi[i].ID.ToString()
                }) ;
            }
            return listItems;
        }

        public static List<SelectListItem> PrendiVerifica()
        {
            List<Verifica> verifica = DatabaseHelper.GetAllVerifica();
            List<SelectListItem> listItems = new List<SelectListItem>();
            for (int i = 0; i < verifica.Count; i++)
            {
                listItems.Add(new SelectListItem
                {

                    Text = "Nome: " + verifica[i].Nome + "Descrizione :" + verifica[i].Descrizione,
                    Value = verifica[i].ID.ToString()
                }) ;
            }
            return listItems;
        }
    }
}
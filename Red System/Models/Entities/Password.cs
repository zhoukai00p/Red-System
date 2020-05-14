using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Red_System.Models.Entities
{
    public class Password
    {
        public int ID { get; set; }
        [Required]
        public string Descrizione { get; set; }
        [Required]
        public int IDStudente { get; set; }
        [Required]
        public int IDVerifica { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Red_System.Models.Entities;

namespace Red_System.Models
{
    public class ProfiloProfessoreModel : BaseModel
    {
        public Professore Professore { get; internal set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Red_System.Models
{
    public class LoginProfessoreModel : BaseModel
    {
        public string LoginLabel { get; set; }
        public string UsernameLabel { get; set; }
        public string PasswordLabel { get; set; }
        public string SendLabel { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}
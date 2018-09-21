using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
    public class UserModel: Model
    {
        public int UserID { get; set; }
        [Required]
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Picture { get; set; }
        public string FullName => $"{FirstName} {LastName}".Trim();

        public UserModel()
        {

        }
    }
}

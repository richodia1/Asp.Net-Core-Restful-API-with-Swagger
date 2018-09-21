using LogicXPro.Domain;
using LogicXPro.Domain.BusinessModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogicXPro.Models
{
    public class User:  IdentityUser
    {
        [Required(ErrorMessage = "Email Address is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public override string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public User()
        {

        }
        public User(UserModel model)
        {
            this.Assign(model);
        }
    }
}

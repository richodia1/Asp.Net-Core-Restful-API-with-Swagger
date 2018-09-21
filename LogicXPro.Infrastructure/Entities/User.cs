using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogicXPro.Infrastructure.Entities
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
    }
}

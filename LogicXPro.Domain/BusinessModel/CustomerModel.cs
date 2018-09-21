using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
   public class CustomerModel: Model
    {
        public int UserID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Picture { get; set; }
        public virtual UserModel User { get; set; }
    }
}

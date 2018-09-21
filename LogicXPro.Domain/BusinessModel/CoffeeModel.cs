using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
   public class CoffeeModel: Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description {get; set;}
        public string CoffeeType {get; set;}
        public int PreparationTime {get; set;}

    }
}

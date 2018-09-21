using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Managers
{
   public interface ICoffeeManager
    {
        Task<CoffeeModel> CreateCoffeeAsync(CoffeeModel model);
        Task<List<CoffeeModel>> GetCoffeesAsync();
        Task<CoffeeModel> GetCoffeeByIdAsync(int id);
    }
}

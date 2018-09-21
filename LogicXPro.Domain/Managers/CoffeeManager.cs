using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.DataAccess;
using LogicXPro.Domain.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Managers
{

    public class CoffeeManager : ICoffeeManager
    {
        private readonly ICoffeeRepository _repo;
        public CoffeeManager(ICoffeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<CoffeeModel> CreateCoffeeAsync(CoffeeModel model)
        {

            if (model == null) throw new Exception("No Data Received");
            model.Validate();
            var newCoffee = await _repo.CreateCoffeeAsync(model);
            return newCoffee;
        }

        public async Task<CoffeeModel> GetCoffeeByIdAsync(int id)
        {
            return await _repo.GetCoffeeByIdAsync(id);
        }

        public async Task<List<CoffeeModel>> GetCoffeesAsync()
        {
            return await _repo.GetCoffeesAsync();
        }
    }
}

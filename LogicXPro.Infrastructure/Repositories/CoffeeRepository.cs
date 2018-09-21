using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.DataAccess;
using LogicXPro.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogicXPro.Domain;
using System.Linq;

namespace LogicXPro.Infrastructure.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private DbContext _context;

        public CoffeeRepository(DbContext context)
        {
            _context =context;
        }

        public async Task<CoffeeModel> CreateCoffeeAsync(CoffeeModel model)
        {
            var coffee = new Coffee();
            coffee.Assign(model);
            await _context.Set<Coffee>().AddAsync(coffee);
            await _context.SaveChangesAsync();
            model.Assign(coffee);
            return model;
        }

        public async Task<List<CoffeeModel>> GetCoffeesAsync()
        {
           var coffees = await _context.Set<Coffee>().ToListAsync();
           return coffees.Select(c => new CoffeeModel().Assign(c)).ToList();
        }

        public async Task<CoffeeModel> GetCoffeeByIdAsync(int id)
        {
            var CoffeeModel = new CoffeeModel();
            var coffee = await _context.Set<Coffee>().FindAsync(id);
            return CoffeeModel.Assign(coffee);
        }
    }
}

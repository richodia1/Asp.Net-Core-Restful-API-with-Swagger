using LogicXPro.Domain;
using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Repositories;
using LogicXPro.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            var user = new User();
            user.Email = model.Email;
            user.Password = model.Password;
            user.DateCreated = DateTime.Now;

            //customer.
            var customer = new Customer();
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.User = user;
            customer.Title = model.Title;
            customer.Email = model.Email;
            customer.MobileNumber = model.MobileNumber;
            customer.Picture = model.Picture;
            user.Customer = customer;

            await _context.Set<User>().AddAsync(user);
            await _context.Set<Customer>().AddAsync(customer);
            await  _context.SaveChangesAsync();

            model.Assign(user);
            return model;
        }

        public async Task<UserModel> GetUserAsync(string email, string password)
        {
            var user = await _context.Set<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
            return  new UserModel().Assign(user);
        }

        public async Task<UserModel> GetUserByEmailAsync(string email)
        {
            var user = await _context.Set<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
            return new UserModel().Assign(user);
        }

        public async Task<UserModel> GetUserByIdAsync(int userID)
        {
            var user = await _context.Set<User>().Where(u => u.UserID == userID)
                                          .Include(c => c.Customer).FirstOrDefaultAsync();
            return new UserModel
            {
                UserID = user.UserID,
                Title = user.Customer.Title,
                Email = user.Email,
                FirstName = user.Customer.FirstName,
                LastName = user.Customer.LastName,
                MobileNumber = user.Customer.MobileNumber,           
            };
        }

        public async Task<UserModel> UpdateUserAsync(UserModel model)
        {
            var user = await _context.Set<User>().Where(u => u.Email == model.Email).SingleOrDefaultAsync();
            user.Customer.FirstName = model.FirstName;
            user.Customer.LastName = model.LastName;
            user.Customer.Picture = model.Picture;

            if (_context.Entry(user).State == EntityState.Detached)
            {
                _context.Set<User>().Attach(user);
            }
            _context.Entry(user).State = EntityState.Modified;
            return new UserModel().Assign(model);
        }
    }
}

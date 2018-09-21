using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Managers;
using LogicXPro.Domain.Interfaces.Repositories;
using LogicXPro.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repo;
        private IEncryption _enc;
        public UserManager(IUserRepository repo, IEncryption enc)
        {
            _repo = repo;
            _enc = enc;
        }

        public async Task<UserModel> ValidateUserAsync(string email, string password)
        {
            //Encrypt Password and Compare Against Username
            string encPassword = _enc.Encrypt(password);
            var user =await _repo.GetUserAsync(email, encPassword);
            if (user == null) throw new Exception("Invalid Username or Password");
            return user;
        }

        public async Task<UserModel> CreateUserAsync(UserModel model)
        {
            //Check to see if User Already Exists
             var user = await _repo.GetUserByEmailAsync(model.Email);
            if (user == null)
            {
                //create the user.
                user.Assign(model);
                model.Password = _enc.Encrypt(model.Password);
                var result =  await _repo.CreateUserAsync(user);
                return new UserModel().Assign(result);
            }
            else
            {
                //Update the user.
                var result = await _repo.UpdateUserAsync(user);
                return new UserModel().Assign(result);
            }
        }

        public async Task<UserModel> GetUserByIdAsync(int userID)
        {
            var user = await _repo.GetUserByIdAsync(userID);
            return user;
        }
    }
}

using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserAsync(string email, string encPassword);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<UserModel> CreateUserAsync(UserModel model);
        Task<UserModel> UpdateUserAsync(UserModel model);
        Task<UserModel> GetUserByIdAsync(int userID);
    }
}

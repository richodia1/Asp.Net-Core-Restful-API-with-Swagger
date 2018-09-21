using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Managers
{
   public interface IUserManager
    {

        Task<UserModel> ValidateUserAsync(string email, string password);
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel> GetUserByIdAsync(int userID);

        // Task<string> Recover(string email);
        // Task ChangePassword(string username, string password, string newpassword);
        // Task<UserModel> Find(int userID);
        //  Task<UserModel> Find(string userName);
        //  Task<UserModel[]> GetUsers();
        //  Task<RoleModel[]> GetRoles(string userID)     
        //  Task<UserModel> AssignRole(UserModel model, string role);
        //  Task<bool> HasRole(UserModel user, string role);
        // Task<UserModel> UpdateUser(UserModel model);
        // Task<RoleModel> RemoveRole(UserModel user, string roleName);
        //Task<RoleModel> AddRole(UserModel user, string roleName);
    }
}

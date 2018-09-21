using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Managers;
using LogicXPro.utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogicXPro.Controllers
{

    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/account")]
    public class AccountsController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly AppSettings _appSettings;
        public AccountsController(IUserManager manager, AppSettings appSettings)
        {
            _userManager = manager;
            _appSettings = appSettings;
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public IActionResult Register(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _userManager.CreateUserAsync(model);
        //    }
        //}
    }
}
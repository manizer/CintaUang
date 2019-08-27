using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CintaUang.ViewModels.AuthViewModels;
using Service.Modules;
using Model.Domain;

namespace CintaUang.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(IndexViewModel viewModels)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModels);
            }

            User user = await userService.doLogin(new User
            {
                UserEmail = viewModels.UserEmail,
                UserPassword = viewModels.UserPassword
            });

            if (user == null)
            {
                AddNotification(ViewNotification.Make("User Tidak Ditemukan", ViewNotification.ERROR));
                return View("Index", viewModels);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Base.Helper;
using Repository.Repositories;

namespace CintaUang.Controllers.CategoryControllers
{
    public class CategoryController : Controller
    {
		public async Task<IActionResult> Index()
        {
            return View(new IndexViewModel());
        }

		public async Task<IActionResult> DTT(int draw, int start, int length)
		{
			return Json(new { });
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.DataTable.Category;
using Repository.Base.Helper;
using Repository.Repositories;
using Repository.Repositories.CategoryRepositories;

namespace CintaUang.Controllers.CategoryControllers
{
    public class CategoryController : Controller
    {
		private readonly ICategoryDataTableRepository categoryDataTableRepository;

		public CategoryController(ICategoryDataTableRepository categoryDataTableRepository)
		{
			this.categoryDataTableRepository = categoryDataTableRepository;
		}

		public IActionResult Index()
		{
			return View(new IndexViewModel());
		}

		public async Task<JsonResult> DTT(int draw, int start, int length)
		{
			CategoryDataTable categoryDataTable = await categoryDataTableRepository.GetCategoryDataTable(1, 5, "", 0, "ASC");
			return Json(categoryDataTable);
		}
	}
}
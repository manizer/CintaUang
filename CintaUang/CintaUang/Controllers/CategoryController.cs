using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.DataTable;
using Model.Domain.DB;
using Model.Domain.DB.DataTable;
using Model.DTO.DB.DataTable.Common;
using Service.Modules;

namespace CintaUang.Controllers.CategoryControllers
{
    public class CategoryController : Controller
    {
		private readonly ICategoryService categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		public async Task<IActionResult> Index()
		{
			return View(new IndexViewModel());
		}

		public async Task<IActionResult> Save(IndexViewModel indexViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View("Index", indexViewModel);
			}

			if (indexViewModel.CategoryId == 0)
			{
				// Insert
				ExecuteResult insertResult = await categoryService.Insert(new Model.Domain.DB.CategoryDB.InsertCategory
				{
					Name = indexViewModel.CategoryName
				});
			}
			else
			{
				// Update
				ExecuteResult updateResult = await categoryService.Update(new Model.Domain.DB.CategoryDB.UpdateCategory
				{
					Id = indexViewModel.CategoryId,
					Name = indexViewModel.CategoryName
				});
			}

			return RedirectToAction("Index", "Category");
		}

		public async Task<JsonResult> DTT(int draw, int start, int length)
		{
			try
			{
				AjaxDataTable<CategoryDataTableRow> categoryAjaxDataTable = await categoryService.GetCategoryDataTable(1, 5, "", 0, AjaxDataTableCriteria.SortDirection.ASC);
				return Json(categoryAjaxDataTable);
			}
			catch(Exception e)
			{
				throw e;
			}
		}
	}
}
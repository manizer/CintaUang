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
			List<Category> Categories = (await categoryService.GetCategories()).ToList();
			List<SubCategory> SubCategoriesFromFirstCategory = Categories[0].Subcategories.Value;
			return View(new IndexViewModel());
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
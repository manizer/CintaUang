using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.DataTable;
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

		public IActionResult Index()
		{
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
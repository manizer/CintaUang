using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.Domain.DB;
using Model.Domain.DB.CategoryDB;
using Model.DTO.DB;
using Repository.Base.Helper;
using Repository.Repositories.CategoryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CintaUang.ViewComponents.CategoryViewComponents
{
	public class CategoriesTable : ViewComponent
	{
		private readonly ICategoryRepository categoryRepository;

		public CategoriesTable(ICategoryRepository categoryRepository)
		{
			this.categoryRepository = categoryRepository;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<Category> Categories = (await categoryRepository.GetCategories())?.ToList();
			return View("~/Views/Category/_CategoriesTable.cshtml", new CategoriesTableViewModel
			{
				Categories = Categories
			});
		}
	}
}

using CintaUang.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
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
		private readonly UnitOfWork unitOfWork;

		public CategoriesTable(ICategoryRepository categoryRepository,
			UnitOfWork unitOfWork)
		{
			this.categoryRepository = categoryRepository;
			this.unitOfWork = unitOfWork;
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

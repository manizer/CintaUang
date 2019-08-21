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
		private readonly ICategoryRepository categoryRepository;
		private readonly UnitOfWork unitOfWork;

		public CategoryController(ICategoryRepository categoryRepository,
			UnitOfWork unitOfWork)
		{
			this.categoryRepository = categoryRepository;
			this.unitOfWork = unitOfWork;
		}

		public async Task<IActionResult> Index()
        {
			var categories = (await categoryRepository.GetCategories()).ToList();

			IndexViewModel viewModel = new IndexViewModel
			{
				Categories = categories
			};
            return View(viewModel);
        }
    }
}
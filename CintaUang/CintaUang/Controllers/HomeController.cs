using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Repository.Base.Helper;
using Repository.Repositories.CategoryRepositories;

namespace CintaUang.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly UnitOfWork unitOfWork;

		int angka = 5;

        public HomeController(ICategoryRepository categoryRepository, UnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            // With local context
            await unitOfWork.Run(async (r, context) =>
            {
                r.ConvertContextOfRepository(categoryRepository).ToUse(context);
                var categoriesWithLocalContext = await categoryRepository.GetCategories();
            });

            // Without local context
            var categories = (await categoryRepository.GetCategories()).ToList();
			var subcategories = categories[0].Subcategories.Value;
            AddNotification(ViewNotification.Make("Alert sukses terbentuk", ViewNotification.SUCCESS));
            AddNotification(ViewNotification.Make("Alert Error terbentuk", ViewNotification.ERROR));
            return View();
        }
    }
}

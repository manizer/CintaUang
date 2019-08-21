using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model.Domain;
using Repository.Base.Helper;
using Repository.Repositories;

namespace CintaUang.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly UnitOfWork unitOfWork;

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
            var categories = await categoryRepository.GetCategories();
            AddNotification(ViewNotificationType.SUCCESS, "Alert Sukses terbentuk");
            AddNotification(ViewNotificationType.ERROR, "Alert Error terbentuk");
            return View();
        }
    }
}

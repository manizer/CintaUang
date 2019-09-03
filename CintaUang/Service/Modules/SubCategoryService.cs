using Model.Domain.DB;
using Model.DTO.DB;
using Repository.Repositories.SubCategoryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules
{
	public interface ISubCategoryService
	{
		Task<IEnumerable<SubCategory>> GetSubcategoriesByCategoryID(int CategoryID);
	}

	public class SubCategoryService : ISubCategoryService
	{
		private readonly ISubCategoryRepository subCategoryRepository;

		public SubCategoryService(ISubCategoryRepository subCategoryRepository)
		{
			this.subCategoryRepository = subCategoryRepository;
		}

		public async Task<IEnumerable<SubCategory>> GetSubcategoriesByCategoryID(int CategoryID)
		{
			IEnumerable<SubCategoryDTO> subCategoryDTOs = await subCategoryRepository.GetSubCategoriesByCategoryID(CategoryID);
			return subCategoryDTOs.Select(x => new SubCategory
			{
				CategoryId = x.CategoryId,
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}

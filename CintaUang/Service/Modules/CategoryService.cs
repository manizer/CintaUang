using Model.Domain;
using Model.Domain.DataTable;
using Model.DTO.DB;
using Model.DTO.DB.DataTable;
using Repository.Repositories.CategoryRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules
{
	public interface ICategoryService
	{
		Task<IEnumerable<Category>> GetCategories();
		Task<Category> GetCategory(int CategoryId);
		Task<AjaxDataTable<CategoryDataTableRow>> GetCategoryDataTable(int Page, int Take, string Search, int OrderColIdx, string OrderDirection);
	}

	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository categoryRepository;
		private readonly ICategoryDataTableRepository categoryDataTableRepository;

		public CategoryService(ICategoryRepository categoryRepository,
			ICategoryDataTableRepository categoryDataTableRepository)
		{
			this.categoryRepository = categoryRepository;
			this.categoryDataTableRepository = categoryDataTableRepository;
		}

		public async Task<IEnumerable<Category>> GetCategories()
		{
			IEnumerable<CategoryDTO> categoryDTOs = await categoryRepository.GetCategories();
			IEnumerable<Category> categories = categoryDTOs.Select(x => new Category
			{
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName
			});
			return categories;
		}

		public async Task<Category> GetCategory(int CategoryId)
		{
			CategoryDTO categoryDTO = await categoryRepository.GetCategory(CategoryId);
			return new Category
			{
				CategoryId = categoryDTO.CategoryId,
				CategoryName = categoryDTO.CategoryName
			};
		}

		public async Task<AjaxDataTable<CategoryDataTableRow>> GetCategoryDataTable(int Page, int Take, string Search, int OrderColIdx, string OrderDirection)
		{
			AjaxDataTableDTO<CategoryDataTableRowDTO> categoryAjaxDataTableDTO = await categoryDataTableRepository.GetCategoryDataTable(Page, Take, Search, OrderColIdx, OrderDirection);
			AjaxDataTable<CategoryDataTableRow> categoryAjaxDataTable = new AjaxDataTable<CategoryDataTableRow>
			{
				Draw = categoryAjaxDataTableDTO.Draw,
				RecordsFiltered = categoryAjaxDataTableDTO.RecordsFiltered,
				RecordsTotal = categoryAjaxDataTableDTO.RecordsTotal,
				Data = categoryAjaxDataTableDTO.Data.Select(x => new CategoryDataTableRow
				{
					CategoryId = x.CategoryId,
					CategoryName = x.CategoryName
				}).ToList()
			};
			return categoryAjaxDataTable;
		}
	}
}

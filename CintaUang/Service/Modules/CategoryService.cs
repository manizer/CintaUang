using Model.Domain.DB;
using Model.Domain.DB.DataTable;
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
		private readonly IServiceProvider serviceProvider;

		public CategoryService(ICategoryRepository categoryRepository,
			ICategoryDataTableRepository categoryDataTableRepository,
			IServiceProvider serviceProvider)
		{
			this.categoryRepository = categoryRepository;
			this.categoryDataTableRepository = categoryDataTableRepository;
			this.serviceProvider = serviceProvider;
		}

		public async Task<IEnumerable<Category>> GetCategories()
		{
			return await categoryRepository.GetCategories();
		}

		public async Task<Category> GetCategory(int CategoryId)
		{
			return await categoryRepository.GetCategory(CategoryId);
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
					Id = x.Id,
					Name = x.Name
				}).ToList()
			};
			return categoryAjaxDataTable;
		}
	}
}

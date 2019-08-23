using Model.Common;
using Model.DataTable;
using Model.DataTable.Category;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.CategoryRepositories
{
	public interface ICategoryDataTableRepository : IRepository<CategoryDataTableRow>
	{
		Task<AjaxDataTable<CategoryDataTableRow>> GetCategoryDataTable(int Page, int Take, string Search, int OrderColIdx, string OrderDirection);
	}

	public class CategoryDataTableRepository : BaseRepository<CategoryDataTableRow>, ICategoryDataTableRepository
	{
		public CategoryDataTableRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

		public async Task<AjaxDataTable<CategoryDataTableRow>> GetCategoryDataTable(int Page, int Take, string Search, int OrderColIdx, string OrderDirection)
		{
			var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getallpaginated")
				.AddParam("1", Page)
				.AddParam("2", Take)
				.AddParam("3", OrderDirection)
				.AddParam("4", OrderColIdx)
				.AddParam("5", Search)
				.SP();
			IEnumerable<CategoryDataTableRow> categoryDataTableRows = await ExecSPToListAsync(sp);

			AjaxDataTable<CategoryDataTableRow> categoryAjaxDataTable = new AjaxDataTable<CategoryDataTableRow>
			{
				Data = categoryDataTableRows.ToList(),
				Draw = Page,
				RecordsFiltered = categoryDataTableRows != null && categoryDataTableRows.Count() > 0 ? Convert.ToInt32(categoryDataTableRows.First().TotalRecord) : categoryDataTableRows.Count(),
				RecordsTotal = categoryDataTableRows.Count()

			};
			return categoryAjaxDataTable;
		}
	}
}

using Model.DataTable.Category;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.CategoryRepositories
{
	public interface ICategoryDataTableRepository : IRepository<CategoryDataTableRow>
	{
		Task<IEnumerable<CategoryDataTableRow>> GetCategoriesPaginated(int Page, int Take, string Search, int OrderColIdx, string OrderDirection);
	}

	public class CategoryDataTableRowRepository : BaseRepository<CategoryDataTableRow>, ICategoryDataTableRepository
	{
		public CategoryDataTableRowRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

		public async Task<IEnumerable<CategoryDataTableRow>> GetCategoriesPaginated(int Page, int Take, string Search, int OrderColIdx, string OrderDirection)
		{
			var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getallpaginated")
				.AddParam("1", Page)
				.AddParam("2", Take)
				.AddParam("3", OrderDirection)
				.AddParam("4", OrderColIdx)
				.AddParam("5", Search)
				.SP();
			var categoriesDataTable = await ExecSPToListAsync(sp);
			return categoriesDataTable;
		}
	}
}

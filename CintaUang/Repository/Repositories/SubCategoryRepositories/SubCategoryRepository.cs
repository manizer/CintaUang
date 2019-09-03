using Model.DTO.DB;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.SubCategoryRepositories
{
	public interface ISubCategoryRepository : IRepository<SubCategoryDTO>
	{
		Task<IEnumerable<SubCategoryDTO>> GetSubCategoriesByCategoryID(int CategoryID);
	}

	public class SubCategoryRepository : BaseRepository<SubCategoryDTO>, ISubCategoryRepository
	{
		public SubCategoryRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

		public async Task<IEnumerable<SubCategoryDTO>> GetSubCategoriesByCategoryID(int CategoryID)
		{
			var sp = DbUtil.StoredProcedureBuilder
				.WithSPName("mssubcategory_getbycategoryid")
				.AddParam(CategoryID)
				.SP();
			var subcategories = await ExecSPToListAsync(sp);
			return subcategories;
		}
	}
}

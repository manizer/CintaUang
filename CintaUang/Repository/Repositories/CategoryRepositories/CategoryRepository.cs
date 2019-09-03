using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Domain.DB;
using Model.DTO.DB;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Base.Helper.StoredProcedure;
using Repository.Context;
using Repository.Repositories.SubCategoryRepositories;

namespace Repository.Repositories.CategoryRepositories
{
    public interface ICategoryRepository : IRepository<CategoryDTO>
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<IEnumerable<ExecuteResult>> InsertCategory(CategoryDTO category, int AuditedUserId);
    }

    public class CategoryRepository : BaseRepository<CategoryDTO>, ICategoryRepository
	{ 
		private readonly ISubCategoryRepository subCategoryRepository;

        public CategoryRepository(CintaUangDbContext dbContext, DbUtil dbUtil,
			ISubCategoryRepository subCategoryRepository) : base(dbContext, dbUtil)
		{
			this.subCategoryRepository = subCategoryRepository;
		}

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getall").SP();
            IEnumerable<CategoryDTO> categoryDTOs = await ExecSPToListAsync(sp);
			IEnumerable<Category> categories = categoryDTOs.Select(x => new Category
			{
				Id = x.Id,
				Name = x.Name,
				Subcategories = _SubCategories(x.Id)
			});
			return categories;
        }

		public async Task<Category> GetCategory(int id)
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getbyid").AddParam(id).SP();
            var categoryDTO = await ExecSPToSingleAsync(sp);
			return new Category
			{
				Id = categoryDTO.Id,
				Name = categoryDTO.Name,
				Subcategories = _SubCategories(id)
			};
		}

        public async Task<IEnumerable<ExecuteResult>> InsertCategory(CategoryDTO category, int AuditedUserId)
        {
            List<StoredProcedure> storedProcedures = new List<StoredProcedure>();
            storedProcedures.Add(
                DbUtil.StoredProcedureBuilder.WithSPName("mscategory_insert")
                    .AddParam(category.Name) 
                    .AddParam(AuditedUserId)
                    .SP()
            );
			IEnumerable<ExecuteResultDTO> executeResults = await ExecSPWithTransaction<ExecuteResultDTO>(storedProcedures.ToArray());
			return executeResults.Select(x => new ExecuteResult
			{
				InstanceId = x.InstanceId,
			});
        }

		#region Mapping DB
		private Lazy<List<SubCategory>> _SubCategories(int CategoryID)
		{
			return new Lazy<List<SubCategory>>(() =>
			{
				var sp = DbUtil.StoredProcedureBuilder.WithSPName("mssubcategory_getbycategoryid")
					.AddParam(CategoryID)
					.SP();
				var subcategories = subCategoryRepository.ExecSPToListAsync(sp).Result;
				return subcategories.Select(x => new SubCategory
				{
					Id = x.Id,
					Name = x.Name,
					CategoryId = x.CategoryId
				}).ToList();
			});
		}
		#endregion
	}
}
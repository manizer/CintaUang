using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.DTO.DB;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Base.Helper.StoredProcedure;
using Repository.Context;

namespace Repository.Repositories.CategoryRepositories
{
    public interface ICategoryRepository : IRepository<CategoryDTO>
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
        Task<ExecuteResultDTO> InsertCategory(CategoryDTO category, int AuditedUserId);
    }

    public class CategoryRepository : BaseRepository<CategoryDTO>, ICategoryRepository
    {
        public CategoryRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getall").SP();
            var categories = await ExecSPToListAsync(sp);
            return categories;
        }

		public async Task<CategoryDTO> GetCategory(int id)
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getbyid").AddParam(id).SP();
            var category = await ExecSPToSingleAsync(sp);
            return category;
        }

        public async Task<ExecuteResultDTO> InsertCategory(CategoryDTO category, int AuditedUserId)
        {
            List<StoredProcedure> storedProcedures = new List<StoredProcedure>();
            storedProcedures.Add(
                DbUtil.StoredProcedureBuilder.WithSPName("mscategory_insert")
                    .AddParam(category.CategoryName) 
                    .AddParam(AuditedUserId)
                    .SP()
            );
            List<ExecuteResultDTO> executeResults = (await ExecSPWithTransaction<ExecuteResultDTO>(storedProcedures.ToArray())).ToList();
            return executeResults[0];
        }
    }
}

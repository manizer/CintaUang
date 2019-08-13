using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Domain;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Base.Helper.StoredProcedure;
using Repository.Context;

namespace Repository.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<ExecuteResult> InsertCategory(Category category, int AuditedUserId);
    }

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getall").SP();
            var categories = await ExecSPToListAsync(sp);
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("mscategory_getbyid").AddParam("ID", id).SP();
            var category = await ExecSPToSingleAsync(sp);
            return category;
        }

        public async Task<ExecuteResult> InsertCategory(Category category, int AuditedUserId)
        {
            List<StoredProcedure> storedProcedures = new List<StoredProcedure>();
            storedProcedures.Add(
                DbUtil.StoredProcedureBuilder.WithSPName("mscategory_insert")
                    .AddParam("categoryname", category.CategoryName) // hardcoded for convenience
                    .AddParam("auditeduserid", AuditedUserId)
                    .SP()
            );
            List<ExecuteResult> executeResults = (await ExecSPWithTransaction<ExecuteResult>(storedProcedures.ToArray())).ToList();
            return executeResults[0];
        }
    }
}

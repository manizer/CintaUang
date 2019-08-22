using System;
using Microsoft.EntityFrameworkCore;
using Model.DataTable.Category;
using Model.Domain;

namespace Repository.Context
{
    public class CintaUangDbContext : DbContext
    {
        public CintaUangDbContext(DbContextOptions<CintaUangDbContext> options) : base(options)
        {
        }

        public DbSet<ExecuteResult> ExecuteResultDbSet { get; set; }
        public DbSet<Category> CategoryDbSet { get; set; }
		public DbSet<CategoryDataTableRow> CategoryDataTableRowDbSet { get; set; }
    }
}

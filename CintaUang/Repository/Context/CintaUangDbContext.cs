using System;
using Microsoft.EntityFrameworkCore;
using Model.DTO.DB;
using Model.DTO.DB.DataTable;

namespace Repository.Context
{
    public class CintaUangDbContext : DbContext
    {
        public CintaUangDbContext(DbContextOptions<CintaUangDbContext> options) : base(options)
        {
        }

        public DbSet<ExecuteResultDTO> ExecuteResultDbSet { get; set; }
        public DbSet<CategoryDTO> CategoryDbSet { get; set; }
        public DbSet<UserDTO> UserDbSet { get; set; }
        public DbSet<CategoryDataTableRowDTO> CategoryDataTableRowDbSet { get; set; }
    }
}

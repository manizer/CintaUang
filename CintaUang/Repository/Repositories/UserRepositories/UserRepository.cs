using Model.DTO.DB;
using Repository.Base;
using Repository.Base.Helper;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<UserDTO>
    {
        Task<UserDTO> doLogin(string userEmail, string userPassword);
    }
    public class UserRepository : BaseRepository<UserDTO>, IUserRepository
    {
        public UserRepository(CintaUangDbContext dbContext, DbUtil dbUtil) : base(dbContext, dbUtil) { }

        public async Task<UserDTO> doLogin(string userEmail, string userPassword)
        {
            var sp = DbUtil.StoredProcedureBuilder.WithSPName("msuser_doLogin")
                .AddParam(userEmail)
                .AddParam(userPassword)
                .SP();

            return await ExecSPToSingleAsync(sp);
        }
    }
}

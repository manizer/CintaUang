using Model.Domain;
using Model.DTO.DB;
using Repository.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Modules
{
    public interface IUserService
    {
        Task<User> doLogin(User user);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> doLogin(User user)
        {
            UserDTO userDTO = await userRepository.doLogin(user.UserEmail, user.UserPassword);

            return (userDTO == null) ? null : new User
            {
                UserId = userDTO.UserId,
                UserName = userDTO.UserName,
                UserEmail = userDTO.UserEmail,
                UserPassword = userDTO.UserPassword
            };
        }
    }
}

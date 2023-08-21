using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public string GetMyEmail()
        {
            return _userRepository.GetMyEmail();
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
        
        public int Count()
        {
            return _userRepository.Count();
        }

        public void Save()
        {
            _userRepository.Save();
        }
    }

}

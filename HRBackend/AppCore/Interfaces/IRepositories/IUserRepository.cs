using HRBackend.AppCore.Models.Entities;

namespace HRBackend.AppCore.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        string GetMyEmail();
        void UpdateUser(User user);
        void DeleteUser(int id);
        void AddUser(User user);
        int Count();
        void Save();
    }
}

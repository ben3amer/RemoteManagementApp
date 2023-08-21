using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Models.Entities;
using System.Security.Claims;

namespace HRBackend.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public int Count ()
        {
            return _context.Users.Count();
        }
        public string GetMyEmail()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            }
            return result;
        }

        public void DeleteUser (int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }
        public User GetUserById (int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public IEnumerable<User> GetUsers ()
        {
            return _context.Users.ToList();
        }
        public void AddUser (User user)
        {
            if (user.CIN.ToString().Length != 8)
            {
                throw new Exception("Le CIN doit être composé de 8 chiffres.");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void Save ()
        {
            _context.SaveChanges();
        }
        public void UpdateUser (User user)
        {
            if (user.CIN.ToString().Length != 8)
            {
                throw new Exception("Le CIN doit être composé de 8 chiffres.");
            }
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}

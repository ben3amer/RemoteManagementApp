using AutoMapper;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Models.DTOs;
using HRBackend.AppCore.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace HRBackend.AppWeb.Controllers
{
    [ApiController]
    [Route("api/users"), Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet, Authorize(Roles = "Gestionnaire")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}"), Authorize(Roles = "Gestionnaire,Employe")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost, Authorize(Roles = "Gestionnaire")]
        public ActionResult<User> CreateUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null.");
            }

            // Map the DTO to the entity

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PasswordSalt = passwordSalt;
            userEntity.HashedPassword = passwordHash;
            _userService.AddUser(userEntity);

            return Ok(userEntity);

        }

        [HttpPut("{userId}"), Authorize(Roles = "Gestionnaire,Employe")]
        public ActionResult UpdateUser(int userId, UserDTO userDto)
        {
            if (userId != userDto.Id)
            {
                return BadRequest();
            }

            if (userDto == null)
            {
                return BadRequest("User data is null.");
            }

            // Map the DTO to the entity
            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var userEntity = _mapper.Map<User>(userDto);
            userEntity.PasswordSalt = passwordSalt;
            userEntity.HashedPassword = passwordHash;
            _userService.UpdateUser(userEntity);

            return NoContent();
        }

        [HttpDelete("{userId}"), Authorize(Roles = "Gestionnaire")]
        public ActionResult DeleteUser(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(userId);

            return NoContent();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
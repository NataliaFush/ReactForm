using Core.Entities;
using Core.Interface;
using Core.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class UsersController : Controller
    {
        protected readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<IUser> GetAllUsers()
        {
            return _userService.GetAllUser();
        }

        [HttpGet("{id}")]
        public IUser GetUserById(Guid id) 
        {
            return _userService.GetUserById(id);
        }

        [HttpGet("email/{email}")]
        public IActionResult CheckEmail(string email)
        {
            return Json(new {isSuccess = !_userService.IsUsedEmail(email), messages ="This email is used"});
        }


        [HttpPut("Update")]
        public bool UpdateUser([FromBody] UserApiModel user)
        {
            var iUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                Password = user.Password,
                Address = user.Address != null ? new Address()
                {
                    City = user.Address.City,
                    PostalCode = user.Address.PostalCode,
                    Street = user.Address.Street
                } : null,
            };

            return _userService.UpdateUser(iUser);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserApiModel user)
        {
            if (_userService.IsUsedEmail(user.Email))
            {
                return BadRequest();
            }
            var iUser = new User()
            {
                Email = user.Email,
                Name = user.Name,
                Age = user.Age,
                Password = user.Password,
                Address = user.Address != null ? new Address()
                {
                    City = user.Address.City,
                    PostalCode = user.Address.PostalCode,
                    Street = user.Address.Street
                } : null,
            };

            return Ok(_userService.CreateUser(iUser));
        }

    }
}

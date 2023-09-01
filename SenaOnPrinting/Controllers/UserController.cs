using AutoMapper;
using BusinessCape.DTOs.User;
using BusinessCape.Services;
using DataCape.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SenaOnPrinting.Filters;
using SenaOnPrinting.Permissions;

namespace SenaOnPrinting.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/user")]
    [AuthorizationFilter(ApplicationPermission.User)]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UserController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.Index();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Show(long id)
        {
            var user = await _userService.Show(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserCreateDto userDto)
        {
            var user = _mapper.Map<UserModel>(userDto);
            user.PasswordDigest = encryptPassword(user.PasswordDigest);

            await _userService.Create(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UserUpdateDto userDto)
        {
            var user = await _userService.Show(userDto.Id);
            user.PasswordDigest = encryptPassword(user.PasswordDigest);
            _mapper.Map(userDto, user);
            await _userService.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _userService.Delete(id);
            return NoContent();
        }

        private string encryptPassword(string password)
        {
            var passwordHasher = new PasswordHasher<UserModel>();

            string password_digest = passwordHasher.HashPassword(null, password);

            return password_digest;
        }
    }
}

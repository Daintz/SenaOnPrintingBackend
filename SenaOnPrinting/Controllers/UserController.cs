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
    //[Authorize]
    [ApiController]
    [Route("api/user")]
   //[AuthorizationFilter(ApplicationPermission.User)]
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

        [HttpPut("{id}/profile")]
        public async Task<IActionResult> UpdateProfile(long id, ProfileUpdateDto userDto)
        {
            var user = await _userService.Show(userDto.Id);

            if (VerifyPassword(userDto.CurrentPassword, user)) {
                if (userDto.NewPassword.Equals(userDto.ConfirmPassword))
                {
                    user.Names = userDto.Names;
                    user.Surnames = userDto.Surnames;
                    user.DocumentNumber = userDto.DocumentNumber;
                    user.TypeDocumentId = userDto.TypeDocumentId;
                    user.Phone = userDto.Phone;
                    user.Address = userDto.Address;
                    user.PasswordDigest = encryptPassword(userDto.NewPassword);

                    await _userService.Update(user);
                    return NoContent();
                } else
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, new { message = "La nueva contraseña no coincide" });
                }
            } else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { message = "La contraseña no coincide con la actual"});
            }
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

        private bool VerifyPassword(string password, UserModel user)
        {
            var passwordHasher = new PasswordHasher<UserModel>();

            var is_valid = passwordHasher.VerifyHashedPassword(user, user.PasswordDigest, password);

            return is_valid == PasswordVerificationResult.Success;
        }
    }
}

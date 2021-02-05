using Microsoft.AspNetCore.Mvc;
using RPG_GAME.Data;
using RPG_GAME.DTO.User;
using RPG_GAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPG_GAME.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AddUserDTO addUserDTO)
        {
            ServiceResponse<int> response = await _authRepository.Register(
                new User { UserName = addUserDTO.UserName }, addUserDTO.Password
            );

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> login(UserLoginDTO userLoginDTO)
        {
            ServiceResponse<string> response = await _authRepository.Login(userLoginDTO.Username, userLoginDTO.Password);
            if (response.Success) return Ok(response); else return BadRequest(response);
        }
    }
}

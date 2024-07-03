using AutoMapper;
using JWT.Api.DTOs;
using JWT.Api.Jwt;
using JWT.Api.Models;
using JWT.Api.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JwtProvider _provider;
        public AuthController(UserManager<AppUser> userManager, IMapper mapper,JwtProvider provider)
        {
            _userManager = userManager;
            _mapper = mapper;
            _provider = provider;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register, CancellationToken cancellation)
        {
            RegisterDTOValidator validator = new RegisterDTOValidator();
            var validationResult = validator.Validate(register);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            bool userNameExist = await _userManager.Users.AnyAsync(p => p.Name == register.Name, cancellation);
            if (userNameExist)
            {
                return BadRequest(new { Message = "Istifadeci bu ad ile qeydiyyatdan kecib" });
            }

            bool userEmailExist = await _userManager.Users.AnyAsync(p => p.Email == register.Email, cancellation);
            if (userEmailExist)
            {
                return BadRequest(new { Message = "Istifadeci Email ile qeydiyyatdan kecilib" });
            }

            AppUser user = _mapper.Map<AppUser>(register);

            IdentityResult identityResult = await _userManager.CreateAsync(user, register.Password);

            if (identityResult.Succeeded)
            {
                return Ok(new { Message = "Istifadeci ugurla qeydiyyatdan kecdi" });
            }
            return BadRequest(new { Message = "Qeydiyyat zamani xeta bas verdi" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login,CancellationToken cancellation)
        {
            LoginDTOValidator validator = new LoginDTOValidator();
            var validationResult = validator.Validate(login);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == login.UsernameOrEmail ||
            p.Email == login.UsernameOrEmail,cancellation);

            if (user == null)
            {
                return BadRequest(new { Message = "Istifadeci tapilmadi" });
            }

            var result = await _userManager.CheckPasswordAsync(user, login.Password);
            if (result)
            {
                return Ok(new { Message = "Istifadeci ugurla daxil oldu" ,JWT= _provider.CreateToken()});
            }
            return BadRequest(new { Message = "Istifadeci girisi ugursuzdur" });
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web.Data.Autenticacao;

namespace web.Controller.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserToken>> Register([FromBody] UsuarioModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.Telefone
            };

            var result = await _userManager.CreateAsync(user, model.Senha);

            if (result.Succeeded)
            {
                return GenerateToken(model);
            }
            else
            {
                return BadRequest(new { message = "Senha ou nome do usuário inválidos..." });
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UsuarioModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Senha, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                return Ok(new { Token = GenerateToken(model) });
            }
            return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok(new { message = "Logout realizado com sucesso" });
        }


        private UserToken GenerateToken(UsuarioModel usuarioModel)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioModel.Email),
                new Claim(ClaimTypes.Name, usuarioModel.Nome),
                new Claim("Developer", "Otimize Sistemas"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2).ToString();
            var message = "Token JWT gerado com sucesso";

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(10),
                signingCredentials: creds
            );

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),                    
               
            };
        }
    }
}

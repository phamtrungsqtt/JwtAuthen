using JwtAuthenSchool.Interface;
using JwtAuthenSchool.Models.Authentication;
using JwtAuthenSchool.Models.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JwtAuthenSchool.Controllers.Authentication
{
    [Route("api/[controller]")] // api/authmanagement
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IOptions<JwtAuthConfig> _jwtConfigs;

        public AuthenticationController(ITokenService tokenService, IOptions<JwtAuthConfig> jwtConfigs)
        {
            _tokenService = tokenService;
            _jwtConfigs = jwtConfigs;
        }

        // <summary>
        /// Creates a Userlogin.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created Userlogin</returns>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] LoginModel loginInfo)
        {
            //// Check if the incoming request is valid
            //if (ModelState.IsValid)
            //{
            //    // check i the user with the same email exist
            //    var existingUser = await _userManager.FindByEmailAsync(user.Email);

            //    if (existingUser != null)
            //    {
            //        return BadRequest(new RegistrationResponse()
            //        {
            //            Result = false,
            //            Errors = new List<string>(){
            //                                "Email already exist"
            //                            }
            //        });
            //    }

            //    var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
            //    var isCreated = await _userManager.CreateAsync(newUser, user.Password);
            //    if (isCreated.Succeeded)
            //    {
            //        var jwtToken = GenerateJwtToken(newUser);

            //        return Ok(new RegistrationResponse()
            //        {
            //            Result = true,
            //            Token = jwtToken
            //        });
            //    }

            //    return new JsonResult(new RegistrationResponse()
            //    {
            //        Result = false,
            //        Errors = isCreated.Errors.Select(x => x.Description).ToList()
            //    }
            //            )
            //    { StatusCode = 500 };
            //}

            //return BadRequest(new RegistrationResponse()
            //{
            //    Result = false,
            //    Errors = new List<string>(){
            //                                "Invalid payload"
            //                            }
            //});
            return null;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult login([FromBody] LoginModel loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parameter is missing");
            }

            IActionResult response = Unauthorized();

            var user = _tokenService.Authenticate(loginUser);

            if (user != null)
            {
                
            }
            else
            {
                return Unauthorized();
            }


            if (user.Result == 1)
            {
                var tokenString = _tokenService.GenerateJWT(user);
                response = Ok(new
                {
                    token = tokenString,
                    expires = _jwtConfigs.Value.Expires,
                    user = user.Username
                });

            }
            else if (user.Result == 2)
            {
                response = Unauthorized();
            }
            else
            {
                // ===0
                response = NotFound();
            }

            return response;
        }
    }
}

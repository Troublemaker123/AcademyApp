using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApp.Business.Enums;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginViewModel model)
        {
            var user = _userService.Login(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect!" }); // or account is Not Active

            // check if email address is verified
            if (!user.IsEmailVerified)
                return BadRequest(new { message = "Email address is not verified." });
               
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("confirm/{userToken}")]
        public IActionResult Authenticate(Guid userToken)
        {
            // first login, after Creating an account
            var user = _userService.Authenticate(userToken); //(int)ActivationLinkType.Register

            if (user == null)
                return BadRequest(new { message = "Activation code is not valid." });

            return Ok(user.ID);
        }

        [AllowAnonymous]
        [HttpPost("forget/{username}")]
        public IActionResult ForgetPassword(string username)
        {
            var user = _userService.FindUserByUsername(username);

            if (user == null)
                return BadRequest(new { message = "Username does not exists." });

            // check again email address 
            if (!user.IsEmailVerified)
                return BadRequest(new { message = "Email address is not verified!" });

            // Send email to reset password
            _userService.SendResetLinkToEmail(user);

            return Ok(user.ID);
        }

        [AllowAnonymous]
        [HttpPost("resetpassword")]
        public IActionResult ForgetPassword([FromBody]ResetPasswordViewModel model)
        {
            var user = _userService.ForgetPassword(model.activationToken, model.newPassword);

            if (user == null)
                return BadRequest(new { message = "Token or User not valid." });

            // check again email address 
            if (!user.IsEmailVerified)
                return BadRequest(new { message = "Email address is not verified!" });

            // Notify User that his password is successfully changed
            _userService.SendChangedPassEmail(user);

            return Ok(user.ID);
        }

        [AllowAnonymous]
        [HttpPost("changepassword")]
        public IActionResult ChangePassword([FromBody]ChangePasswordViewModel model)
        {
            var user = _userService.ChangePassword(model);

            if (user == null)
                return BadRequest(new { message = "Current Password doesn't match!" });

            // check again email address 
            if (!user.IsEmailVerified)
                return BadRequest(new { message = "Email address is not verified!" });

            // Notify User that his password is successfully changed
            _userService.SendChangedPassEmail(user);

            return Ok(user.ID);
        }

        [AllowAnonymous]
        [HttpPost("resendlogin/{userId}")]
        public IActionResult ResendLoginCredentials(int userId)
        {
            try
            {
                _userService.ReSendLoginCredentials(userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error occured." });
            }
        }

        [Authorize]
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
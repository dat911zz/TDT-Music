using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Extensions;
using System.Collections.Generic;
using System.Linq;
using TDT.Core.Enums;
using TDT.Core.ModelClone;
using TDT.Core.Models;
using TDT.Core.Ultils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TDT.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly QLDVModelDataContext _db;
        public UserController(ILogger<UserController> logger, QLDVModelDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            var currentUser = HttpContext.User;

            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public string Get(int id)
        {
            return "value";
        }

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate(AuthenticateRequest model)
        //{
        //    var response = _userService.Authenticate(model);
        //    return Ok(response);
        //}

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                if (_db.Users.Any(u => u.UserName.Equals(model.UserName)))
                {
                    return new JsonResult(new { code = SignUpResult.ExistingAccount, msg = APIHelper.GetEnumDescription(SignUpResult.ExistingAccount)});
                }
                _db.Users.InsertOnSubmit(new User()
                {
                    UserName = model.UserName,
                    Address = model.Address,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = IdentityCore.Utils.SecurityHelper.HashPassword(model.Password)
                });
                _db.SubmitChanges();
                return APIHelper.GetJsonResult(SignUpResult.Ok, new Dictionary<string, object>()
                {
                    {"data", model}
                });
            }
            catch (System.Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var users = _userService.GetAll();
        //    return Ok(users);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var user = _userService.GetById(id);
        //    return Ok(user);
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, UpdateRequest model)
        //{
        //    _userService.Update(id, model);
        //    return Ok(new { message = "User updated successfully" });
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _userService.Delete(id);
        //    return Ok(new { message = "User deleted successfully" });
        //}

    }
}

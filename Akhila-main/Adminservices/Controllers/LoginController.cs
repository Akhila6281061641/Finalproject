using Adminservices.Services;
using Adminservices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminservices.Controllers
{
    [Route("api/1.0/flight/admin")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        IJwtManagerRepository iJwtMangerRepository;
        public LoginController(IJwtManagerRepository _iJwyMangerRepository)
        {

            iJwtMangerRepository = _iJwyMangerRepository;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AdminLoginViewModel adminloginViewModel)
        {
            var token = iJwtMangerRepository.Authenticate(adminloginViewModel, false);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }


        [HttpPost]
        public IActionResult Register(AdminLoginViewModel loginViewModel)
        {
            var token = iJwtMangerRepository.Authenticate(loginViewModel, true);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }

    // interface IJwtMangerRepository
    //{
    //}
}

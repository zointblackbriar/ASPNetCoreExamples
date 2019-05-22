using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorialAuthentication.DTOS;

namespace TutorialAuthentication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        //Create a private AuthenticationController object
        private readonly AuthenticationController _authentication = null;

        //Assign with setter method to private object
        public AuthenticationController(AuthenticationController authentication)
        {
            _authentication = authentication;
        }
        [HttpPost]
        public IActionResult Login(Dtos log)
        {
            var jwtToken = _authentication.Login(log);
            if(jwtToken == null)
            {
                return Unauthorized();
            }
            return Ok(jwtToken);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}


    }
}
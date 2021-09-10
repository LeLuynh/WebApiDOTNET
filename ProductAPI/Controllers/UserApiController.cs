using eProjectDemoApplication.System;
using eProjectDemoData.EF;
using eProjectDemoViewModel.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserServer _userServer;
  
        public UserApiController(IUserServer userServer, IConfiguration config)
        {
            _userServer = userServer;
            _config = config;
        }

        [HttpGet("User")]
        public async Task<List<UserViewModel>> Get()
        {
            var todo = await _userServer.GetAll();
            return todo;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request )
        {
            var resultToken =await _userServer.Authenticate(request);
            if (string.IsNullOrEmpty(resultToken.ResultObj))
            {
                return BadRequest("UserName or password error!!!!");
            }
            return Ok( resultToken );

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServer.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest("Register not success");
            }
            return Ok(new Respone { Status="Success", Messenger="User Create successfully"});

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userServer.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userServer.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update (Guid id, [FromBody] UserViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userServer.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

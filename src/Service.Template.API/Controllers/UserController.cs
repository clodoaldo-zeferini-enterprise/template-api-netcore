using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.JWT;
using Service.Template.Application.Models.Response.Errors;
using Service.Template.Application.Models.Response.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Template.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUseCaseAsync<UserRequest, UserOutResponse> _autenticarUserUseCaseAsync;

        public UserController(IUseCaseAsync<UserRequest, UserOutResponse> autenticarUserUseCaseAsync)
        {
            _autenticarUserUseCaseAsync = autenticarUserUseCaseAsync;
        }

        [HttpPost("Autenticar")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Autenticar([FromBody] UserRequest request)
        {
            try
            {
                using (UserOutResponse userOutResponse = await _autenticarUserUseCaseAsync.ExecuteAsync(request))
                {
                    return Ok(userOutResponse);
                }
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }
    }
}

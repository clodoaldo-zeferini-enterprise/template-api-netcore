using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request;
using Service.Template.Application.Models.Request.JWT;
using Service.Template.Application.Models.Response;
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
    public class TemplateController : ApiController
    {
        private readonly IUseCaseAsync<DeleteTemplateRequest, TemplateOutResponse> _deleteTemplateUseCaseAsync;
        private readonly IUseCaseAsync<GetTemplateRequest, TemplateOutResponse>    _getTemplateUseCaseAsync;
        private readonly IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse> _insertTemplateUseCaseAsync;
        private readonly IUseCaseAsync<UpdateTemplateRequest, TemplateOutResponse> _updateTemplateUseCaseAsync;

        public TemplateController(
            IUseCaseAsync<DeleteTemplateRequest, TemplateOutResponse> deleteTemplateUseCaseAsync,
            IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync,
            IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse> insertTemplateUseCaseAsync,
            IUseCaseAsync<UpdateTemplateRequest, TemplateOutResponse> updateTemplateUseCaseAsync


            )
        {
            _deleteTemplateUseCaseAsync = deleteTemplateUseCaseAsync;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _insertTemplateUseCaseAsync = insertTemplateUseCaseAsync;
            _updateTemplateUseCaseAsync = updateTemplateUseCaseAsync;
        }

        [HttpGet("Get")]
        [Authorize]
        [ProducesResponseType(typeof(TemplateOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] GetTemplateRequest request)
        {
            try
            {
                using TemplateOutResponse templateOutResponse = await _getTemplateUseCaseAsync.ExecuteAsync(request);
                return Ok(templateOutResponse);
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }

        [HttpPost("Post")]
        [Authorize]
        [ProducesResponseType(typeof(TemplateOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] InsertTemplateRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                using TemplateOutResponse templateOutResponse = await _insertTemplateUseCaseAsync.ExecuteAsync(request);
                return Ok(templateOutResponse);
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }

        [HttpPut("Put")]
        [Authorize]
        [ProducesResponseType(typeof(TemplateOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(long id, [FromBody] UpdateTemplateRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                using TemplateOutResponse templateOutResponse = await _updateTemplateUseCaseAsync.ExecuteAsync(request);
                return Ok(templateOutResponse);
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }

        [HttpDelete("Delete")]
        [Authorize]
        [ProducesResponseType(typeof(TemplateOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id, [FromBody] DeleteTemplateRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest();

                using TemplateOutResponse templateOutResponse = await _deleteTemplateUseCaseAsync.ExecuteAsync(request);
                return Ok(templateOutResponse);
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }
    }
}

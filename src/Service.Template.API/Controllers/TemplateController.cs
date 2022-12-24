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
        private readonly IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> _getTemplateUseCaseAsync;
        private readonly IUseCaseAsync<TemplateRequest, TemplateOutResponse> _pessoaUseCaseAsync;

        public TemplateController(IUseCaseAsync<TemplateBuscaRequest, TemplateOutResponse> getTemplateUseCaseAsync, IUseCaseAsync<TemplateRequest, TemplateOutResponse> pessoaUseCaseAsync)
        {
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _pessoaUseCaseAsync = pessoaUseCaseAsync;
        }

        [HttpGet("Get")]
        [Authorize]
        [ProducesResponseType(typeof(TemplateOutResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorsResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] TemplateBuscaRequest request)
        {
            try
            {
                using TemplateOutResponse pessoaOutResponse = await _getTemplateUseCaseAsync.ExecuteAsync(request);
                return Ok(pessoaOutResponse);
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
        public async Task<IActionResult> Post([FromBody] TemplateRequest request)
        {
            try
            {
                if (request == null || request.Id != 0 || request.EAction != Domain.Enum.EAction.INSERT)
                    return BadRequest();

                using TemplateOutResponse pessoaOutResponse = await _pessoaUseCaseAsync.ExecuteAsync(request);
                return Ok(pessoaOutResponse);
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
        public async Task<IActionResult> Put(long id, [FromBody] TemplateRequest request)
        {
            try
            {
                if (request == null || request.Id != id || request.EAction != Domain.Enum.EAction.UPDATE)
                    return BadRequest();

                using TemplateOutResponse pessoaOutResponse = await _pessoaUseCaseAsync.ExecuteAsync(request);
                return Ok(pessoaOutResponse);
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
        public async Task<IActionResult> Delete(long id, [FromBody] TemplateRequest request)
        {
            try
            {
                if (request == null || request.Id != id || request.EAction != Domain.Enum.EAction.DELETE)
                    return BadRequest();

                using TemplateOutResponse pessoaOutResponse = await _pessoaUseCaseAsync.ExecuteAsync(request);
                return Ok(pessoaOutResponse);
            }
            catch (Exception)
            {
                /*Pegar erro do Context*/
                return StatusCode(500, ControllerContext.ModelState);
            }
        }
    }
}

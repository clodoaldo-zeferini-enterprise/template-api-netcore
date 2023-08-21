using Microsoft.AspNetCore.Mvc;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.Template;
using Service.Template.Application.Models.Request.Template.Template;
using Service.Template.Application.Models.Response;
using Service.Template.Application.Models.Response.Errors;

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
        private readonly IConfiguration _configuration;

        public TemplateController(
            IConfiguration configuration,
            IUseCaseAsync<DeleteTemplateRequest, TemplateOutResponse> deleteTemplateUseCaseAsync,
            IUseCaseAsync<GetTemplateRequest, TemplateOutResponse> getTemplateUseCaseAsync,
            IUseCaseAsync<InsertTemplateRequest, TemplateOutResponse> insertTemplateUseCaseAsync,
            IUseCaseAsync<UpdateTemplateRequest, TemplateOutResponse> updateTemplateUseCaseAsync
            )
        {
            _configuration = configuration;
            _deleteTemplateUseCaseAsync = deleteTemplateUseCaseAsync;
            _getTemplateUseCaseAsync = getTemplateUseCaseAsync;
            _insertTemplateUseCaseAsync = insertTemplateUseCaseAsync;
            _updateTemplateUseCaseAsync = updateTemplateUseCaseAsync;
        }

        [HttpGet("Get")]
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
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateTemplateRequest request)
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
        public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteTemplateRequest request)
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

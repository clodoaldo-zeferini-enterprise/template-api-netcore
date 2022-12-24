using AutoMapper;
using Service.Template.Application.Interfaces;
using Service.Template.Application.Models.Request.JWT;
using Service.Template.Application.Models.Response.JWT;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Service.Template.Domain.Entities.JWT;

namespace Service.Template.Application.UseCases.JWT
{
    public class AutenticarUserUseCaseAsync : IUseCaseAsync<UserRequest, UserOutResponse>, IDisposable
    {
        private IConfiguration _configuration;

        public AutenticarUserUseCaseAsync(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task<bool> ValidaParamentos(UserRequest request)
        { 
            if (!string.IsNullOrEmpty(ValidaRequestUser(request))) return false;

            //configuration["Swagger:SwaggerDoc:OpenApiInfo:Title"]
            User user = new(new Guid(_configuration["Client:Id"]) , _configuration["Client:Secret"]);

            bool isValidParameters = ((request.ClientId == user.ClientId) && (request.ClientSecret == user.ClientSecret));

            return isValidParameters;
        }

        public async Task<UserOutResponse> ExecuteAsync(UserRequest request)
        {
            UserOutResponse output = new();
            var validaParametros = await ValidaParamentos(request);

            if (!validaParametros)
            {
                output.Resultado = false;
                output.Mensagem = $@"Token Não Gerado.";
                output.Data = null;

                return output;
            }

            try
            {
                var tokenValue = _configuration["Client:Secret"];

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(tokenValue);
               
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("SysUsuSessionId", Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var strToken = tokenHandler.WriteToken(token);

                UserResponse userResponse = new UserResponse(true, request.ClientId, strToken);

                output.Resultado = true;
                output.Mensagem = $@"Token Gerado.";
                output.Data = userResponse;
                return output;
            }
            catch (ArgumentException argEx)
            {
                output.Resultado = false;
                output.Mensagem = argEx.Message;
                throw new ArgumentException(argEx.Message);
            }
            catch (Exception ex)
            {
                output.Resultado = false;
                output.Mensagem = ex.Message;
                return output;
            }
        }

        private string ValidaRequestUser(UserRequest request)
        {
            try
            {
                string result = "";
                bool isClientIdValid = Guid.TryParse(request.ClientId.ToString(), out Guid guidClientId);

                bool isClientSecretValid = (!String.IsNullOrEmpty(request.ClientSecret));

                result = $@"{(isClientIdValid ? ("") : $@"O ClientId informado é Inválido!\n")}";

                result = $@"{(isClientSecretValid ? ($@"{result}") : $@"{result} O ClientSecret informado é Inválido!\n")}";

                result = $@"{((request.ClientId == new Guid(_configuration.GetSection("Client").GetSection("Id").Value)) ? ($@"{result}") : ($@"{result} O ClientId informado não está autorizado.\n"))}";

                result = $@"{((request.ClientSecret == _configuration.GetSection("Client").GetSection("Secret").Value) ? ($@"{result}") : ($@"{result} O ClientSecret informado não foi reconhecido.\n"))}";

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _configuration = null;
        }

        ~AutenticarUserUseCaseAsync()
        {
            Dispose(false);
        }
        #endregion
    }
}

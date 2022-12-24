using Service.Template.Application.Models.Response.Errors;
using System;

namespace Service.Template.Application.Models.Response
{
    public class ResponseBase : IDisposable
    {
        public bool Resultado { get; set; }
             
        public string Mensagem { get; set; }

        public object Data { get; set; }

        public string Request { get; set; }
        
        public Errors.ErrorsResponse ErrorsResponse { get; set; }

        public ResponseBase()
        {
        }

        public ResponseBase(bool resultado, string mensagem, object data)
        {
            Resultado = resultado;
            Mensagem = mensagem;
            Data = data;
        }

        public ResponseBase(bool resultado, string mensagem, object data, ErrorsResponse errorsResponse) : this(resultado, mensagem, data)
        {
            ErrorsResponse = errorsResponse;
        }

        public ResponseBase(bool resultado, string mensagem, object data, string request, ErrorsResponse errorsResponse) : this(resultado, mensagem, data)
        {
            Request = request;
            ErrorsResponse = errorsResponse;
        }





        #region IDisposable Support
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        ~ResponseBase()
        {
            Dispose(false);
        }
        #endregion
    }
}

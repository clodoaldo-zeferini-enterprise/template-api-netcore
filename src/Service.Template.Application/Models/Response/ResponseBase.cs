using Service.Template.Application.Models.Response.Errors;
using System;
using System.Collections.Generic;

namespace Service.Template.Application.Models.Response
{
    public class ResponseBase : IDisposable
    {
        public bool Resultado { get; set; }
             
        public string Mensagem { get; set; }
        public List<Mensagem> Mensagens { get; set; }
        public List<Exception> Exceptions { get; set; }
        public object Data { get; set; }

        public string Request { get; set; }
        
        public Errors.ErrorsResponse ErrorsResponse { get; set; }

        public ResponseBase()
        {
            Mensagens = new List<Mensagem>();
            Exceptions = new List<Exception>(); 
            ErrorsResponse = new Errors.ErrorsResponse();
            Resultado = false;
        } 

        public void AddMensagem(string mensagem)
        {
            Mensagens.Add(new Mensagem(mensagem));
        }

        public void AddExceptions(Exception exception)
        {
            Exceptions.Add(exception);
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

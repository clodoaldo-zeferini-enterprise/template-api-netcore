using Service.Template.Application.Models.Request.Template;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Template.Application.Models.Request
{
    public class GetTemplateRequest : RequestBase
    {
        [Range(1, 1000, ErrorMessage = "O Número da Página deverá estar entre 1 e 1000")]
        public int PageNumber { get; set; }

        [Range(1, 1000, ErrorMessage = "O Tamanho da Página deverá estar entre 1 e 100")]
        public int PageSize { get; set; }
        public Guid? Id { get; set; }

        public bool FiltraNome { get; set; }
        public string FiltroNome { get; set; }

        public bool FiltraDataInsert { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public bool FiltraStatus { get; set; }
        public int Status { get; set; }

        public GetTemplateRequest()
        {
        }

        public GetTemplateRequest(Guid id)
        {
            Id = id;
        }
    }
}

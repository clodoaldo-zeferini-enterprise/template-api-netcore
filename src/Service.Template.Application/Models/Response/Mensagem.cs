using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Template.Application.Models.Response
{
    public class Mensagem
    {
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }

        public Mensagem() { }

        public Mensagem(string texto)
        {
            Texto = texto;
            DataHora = DateTime.Now;
        }
    }
}

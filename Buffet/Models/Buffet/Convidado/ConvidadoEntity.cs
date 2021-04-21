using System;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Situacao;

namespace Buffet.Models.Buffet.Convidado
{
    public class ConvidadoEntity
    {
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public EventoEntity Evento { get; set; }
        public SituacaoConvidadoEntity Situacao { get; set; }
        public string TextoObservacao { get; set; }
        public DateTime DataInsercao { get; set; }
        public DateTime DataUltimaModificacao { get; set; }
        
        
    }
}
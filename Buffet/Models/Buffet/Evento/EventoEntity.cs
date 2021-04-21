using System;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Situacao;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime DataHoraTermino { get; set; }

        public ClienteEntity Cliente { get; set; }

        public SituacaoEventoEntity Situacao { get; set; }

        public string Local { get; set; }

        public string TextoObservacao { get; set; }

        public DateTime DataInsercao { get; set; }

        public DateTime DataUltimaModificacao { get; set; }
        public EventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
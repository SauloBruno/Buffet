using System;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.Models.Buffet.Evento
{
    public class EventoEntity
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public EventoEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Buffet.Models.Buffet.Evento;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteEntity
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public ClienteEntity(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Buffet.Models.Buffet.Cliente
{
    public class ClienteService
    {
        public List<ClienteEntity> ObterClientes()
        {
            var listaDeClientes = new List<ClienteEntity>();

            listaDeClientes.Add(new ClienteEntity
            {
                Id = 1,
                Nome = "saulo",
                DataDeNascimento = new DateTime(2001,03,13),
                Idade = 20
            });
            
            listaDeClientes.Add(new ClienteEntity
            {
                Id = 2,
                Nome = "pedro",
                DataDeNascimento = new DateTime(2002,04,14),
                Idade = 19
            });
            
            //serviço retornando entidades(Entity) de clientes
            return listaDeClientes;
        }
    }
}
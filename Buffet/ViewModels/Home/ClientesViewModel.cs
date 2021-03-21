using System.Collections.Generic;
using Buffet.Models.Buffet.Cliente;

namespace Buffet.ViewModels.Home
{
    public class ClientesViewModel
    {
        public List<Cliente> Clientes { get; set; }

        public ClientesViewModel()
        {
            Clientes = new List<Cliente>();
        }
    }
    
    public class Cliente
    {
        //classes simples com dados extremamente simples como string e inteiros 
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }

        public int Idade { get; set; }
    }
}
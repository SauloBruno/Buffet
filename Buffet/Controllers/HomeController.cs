using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buffet.Models;
using Buffet.Models.Buffet;
using Buffet.Models.Buffet.Cliente;
using Buffet.ViewModels.Home;
using Buffet.ViewModels.Shared;

namespace Buffet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Formas de passar informações do controller para a view!!!
            //primeira forma de enviar dados para a view
            //permite setar informações donamicamente como por exemplo "InformacaoQualquer" e atribuir
            //um valor como no caso "qualquer coisa"
            ViewBag.InformacaoQualquer = "Infomação qualquer";
            
            //segunda forma de envio de dados para a view
            ViewData["informacao"] = "Outra informação";
            
            //terceira forma de envio de dados para a view(viewModel)
            var viewModel = new IndexViewModel();
            viewModel.InformacaoQualquer = "Informação pela View Model";
            viewModel.Titulo = "titulo qualquer";
            viewModel.UsuarioLogado = new Usuario
            {
                Nome = "Saulo",
                Idade = 20
            };
            
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Clientes()
        {
            //trazer lista de Entidades(Entity) de clientes do service de clientes (model)
            var clienteService = new ClienteService();
            var listaDeClientes = clienteService.ObterClientes();
            
            //criar e popular viewModel
            var viewModel = new ClientesViewModel();

            foreach (ClienteEntity clienteEntity in listaDeClientes)
            {
                viewModel.Clientes.Add(new Cliente
                {
                    Nome = clienteEntity.Nome,
                    DataDeNascimento = clienteEntity.DataDeNascimento.ToShortDateString(),
                    Idade = clienteEntity.Idade
                });
            }
            
            return View(viewModel);
        }
        
        public IActionResult StatusEvento()
        {
            //Acessando um service para obter a lista de status de um dominio
            var ListaStatusEventos = new List<StatusEvento>();
            ListaStatusEventos.Add(new StatusEvento
            {
                Id = 1,
                Descricao = "Reservado"
            });
            ListaStatusEventos.Add(new StatusEvento
            {
                Id = 2,
                Descricao = "Confirmado"
            });
            ListaStatusEventos.Add(new StatusEvento
            {
                Id = 3,
                Descricao = "Realizado"
            });
            //crio a view model
            var viewModel = new StatusEventoViewModel();

            //Alimento ela com os dados dos status
            foreach (StatusEvento statusEvento in ListaStatusEventos)
            {
                viewModel.ListaDeStatus.Add(new Status
                {
                    Id = statusEvento.Id,
                    Descricao = statusEvento.Descricao
                });
            }
            
            return View(viewModel);
        }
        
        public IActionResult StatusConvidados()
        {
            //Acessando um service para obter a lista de status de um dominio
            var ListaStatusConvidados = new List<StatusConvidado>();
            ListaStatusConvidados.Add(new StatusConvidado
            {
                Id = 1,
                Descricao = "Confirmar"
            });
            ListaStatusConvidados.Add(new StatusConvidado
            {
                Id = 2,
                Descricao = "Confirmado"
            });
            
            //crio a view model
            var viewModel = new StatusConvidadosViewModel();
            
            //Alimento ela com os dados dos status
            foreach (StatusConvidado statusConvidado in ListaStatusConvidados)
            {
                viewModel.ListaDeStatus.Add(new Status
                {
                    Id = statusConvidado.Id,
                    Descricao = statusConvidado.Descricao
                });
            }
            
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}
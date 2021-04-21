using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet.Cliente;
using Buffet.RequestModels;
using Buffet.ViewModels.Acesso;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers
{
    public class AcessoController : Controller
    {
        private readonly AcessoService _acessoService;

        public AcessoController(AcessoService acessoService)
        {
            _acessoService = acessoService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RecuperarConta()
        {
            return View();
        }

        //o browser faz requisições via get quando clicamos em um link, como por exemplo a cadastrar 
        //ma tela de login, por isso ele entra aqui inicialmente
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewmdel = new CadastrarViewModel();

            viewmdel.Mensagem = (string) TempData["msg-cadastro"];
            viewmdel.ErrosCadastro = (string[])TempData["erros-cadastro"];    
            
            return View(viewmdel);
        }
        
        //Ideia: clica no formulario, ele e post, vc processa os dados e em seguida ele devolver o retorno
        //para o HTTPget
        [HttpPost]
        public async Task<RedirectToActionResult> Cadastrar(AcessoCadastrarRequestModel request)
        {
            var email = request.Email;
            var senha = request.Senha;
            var senhaConfimacao = request.SenhaConfirmacao;

            if (email == null){
                TempData["msg-cadastro"] = "Por favor informe o e-mail";

                return RedirectToAction("Cadastrar");
            }

            try
            {
                await _acessoService.RegistrarUsuario(email, senha);
                TempData["msg-cadastro"] = "Cadastro realizado com sucesso, faça o login";
                return RedirectToAction("Login");
            }
            catch (CadastrarUsuarioException exception)
            {
                var listaErros = new List<string>();
                
                foreach (var identityError in exception.Erros)
                {
                    listaErros.Add(identityError.Description);
                }
                
                TempData["erros-cadastro"] = listaErros;

                return RedirectToAction("Cadastrar");
            }
            
        }
    }
}       
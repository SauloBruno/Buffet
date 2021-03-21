using System.Collections.Generic;
using Buffet.ViewModels.Shared;

namespace Buffet.ViewModels.Home
{
    public class StatusConvidadosViewModel
    {
        public List<Status> ListaDeStatus { get; set; }

        public StatusConvidadosViewModel()
        {
            ListaDeStatus = new List<Status>();
        }
        
    }
    
}
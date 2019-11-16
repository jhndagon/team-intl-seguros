using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamSeguros.Data;
using TeamSeguros.Models;

namespace TeamSeguros.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<Client> Clients { get; set; }
        public ClientStore ClientStore { get; set; }
        public IndexModel(ClientStore clientStore)
        {
            ClientStore = clientStore;            
        }
        public void OnGetAsync(string searchString)
        {
            Clients = ClientStore.GetClients();
            if(searchString != null && searchString.Count() >=0)
            {
                var data = Clients.Where(x => x.Nombres.Contains(searchString) || x.Apellidos.Contains(searchString) || x.CiudadResidencia.Contains(searchString) || x.NumeroDocumento.Contains(searchString) );
                if(data != null)
                {
                    Clients = data.ToList();
                }
            }
        }

        public IActionResult OnPostDelete(Guid id)
        {
            ClientStore.DeleteClient(id);
            return RedirectToPage();
        }
    }
}
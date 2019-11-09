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
            Clients = ClientStore.GetClients();
        }
        public void OnGet()
        {

        }
    }
}
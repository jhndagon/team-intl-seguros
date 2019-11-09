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
    public class AddModel : PageModel
    {
        public ClientStore ClientStore { get; set; }
        [BindProperty]
        public Client Client { get; set; }
        public List<String> TipoDocumento { get; set; }
        public AddModel(ClientStore clientStore)
        {
            ClientStore = clientStore;
            TipoDocumento = ClientStore.GetTipoDocumento();
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ClientStore.AddCliente(Client);
            return RedirectToPage("./Index");
        }
    }
}
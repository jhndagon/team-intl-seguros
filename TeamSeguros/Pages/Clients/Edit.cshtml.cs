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
    public class EditModel : PageModel
    {
        public ClientStore ClientStore { get; set; }
        [BindProperty]
        public Client Client { get; set; }
        public List<String> TipoDocumento { get; set; }
        public EditModel(ClientStore clientStore)
        {
            ClientStore = clientStore;
            TipoDocumento = ClientStore.GetTipoDocumento();
        }
        public IActionResult OnGet(Guid id)
        {
            Client = ClientStore.GetClientById(id);
            if (Client == null)
            {
                return RedirectToPage("./Add");
            }
            return Page();
        }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ClientStore.UpdateClient(Client);
            return RedirectToPage("./Index");
        }
    }
}
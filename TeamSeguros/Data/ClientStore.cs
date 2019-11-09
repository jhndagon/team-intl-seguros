using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSeguros.Models;

namespace TeamSeguros.Data
{
    public class ClientStore
    {
        public SeguroContext SeguroContext { get; set; }

        public ClientStore(SeguroContext seguroContext)
        {
            SeguroContext = seguroContext;
        }

        internal void AddCliente(Client cliente)
        {
            SeguroContext.Client.Add(cliente);
            SeguroContext.SaveChanges();
        }

        internal List<Client> GetClients()
        {
            return this.SeguroContext.Client.Include(x => x.Vehiculos).ToList();
        }

        internal List<string> GetTipoDocumento()
        {
            return Enum.GetNames(typeof(TipoDocumento)).ToList();
        }

        internal Client GetClientById(Guid id)
        {
            return SeguroContext.Client.FirstOrDefault<Client>(x => x.Id == id);
        }

        internal void UpdateClient(Client client)
        {
            SeguroContext.Update(client);
            SeguroContext.SaveChanges();
        }
    }
}

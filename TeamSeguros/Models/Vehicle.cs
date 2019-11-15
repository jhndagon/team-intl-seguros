using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSeguros.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public int Anio { get; set; }
        public Guid ClientId { get; set; }
        public double ValorSeguro { get; set; }

        public Vehicle()
        {
            Id = Guid.NewGuid();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSeguros.Models
{
    enum TipoDocumento
    {
        CC,
        TI,
        CE,
    }
    public class Client
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es requerido.")]
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String TipoDocumento { get; set; }
        [Required(ErrorMessage = "El número de documento del cliente es requerido.")]
        public String NumeroDocumento { get; set; }
        [Required(ErrorMessage = "La fecha de nacimiento del cliente es requerida.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/1900", "31/12/2999")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La ciudad de residencia del cliente es requerida.")]
        public String CiudadResidencia { get; set; }
        public List<Vehicle> Vehiculos { get; set; }

        public Client()
        {
            Id = Guid.NewGuid();
        }

    }
}

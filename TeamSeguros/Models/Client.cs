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
        public String Nombres { get; set; }
        public String  Apellidos { get; set; }
        public String TipoDocumento { get; set; }
        public String NumeroDocumento { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public String CiudadResidencia { get; set; }
        public List<Vehicle> Vehiculos { get; set; }

        public Client()
        {
            Id = Guid.NewGuid();
        }

    }
}

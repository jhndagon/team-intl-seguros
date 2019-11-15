using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamSeguros.Services
{
    public class CalculateAge
    {
        public static int Calcule(DateTime fechaNacimiento)
        {
            int years = DateTime.Now.Year - fechaNacimiento.Year;

            if ((fechaNacimiento.Month > DateTime.Now.Month) || (fechaNacimiento.Month == DateTime.Now.Month && fechaNacimiento.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}

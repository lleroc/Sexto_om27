using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Provincias.Models.ViewModel
{
    public class Habitante_Completo
    {
        public int HabitanteId { get; set; }
       
        public string Nombre { get; set; }
       
        public string Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

       
        public string email { get; set; }

        public DateTime Fecha_Registro { get; set; } = DateTime.Now;

        public int Edad => DateTime.Now.Year - Fecha_Nacimiento.Year;

        public int CantonId { get; set; }
        public string Nombre_Canton { get; set; }

        public int ProvinciaId { get; set; }
        public string Nombre_Provincia { get; set; }

    }
}

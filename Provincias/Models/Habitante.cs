using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Provincias.Models
{
    public class Habitante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del habitante es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del habitante es obligatorio")]
        public string Apellido { get; set; }
        
        [Required(ErrorMessage = "La fecha de nacimiento del habitante es obligatoria")]
        //[DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "El correo del habitante es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        public string email { get; set; }

        [NotMapped]
        public DateTime Fecha_Registro { get; set; } = DateTime.Now;

        [NotMapped]
        public int Edad => DateTime.Now.Year - Fecha_Nacimiento.Year;


        //relacion con la tabla canton
        public int CantonId { get; set; }
        public Canton Canton { get; set; }


    }
}

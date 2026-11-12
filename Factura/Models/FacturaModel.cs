using System.ComponentModel.DataAnnotations;
namespace Factura.Models
{
    public class FacturaModel
    {
        public int id { get; set; }
        [Display(Name = "Cédula")]
        [Required(ErrorMessage = "La cédula es obligatoria")]
        public string cedula { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]    
        public string direccion { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string telefono { get; set; }
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string mail { get; set; }
    }
}

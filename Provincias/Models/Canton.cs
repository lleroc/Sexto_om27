using System.ComponentModel.DataAnnotations;

namespace Provincias.Models
{
    public class Canton
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del cantón es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La extensión del cantón es obligatoria")]
        public int Extension { get; set; }
        [Required(ErrorMessage = "El número de habitantes del cantón es obligatorio")]
        public int Numero_Habitantes { get; set; }

        //relacion entre la tabla Provincia y Canton

        [Required(ErrorMessage = "La provincia del cantón es obligatoria")]

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
                
    }
}

namespace Provincias.Models
{
    public class Canton
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Extension { get; set; }
        public int Numero_Habitantes { get; set; }

        //relacion entre la tabla Provincia y Canton

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

    }
}

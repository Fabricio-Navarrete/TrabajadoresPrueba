using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Models
{
    public class Distrito
    {
        [Key]
        public int Id { get; set; }
        public int IdProvincia { get; set; }
        public string NombreDistrito { get; set; }

    }
}

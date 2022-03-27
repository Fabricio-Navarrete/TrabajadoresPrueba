using System.ComponentModel.DataAnnotations;

namespace TrabajadoresPrueba.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }


        public string NombreDepartamento { get; set; }
    }
}

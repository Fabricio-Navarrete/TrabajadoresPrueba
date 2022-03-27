using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajadoresPrueba.Models
{
    public class Trabajadores
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obligatorio")]
        public string TipoDocumento { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        public string Nombres { get; set; }
        
        [Required(ErrorMessage = "Obligatorio")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name ="Nombre Departamento")]

        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nombre Provincia")]

        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Nombre Distrito")]


        public int IdDistrito { get; set; }

        [NotMapped]
        public string Departamento { get; set; }
        [NotMapped]
        public string Provincia { get; set; }
        [NotMapped]
        public string Distrito { get; set; }



    }
}

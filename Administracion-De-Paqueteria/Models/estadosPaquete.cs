using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdministracionDePaqueteria.Models
{
    public class estadosPaquete
    {
        [Key]
        public int idEstado {get; set;}

        [ForeignKey("codRastreo")]
        public long codRastreo  {get; set;}

        [Required]
        [MaxLength(20)]
        public string idPaquete {get; set;}

        [Required]
        public int numPieza {get; set;}

        public DateTime fechaHora {get; set;}

        [Required]
        [MaxLength(80)]
        public string areaServicio {get; set;}

        [Required]
        [MaxLength(80)]
        public string estadoActual {get; set;}


        public virtual Paquete Paquetes {get; set;}

    }
}
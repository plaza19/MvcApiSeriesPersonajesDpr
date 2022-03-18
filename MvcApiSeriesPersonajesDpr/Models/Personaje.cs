using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiSeriesPersonajesDpr.Models
{
    [Table("PERSONAJES")]
    public class Personaje
    {
        [Column("IDPERSONAJE")]
        [Key]
        public int IdPersonaje { get; set; }

        [Column("PERSONAJE")]
        public String NombrePersonaje { get; set; }
        [Column("IMAGEN")]
        public String Imagen { get; set; }
        [Column("IDSERIE")]
        public int IdSerie { get; set; }

    }
}

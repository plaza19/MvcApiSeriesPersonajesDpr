using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiSeriesPersonajesDpr.Models
{
    [Table("SERIES")]
    public class Serie
    {
        [Column("IDSERIE")]
        [Key]
        public int IdSerie { get; set; }
        [Column("SERIE")]
        public String NombreSerie { get; set; }
        [Column("IMAGEN")]
        public String Imagen { get; set; }
        [Column("PUNTUACION")]
        public double Puntuacion { get; set; }
        [Column("AÑO")]
        public int Año { get; set; }

    }
}


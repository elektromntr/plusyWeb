using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace plusyWeb.Models
{
    public class ZadanieBohatera
    {
        [Key]
        public int id { get; set; }

        public virtual Bohater BohaterId { get; set; }

        public virtual Zadanie ZadanieId { get; set; }

        public int Wartosc { get; set; }
    }
}
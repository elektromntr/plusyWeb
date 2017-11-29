using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace plusyWeb.Models
{
    public class Zadanie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Podaj nazwę zadania")]
        public string Nazwa { get; set; }

        public virtual ICollection<Bohater> Bohaterowie { get; set; }
    }
}
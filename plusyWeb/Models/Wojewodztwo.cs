using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace plusyWeb.Models
{
    public class Wojewodztwo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Województwo")]
        [Required(ErrorMessage ="Podaj nazwę województwa")]
        public string Nazwa { get; set; }

        virtual public ICollection<Bohater> Bohaterowie { get; set; }
    }
}
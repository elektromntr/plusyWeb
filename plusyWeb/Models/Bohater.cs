using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace plusyWeb.Models
{
    public class Bohater
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Podaj imię Bohatera zabawy")]
        [MaxLength(20)]
        [Display(Name ="Imię")]
        public string Imie { get; set; }

        public int WolewodztwoId { get; set; }

        [Required(ErrorMessage ="Podaj województwo, w którym mieszka Twój Bohater")]
        [ForeignKey("WojewodztwoId")]
        [Display(Name = "Województwo")]
        public virtual Wojewodztwo WojewodztwoBohatera { get; set; }

        [Required(ErrorMessage ="Podaj rok urodzenia Bohatera")]
        [Display(Name ="Rok urodzenia")]
        public int RokUrodzenia { get; set; }
        
    }
}
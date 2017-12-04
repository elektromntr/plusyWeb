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

        [Required(ErrorMessage = "Podaj województwo, w którym mieszka Twój Bohater")]
        [Display(Name = "Województwo")]
        public int WojewodztwoId { get; set; }
                
        [ForeignKey("WojewodztwoId")]
        public virtual Wojewodztwo WojewodztwoBohatera { get; set; }

        [Required(ErrorMessage ="Podaj rok urodzenia Bohatera")]
        [Display(Name ="Rok urodzenia")]
        public int RokUrodzenia { get; set; }

        public virtual ICollection<Zadanie> Zadania { get; set; }

        public virtual ICollection<ZadanieBohatera> ZadaniaBohatera { get; set; }

    }
}
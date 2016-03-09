using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public enum Prioritet{mali, srednji, veliki}
    public class Potraznja
    {
        public int ID { get; set; }
        [Display(Name = "Naziv")]
        [Required]
        public string Naziv { get; set; }
        [Display(Name = "Cijena")]
        [Required]
        public double Cijena { get; set; }
        [Display(Name = "Prioritet cijene")]
        [Required]
        public Prioritet PrioritetCijene { get; set; }
        [Required]
        public string Opis { get; set; }
        [Display(Name ="Rok isporuke")]
        [Required]
        public DateTime RokIsporuke { get; set; }
        [Display(Name ="Prioritet roka isporuke")]
        [Required]
        public Prioritet PrioritetRokaIsporuke { get; set; }
        public int? PonudaId { get; set; }
        [ForeignKey("PonudaId")]
        public virtual Ponuda Ponuda { get; set; }

        public int? OcjenaDobavljacaId { get; set; }
        [ForeignKey("OcjenaDobavljacaId")]
        public virtual OcjenaDobavljaca OcjenaDobavljaca { get; set; }

    }
}
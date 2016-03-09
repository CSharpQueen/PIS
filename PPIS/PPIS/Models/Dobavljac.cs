using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public class Dobavljac
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Adresa { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Email { get; set; }

        public virtual List<Ugovor> Ugovor { get; set; }
        public virtual  List<Ponuda> Ponuda{ get; set; }
    }
}
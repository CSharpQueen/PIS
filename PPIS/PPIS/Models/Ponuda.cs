using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public class Ponuda
    {

        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public double Cijena { get; set; }
        [DataType(DataType.Text)]
        [Required]
        public string Opis { get; set; }
        [Display(Name ="Rok isporuke")]
        [Required]
        public DateTime RokIsporuke { get; set; }
        public virtual List<Certifikat> certifikati { get; set; }

        public virtual int DobavljacId { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }
    }
}
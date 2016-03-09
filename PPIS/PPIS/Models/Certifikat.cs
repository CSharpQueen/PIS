using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public class Certifikat
    {    
        public int ID { get; set; }
        [Display(Name ="Naziv")]
        [DataType(DataType.Text)]
        [Required]
        public string Naziv { get; set; }
        
        public virtual int PonudaId { get; set; }

        public virtual Ponuda Ponuda { get; set; }


        public virtual int PotraznjaId { get; set; }
        public virtual Potraznja Potraznja { get; set; }


    }
}
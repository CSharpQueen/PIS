using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public enum Ocjena { niska, srednja, visoka};
    public class OcjenaDobavljaca
    {
        public int ID { get; set; }
        [Required]
        public Ocjena  Ocjena { get; set; }
     
        //public virtual Potraznja Potraznja { get; set; }

        

    }
}
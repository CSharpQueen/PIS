using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public class OcjenaDobavljaca
    {
        public int ID { get; set; }

        [Display(Name = "Cijena")]
        public int OcjenaCijene { get; set; }

        [Display(Name = "Rok isporuke")]
        public int OcjenaRokaIporuke { get; set; }

        [Display(Name = "Ispostovane stavke ugovora")]
        public int IspostovaneStavkeUgovora { get; set; }

        [Display(Name = "Kvalitet isporuke")]
        public int KvalitetIsporuke { get; set; }

        [Display(Name = "Opći utisak")]
        public int Utisak { get; set; }

        public int Ocjena { get; set; }

        public string OpisnaOcjena { get; set; }


        public virtual int DobavljacId { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }

}
}
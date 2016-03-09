using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public class Ugovor
    {
        public int ID { get; set; }
        [Display(Name = "Period vazenja od")]
        [Required] 
        public DateTime PeriodVazenjaOd { get; set; }
        [Display(Name = "Period vazenja do")]
        [Required]
        public DateTime PeriodVazenjaDo { get; set; }
        [Display(Name = "Sadrzaj ugovora")]
        [DataType(DataType.Text)]
        [Required]
        public string sadrzajUgovora { get; set; }
        [Display(Name = "Potpisnik ugovora-dobavljac")]
        [Required]
        public string potpisnikUgovoraSupplier { get; set; }
        [Display(Name = "Potpisnik ugovora- manager")]
        [Required]
        public string potpisnikUgovoraManager { get; set; }
        [Display(Name = "Dodatne stavke")]
        [DataType(DataType.Text)]
        public string dodatneStavke { get; set; }

        public virtual int DobavljacId { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }



    }
}
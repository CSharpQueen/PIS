using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPIS.Models {
    public enum StatusZahtjevaZaPromjenom {
        Poslan, Cab, Prihvacen, Odbijen
    }

    public enum ZahtjevZaPromjenomPrioritet { nizak, srednji, visok }

    public class ZahtjevZaPromjenom {

        public int ID { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [Display(Name = "Korisnik")]
        public ApplicationUser User { get; set; }
        [Display(Name = "Status zahtjeva za promjenom")]
        public StatusZahtjevaZaPromjenom StatusZahtjevaZaPromjenom { get; set; }
        [Display(Name = "Datum podnosenja")]
        public DateTime DatumPodnosenja { get; set; }
        [Display(Name = "Naziv promjene")]
        public string NazivPromjene { get; set; }
        [Display(Name = "Opis promjene")]
        [DataType(DataType.Text)]
        public string OpisPromjene { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Rok izvršenja")]
        public DateTime? RokIzvrsenja { get; set; }
        
        public string MenadzerId { get; set; }
        [ForeignKey("MenadzerId")]
        public ApplicationUser Menadzer { get; set; }
        [Display(Name = "Zahtijevani posao")]
        [DataType(DataType.Text)]
        public string ZahtijevaniPosao { get; set; }
        [Display(Name = "Plan realizacije")]
        [DataType(DataType.Text)]
        public string PlanRealizacije { get; set; }
        [Display(Name = "Datum završetka")]
        public DateTime? DatumSvrsetka { get; set; }
        [Display(Name = "Prioritet zahtjeva za promjenom")]
        public ZahtjevZaPromjenomPrioritet PrioritetZahtjeva { get; set; }

        public string CabId { get; set; }
        [ForeignKey("CabId")]
        public ApplicationUser Cab { get; set; }
        [Display(Name = "Datum prihvatanja")]
        public DateTime? DatumPrihvatanja { get; set; }
        [DataType(DataType.Text)]
        public string Komentar { get; set; }


    }
}
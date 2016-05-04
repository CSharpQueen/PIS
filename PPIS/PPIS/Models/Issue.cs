using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public enum StatusProblema
    {
        Poslan, Incident, Problem, Riješen, PonovoOtvoren
    }

    public enum PrioritetProblema
    {
        nizak, srednji,visok
    }
    public class Issue
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [Display(Name = "Korisnik")]
        public ApplicationUser User { get; set; }

         [Display(Name = "Status problema")]
        public StatusProblema StatusProblema { get; set; }

        [Display(Name = "Datum podnosenja")]
        public DateTime? DatumPodnosenja { get; set; }

        [Display(Name = "Naziv problema")]
        public string NazivProblema { get; set; }

        [Display(Name = "Opis problema")]
        [DataType(DataType.Text)]
        public string OpisProblema { get; set; }
        
  public string IncidentId { get; set; }
        [ForeignKey("IncidentId")]
        public ApplicationUser Incident { get; set; }
         [Display(Name = "Prioritet problema")]
        public PrioritetProblema PrioritetProblema { get; set; }

        public string EventId { get; set; }
        [ForeignKey("EventId")]
        public ApplicationUser Event { get; set; }
        


        public string ProblemManagerId { get; set; }
        [ForeignKey("ProblemManagerId")]
        public ApplicationUser ProblemManager { get; set; }
        [DataType(DataType.Text)]
        public string Komentar { get; set; }


    }
}
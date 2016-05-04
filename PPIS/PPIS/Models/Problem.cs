using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPIS.Models
{
    public enum StatusGlavnogProblema
    {
        UToku, Rijesen, Odbijen
    }

    public class Problem
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public StatusGlavnogProblema StatusGlavnogProblema { get; set; }
        public virtual List<Issue> Issue { get; set; }
    }
}
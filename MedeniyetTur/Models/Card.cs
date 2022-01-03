using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedeniyetTur.Models
{
    public class Card
    {
        public int Id { get; set; }
        public long CardNumber { get; set; }
        public string FullName { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Cvv { get; set; }

    }
}

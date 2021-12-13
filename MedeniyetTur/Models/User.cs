using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedeniyetTur.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Tc { get; set; }
    }
}

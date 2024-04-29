using System;
using System.Collections.Generic;

namespace GSB_BM.Models
{
    public partial class Departement
    {
        public Departement()
        {
            Medecins = new HashSet<Medecin>();
        }

        public string CodeDepartement { get; set; } = null!;
        public string NomDepartement { get; set; } = null!;
        public string? CodeRegion { get; set; }
        public string? NomRegion { get; set; }

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace GSB_BM.Models
{
    public partial class Specialite
    {
        public Specialite()
        {
            Medecins = new HashSet<Medecin>();
        }

        public int Idspecialite { get; set; }
        public string? Nomspecialite { get; set; }

        public virtual ICollection<Medecin> Medecins { get; set; }
    }
}

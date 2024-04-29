using System;
using System.Collections.Generic;

namespace GSB_BM.Models
{
    public partial class Medecin
    {
        public int Idmedecin { get; set; }
        public string Nom { get; set; } = null!;
        public string? Prenom { get; set; }
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
        public string CodeDepartement { get; set; } = null!;
        public int Idspecialite { get; set; }

        public virtual Departement? CodeDepartementNavigation { get; set; } = null!;
        public virtual Specialite? IdspecialiteNavigation { get; set; } = null!;
    }
}

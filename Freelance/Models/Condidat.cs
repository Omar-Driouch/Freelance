using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class Condidat
{
    public int Id { get; set; }

    public string? Titre { get; set; }

    public string? Gender { get; set; }

    public string? Avatar { get; set; }

    public string? Adresse { get; set; }

    public DateTime? DateNaissance { get; set; }

    public string? Tele { get; set; }

    public string? Mobilite { get; set; }

    public string? Disponibilite { get; set; }

    public string? Ville { get; set; }

    public virtual ICollection<CondidatComp> CondidatComps { get; set; } = new List<CondidatComp>();

    public virtual ICollection<ConsultaionProfil> ConsultaionProfils { get; set; } = new List<ConsultaionProfil>();

    public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

    public virtual ICollection<Formation> Formations { get; set; } = new List<Formation>();

    public virtual ICollection<Messagery> Messageries { get; set; } = new List<Messagery>();

    public virtual ICollection<Projet> Projets { get; set; } = new List<Projet>();
}

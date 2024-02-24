using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class Entreprise
{
    public int Id { get; set; }

    public string? RaisonSociale { get; set; }

    public string? Logo { get; set; }

    public DateTime? DateCreation { get; set; }

    public string? Adresse { get; set; }

    public string? Ville { get; set; }

    public virtual ICollection<ConsultaionProfil> ConsultaionProfils { get; set; } = new List<ConsultaionProfil>();

    public virtual ICollection<Messagery> Messageries { get; set; } = new List<Messagery>();
}

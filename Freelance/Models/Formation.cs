using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class Formation
{
    public int Id { get; set; }

    public string? Niveau { get; set; }

    public string? Ecole { get; set; }

    public string? Diplome { get; set; }

    public string? Description { get; set; }

    public string? Ville { get; set; }

    public DateTime? DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public int? IdCondidat { get; set; }

    public int? IdCondidatNavigationId { get; set; }

    public virtual Condidat? IdCondidatNavigation { get; set; }
}

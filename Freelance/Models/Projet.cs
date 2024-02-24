using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class Projet
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public string? Description { get; set; }

    public string? Link { get; set; }

    public int? IdCondidat { get; set; }

    public int? IdCondidatNavigationId { get; set; }

    public virtual Condidat? IdCondidatNavigation { get; set; }
}

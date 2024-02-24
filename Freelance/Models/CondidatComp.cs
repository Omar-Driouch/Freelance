using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class CondidatComp
{
    public int Id { get; set; }

    public string? Niveau { get; set; }

    public int? IdComp { get; set; }

    public int? IdCond { get; set; }

    public int? IdCompNavigationId { get; set; }

    public int? IdCondNavigationId { get; set; }

    public int? CompetenceId { get; set; }

    public virtual Competence? Competence { get; set; }

    public virtual ComptenceDmExpertise? IdCompNavigation { get; set; }

    public virtual Condidat? IdCondNavigation { get; set; }
}

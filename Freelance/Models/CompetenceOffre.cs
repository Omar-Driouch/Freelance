using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class CompetenceOffre
{
    public int Id { get; set; }

    public int? IdCompetence { get; set; }

    public int? IdOffre { get; set; }

    public int? IdCompetenceNavigationId { get; set; }

    public int? IdOffreNavigationId { get; set; }

    public virtual Competence? IdCompetenceNavigation { get; set; }

    public virtual Offre? IdOffreNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class ComptenceDmExpertise
{
    public int Id { get; set; }

    public int? IdCompetence { get; set; }

    public int? IdDmexpertise { get; set; }

    public int? IdCompetenceNavigationId { get; set; }

    public int? IdDmexpertiseNavigationId { get; set; }

    public virtual ICollection<CondidatComp> CondidatComps { get; set; } = new List<CondidatComp>();

    public virtual Competence? IdCompetenceNavigation { get; set; }

    public virtual DomaineExpertise? IdDmexpertiseNavigation { get; set; }
}

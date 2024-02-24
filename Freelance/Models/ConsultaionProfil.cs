using System;
using System.Collections.Generic;

namespace Freelance.Models;

public partial class ConsultaionProfil
{
    public int Id { get; set; }

    public int? IdCondidat { get; set; }

    public int? IdEntreprise { get; set; }

    public DateTime? DateConsultation { get; set; }

    public int? IdCondidatNavigationId { get; set; }

    public int? IdEntrepriseNavigationId { get; set; }

    public virtual Condidat? IdCondidatNavigation { get; set; }

    public virtual Entreprise? IdEntrepriseNavigation { get; set; }
}

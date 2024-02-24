namespace Freelance.DTOs.Experiences
{
    public class ExperiencesInputModel
    {
        

        public string? Titre { get; set; }

        public string? Local { get; set; }

        public string? Description { get; set; }

        public string? Ville { get; set; }

        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        public int? IdCondidat { get; set; }

        public int? IdCondidatNavigationId { get; set; }
    }
}

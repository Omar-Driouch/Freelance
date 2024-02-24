using Freelance.DB;
using Freelance.DTOs.Experiences;
using Freelance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Freelance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperiencesController : ControllerBase
    {
        private readonly FreelanceContext _Experiences;
        public ExperiencesController(FreelanceContext experiences)
        {
            _Experiences = experiences;
        }

        [HttpGet] // Get Method Verified
        public async Task<ActionResult<Experience>> GetAll()
        {
            var experiences = _Experiences.Experiences.ToList();

            return Ok(experiences);
        }


        [HttpGet("{id}")] //Get by ID  Method Verified
        public async Task<ActionResult<ExperiencesIOutputModel>> Get(int id)
        {
            try
            {
                List<ExperiencesIOutputModel> experiencesIOutputModels = new List<ExperiencesIOutputModel>();

                var experiences = await _Experiences.Experiences.Where(experience => experience.IdCondidatNavigationId == id).ToListAsync();
                if (experiences == null || experiences.Count == 0)
                {
                    return NotFound();
                }

                // Convert each experience to the output model and add to the list
                foreach (var experience in experiences)
                {
                    var outputModel = new ExperiencesIOutputModel
                    {
                        Id = experience.Id,
                        Titre = experience.Titre,
                        Local = experience.Local,
                        Description = experience.Description,
                        Ville = experience.Ville,
                        DateDebut = experience.DateDebut,
                        DateFin = experience.DateFin,
                        IdCondidat = experience.IdCondidat,
                        IdCondidatNavigationId = experience.IdCondidatNavigationId
                    };

                    experiencesIOutputModels.Add(outputModel);
                }

                return Ok(experiencesIOutputModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        // DELETE api/<ExperiencesController>/5 Verified
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var experience = await _Experiences.Experiences.FindAsync(id);

                if (experience == null)
                {
                    return Ok("Deleted successfully");  
                }

                _Experiences.Experiences.Remove(experience);  
                await _Experiences.SaveChangesAsync();  

                return NoContent(); 
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // PUT api/<ExperiencesController>/5 /Verified
        [HttpPut("{Id}")]
        public async Task<ActionResult> Put([FromBody] ExperiencesUpdateModel updatedExperience)
        {
            try
            {
                var experience = await _Experiences.Experiences.FindAsync(updatedExperience.Id);

                if (experience == null)
                {
                    return NotFound(); 
                }

                
                experience.Titre = updatedExperience.Titre;
                experience.Local = updatedExperience.Local;
                experience.Description = updatedExperience.Description;
                experience.Ville = updatedExperience.Ville;
                experience.DateDebut = updatedExperience.DateDebut;
                experience.DateFin = updatedExperience.DateFin;
                

                _Experiences.Experiences.Update(experience); 
                await _Experiences.SaveChangesAsync(); 

                return Ok("successful update"); 
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // POST api/<ExperiencesController> Verifeid 
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExperiencesInputModel newExperience)
        {
            try
            {
              
                var experience = new Experience
                {
                    Titre = newExperience.Titre,
                    Local = newExperience.Local,
                    Description = newExperience.Description,
                    Ville = newExperience.Ville,
                    DateDebut = newExperience.DateDebut,
                    DateFin = newExperience.DateFin,
                    IdCondidat = newExperience.IdCondidat,
                    IdCondidatNavigationId = newExperience.IdCondidatNavigationId
                };

             
                _Experiences.Experiences.Add(experience);

               
                await _Experiences.SaveChangesAsync();

               
                return CreatedAtAction(nameof(Get), new { id = experience.Id }, experience);
            }
            catch (Exception ex)
            {
                 
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}

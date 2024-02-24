using Freelance.DB;
using Freelance.DTOs.Condidats;
using Freelance.Models;
using Microsoft.AspNetCore.Mvc;



namespace Freelance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondidatsController : ControllerBase
    {
        private readonly FreelanceContext _Condidate;
        public CondidatsController (FreelanceContext Condidate)
        {
            _Condidate = Condidate;
        }
        // GET: api/<CondidatsController>  VERIFIED
        [HttpGet]
        public async Task<ActionResult<Condidat>> GetAll()
        {
            var condidats = _Condidate.Condidats.ToList();
             
            return Ok(condidats);
        }

        // GET api/<CondidatsController>/ VERIFIED 
        [HttpGet("{id}")]
        public async Task<ActionResult<Condidat>> Get(int id)
        {
            try
            {
                var condidat = await _Condidate.Condidats.FindAsync(id);

                if (condidat == null)
                {
                    return NotFound(); // Return 404 Not Found if the condidat with the specified id is not found
                }

                return condidat; // Return the condidat if found
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // POST api/<CondidatsController> VERIFIED
        [HttpPost]
        public async Task<ActionResult<InputCondidatModel>> Post([FromBody] InputCondidatModel inputCondidatModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Map inputCondidatModel to Condidat using AutoMapper if available
                Condidat condidat = new Condidat
                {
                    Titre = inputCondidatModel.Titre,
                    Gender = inputCondidatModel.Gender,
                    Disponibilite = inputCondidatModel.Disponibilite,
                    Avatar = inputCondidatModel.Avatar,
                    DateNaissance = inputCondidatModel.DateNaissance,
                    Adresse = inputCondidatModel.Adresse,
                    Tele = inputCondidatModel.Tele,
                    Mobilite = inputCondidatModel.Mobilite,
                    Ville = inputCondidatModel.Ville
                };

                // Add the new Condidat entity to the context asynchronously
                _Condidate.Condidats.Add(condidat);
                await _Condidate.SaveChangesAsync();

                // Return 201 Created status with the created entity
                return CreatedAtAction(nameof(Get), new { id = condidat.Id }, inputCondidatModel);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        // PUT api/<CondidatsController>/ VERIFIED
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCondidatsModel updateCondidats)
        {
            if (id != updateCondidats.Id)
            {
                return BadRequest("Mismatched ids");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingCondidat = await _Condidate.Condidats.FindAsync(id);

                if (existingCondidat == null)
                {
                    return NotFound("Condidat not found");
                }

                // Update existing Condidat entity with values from inputCondidatModel
                existingCondidat.Titre = updateCondidats.Titre;
                existingCondidat.Gender = updateCondidats.Gender;
                existingCondidat.Disponibilite = updateCondidats.Disponibilite;
                existingCondidat.Avatar = updateCondidats.Avatar;
                existingCondidat.DateNaissance = updateCondidats.DateNaissance;
                existingCondidat.Adresse = updateCondidats.Adresse;
                existingCondidat.Tele = updateCondidats.Tele;
                existingCondidat.Mobilite = updateCondidats.Mobilite;
                existingCondidat.Ville = updateCondidats.Ville;

                _Condidate.Condidats.Update(existingCondidat);
                await _Condidate.SaveChangesAsync();

                return Ok("successful update with no response body"); 
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        

        // DELETE api/<CondidatsController>/ >> VERIFIED
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var condidat = await _Condidate.Condidats.FindAsync(id);

                if (condidat == null)
                {
                    return NotFound(); 
                }

                _Condidate.Condidats.Remove(condidat); 
                await _Condidate.SaveChangesAsync(); 

                return Ok("successful deletion"); 
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}

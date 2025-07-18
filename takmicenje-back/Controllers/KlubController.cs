using BusinessAccess.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class KlubController : ControllerBase
    {
        private readonly IKlubService _klubService;
       
        public KlubController (IKlubService klubService)
        {
            _klubService = klubService;
        }

        [HttpPost("create")] 
        public async Task<IActionResult> CreateAsync([FromBody]Klub klub)
        {
            try
            {
                if (klub == null)
                {
                    return BadRequest("Podaci o korisniku su netačni");
                }

                await _klubService.CreateAsync(klub);
                return Ok("Korisnik uspešno kreiran");
            }

            catch (Exception ex)
            {
                return StatusCode(500,$"Greška prilikom kreiranja kluba: {ex.Message}");
            }

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Klub klub)
        {
            try
            {
                klub.Id = id;
                if (klub == null)
                {
                    return BadRequest();
                }

                var postojeciKlub = await _klubService.GetByIdAsync(id);
                if (postojeciKlub == null)
                {
                    return NotFound();
                }

                await _klubService.UpdateAsync(klub);
                return Ok("Uspešno izmenjen klub.");
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom izmene kluba: {error.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
       public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var postojeciKlub = await _klubService.GetByIdAsync(id);
                if (postojeciKlub == null)
                {
                    return NotFound();
                }

                await _klubService.DeleteAsync(postojeciKlub);
                return Ok("Uspešno obrisan klub.");
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom brisanja kluba: {error.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var klubovi = await _klubService.GetAllAsync();

            if(klubovi == null || !klubovi.Any())
            {
                return NotFound();

            }
            return Ok(klubovi);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var klub = await _klubService.GetByIdAsync(id);
                if (klub == null)
                {
                    return NotFound();
                }
                return Ok(klub);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja kluba: {error.Message}");
            }
        }
        [HttpGet("getIme/{imeKluba}")]
        public async Task<IActionResult> GetByImeKlubaAsync(string imeKluba)
        {
            try
            {
                var klub = await _klubService.GetByImeKlubaAsync(imeKluba);
                if (klub == null)
                {
                    return NotFound();
                }
                return Ok(klub);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja kluba: {error.Message}");
            }
        }
        [HttpGet("getGrad/{grad}")]
        public async Task<IActionResult> GetByGradAsync(string grad)
        {
            try
            {
                var klub = await _klubService.GetByGradAsync(grad);
                if (klub == null)
                {
                    return NotFound();
                }
                return Ok(klub);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja kluba: {error.Message}");
            }

        }
        [HttpGet("getDrzava/{drzava}")]
        public async Task<IActionResult> GetByDrzavaAsync(string drzava)
        {
            try
            {
                var klub = await _klubService.GetByDrzavaAsync(drzava);
                if (klub == null)
                {
                    return NotFound();
                }
                return Ok(klub);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja kluba: {error.Message}");
            }
        }

    }
}

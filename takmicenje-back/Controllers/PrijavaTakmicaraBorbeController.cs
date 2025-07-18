using BusinessAccess.Contracts;
using BusinessAccess.Services;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class PrijavaTakmicaraBorbeController : ControllerBase
    {
        private readonly IPrijaveTakmicaraBorbeService _service;

        public PrijavaTakmicaraBorbeController (IPrijaveTakmicaraBorbeService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePrijavaTakmicaraBorbe([FromBody] Takmicar takmicar)
        {
            try
            {
                if (takmicar == null)
                {
                    return BadRequest("Podaci o takmičaru su netačni");
                }

                await _service.CreateAsync(takmicar);
                return Ok(takmicar);
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Greška prilikom kreiranja prijave: {ex.Message}");
            }

        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PrijavaTakmicaraBorbe prijavaTakmicara)
        {
            try
            {
                prijavaTakmicara.Id = id;
                if (prijavaTakmicara == null)
                {
                    return BadRequest();
                }

                var postojecaPrijava = await _service.GetById(id);
                if (postojecaPrijava == null)
                {
                    return NotFound();
                }

                await _service.UpdateAsync(prijavaTakmicara);
                return Ok("Uspešno promenjeni podaci o prijavi.");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom izmene podataka: {ex.Message}");

            }
        }

        [HttpPost("{prijavaTakmicaraId}/prijavi-u-tim-borbe/{ekipnoBorbeId}")]

        public async Task<IActionResult> PrijavaTakmicaraUEkipu(int prijavaTakmicaraId, int ekipnoBorbeId)
        {
            try
            {
                var takmicar = await _service.PrijavaTakmicaraUTimAsync(prijavaTakmicaraId, ekipnoBorbeId);
                if (takmicar == null)
                {
                    return BadRequest();
                }

                return Ok("Takmicar uspesno prijavljen u tim");
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Greška prilikom dodavanja takmicara u tim: {ex.Message}");
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(PrijavaTakmicaraBorbe prijavaTakmicara)
        {
            try
            {
                if (prijavaTakmicara == null)
                {
                    return NotFound();
                }
                await _service.DeleteAsync(prijavaTakmicara);
                return Ok("Prijava uspešno obrisana");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom brisanja prijave:{ex.Message}");
            }

        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var prijave = await _service.GetAllAsync();

            if (prijave == null || !prijave.Any())
            {
                return NotFound();
            }

            return Ok(prijave);
        }

        [HttpGet("get-by-name-prijava-borbe")]
        public async Task<IActionResult> GetByImeIPrezimeAsync([FromQuery] string imePrezime)
        {
            try
            {
                var delovi = imePrezime.Trim().Split(' ');
                var takmicar = await _service.GetByImeIPrezimeAsync(delovi[0], delovi[1]);

                if (takmicar == null)
                {
                    return NotFound();
                }
                return Ok(takmicar);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom pronalaženja prijave: {ex.Message}");
            }
        }

        [HttpGet("get-by-klasa-borbi")]
        public async Task<IActionResult> GetByKlasa([FromBody] string klasa)
        {
            try
            {
                var delovi = klasa.Trim().Split(' ');
                var takmicar = await _service.GetByKategorija(delovi[0], delovi[1], delovi[2]);

                if (takmicar == null)
                {
                    return NotFound();
                }
                return Ok(takmicar);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom pronalaženja prijave: {ex.Message}");
            }
        }
    }
}

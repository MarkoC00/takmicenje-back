using BusinessAccess.Contracts;
using BusinessAccess.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class PrijavaTakmicaraController : ControllerBase
    {
        private readonly IPrijavaTakmicaraService _prijavaTakmicaraService;
        
        public PrijavaTakmicaraController (IPrijavaTakmicaraService service)
        {
            _prijavaTakmicaraService = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePrijavaTakmicara([FromBody] Takmicar takmicar)
        {
            try
            {
                if (takmicar == null)
                {
                    return BadRequest("Podaci o takmičaru su netačni");
                }

                await _prijavaTakmicaraService.CreateAsync(takmicar);
                return Ok(takmicar);
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"Greška prilikom kreiranja prijave: {ex.Message}");
            }

        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update([FromBody] PrijavaTakmicara prijavaTakmicara)
        {
            try
            {
                if(prijavaTakmicara == null)
                {
                    return BadRequest();
                }

                await _prijavaTakmicaraService.UpdateAsync(prijavaTakmicara);
                return Ok("Uspešno promenjeni podaci o prijavi.");
            }

            catch (Exception ex)
            {
                return StatusCode (500, $"Greška prilikom izmene podataka: {ex.Message}");
          
            }
        }

        [HttpPost("{prijavaTakmicaraId}/prijavi-u-tim/{ekipnoKateId}")]

        public async Task<IActionResult> PrijavaTakmicaraUEkipu(int prijavaTakmicaraId, int ekipnoKateId)
        {
            try
            {
                var takmicar = await _prijavaTakmicaraService.PrijavaTakmicaraUTimAsync(prijavaTakmicaraId, ekipnoKateId);
                if (takmicar == null)
                {
                    return BadRequest();
                }

                return Ok("Takmicar uspesno prijavljen u tim");
            }

            catch (Exception ex) {

                return StatusCode(500, $"Greška prilikom dodavanja takmicara u tim: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task <IActionResult> Delete (PrijavaTakmicara prijavaTakmicara)
        {
            try
            {
                if (prijavaTakmicara == null)
                {
                    return NotFound();
                }
                await _prijavaTakmicaraService.DeleteAsync(prijavaTakmicara);
                return Ok("Prijava uspešno obrisana");
            }

            catch (Exception ex) 
            { 
                return StatusCode(500, $"Greška prilikom brisanja prijave:{ex.Message}" );
            }

        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var prijave = await _prijavaTakmicaraService.GetAllAsync();

            if(prijave == null || !prijave.Any())
            {
                return NotFound();
            }

            return Ok(prijave);
        }

        [HttpGet("get-by-name-prijava")]
        public async Task<IActionResult> GetByImeIPrezimeAsync([FromQuery] string imePrezime)
        {
            try
            {
                var delovi = imePrezime.Trim().Split(' ');
                var takmicar = await _prijavaTakmicaraService.GetByImeIPrezimeAsync(delovi[0], delovi[1]);

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

        [HttpGet("get-by-clasa")]
        public async Task<IActionResult> GetByKlasa([FromBody] string klasa)
        {
            try
            {
                var delovi = klasa.Trim().Split(' ');
                var takmicar = await _prijavaTakmicaraService.GetByKategorija(delovi[0], delovi[1], delovi[2]);

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

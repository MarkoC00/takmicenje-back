using BusinessAccess.Contracts;
using BusinessAccess.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class EkipnoKateController : ControllerBase
    {
        private readonly IEkipnoKateService _kateService;
        
        public EkipnoKateController(IEkipnoKateService kateService)
        {
            _kateService = kateService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] EkipnoKate kate)
        {
            try
            {
                if (kate == null)
                {
                    return BadRequest("Podaci oekipi su netačni");
                }

                await _kateService.CreateAsync(kate);
                return Ok("Ekipa uspešno kreiran");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom kreiranja ekipe: {ex.Message}");
            }

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EkipnoKate ekipa)
        {
            try
            {
                ekipa.Id = id;
                if (ekipa == null)
                {
                    return BadRequest();
                }

                var postojecaEkipa = await _kateService.GetByIdAsync(id);
                if (postojecaEkipa == null)
                {
                    return NotFound();
                }

                await _kateService.UpdateAsync(postojecaEkipa);
                return Ok("Uspešno izmenjena ekipa.");
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom izmene ekipe: {error.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var ekipnoKate = await _kateService.GetByIdAsync(id);
                if (ekipnoKate == null)
                {
                    return NotFound();
                }

                await _kateService.DeleteAsync(ekipnoKate);
                return Ok("Uspešno obrisana ekipa.");
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom brisanja ekipe: {error.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ekipe = await _kateService.GetAllAsync();

            if (ekipe == null || !ekipe.Any())
            {
                return NotFound();

            }
            return Ok(ekipe);
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var ekipa = await _kateService.GetByIdAsync(id);
                if (ekipa == null)
                {
                    return NotFound();
                }
                return Ok(ekipa);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja ekipe: {error.Message}");
            }
        }
        [HttpGet("getImeEkipe/{imeEkipe}")]
        public async Task<IActionResult> GetByImeEkipeAsync(string imeEkipe)
        {
            try
            {
                var ekipa = await _kateService.GetByImeEkipeAsync(imeEkipe);
                if (ekipa == null)
                {
                    return NotFound();
                }
                return Ok(ekipa);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja ekipe: {error.Message}");
            }
        }

        [HttpGet("get/{klub}")]
        public async Task<IActionResult> GetAllByKlub(int idKluba)
        {
            try
            {
                var ekipa = await _kateService.GetAllByKlub(idKluba);
                if (ekipa == null)
                {
                    return NotFound();
                }
                return Ok(ekipa);
            }

            catch (Exception error)
            {
                return StatusCode(500, $"Greška prilikom traženja ekipe: {error.Message}");
            }
        }
        [HttpGet("get-by-uzrast-pol")]
        public async Task<IActionResult> GetAllByPoliUzrast([FromQuery] string uzrastPol)
        {
            try
            {
                var delovi = uzrastPol.Trim().Split(' ');
                var ekipa = await _kateService.GetAllByPoliUzrast(delovi[0], delovi[1]);

                if (ekipa == null)
                {
                    return NotFound();
                }
                return Ok(ekipa);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom pronalaženja ekipa: {ex.Message}");
            }
        }

    }
}

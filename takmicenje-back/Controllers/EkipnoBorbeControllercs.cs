using BusinessAccess.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class EkipnoBorbeControllercs : ControllerBase
    {
        private readonly IEkipnoBorbeService _ekipnoBorbeService;
        public EkipnoBorbeControllercs(IEkipnoBorbeService ekipnoBorbeService)
        {
            _ekipnoBorbeService = ekipnoBorbeService;
        }

        [HttpPost("createEkipnoBorbe")]
        public async Task<IActionResult> CreateEkipnoBorbe([FromBody] EkipnoBorbe ekipa)
        {
            try
            {
                if (ekipa == null)
                {
                    return BadRequest("Podaci o ekipi nisu validni");
                }

                await _ekipnoBorbeService.Create(ekipa);
                return Ok("Ekipa uspesno kreirana");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom kreiranja ekipe: {ex.Message}");
            }
        }

        [HttpDelete("deleteEkipnoBorbe/{id}")]
        public async Task<IActionResult> DeleteEkipnoBorbe(int id)
        {
            try
            {
                var postojecaEkipa = await _ekipnoBorbeService.GetById(id);

                if (postojecaEkipa == null)
                {
                    return NotFound();
                }

                await _ekipnoBorbeService.Delete(postojecaEkipa);
                return Ok("Ekipa uspesno obrisana");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom brisanja ekipe: {ex.Message}");
            }
        }

        [HttpPost("updateEkipnoBorbe/{id}")]
        public async Task<IActionResult> UpdateEkipnoBorbe(int id, [FromBody] EkipnoBorbe ekipa)
        {
            try
            {
                ekipa.Id = id;

                if (ekipa == null)
                {
                    return BadRequest("Podaci o ekipi nevazeci");
                }
                var postojecaEkipa = await _ekipnoBorbeService.GetById(id);

                if (postojecaEkipa == null)
                {
                    return BadRequest("Ekipa ne postoji");
                }

                await _ekipnoBorbeService.Update(postojecaEkipa);
                return Ok("Ekipa uspesno izmenjena");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom brisanja ekipe: {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetByIdEkipnoBorbe(int id)
        {
            try
            {
                var postojecaEkipa = await _ekipnoBorbeService.GetById(id);

                if (postojecaEkipa == null)
                {
                    return NotFound();
                }

                return Ok(postojecaEkipa);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom pronalaska ekipe: {ex.Message}");
            }
        }

        [HttpGet("getAllEkipnoBorbe")]
        public async Task<IActionResult> GetAllEkipnoBorbe()
        {
            try
            {
                var ekipe = await _ekipnoBorbeService.GetAll();

                if (ekipe == null || !ekipe.Any())
                {
                    return NotFound();
                }

                return Ok(ekipe);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom brisanja ekipe: {ex.Message}");
            }
        }

        [HttpGet("getByImeEkipeEkipnoBorbe/{imeEkipe}")]
        public async Task<IActionResult> GetByImeEkipeAsync(string imeEkipe)
        {
            try
            {
                var ekipa = await _ekipnoBorbeService.GetByImeEkipe(imeEkipe);
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

        [HttpGet("getByKlubEkipnoBorbe/{klub}")]
        public async Task<IActionResult> GetByKlub(int idKluba)
        {
            try
            {
                var ekipa = await _ekipnoBorbeService.GetByKlub(idKluba);
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

        [HttpGet("getByKlasaEkipnoBorbe")]
        public async Task<IActionResult> GetByKlasa([FromQuery] string uzrastPol)
        {
            try
            {
                var delovi = uzrastPol.Trim().Split(' ');
                var ekipa = await _ekipnoBorbeService.GetByKlasa(delovi[0], delovi[1]);

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

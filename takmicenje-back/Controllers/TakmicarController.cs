using BusinessAccess.Services;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using BusinessAccess.Contracts;
using Microsoft.AspNetCore.Cors;

namespace takmicenje_back.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    [Route("api/[controller]")]
    public class TakmicarController : ControllerBase
    {
        private readonly ITakmicarService _takmicarService;

        public TakmicarController(ITakmicarService takmicarService)
        {
            _takmicarService = takmicarService;
        }

        //[HttpGet("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var takmicari = await _takmicarService.GetAllAsync();

            if (takmicari == null || !takmicari.Any())
            {
                return NotFound();
            }
            return Ok(takmicari);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                var takmicar = await _takmicarService.GetByIdAsync(id);

                if (takmicar == null)
                {
                    return NotFound();
                }

                return Ok(takmicar);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom vraćanja takmičara : {ex.Message}");
            }

        }

        [HttpGet("get-by-name")]

        public async Task<IActionResult> GetByName([FromQuery] string imePrezime)
        {
            try
            {
                var delovi= imePrezime.Trim().Split(' ');
                var takmicar = await _takmicarService.GetByImeIPrezimeAsync(delovi[0], delovi[1]);

                if (takmicar == null)
                {
                    return NotFound();
                }
                return Ok(takmicar);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greska prilikom pronalaženja korisnika: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTakmicar([FromBody] Takmicar takmicar)
        {
            try
            {
                if (takmicar == null)
                {
                    return BadRequest("Netačni podaci o takmičaru");
                }

                await _takmicarService.CreateAsync(takmicar);
                return Ok("Takmičar uspešno kreiran");
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom kreiranja tamičara: {ex.Message}");
            }
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Takmicar takmicar)
        {
            try
            {
                takmicar.Id = id;
                if (takmicar == null)
                {
                    return BadRequest();
                }

                var postojeciTakmicar = await _takmicarService.GetByIdAsync(takmicar.Id);
                if (postojeciTakmicar == null)
                {
                    return NotFound();
                }

                await _takmicarService.UpdateAsync(takmicar);
                return Ok("Takmičar uspešno update-ovan");

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Greška prilikom update-ovanja takmičara: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var takmicar = await _takmicarService.GetByIdAsync(id);

                if (takmicar == null)
                {
                    return NotFound();
                }

                await _takmicarService.DeleteAsync(takmicar);
                return Ok("Takmicar uspesno obrisan!");
            }

            catch(Exception ex)
            {
                return StatusCode(500, $"Greska prilikom brisanja takmicara: {ex.Message}");
            }
        }


    }
}

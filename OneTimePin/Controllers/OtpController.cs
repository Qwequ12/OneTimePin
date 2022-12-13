using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneTimePin.Data;
using OneTimePin.Models;

namespace OneTimePin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly OtpDBContext _context;

        public OtpController(OtpDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Otp>> Get()
        {
            return await _context.otps.ToListAsync();

        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Otp),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetbyId(int id)
        {
            var otp = await _context.otps.FindAsync(id);
            return otp == null ? NotFound() : Ok(otp);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Otp otp)
        {
            await _context.otps.AddAsync(otp);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetbyId), new { id = otp.Id }, otp);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Otp otp)
        {
            if (id != otp.Id) return BadRequest();
            _context.Entry(otp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var otptoDelete = await _context.otps.FindAsync(id);
            if (otptoDelete == null) return NotFound();

            _context.otps.Remove(otptoDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

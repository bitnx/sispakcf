using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using MainApp.Data;
using MainApp.Models;
using MainApp;

namespace MainWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasiensController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly Perhitungan _perhitungan;

        public PasiensController( ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender, Perhitungan perhitungan)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
            _perhitungan = perhitungan;
        }

        // GET: api/Pasiens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasien>>> GetPasien()
        {
            var requestUrl = $"{Request.Scheme}://{Request.Host.Value}/";
            if (_context.Pasien == null)
          {
              return NotFound();
          }
            return await _context.Pasien.ToListAsync();
        }

        // GET: api/Pasiens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasien>> GetPasien(int id)
        {
          if (_context.Pasien == null)
          {
              return NotFound();
          }
            Pasien? peserta = await _context.
                Pasien.Include(x => x.Konsultasi)
                .ThenInclude(x=>x.GejalaPasien)
                .ThenInclude(x=>x.Gejala)
                .FirstOrDefaultAsync(x=>x.Id==id);

            if (peserta == null)
            {
                return NotFound();
            }

            return peserta;
        }

        // PUT: api/Pasiens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasien(int id, Pasien peserta)
        {
            if (id != peserta.Id)
            {
                return BadRequest();
            }

            _context.Entry(peserta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return Ok(peserta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }

        // POST: api/Pasiens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasien>> PostPasien(Pasien peserta)
        {
            var trans = await _context.Database.BeginTransactionAsync();
            try
            {
                if (_context.Pasien == null)
                {
                    throw new SystemException("Entity set 'ApplicationDbContext.Pasien'  is null.");
                }
                var password = Helper.CreateRandomPassword();
                var user = new IdentityUser(peserta.Email) { Email = peserta.Email };
                var createResult = await _userManager.CreateAsync(user, password);

                if (!createResult.Succeeded)
                {
                    throw new SystemException(createResult.Errors.FirstOrDefault().Description);
                }

                await _userManager.AddToRoleAsync(user, "Pasien");
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var requestUrl = $"{Request.Scheme}://{Request.Host.Value}/";
                var callbackUrl = $"{requestUrl}/Identity/Account/confirmemail?userid={user.Id}&code={code}";
                peserta.UserId = user.Id;
                //save File

                _context.Pasien.Add(peserta);
                await _context.SaveChangesAsync();
                await _emailSender.SendEmailAsync(peserta.Email, "Confirm your email",
                   $"<p>Your UserName : {user.Email} </p>" +
                   $"<p>Your Password : {password} </p>" +
                   $"<p>Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

               await trans.CommitAsync();
                return CreatedAtAction("GetPasien", new { id = peserta.Id }, peserta);
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return Problem(ex.Message);
            }
        }

        // DELETE: api/Pasiens/5


        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate(IEnumerable<Jawaban> jawabans)
        {
            try
            {
                if (jawabans == null || jawabans.Count() <= 0)
                {
                    return BadRequest("Anda Belum Memilih Jawaban");
                }
                var results = _perhitungan.Hitung(jawabans.ToList());
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("history/{id}")]
        public async Task<IActionResult> AddToHistory(int id, Konsultasi konsultasi)
        {
            try
            {
                var pasien = _context.Pasien.Include(x=>x.Konsultasi)
                    .FirstOrDefault(x => x.Id == id);
                if (pasien == null)
                {
                    return Unauthorized("Anda Tidak Memiliki Akses !");
                }

                pasien.Konsultasi.Add(konsultasi);
                _context.SaveChanges();
                return Ok(konsultasi);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool PasienExists(int id)
        {
            return (_context.Pasien?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

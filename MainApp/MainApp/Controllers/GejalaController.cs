using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using MainApp.Data;
using MainApp.Models;

namespace MainWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GejalaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public GejalaController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: api/Gejalas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gejala>>> GetGejala()
        {
            if (_context.Gejala == null)
            {
                return NotFound();
            }
            return await _context.Gejala.ToListAsync();
        }

        // GET: api/Gejalas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gejala>> GetGejala(int id)
        {
            if (_context.Gejala == null)
            {
                return NotFound();
            }
            Gejala? peserta = await _context.Gejala
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peserta == null)
            {
                return NotFound();
            }

            return peserta;
        }


        private bool GejalaExists(int id)
        {
            return (_context.Gejala?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

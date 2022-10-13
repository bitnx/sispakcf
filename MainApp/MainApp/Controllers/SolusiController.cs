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
    public class SolusiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public SolusiController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: api/Solusis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solusi>>> GetSolusi()
        {
            if (_context.Solusi == null)
            {
                return NotFound();
            }
            return await _context.Solusi.ToListAsync();
        }

        // GET: api/Solusis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solusi>> GetSolusi(int id)
        {
            if (_context.Solusi == null)
            {
                return NotFound();
            }
            Solusi? peserta = await _context.Solusi
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peserta == null)
            {
                return NotFound();
            }

            return peserta;
        }


        private bool SolusiExists(int id)
        {
            return (_context.Solusi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VidreriaGarmendia.Data;
using VidreriaGarmendia.Models;

namespace VidreriaGarmendia.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactosController : ControllerBase
{
    private readonly VidreriaDbContext _context;
    private readonly ILogger<ContactosController> _logger;

    public ContactosController(VidreriaDbContext context, ILogger<ContactosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>GET /api/contactos - Consulta los registros guardados.</summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contacto>>> Get()
    {
        var contactos = await _context.Contactos
            .AsNoTracking()
            .OrderByDescending(c => c.FechaRegistro)
            .ToListAsync();

        return Ok(contactos);
    }

    /// <summary>POST /api/contactos - Guarda un contacto del formulario Contáctenos.</summary>
    [HttpPost]
    public async Task<ActionResult<Contacto>> Post([FromBody] Contacto contacto)
    {
        // El Id lo genera SQL Server (IDENTITY) y la fecha la pone el servidor.
        contacto.Id = 0;
        contacto.FechaRegistro = DateTime.UtcNow;

        _context.Contactos.Add(contacto);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Contacto {Id} guardado.", contacto.Id);
        return Ok(contacto); // 200 OK, según la guía
    }
}

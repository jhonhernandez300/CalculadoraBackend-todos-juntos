using CalculadoraLaboralBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace CalculadoraLaboralBackend.Controllers
{
    //[Route("api/Colaborador")]
    [Route("api")]
    [EnableCors("CorsPolicy")]
    public class ColaboradorController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public ColaboradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/RegistrarColaborador       
        [HttpPost("RegistrarColaborador")]
        public async Task<ActionResult<Colaborador>> RegistrarColaborador([FromBody] Colaborador colaborador)
        {
            _context.Colaborador.Add(colaborador);
            await _context.SaveChangesAsync();
            return colaborador;
        }

        // GET: api/ConsultarColaboradorPorIdentificación/5        
        [HttpGet("ConsultarColaboradorPorIdentificacion/{numeroDeIdentificacion}")]        
        public async Task<IActionResult> ConsultarColaboradorPorIdentificacion(int numeroDeIdentificacion)
        {
            var result = await _context.Colaborador.Where(i => i.NumeroDeIndentificacion == numeroDeIdentificacion).ToListAsync();

            if (result.Count == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // UPDATE: api/ActualizarColaborador        
        [HttpPatch("ActualizarColaborador")]
        public async Task<ActionResult<Colaborador>> ActualizarColaborador([FromBody] Colaborador colaborador)
        {
            var result = await _context.Colaborador.AsNoTracking().Where(i => i.Id == colaborador.Id).ToListAsync();

            if (result.Count == 0)
            {
                return NotFound();
            }

            _context.Colaborador.Update(colaborador);
            await _context.SaveChangesAsync();
            //return colaborador;

            return Ok(colaborador);
        }

        // GET: api/GetCodigoInterno/      
        [HttpGet("GetCodigoInterno")]
        public string getCodigoInterno()
        {
            var guid = Guid.NewGuid();
            string json = JsonConvert.SerializeObject(guid);
            return json;
        }

    }
}

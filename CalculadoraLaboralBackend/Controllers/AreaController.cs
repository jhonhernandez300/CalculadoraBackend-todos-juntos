using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadoraLaboralBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Newtonsoft.Json;

namespace CalculadoraLaboralBackend.Controllers
{
    [Route("api")]
    [EnableCors("CorsPolicy")]
    public class AreaController : Controller
    {
        private readonly ApplicationDbContext _context;


        public AreaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ObtenerAreas
        [HttpGet("ObtenerAreas")]
        public string ObtenerAreas()
        {
            var result =  _context.Area.ToList();
            string json = JsonConvert.SerializeObject(result);
            return json;
        }
    }
}

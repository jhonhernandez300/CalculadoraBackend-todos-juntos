using CalculadoraLaboralBackend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace CalculadoraLaboralBackend.Controllers
{
    [Route("api/Servicio")]
    [EnableCors("CorsPolicy")]
    public class ServicioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/PostServicio        
        [HttpPost("PostServicio")]        
        public async Task<ActionResult<Servicio>> PostServicio([FromBody]Servicio servicio)        
        {
            servicio.semanaDelAno = ObtenerLaSemana(servicio.fechaDeInicio);
            await CalcularHorasAsync(servicio);            
            
            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();
            
            return servicio;
        }

        public async Task<ActionResult<Servicio>> IngresarServicioALaBaseDeDatos(Servicio servicio)
        {
            _context.Servicio.Add(servicio);
            await _context.SaveChangesAsync();

            return servicio;
        }


        // GET: api/GetServicio/5        
        [HttpGet("GetServicio/{tecnico}/{semanaDelAno}")]
        public async Task<IActionResult> GetServicio(string tecnico, int semanaDelAno)
        {
            var servicio = await _context.Servicio.Where(i => i.tecnico == tecnico && i.semanaDelAno == semanaDelAno).ToListAsync();

            if (servicio.Count == 0)
            {
                return NotFound();
            }

            return Ok(servicio);
        }

        public async Task CalcularHorasAsync(Servicio servicio)
        {
            if (servicio.horaDeInicio >= 7 && servicio.horaDeInicio < 20)
            {
                await inicioDiurnoAsync(servicio);

            }
            else {
                await inicioNocturno(servicio);
            }
        }

        public async Task inicioDiurnoAsync(Servicio servicio)
        {
            if (servicio.horaDeFinalizacion >= 7 && servicio.horaDeFinalizacion < 20)
            {
                //fin diurno
                servicio.cantidadDeHoras = servicio.horaDeFinalizacion - servicio.horaDeInicio;
                servicio.tipoDeHora = "Diurnas";
            }
            else
            {
                //fin nocturno
                //Las horas son diurnas hasta las 20
                servicio.cantidadDeHoras = 20 - servicio.horaDeInicio;

                if (servicio.horaDeFinalizacion < 24)
                {
                    await IngresarServicioALaBaseDeDatos(CrearServicioNocturno(servicio));
                }
                else
                {
                    await IngresarServicioALaBaseDeDatos(CrearServicioDiaSiguiente(servicio));
                }
            }
        }

        public async Task inicioNocturno(Servicio servicio)
        {
            //Terminó en la noche
            if (servicio.horaDeInicio >= 20 && servicio.horaDeFinalizacion <= 24)
            {
                servicio.cantidadDeHoras = servicio.horaDeFinalizacion - 20;
                servicio.tipoDeHora = "Nocturnas";
            }
            //Terminó al otro día
            else 
            {
                await IngresarServicioALaBaseDeDatos(CrearServicioNocturno(servicio));
            }            
        }

        public Servicio CrearServicioDiaSiguiente(Servicio servicio)
        {
            Servicio servicioDiaSiguiente = new Servicio();
            servicioDiaSiguiente.tecnico = servicio.tecnico;
            servicioDiaSiguiente.servicioRealizado = servicio.servicioRealizado;
            servicioDiaSiguiente.semanaDelAno = servicio.semanaDelAno;
            servicioDiaSiguiente.fechaDeInicio = servicio.fechaDeInicio.AddDays(1);
            servicioDiaSiguiente.horaDeInicio = 0;
            servicioDiaSiguiente.fechaDeFinalizacion = servicio.fechaDeFinalizacion;
            servicioDiaSiguiente.horaDeFinalizacion = servicio.horaDeFinalizacion;
            servicioDiaSiguiente.cantidadDeHoras = servicio.horaDeFinalizacion;
            servicioDiaSiguiente.tipoDeHora = "Nocturnas";
            return servicioDiaSiguiente;
        }

        public Servicio CrearServicioNocturno(Servicio servicio)
        {
            Servicio servicioNocturno = new Servicio();
            servicioNocturno.tecnico = servicio.tecnico;
            servicioNocturno.servicioRealizado = servicio.servicioRealizado;
            servicioNocturno.semanaDelAno = servicio.semanaDelAno;
            servicioNocturno.fechaDeInicio = servicio.fechaDeInicio;
            servicioNocturno.horaDeInicio = 20;
            servicioNocturno.fechaDeFinalizacion = servicio.fechaDeFinalizacion;
            servicioNocturno.horaDeFinalizacion = servicio.horaDeInicio;
            servicioNocturno.cantidadDeHoras = servicio.horaDeFinalizacion - 20;
            servicioNocturno.tipoDeHora = "Nocturnas";
            return servicioNocturno;
        }

        public int ObtenerLaSemana(DateTime fecha)
        {
            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo("en-US");
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            // Displays the number of the current week relative to the beginning of the year.
            
            return myCal.GetWeekOfYear(fecha, myCWR, myFirstDOW);
        }

    }
}

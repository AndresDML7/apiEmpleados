using apiEmpleados.Context;
using apiEmpleados.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiEmpleados.Controllers
{
    [Route("api/[controller]")]
    public class EmpleadosController : Controller
    {
        private readonly AppDbContext context;

        public EmpleadosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<EmpleadosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.EMPLEADOS.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}", Name = "GetEmpleado")]
        public ActionResult Get(int id)
        {
            try
            {
                var empleado = context.EMPLEADOS.FirstOrDefault(e => e.id == id);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public ActionResult Post([FromBody] Empleados_Bd empleado)
        {
            try
            {
                context.EMPLEADOS.Add(empleado);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleado", new { id = empleado.id }, empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmpleadosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleados_Bd empleado)
        {
            try
            {
                if(empleado.id == id)
                {
                    context.Entry(empleado).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEmpleado", new { id = empleado.id }, empleado);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var empleado = context.EMPLEADOS.FirstOrDefault(e => e.id == id);
                if(empleado != null)
                {
                    context.EMPLEADOS.Remove(empleado);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

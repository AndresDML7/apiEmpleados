using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiEmpleados.Models
{
    public class Empleados_Bd
    {
        [Key]
        public int id { get; set; }

        public int cedula { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public int telefono { get; set; }

        public int celular { get; set; }

        public string email { get; set; }

        public string direccion { get; set; }
    }
}

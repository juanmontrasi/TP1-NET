using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_academia.Servicios
{
    public class PlanesService
    {
        public IEnumerable<Plan> GetAll()
        {
            using var context = new AcademiaDbContext();

            return context.Planes.ToList();
        }
    }
}

﻿using Entidades;
using proyecto_academia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_academia.Servicios
{
    public class CursosService
    {
        public bool Add(Curso curso)
        {
            using var context = new AcademiaDbContext();

            if (context.Cursos.Any(p => p.IdMateria == curso.IdMateria && p.IdComision== curso.IdComision && p.Nombre == curso.Nombre && p.Anio_Calendario == curso.Anio_Calendario))
            {
                return false;
            }

            if (context.Comisiones.Any(c => c.IdComision == curso.IdComision) && context.Materias.Any(m => m.IdMateria== curso.IdMateria))
            {
                context.Cursos.Add(curso);
                context.SaveChanges();
                return true;
            }
            else
            {
                throw new ArgumentException("IDs no válidos.");
            }
        }
        public void Delete(int id)
        {
            using var context = new AcademiaDbContext();

            Curso? cursoToDelete = context.Cursos.Find(id);

            if (cursoToDelete != null)
            {
                context.Cursos.Remove(cursoToDelete);
                context.SaveChanges();
            }
        }

        public Curso? Get(int id)
        {
            using var context = new AcademiaDbContext();

            return context.Cursos.Find(id);
        }

        public IEnumerable<dynamic> GetAll()
        {
            using var context = new AcademiaDbContext();
            
            var cursosConMateriaComision = (from c in context.Cursos
                                            join m in context.Materias on c.IdMateria equals m.IdMateria
                                            join co in context.Comisiones on c.IdComision equals co.IdComision
                                            select new
                                            {
                                                c.IdCurso,
                                                c.Nombre,
                                                c.Cupo,
                                                c.Anio_Calendario,
                                                Nombre_Materia = m.Nombre_Materia,
                                                Nombre_Comision = co.Nombre_Comision,
                                                c.IdComision,
                                                c.IdMateria
                                                
                                            }).ToList();
            return cursosConMateriaComision;
        }

        public void Update(Curso curso)
        {
            using var context = new AcademiaDbContext();

            Curso? cursoToUpdate = context.Cursos.Find(curso.IdCurso);

            if (cursoToUpdate != null)
            {
                cursoToUpdate.Nombre = curso.Nombre;
                cursoToUpdate.Cupo = curso.Cupo;
                cursoToUpdate.Anio_Calendario = curso.Anio_Calendario;
                cursoToUpdate.IdMateria = curso.IdMateria;
                cursoToUpdate.IdComision = curso.IdComision;
                context.SaveChanges();
            }
        }
    }
}

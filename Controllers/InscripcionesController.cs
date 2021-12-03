using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using u3_aspnetcore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace u3_aspnetcore.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly InscripcionesContext db;

        public InscripcionesController(InscripcionesContext context)
        {
            db = context;
        }


        public IActionResult ListadoRegistros()
        {
            var listaInscripciones = db.Inscripcions.ToList();
            return View(listaInscripciones);
        }
        public IActionResult CargarObjetos()
        {
            Inscripcion inscripcion1 = new Inscripcion();
            inscripcion1.Id = 5;
            inscripcion1.IdAlumno = 4;
            inscripcion1.Carrera = "civil";
            db.Add(inscripcion1);
            db.SaveChanges();

            Inscripcion inscripcion2 = new Inscripcion();
            inscripcion2.Id = 6;
            inscripcion2.IdAlumno = 5;
            inscripcion2.Carrera = "agricultura";
            db.Add(inscripcion2);
            db.SaveChanges();
            Inscripcion inscripcion3 = new Inscripcion();
            inscripcion3.Id = 7;
            inscripcion3.IdAlumno = 6;
            inscripcion3.Carrera = "comercio";
            db.Add(inscripcion3);
            db.SaveChanges();
            Inscripcion inscripcion4 = new Inscripcion();
            inscripcion4.Id = 8;
            inscripcion4.IdAlumno = 7;
            inscripcion4.Carrera = "contaduria";
            db.Add(inscripcion4);
            db.SaveChanges();
            Inscripcion inscripcion5 = new Inscripcion();
            inscripcion5.Id = 9;
            inscripcion5.IdAlumno = 8;
            inscripcion5.Carrera = "gestion";
            db.Add(inscripcion5);
            db.SaveChanges();
            return RedirectToAction("ListadoRegistros");
        }
        public IActionResult AgregarRegistro()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgrrgarRegistro([Bind("Id,IdAlumno,Carrera")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Add(inscripcion);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReportsTo"] = new SelectList(db.Inscripcions, "Id", "IdAlumno", "Carrera");
            //ViewBag.Inscripcions = new SelectList(db.Inscripcions, "Id", "IdAlumno", "Carrera");
            return View("RegistroExitoso", inscripcion);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ins = await db.Inscripcions.FindAsync(id);
            if (ins == null)
            {
                return NotFound();
            }
            ViewData["ReportsTo"] = new SelectList(db.Inscripcions, "Id", "IdAlumno", "Carrera");
            //ViewData["ReportsTo"] = new SelectList(db.Inscripcions, "EmployeeId", "FirstName", .ReportsTo);
            //ViewBag.Inscripcions = new SelectList(db.Inscripcions, "Id", "IdAlumno", "Carrera");
            return View(ins);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, IdAlumno, Carrera")] Inscripcion inscripcion)
        {
            if (id != inscripcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(inscripcion);
                db.SaveChanges();

                return RedirectToAction(nameof(ListadoRegistros));
            }

            ViewData["ReportsTo"] = new SelectList(db.Inscripcions, "Id", "IdAlumno", "Carrera");
            return View(inscripcion);
        }
        [HttpPost]
        public IActionResult Proveedor(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isncrip = db.Inscripcions.Find(id);

            if (isncrip == null)
            {
                return NotFound();
            }

            return View("ListadoRegistros");
        }


        public IActionResult Index()
        {
            return View();
        }
            

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly TrabajadoresContext _Db;
        public TrabajadoresController(TrabajadoresContext Db)
        {
            _Db = Db;


        }

        public IActionResult TrabajadoresList()
        {
            try
            {
                //var tbList=_Db.Trabajadores.ToList();
                var tbList = from a in _Db.Trabajadores
                             join b in _Db.Departamento
                             on a.IdDepartamento equals b.Id
                             into Dep
                             from b in Dep.DefaultIfEmpty()
                             join c in _Db.Provincia
                             on a.IdProvincia equals c.Id
                             into Prov
                             from c in Prov.DefaultIfEmpty()
                             join d in _Db.Distrito
                             on a.IdDistrito equals d.Id
                             into Dis
                             from d in Dis.DefaultIfEmpty()
                             select new Trabajadores
                             {
                                 Id = a.Id,
                                 TipoDocumento = a.TipoDocumento,
                                 NumeroDocumento = a.NumeroDocumento,
                                 Nombres = a.Nombres,
                                 Sexo = a.Sexo,
                                 IdDepartamento = a.IdDepartamento,
                                 Departamento = b == null ? "" : b.NombreDepartamento,
                                 IdProvincia = a.IdProvincia,
                                 Provincia = c == null ? "" : c.NombreProvincia,
                                 IdDistrito = a.IdDistrito,
                                 Distrito = d == null ? "" : d.NombreDistrito

                             };


                return View(tbList);
            }
            catch (Exception ex)
            {
                return View();

            }
        }

        public IActionResult Create( Trabajadores obj)
        {
            loadDepartamento();
           
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddTrabajadores(Trabajadores obj)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.Id == 0)
                    {
                        _Db.Trabajadores.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync(); 
                    }
                    
                    return RedirectToAction("TrabajadoresList");
                }

                return View(obj);
            }
            catch (Exception ex)
            {
                return RedirectToAction("TrabajadoresList");
            }

        }

        public async Task<IActionResult> DeleteTb(int id)
        {
            try

            {
                var tb = await _Db.Trabajadores.FindAsync(id);
                if(tb!= null)
                {
                    _Db.Trabajadores.Remove(tb);
                    await _Db.SaveChangesAsync();
                }

                return RedirectToAction("TrabajadoresList");

            }
            catch (Exception ex)
            {
                return RedirectToAction("TrabajadoresList");
            }
        }

        private void loadDepartamento()
        {
            try
            {
                List<Departamento> depList = new List<Departamento>();
                depList = _Db.Departamento.ToList();
                ViewBag.DepList = depList;

            }
            catch (Exception ex)
            {

            }
        }
        [HttpPost]
        public JsonResult GetProvincia( int IdDepartamento)
        {
            var ProvinciaList = _Db.Provincia.Where(x => x.IdDepartamento == IdDepartamento);

            return Json(new SelectList(ProvinciaList,"Id","NombreProvincia"));
        }

        [HttpPost]
        public JsonResult GetDistrito(int IdProvincia)
        {
            var DistritoList = _Db.Distrito.Where(x => x.IdProvincia == IdProvincia);

            return Json(new SelectList(DistritoList, "Id", "NombreDistrito"));
        }
    }
}

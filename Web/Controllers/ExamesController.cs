using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using ApplicationCore.Dto;

namespace Web.Controllers
{
    public class ExamesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Criar()
        {
            return View("Manter");
        }

        // POST: Exames/Create
        [HttpPost]
        public ActionResult Criar(ExameDto novoExame)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter");
            }
        }
        
        public ActionResult Editar(int id)
        {
            return View("Manter");
        }

        [HttpPost]
        public ActionResult Editar(ExameDto exameEditado)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter");
            }
        }
        
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                // TODO: Add delete logic here
                
            }
            catch
            {
                ViewBag.Error = "Falha ao excluir registro";
                
            }

            return RedirectToAction("Index");
        }
    }
}

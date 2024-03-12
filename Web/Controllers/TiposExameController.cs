using System.Web.Mvc;
using ApplicationCore.Dto;

namespace Web.Controllers
{
    public class TiposExameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        
        public ActionResult Criar()
        {
            return View("Manter");
        }
        
        [HttpPost]
        public ActionResult Criar(TipoExameDto novoTipoExame)
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
        public ActionResult Editar(TipoExameDto tipoExameEditado)
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
        public ActionResult Excluir(int id, FormCollection collection)
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

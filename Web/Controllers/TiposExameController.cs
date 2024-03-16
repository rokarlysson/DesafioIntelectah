using System.Web.Mvc;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class TiposExameController : Controller
    {
        private readonly ITiposExameService _tiposExameService;

        public TiposExameController(ITiposExameService tiposExameService)
        {
            _tiposExameService = tiposExameService;
        }

        public ActionResult Index()
        {
            var tiposExame = _tiposExameService.ListarTiposExame();
            return View(tiposExame);
        }
        
        
        public ActionResult Criar()
        {
            return View("Manter");
        }
        
        [HttpPost]
        public ActionResult Criar(TipoExameDto novoTipoExame)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", novoTipoExame);
            }

            try
            {
                _tiposExameService.ManterTipoExame(novoTipoExame);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter", novoTipoExame);
            }
        }
        
        public ActionResult Editar(int id)
        {
            var tipoExame = _tiposExameService.BuscarTipoExame(id);

            return View("Manter", tipoExame);
        }
        
        [HttpPost]
        public ActionResult Editar(TipoExameDto tipoExameEditado)
        {

            if (!ModelState.IsValid)
            {
                return View("Manter", tipoExameEditado);
            }

            try
            {
                _tiposExameService.ManterTipoExame(tipoExameEditado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter", tipoExameEditado);
            }
        }
        
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                _tiposExameService.ExcluirTipoExame(id);
            }
            catch
            {
                ViewBag.Error = "Falha ao excluir registro";
            }
            
            return RedirectToAction("Index");
        }
    }
}

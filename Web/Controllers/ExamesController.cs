using System.Web.Mvc;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class ExamesController : Controller
    {
        private readonly IExamesService _examesService;

        public ExamesController(IExamesService examesService)
        {
            _examesService = examesService;
        }

        public ActionResult Index()
        {
            var exames = _examesService.ListarExames();

            return View(exames);
        }
        
        public ActionResult Criar()
        {
            return View("Manter");
        }

        // POST: Exames/Create
        [HttpPost]
        public ActionResult Criar(ExameDto novoExame)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", novoExame);
            }

            try
            {
                _examesService.ManterExame(novoExame);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter", novoExame);
            }
        }
        
        public ActionResult Editar(int id)
        {
            var exame = _examesService.BuscarExame(id);

            return View("Manter", exame);
        }

        [HttpPost]
        public ActionResult Editar(ExameDto exameEditado)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", exameEditado);
            }

            try
            {
                _examesService.ManterExame(exameEditado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter", exameEditado);
            }
        }
        
        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                _examesService.ExcluirExame(id);
            }
            catch
            {
                ViewBag.Error = "Falha ao excluir registro";
                
            }

            return RedirectToAction("Index");
        }
    }
}

using System.Collections.Generic;
using System.Web.Mvc;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class ExamesController : Controller
    {
        private readonly IExamesService _examesService;
        private readonly ITiposExameService _tiposExameService;

        public ExamesController(IExamesService examesService, ITiposExameService tiposExameService)
        {
            _examesService = examesService;
            _tiposExameService = tiposExameService;
        }

        public ActionResult Index()
        {
            var exames = _examesService.ListarExames();

            return View(exames);
        }
        
        public ActionResult Criar()
        {
            ViewBag.TiposExame = GetTiposExameList();
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

        private IEnumerable<SelectListItem> GetTiposExameList()
        {
            var tiposExame = _tiposExameService.ListarTiposExame();

            return new SelectList(tiposExame, "Id", "Nome");
        }
    }
}

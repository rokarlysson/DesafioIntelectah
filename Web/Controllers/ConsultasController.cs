using System;
using System.Web.Mvc;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IConsultasService _consultasService;
        private readonly IPacientesService _pacientesService;
        private readonly ITiposExameService _tiposExameService;
        private readonly IExamesService _examesService;

        public ConsultasController(IConsultasService consultasService,
                                   IPacientesService pacientesService,
                                   ITiposExameService tiposExameService,
                                   IExamesService examesService)
        {
            _consultasService = consultasService;
            _pacientesService = pacientesService;
            _tiposExameService = tiposExameService;
            _examesService = examesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Criar()
        {
            ViewBag.PacienteId = new SelectList(_pacientesService.ListarPacientes(), "Id", "Nome");
            ViewBag.TipoExameId = new SelectList(_tiposExameService.ListarTiposExame(), "Id", "Nome");
            return View("Manter");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(ConsultaDto novaConsulta)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", novaConsulta);
            }

            if (!_consultasService.VerificarConflitoDeHorarios(novaConsulta))
            {
                ModelState.AddModelError("DataHora", "Conflito de horários. Selecione outra data e hora.");
            }
            else
            {
                novaConsulta.NumeroProtocolo = GerarNumeroDeProtocolo();

                _consultasService.ManterConsulta(novaConsulta);

                return RedirectToAction("Index");
            }

            ViewBag.PacienteId = new SelectList(_pacientesService.ListarPacientes(), "Id", "Nome", novaConsulta.PacienteId);

            var exame = _examesService.BuscarExame(novaConsulta.ExameId);
            ViewBag.TipoExameId = new SelectList(_tiposExameService.ListarTiposExame(), "Id", "Nome", exame.TipoExameId);
            return View("Manter", novaConsulta);
        }

        public ActionResult Editar(int id)
        {
            return View("Manter");
        }

        [HttpPost]
        public ActionResult Editar(ConsultaDto consultaEditada)
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

        public ActionResult CarregarExames(int tipoExameId)
        {
            var exames = _examesService.ListarExamesPeloTipo(tipoExameId);
            return Json(exames, JsonRequestBehavior.AllowGet);
        }

        private static string GerarNumeroDeProtocolo()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
}
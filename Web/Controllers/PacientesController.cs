using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApplicationCore.Dto;
using ApplicationCore.Interfaces;

namespace Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacientesService _pacienteService;

        public PacientesController(IPacientesService pacienteService)
        {
            _pacienteService = pacienteService;
            
        }

        public ActionResult Index()
        {
            var pacientes = _pacienteService.ListarPacientes();
            return View(pacientes.ToList());
        }

        public ActionResult Criar()
        {
            ViewBag.SexoSelectList = new SelectList(GetSexoList(), "Value", "Text");
            return View("Manter");
        }

        [HttpPost]
        public ActionResult Criar(PacienteDto novoPaciente)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", novoPaciente);
            }

            try
            {
                _pacienteService.ManterPaciente(novoPaciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Manter", novoPaciente);
            }
        }

        public ActionResult Editar(int id)
        {
            var paciente = _pacienteService.BuscarPaciente(id);
            ViewBag.SexoSelectList = new SelectList(GetSexoList(), "Value", "Text", paciente.Sexo);
            return View("Manter", paciente);
        }

        [HttpPost]
        public ActionResult Editar(PacienteDto pacienteEditado)
        {
            if (!ModelState.IsValid)
            {
                return View("Manter", pacienteEditado);
            }

            try
            {
                _pacienteService.ManterPaciente(pacienteEditado);

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.SexoSelectList = new SelectList(GetSexoList(), "Value", "Text", pacienteEditado.Sexo);
                return View("Manter", pacienteEditado);
            }
        }


        [HttpPost]
        public ActionResult Excluir(int id)
        {
            try
            {
                _pacienteService.ExcluirPaciente(id);
            }
            catch
            {
                ViewBag.Error = "Falha ao excluir registro";
            }

            return RedirectToAction("Index");
        }

        private static IEnumerable<SelectListItem> GetSexoList()
        {
            var sexoListItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "M", Text = "Masculino" },
                new SelectListItem { Value = "F", Text = "Feminino" },
                new SelectListItem { Value = "N", Text = "Não-declarado"}
            };

            return new SelectList(sexoListItems, "Value", "Text");
        }
    }
}

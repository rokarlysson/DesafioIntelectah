using System;
using System.Web.Mvc;
using ApplicationCore.Dto;

namespace Web.Controllers
{
    public class ConsultasController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Criar()
        {
            //ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nome");
            //ViewBag.TipoExameId = new SelectList(db.TiposExame, "Id", "Nome");
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
            
            if (!VerificarConflitoDeHorarios(novaConsulta))
            {
                ModelState.AddModelError("DataHora", "Conflito de horários. Selecione outra data e hora.");
            }
            else
            {
                novaConsulta.NumeroProtocolo = GerarNumeroDeProtocolo();
                //db.Consultas.Add(consulta);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PacienteId = new SelectList(db.Pacientes, "Id", "Nome", consulta.PacienteId);
            //ViewBag.TipoExameId = new SelectList(db.TiposExame, "Id", "Nome", consulta.Exame?.TipoExameId);
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

        private static bool VerificarConflitoDeHorarios(ConsultaDto novaConsulta)
        {
            return false;
            //return !db.Consultas.Any(c =>
            //    c.DataHora == novaConsulta.DataHora &&
            //    c.PacienteId == novaConsulta.PacienteId &&
            //    c.Id != novaConsulta.Id);
        }

        private static string GerarNumeroDeProtocolo()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
}
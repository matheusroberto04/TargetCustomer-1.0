using Microsoft.AspNetCore.Mvc;
using TargetCustomer___MVC.Data;
using TargetCustomer___MVC.DTOs;

namespace TargetCustomer___MVC.Controllers
{
    public class ConsultoriaController : Controller
    {
        private readonly DataContext _dataContext;
        public ConsultoriaController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Exibir a página de Consultoria
        public IActionResult ConsultoriaPage()
        {
            var consultorias = _dataContext.Consultorias.ToList();
            ViewBag.Consultorias = consultorias;
            return View();
        }

        // Solicitar nova Consultoria
        public IActionResult SolicitarConsultoria(ConsultoriaDTO request)
        {
            Consultoria novaConsultoria = new Consultoria
            {
                Id = request.Id,
                DescricaoConsultoria = request.DescricaoConsultoria,
                Representante= request.Representante
            };

            _dataContext.Consultorias.Add(novaConsultoria);
            _dataContext.SaveChanges();

            return RedirectToAction("ConsultoriaPage");
        }

        // Atualizar Consultoria
        public IActionResult AtualizarConsultoria(int id, ConsultoriaDTO request)
        {
            var consultoria = _dataContext.Consultorias.Find(id);
            if (consultoria == null)
            {
                return NotFound();
            }

            consultoria.Id = request.Id;
            consultoria.DescricaoConsultoria = request.DescricaoConsultoria;
            consultoria.Representante = request.Representante;

            _dataContext.Update(consultoria);
            _dataContext.SaveChanges();

            return RedirectToAction("ConsultoriaPage");
        }

        // Excluir Consultoria
        public IActionResult ExcluirConsultoria(int id)
        {
            var consultoria = _dataContext.Consultorias.Find(id);
            if (consultoria == null)
            {
                return NotFound();
            }

            _dataContext.Consultorias.Remove(consultoria);
            _dataContext.SaveChanges();

            return RedirectToAction("ConsultoriaPage");
        }
    }


}

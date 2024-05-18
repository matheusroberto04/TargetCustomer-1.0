using Microsoft.AspNetCore.Mvc;
using TargetCustomer___MVC.Data;
using TargetCustomer___MVC.DTOs;

namespace TargetCustomer___MVC.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly DataContext _dataContext;
        public AvaliacaoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // Exibir a página de Avaliações
        public IActionResult AvaliacaoPage()
        {
            var avaliacoes = _dataContext.AvaliacaoConsultorias.ToList();
            ViewBag.Avaliacoes = avaliacoes;
            return View();
        }

        // Criar nova Avaliação
        public IActionResult CriarAvaliacao(AvaliacaoDTO request)
        {
            AvaliacaoConsultoria novaAvaliacao = new AvaliacaoConsultoria
            {
                Id = request.Id,
                TextoAvaliacao = request.TextoAvaliacao,
            };

            _dataContext.AvaliacaoConsultorias.Add(novaAvaliacao);
            _dataContext.SaveChanges();

            return RedirectToAction("AvaliacaoPage");
        }

        // Alterar Avaliação existente
        public IActionResult AlterarAvaliacao(int id, AvaliacaoDTO request)
        {
            var avaliacao = _dataContext.AvaliacaoConsultorias.Find(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            avaliacao.Id = request.Id;
            avaliacao.TextoAvaliacao = request.TextoAvaliacao;

            _dataContext.Update(avaliacao);
            _dataContext.SaveChanges();

            return RedirectToAction("AvaliacaoPage");
        }

        // Excluir Avaliação
        public IActionResult ExcluirAvaliacao(int id)
        {
            var avaliacao = _dataContext.AvaliacaoConsultorias.Find(id);
            if (avaliacao == null)
            {
                return NotFound();
            }

            _dataContext.AvaliacaoConsultorias.Remove(avaliacao);
            _dataContext.SaveChanges();

            return RedirectToAction("AvaliacaoPage");
        }
    }

}

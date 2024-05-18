using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using TargetCustomer___MVC.Data;
using TargetCustomer___MVC.DTOs;

namespace TargetCustomer___MVC.Controllers
{
    public class UsuarioController : Controller
    {
       private readonly DataContext _dataContext;
       public UsuarioController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult EfetuarLogin(LoginDTO request)
        {
            var getUser = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);
            if (getUser == null)
            {
                return NotFound();
            }
            if (!BCrypt.Net.BCrypt.Verify(request.SenhaHash, getUser.HashSenha))
            {
                return NotFound();
            }
            if (getUser.IsActive == false)
            {
                getUser.IsActive = true;
            }
            return RedirectToAction("Home", "Index");
        }

        public IActionResult CadastroPage()
        {
            return View();
        }

        public IActionResult EfetuarCadastro(CadastroDTO request)
        {
            var findUser = _dataContext.Usuarios.FirstOrDefault(x => x.Email == request.Email);
            if (findUser != null)
            {
                return NotFound();
            }

            Usuario newUser = new Usuario
            {
                CNPJ = request.CNPJ,
                Razao = request.RazaoSocial,
                Telefone = request.Telefone,
                RamoDeAtuacao = request.RamodeAtuacao,
                Email = request.Email,
                Logradouro = request.Logradouro,
                NumeroLogradouro = request.NumeroLogradouro,
                HashSenha = BCrypt.Net.BCrypt.HashPassword(request.SenhaHash),
            };

            _dataContext.Usuarios.Add(newUser);
            _dataContext.SaveChanges();

            return RedirectToAction("Usuario", "LoginPage");
        }
        public IActionResult PerfilPage(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
          

            ViewBag.Usuario = getUser;

            return View();
        }

        public IActionResult EditarPerfil(int id, string newPassword, CadastroDTO request)
        {
            var getUser = _dataContext.Usuarios.Find(id);

            

            if (BCrypt.Net.BCrypt.Verify(request.SenhaHash, getUser!.HashSenha))
            {
                getUser.CNPJ = request.CNPJ;
                getUser.Razao = request.RazaoSocial;
                getUser.Telefone = request.Telefone;
                getUser.RamoDeAtuacao = request.RamodeAtuacao;
                getUser.Email = request.Email;
                getUser.Logradouro = request.Logradouro;
                getUser.NumeroLogradouro = request.NumeroLogradouro;
                getUser.HashSenha = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");
        }

        public IActionResult DeletarPerfil(int id)
        {
            var getUser = _dataContext.Usuarios.Find(id);
           

            getUser!.IsActive = false;

            _dataContext.Update(getUser);
            _dataContext.SaveChanges();

            return RedirectToAction("PerfilPage");
        }
    }
}

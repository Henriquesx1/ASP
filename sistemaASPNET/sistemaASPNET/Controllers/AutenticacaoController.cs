using sistemaASPNET.Models;
using sistemaASPNET.Utils;
using sistemaASPNET.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaASPNET.Controllers
{
    public class AutenticacaoController : Controller
    {
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(CadastroUsuarioViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }

            Usuario novousuario = new Usuario
            {
                UsuNome = viewmodel.UsuNome,
                Login = viewmodel.Login,
                Senha = Hash.GerarHash(viewmodel.Senha)
            };
            novousuario.Insert(novousuario);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LoginBusca(string Login) //Action LoginBusca que tem que receber um parâmetro. Este que será enviado através do Remote.
        {
            bool LoginExists; // Variável do tipo boleano (True /False)
            var usuario = new Usuario(); // Objeto instanciado da classe Usuario
            string login = usuario.SelectLogin(Login);

            if (login.Length == 0)
                LoginExists = false;
            else
                LoginExists = true; // PAREI AQUIIIIIII

            return Json(!LoginExists, JsonRequestBehavior.AllowGet); // retorna tipo boleano
        }
    }
    
}
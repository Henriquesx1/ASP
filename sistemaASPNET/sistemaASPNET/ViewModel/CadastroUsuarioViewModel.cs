using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sistemaASPNET.ViewModel
{
    public class CadastroUsuarioViewModel
    {
        [Display(Name = "Nome")] ///DISPLAY = NOME DE EXIBIÇÃO DA VIEW
        [Required(ErrorMessage = "Informe o seu Nome")] // REQUIRED = ESPECIFICA QUE UM VALOR DE DADOS É OBRIGATÓRIO
        [MaxLength(100, ErrorMessage = "O nome deve ter até 100 carácteres")] //MAXLENGTH= COMPRIMENTO MÁXIMO
        public string UsuNome { get; set; }

        [Required(ErrorMessage = "Informe o Login")] //VALOR OBRIGATÓRIO
        [MaxLength(50, ErrorMessage = "O login deve ter até 50 carácteres")] //COMPRIMENTO MÁXIMO
        [Remote("LoginBusca", "Autenticacao", ErrorMessage = "O login já existe!")] //VALIDAR DADOS SEM POSTAR PARA O SERVIDOR
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 carácteres")] //MINLENGTH = COMPRIMENTO MINIMO
        [DataType(DataType.Password)] //FORMATO/TIPO SENHA
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Confirme a Senha")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare(nameof(Senha), ErrorMessage ="As senhas são diferentes")] // COMPARE = COMPARA DUAS UNIDADES DE UM MODELO & nameof é avaliada em tempo de compilação e não tem efeito em tempo de execução.Podemosusar uma nameofpara tornar o código de verificação de argumento mais sustentável
        public string ConfirmarSenha { get; set; }
            
    }
}
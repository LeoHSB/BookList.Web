using System.ComponentModel.DataAnnotations;
using Projeto.Web.Validators;
using System.Linq;
namespace Projeto.Web.Models
{
    public class UsuarioModelLogin
    {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        [Display(Name = "Informe seu Login:")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        [Display(Name = "Informe sua Senha:")]
        public string Senha { get; set; }
    }
    public class UsuarioModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuario.")]
        [RegularExpression("^[A-Za-z ]{6,50}$", ErrorMessage = "Erro. Nome inválido.")]
        [Display(Name = "Informe seu Nome:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe o email do usuario.")]
        [RegularExpression("^(?=.{1,254}$)(?=.{1,64}@)[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$", ErrorMessage = "Erro. email inválido.")]
        [LoginDisponivel(ErrorMessage = "Erro. Este email encontra-se indisponivel.Tente outro.")]
        [Display(Name = "Informe seu Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Por favor, informe a senha do usuario.")]
        [RegularExpression("^\\S{6,40}$", ErrorMessage = "Erro. Senha inválida.")]
        [Display(Name = "Senha de Acesso:")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Por favor, confirme a senha do usuario.")]
        [Compare("Senha", ErrorMessage = "Erro. Confirme sua Senha corretamente.")]
        [Display(Name = "Confirme sua Senha:")]
        public string SenhaConfirm { get; set; }
    }

    public class ChaveApiCadastroModel
    {
        public int Id { get; set; }

        [Display(Name = "Insira sua Chave Api da Google Books")]
        public string ApiKey { get; set; }
    }
}
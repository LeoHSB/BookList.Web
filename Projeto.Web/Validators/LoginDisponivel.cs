using Projeto.Data.Persistence;
using System.ComponentModel.DataAnnotations;
namespace Projeto.Web.Validators
{
    public class LoginDisponivel : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string Login = (string)value;
            UsuarioData d = new UsuarioData();
            return !d.HasLogin(Login);
        }
    }
}
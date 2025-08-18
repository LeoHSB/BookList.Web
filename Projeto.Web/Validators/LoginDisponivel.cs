using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto.Data.Persistence;
using System.ComponentModel.DataAnnotations;
namespace Projeto.Web.Validators
{
    //Classe de validação customizada, para tal, deverá
    //herdar -> ValidationAttribute
    public class LoginDisponivel : ValidationAttribute
    {
        //implementar o método IsValid
        //retornar true se a validação está ok...
        //retornar false se ocorreu um erro de validação
        public override bool IsValid(object value)
        {
            //value -> representa o valor do elemento que está sendo validado
            string Login = (string)value;
            //acessar a base de dados...
            UsuarioData d = new UsuarioData();
            return !d.HasLogin(Login);
        }
    }
}
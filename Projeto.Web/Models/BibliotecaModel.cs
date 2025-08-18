using System.ComponentModel.DataAnnotations;
using Projeto.Web.Validators;
namespace Projeto.Web.Models

{
    public class BibliotecaModelConsulta
    {
    }

    public class BibliotecaModelCadastro
    {
        [Required(ErrorMessage = "O nome da biblioteca é obrigatório")]
        [Display(Name = "Nome da biblioteca:")]
        public string Nome { get; set; }

    }
}
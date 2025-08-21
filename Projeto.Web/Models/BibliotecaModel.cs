using System.ComponentModel.DataAnnotations;
namespace Projeto.Web.Models

{
    public class BibliotecaModelConsulta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeLivros { get; set; }
    }

    public class BibliotecaModelCadastro
    {
        [Required(ErrorMessage = "O nome da biblioteca é obrigatório")]
        [StringLength(14, ErrorMessage = "O nome da biblioteca não pode ter mais de 14 caracteres.")]
        [Display(Name = "Nome da biblioteca:")]
        public string Nome { get; set; }

    }

}
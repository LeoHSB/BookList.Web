using System;
using System.Collections.Generic;
namespace Projeto.Data.Entities
{
    /// Classe de entidade
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string ApiKey { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual ICollection<Biblioteca> Biblioteca { get; set; }
    }
}
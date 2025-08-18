using System.Collections.Generic;

namespace Projeto.Data.Entities
{
    public class Biblioteca
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Livro> Livro { get; set; }
    }
}
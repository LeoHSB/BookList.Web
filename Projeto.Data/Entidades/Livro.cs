using System;

namespace Projeto.Data.Entities
{
    public class Livro
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Autor { get; set; }
        public virtual int NumeroPaginas { get; set; }
        public virtual DateTime DataPublicacao { get; set; }
    }
}
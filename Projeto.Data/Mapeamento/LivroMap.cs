using FluentNHibernate.Mapping;
using Projeto.Data.Entities;
namespace Projeto.Data.Mapping
{
    /// Classe de mapeamento da entidade Livro
    public class LivroMap : ClassMap<Livro>
    {
        public LivroMap()
        {
            Table("Livro");
            Id(l => l.Id, "Id").GeneratedBy.Identity();

            Map(l => l.Titulo, "Titulo").Length(200).Not.Nullable();
            Map(l => l.Autor, "Autor").Length(200).Not.Nullable();
            Map(l => l.NumeroPaginas, "NumeroPaginas").Length(50).Not.Nullable();
            Map(l => l.DataPublicacao, "DataPublicacao").Length(50).Not.Nullable();

        }
    }
}

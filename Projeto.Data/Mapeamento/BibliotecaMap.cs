using FluentNHibernate.Mapping;
using Projeto.Data.Entities;
namespace Projeto.Data.Mapping
{
    /// Classe de mapeamento da entidade Biblioteca
    public class BibliotecaMap : ClassMap<Biblioteca>
    {
        public BibliotecaMap()
        {
            Table("Biblioteca");
            Id(b => b.Id, "Id").GeneratedBy.Identity();

            Map(b => b.Nome, "Nome").Length(60).Not.Nullable();
            References(b => b.Usuario, "IdUsuario").Not.Nullable();
            HasMany(b => b.Livro).KeyColumn("IdBiblioteca").Inverse();

        }
    }
}

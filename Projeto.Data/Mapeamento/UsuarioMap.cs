using FluentNHibernate.Mapping; 
using Projeto.Data.Entities;
namespace Projeto.Data.Mapping
{
    /// Classe de mapeamento da entidade Usuario
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario"); 
            Id(u => u.Id, "Id").GeneratedBy.Identity();

            Map(u => u.Nome, "Nome").Length(50).Not.Nullable();
            Map(u => u.Email, "Email").Length(254).Not.Nullable().Unique();
            Map(u => u.Senha, "Senha").Length(40).Not.Nullable();
            Map(u => u.ApiKey, "ApiKey").Length(400).Nullable();
            Map(u => u.DataCadastro, "DataCadastro").Not.Nullable();
            HasMany(u => u.Biblioteca).KeyColumn("IdUsuario").Inverse();

        }
    }
}

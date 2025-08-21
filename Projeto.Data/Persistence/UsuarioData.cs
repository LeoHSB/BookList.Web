using System.Linq;
using NHibernate;
using Projeto.Data.Entities;
using Projeto.Data.Util;
using Projeto.Data.Generics;
namespace Projeto.Data.Persistence
{
    /// <summary>
    /// Classe de persistencia para a entidade Usuario
    /// </summary>
    public class UsuarioData : GenericData<Usuario>
    {
        public bool HasLogin(string Login)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from u in s.Query<Usuario>()
                            where u.Email.Equals(Login)
                            select u;
                return query.Count() > 0;
            }
        }
        public Usuario Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from u in s.Query<Usuario>()
                            where u.Email.Equals(Login)
                            && u.Senha.Equals(Senha)
                            select u;
                return query.FirstOrDefault();
            }
        }
    }
}

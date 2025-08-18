using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
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
                //SQL -> select count(*) from Usuario where Login = ?
                var query = from u in s.Query<Usuario>()
                            where u.Email.Equals(Login)
                            select u;
                //retornar a quantidade obtida...
                return query.Count() > 0;
            }
        }
        public Usuario Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                //SQL -> select * from Usuario where Login=? and Senha=?
                var query = from u in s.Query<Usuario>()
                            where u.Email.Equals(Login)
                            && u.Senha.Equals(Senha)
                            select u;
                //retornar o primeiro registro encontrado
                return query.FirstOrDefault();
            }
        }
    }
}

using NHibernate;
using NHibernate.Linq;
using Projeto.Data.Entities;
using Projeto.Data.Util;
using Projeto.Data.Generics;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Data.Persistence
{
    /// <summary>
    /// Classe de persistencia para a entidade Biblioteca
    /// </summary>
    public class BibliotecaData : GenericData<Biblioteca>
    {
        public IList<Biblioteca> BuscarBibliotecasPorId(int id)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var bibliotecas = s.Query<Biblioteca>()
                                    .Fetch(b => b.Usuario)
                                    .FetchMany(b => b.Livro)
                                    .Where(b => b.Usuario.Id == id)
                                    .ToList()
                                    .Distinct()
                                    .ToList();

                return bibliotecas;
            }
        }
    }
}
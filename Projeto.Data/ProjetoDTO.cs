using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projeto.Data.Dto
{
    //DTO - Data Transfer Object
    public class TarefaDto
    {
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public string Categoria { get; set; }
        public string Usuario { get; set; }
    }
    public class CategoriaDto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}

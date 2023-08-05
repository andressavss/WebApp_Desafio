using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Desafio_BackEnd.Models;

namespace WebApp_Desafio_BackEnd.Interfaces
{
    public interface IDepartamentosDAL
    {
        IEnumerable<Departamento> ListarDepartamentos();
        Departamento ObterDepartamento(int idDepartamento);
        bool GravarDepartamento(int ID, string Descricao);
        bool ExcluirDepartamento(int idDepartamento);
    }
}

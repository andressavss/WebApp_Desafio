using System.Collections.Generic;
using WebApp_Desafio_BackEnd.DataAccess;
using WebApp_Desafio_BackEnd.Interfaces;
using WebApp_Desafio_BackEnd.Models;

namespace WebApp_Desafio_BackEnd.Business
{
    public class DepartamentosBLL : IDepartamentosBLL
    {
        private readonly IDepartamentosDAL _departamentosDAL;

        public DepartamentosBLL(IDepartamentosDAL departamentosDAL)
        {
            _departamentosDAL = departamentosDAL;
        }

        public IEnumerable<Departamento> ListarDepartamentos()
        {
            return _departamentosDAL.ListarDepartamentos();
        }

        public Departamento ObterDepartamento(int idDepartamento)
        {
            return _departamentosDAL.ObterDepartamento(idDepartamento);
        }

        public bool GravarDepartamento(int ID, string Descricao)
        {
            return _departamentosDAL.GravarDepartamento(ID, Descricao);
        }

        public bool ExcluirDepartamento(int idDepartamento)
        {
            return _departamentosDAL.ExcluirDepartamento(idDepartamento);
        }
    }
}

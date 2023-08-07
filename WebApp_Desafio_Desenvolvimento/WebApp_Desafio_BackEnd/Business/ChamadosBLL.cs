using System;
using System.Collections.Generic;
using System.IO;
using WebApp_Desafio_BackEnd.DataAccess;
using WebApp_Desafio_BackEnd.Interfaces;
using WebApp_Desafio_BackEnd.Models;

namespace WebApp_Desafio_BackEnd.Business
{
    public class ChamadosBLL : IChamadosBLL
    {
        private readonly IChamadosDAL _chamadosDAL;

        public ChamadosBLL(IChamadosDAL chamadosDAL)
        {
            _chamadosDAL = chamadosDAL;
        }

        public IEnumerable<Chamado> ListarChamados()
        {
            return _chamadosDAL.ListarChamados();
        }

        public Chamado ObterChamado(int idChamado)
        {
            return _chamadosDAL.ObterChamado(idChamado);
        }       

        public bool GravarChamado(int ID, string Assunto, string Solicitante, int IdDepartamento, DateTime DataAbertura)
        {
            if (DataAbertura < DateTime.Now)
            {
                throw new ArgumentException("Por favor, informe uma data válida.");
            }

            return _chamadosDAL.GravarChamado(ID, Assunto, Solicitante, IdDepartamento, DataAbertura);
        }

        public bool ExcluirChamado(int idChamado)
        {
            return _chamadosDAL.ExcluirChamado(idChamado);
        }

        public List<string> ListarSolicitantes()
        {
            return _chamadosDAL.ListarSolicitantes();
        }
    }
}

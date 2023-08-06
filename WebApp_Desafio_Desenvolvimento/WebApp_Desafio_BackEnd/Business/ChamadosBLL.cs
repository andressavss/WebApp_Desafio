﻿using System;
using System.Collections.Generic;
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
            return _chamadosDAL.GravarChamado(ID, Assunto, Solicitante, IdDepartamento, DataAbertura);
        }

        public bool ExcluirChamado(int idChamado)
        {
            return _chamadosDAL.ExcluirChamado(idChamado);
        }
    }
}

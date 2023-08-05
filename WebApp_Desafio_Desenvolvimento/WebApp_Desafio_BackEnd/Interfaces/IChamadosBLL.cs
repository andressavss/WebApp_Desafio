using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp_Desafio_BackEnd.Models;

namespace WebApp_Desafio_BackEnd.Interfaces
{
    public interface IChamadosBLL
    {
        IEnumerable<Chamado> ListarChamados();
        Chamado ObterChamado(int idChamado);
        bool GravarChamado(int ID, string Assunto, string Solicitante, int IdDepartamento, DateTime DataAbertura);
        bool ExcluirChamado(int idChamado);
    }
}

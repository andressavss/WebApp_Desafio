using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Desafio_API.ViewModels;
using WebApp_Desafio_BackEnd.Business;
using WebApp_Desafio_BackEnd.Interfaces;
using WebApp_Desafio_BackEnd.Models;

namespace WebApp_Desafio_API.Controllers
{
    /// <summary>
    /// DepartamentosController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentosBLL _departamentosBLL;

        public DepartamentosController(IDepartamentosBLL departamentosBLL)
        {
            _departamentosBLL = departamentosBLL;
        }

        /// <summary>
        /// Lista todos os departamento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartamentoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Listar()
        {
            try
            {
                var _lst = _departamentosBLL.ListarDepartamentos();

                var lst = from departamento in _lst
                          select new DepartamentoResponse()
                          {
                              id = departamento.ID,
                              descricao = departamento.Descricao,
                          };

                return Ok(lst);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Obtém dados de um departamento específico
        /// </summary>
        /// <param name="idDepartamento">O ID do departamento a ser obtido</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ChamadoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("{idDepartamento}")]
        public IActionResult Obter([FromRoute] int idDepartamento)
        {
            try
            {
                var _departamento = _departamentosBLL.ObterDepartamento(idDepartamento);

                var departamento = new DepartamentoResponse()
                {
                    id = _departamento.ID,
                    descricao = _departamento.Descricao,
                };

                return Ok(departamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Grava os dados de um departamento
        /// <param name="request.id">Para inserir um novo registro colocar "ID = 0", senão atualizará o registro encontrado</param>
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Gravar([FromBody] DepartamentoRequest request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException("Request não informado.");

                var resultado = _departamentosBLL.GravarDepartamento(request.id, request.descricao);


                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Exclui um departamento específico
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("{idDepartamento}")]
        public IActionResult Excluir([FromRoute] int idDepartamento)
        {
            try
            {
                var resultado = _departamentosBLL.ExcluirDepartamento(idDepartamento);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(422, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

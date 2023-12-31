﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp_Desafio_API.ViewModels;
using WebApp_Desafio_BackEnd.Business;
using WebApp_Desafio_BackEnd.Interfaces;

namespace WebApp_Desafio_API.Controllers
{
    /// <summary>
    /// ChamadosController
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : Controller
    {
        private readonly IChamadosBLL _chamadosBLL;

        public ChamadosController(IChamadosBLL chamadosBLL)
        {
            _chamadosBLL = chamadosBLL;
        }

        /// <summary>
        /// Lista todos os chamados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ChamadoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Listar()
        {
            try
            {
                var _lst = _chamadosBLL.ListarChamados();

                var lst = from chamado in _lst
                          select new ChamadoResponse()
                          {
                              id = chamado.ID,
                              assunto = chamado.Assunto,
                              solicitante = chamado.Solicitante,
                              idDepartamento = chamado.Departamento.ID,
                              departamento = chamado.Departamento.Descricao,
                              dataAbertura = chamado.DataAbertura
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
        /// Obtém dados de um chamado específico
        /// </summary>
        /// <param name="idChamado">O ID do chamado a ser obtido</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ChamadoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("{idChamado}")]
        public IActionResult Obter([FromRoute] int idChamado)
        {
            try
            {
                var _chamado = _chamadosBLL.ObterChamado(idChamado);

                var chamado = new ChamadoResponse()
                              {
                                  id = _chamado.ID,
                                  assunto = _chamado.Assunto,
                                  solicitante = _chamado.Solicitante,
                                  idDepartamento = _chamado.Departamento.ID,
                                  departamento = _chamado.Departamento.Descricao,
                                  dataAbertura = _chamado.DataAbertura
                              };

                return Ok(chamado);
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
        /// Grava os dados de um chamado
        /// <param name="request.id">Para inserir um novo registro colocar "ID = 0", senão atualizará o registro encontrado</param>
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public IActionResult Gravar([FromBody] ChamadoRequest request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException("Request não informado.");

                if (request.dataAbertura < DateTime.Now)
                {
                    throw new ArgumentException("Por favor, informe uma data válida.");
                }

                var resultado = _chamadosBLL.GravarChamado(request.id,
                                                       request.assunto,
                                                       request.solicitante,
                                                       request.idDepartamento,
                                                       request.dataAbertura);

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
        /// Exclui um chamado específico
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("{idChamado}")]
        public IActionResult Excluir([FromRoute] int idChamado)
        {
            try
            {
                var resultado = _chamadosBLL.ExcluirChamado(idChamado);

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
        /// Lista todos os solicitantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Route("Solicitantes")]
        public IActionResult ListarSolicitante()
        {
            try
            {
                var solicitantes = _chamadosBLL.ListarSolicitantes();

                return Ok(solicitantes);
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

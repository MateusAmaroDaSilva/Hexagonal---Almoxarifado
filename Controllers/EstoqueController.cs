using Microsoft.AspNetCore.Mvc;
using System;
using Almoxarifado.DTOs;
using Almoxarifado.Services;

namespace Almoxarifado.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _service;

        public EstoqueController(EstoqueService service)
        {
            _service = service;
        }

        // --- GET METHODS ---

        [HttpGet("listar")]
        public IActionResult Listar()
        {
            var estoque = _service.Listar();
            return Ok(estoque);
        }

        [HttpGet("filtrar")]
        public IActionResult Filtrar([FromQuery] string descricao)
        {
            var resultado = _service.Filtrar(descricao ?? "");
            return Ok(resultado);
        }

        // --- POST METHODS ---

        [HttpPost("adicionar")]
        public IActionResult Adicionar([FromBody] AdicionarItemDto dto)
        {
            try
            {
                _service.Adicionar(dto);
                return Ok(new { Mensagem = "Item processado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpPost("remover-quantidade")]
        public IActionResult RemoverQuantidade([FromBody] RemoverItemDto dto)
        {
            try
            {
                _service.RemoverQuantidade(dto);
                return Ok(new { Mensagem = "Quantidade removida com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        // --- PUT METHODS ---

        [HttpPut("atualizar-quantidade")]
        public IActionResult AtualizarQuantidade([FromBody] AtualizarItemDto dto)
        {
            try
            {
                _service.AtualizarQuantidade(dto);
                return Ok(new { Mensagem = "Quantidade atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        [HttpPut("atualizar-descricao")]
        public IActionResult AtualizarDescricao([FromBody] AtualizarDescricaoDto dto)
        {
            try
            {
                _service.AtualizarDescricao(dto);
                return Ok(new { Mensagem = "Descrição atualizada com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = ex.Message });
            }
        }

        // --- DELETE METHODS ---

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(Guid id)
        {
            _service.Excluir(id);
            return Ok(new { Mensagem = "Item removido definitivamente do estoque." });
        }
    }
}
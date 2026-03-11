using System;
using System.Collections.Generic;
using Almoxarifado.Models;
using Almoxarifado.DTOs;
using Almoxarifado.Interfaces;

namespace Almoxarifado.Services
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _repository;
        public EstoqueService(IEstoqueRepository repository)    
        {
            _repository = repository;
        }

        // --- GET ---
        public List<ItemEstoque> Listar()
        {
            return _repository.ListarTodos();
        }

        public List<ItemEstoque> Filtrar(string descricao)
        {
            return _repository.FiltrarPorDescricao(descricao);
        }

        // --- POST ---
        public void Adicionar(AdicionarItemDto dto)
        {
            if (dto.Quantidade < 0)
                throw new Exception("Não é permitido incluir itens com quantidade negativa.");

            var item = _repository.ObterPorDescricao(dto.Descricao);

            if (item != null)
            {
                item.Quantidade += dto.Quantidade;
                _repository.Atualizar(item);
            }
            else
            {
                var novoItem = new ItemEstoque { Descricao = dto.Descricao, Quantidade = dto.Quantidade };
                _repository.AdicionarNovo(novoItem);
            }
        }

        public void RemoverQuantidade(RemoverItemDto dto)
        {
            if (dto.Quantidade < 0)
                throw new Exception("A quantidade a remover não pode ser negativa.");

            var item = _repository.ObterPorDescricao(dto.Descricao);

            if (item == null)
                throw new Exception("Item não encontrado no estoque.");

            if (item.Quantidade - dto.Quantidade < 0)
                throw new Exception("Não se pode remover itens e ele ficar com quantidade negativa.");

            item.Quantidade -= dto.Quantidade;
            _repository.Atualizar(item);
        }

        // --- PUT ---
        public void AtualizarQuantidade(AtualizarItemDto dto)
        {
            var item = _repository.ObterPorId(dto.Id);
            if (item == null)
                throw new Exception("Item não encontrado.");

            if (dto.NovaQuantidade < 0)
                throw new Exception("Não se pode incluir itens com quantidade negativa.");

            item.Quantidade = dto.NovaQuantidade;
            _repository.Atualizar(item);
        }

        public void AtualizarDescricao(AtualizarDescricaoDto dto)
        {
            var item = _repository.ObterPorId(dto.Id);
            if (item == null)
                throw new Exception("Item não encontrado.");

            if (string.IsNullOrWhiteSpace(dto.NovaDescricao))
                throw new Exception("A nova descrição não pode ser vazia.");

            item.Descricao = dto.NovaDescricao;
            _repository.Atualizar(item);
        }

        // --- DELETE ---
        public void Excluir(Guid id)
        {
            _repository.Remover(id);
        }
    }
}
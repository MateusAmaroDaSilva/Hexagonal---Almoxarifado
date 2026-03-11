using System;
using System.Collections.Generic;
using System.Linq;
using Almoxarifado.Models;
using Almoxarifado.Interfaces;

namespace Almoxarifado.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private static List<ItemEstoque> _bancoDeDados = new List<ItemEstoque>();

        public ItemEstoque ObterPorId(Guid id)
        {
            return _bancoDeDados.FirstOrDefault(i => i.Id == id);
        }

        public ItemEstoque ObterPorDescricao(string descricao)
        {
            return _bancoDeDados.FirstOrDefault(i => i.Descricao.Equals(descricao, StringComparison.OrdinalIgnoreCase));
        }

        public void AdicionarNovo(ItemEstoque item)
        {
            _bancoDeDados.Add(item);
        }

        public void Atualizar(ItemEstoque item)
        {
            var index = _bancoDeDados.FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                _bancoDeDados[index] = item;
            }
        }

        public void Remover(Guid id)
        {
            _bancoDeDados.RemoveAll(i => i.Id == id);
        }

        public List<ItemEstoque> ListarTodos()
        {
            return _bancoDeDados;
        }

        public List<ItemEstoque> FiltrarPorDescricao(string descricao)
        {
            return _bancoDeDados.Where(i => i.Descricao.Contains(descricao, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
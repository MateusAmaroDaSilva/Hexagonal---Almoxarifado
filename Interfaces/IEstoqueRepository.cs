using System.Collections.Generic;
using Almoxarifado.Models;

namespace Almoxarifado.Interfaces
{
    public interface IEstoqueRepository
    {
        ItemEstoque ObterPorId(Guid id);
        ItemEstoque ObterPorDescricao(string descricao);
        void AdicionarNovo(ItemEstoque item);
        void Atualizar(ItemEstoque item);
        void Remover(Guid id);
        List<ItemEstoque> ListarTodos();
        List<ItemEstoque> FiltrarPorDescricao(string descricao);
    }
}
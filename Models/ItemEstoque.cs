namespace Almoxarifado.Models
{
    public class ItemEstoque
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
    }
}
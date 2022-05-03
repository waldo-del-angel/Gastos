namespace CursoBlazor.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public ExpenseType TipoGasto { get; set; }
        public DateTime FechaTransaccion { get; set; }
    }
}

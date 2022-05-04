using CursoBlazor.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace CursoBlazor.Models
{
    public class Expense // : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [Range (1, double.MaxValue, ErrorMessage = "La cantidad necesita ser mayor a cero")]
        
        public decimal Cantidad { get; set; }
        
        [Required]
        
        public string IdCategoria { get; set; }
        
        public Categoria Categoria { get; set; }
        
        public ExpenseType TipoGasto { get; set; }

        [Required]
        [ExpenseTransactionDateValidator(DaysInTheFuture = 30)]
        public DateTime FechaTransaccion { get; set; }

        /*public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (TipoGasto == ExpenseType.Income && Cantidad < 0)
            {
                errors.Add(new ValidationResult("El ingreso no puede menor a cero", new[] { nameof(Cantidad) } ));
            }
            else if (TipoGasto == ExpenseType.Expense && Cantidad > 0)
            {
                errors.Add(new ValidationResult("El gasto no puede mayor a cero", new[] { nameof(Cantidad) }));
            }
            return errors;
        }*/
    }
}

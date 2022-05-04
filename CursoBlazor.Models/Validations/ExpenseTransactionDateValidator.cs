using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBlazor.Models.Validations
{
    public class ExpenseTransactionDateValidator : ValidationAttribute
    {
        public int DaysInTheFuture { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime transactionDate;
            if (DateTime.TryParse(value?.ToString(), out transactionDate))
            {
                if (transactionDate == DateTime.MinValue)
                {
                    return new ValidationResult($"La fecha no puede estar vacía", new[] { validationContext.MemberName });
                } else if (transactionDate > DateTime.Now.AddDays(DaysInTheFuture))
                {
                    return new ValidationResult($"La fecha no puede superar los {DaysInTheFuture} día(s)", new[] { validationContext.MemberName });
                }
                return null;
            }
            return new ValidationResult($"Fecha inválida: {DaysInTheFuture}", new[] { validationContext.MemberName });
        }
    }
}

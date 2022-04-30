using System.ComponentModel.DataAnnotations;

namespace CursoBlazor.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "!El nombre de la categoria es requerido!")]
        public string Name { get; set; }
    }
}
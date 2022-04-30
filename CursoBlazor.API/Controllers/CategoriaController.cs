using CursoBlazor.Data.Repositories;
using CursoBlazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursoBlazor.API.Controllers
{
    [Route("api/cursoblazor/[controller]")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoriaController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await _categoryRepo.GetCategorias());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria(int id)
        {
            return Ok(await _categoryRepo.GetCategoria(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            if(categoria.Name == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre de la categoría podría estar vacío, verifíquelo.");
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _categoryRepo.InsertCategoria(categoria);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> EditCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null) return BadRequest();
            if (categoria.Name.Trim() == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre de la categoría podría estar vacío, verifíquelo.");
            }
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _categoryRepo.UpdateCategoria(categoria);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (id == 0) return BadRequest();
            await _categoryRepo.DeleteCategoria(id);
            return NoContent();
        }
    }
}

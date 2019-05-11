using System.Linq;
using Merenda.DataContext;
using Merenda.Models;
using Merenda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Merenda.Controllers
{
     [Produces("application/json")]
    [Route("api/AlunoLanche")]
    public class AlunoLancheController : Controller
    {
        public AlunoLancheRepository _repository;
        public AlunoLancheController(Context context)
        {
            _repository = new AlunoLancheRepository(context);
        }


        [HttpGet]
        public IQueryable<AlunoLanche> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        [HttpPost]
        public IActionResult Create([FromBody] AlunoLanche entity)
        {
            if (entity == null)
            {
                return BadRequest("A entidade não pode ser null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_repository.Create(entity));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AlunoLanche entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            _repository.Update(entity, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            return Ok();
        }
    }
    
}
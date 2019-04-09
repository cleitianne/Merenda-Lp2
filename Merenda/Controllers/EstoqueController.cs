using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merenda.DataContext;
using Merenda.Models;
using Merenda.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merenda.Controllers
{
    [Produces("application/json")]
    [Route("api/Estoque")]
    public class EstoqueController : Controller
    {
        public EstoqueRepository _repository;
        public EstoqueController(Context context)
        {
            _repository = new EstoqueRepository(context);
        }


        [HttpGet]
        public IQueryable<Estoque> GetAll()
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
        public IActionResult Create([FromBody] Estoque entity)
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
        public IActionResult Update(int id, [FromBody] Estoque entity)
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
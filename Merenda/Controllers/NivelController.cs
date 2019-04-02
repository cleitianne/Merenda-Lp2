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
    [Route("api/Nivel")]
    public class NivelController : Controller
    {

        public NivelRepository _repository;
        public NivelController(Context context)
        {
            _repository = new NivelRepository(context);
        }


        [HttpGet]
        public IQueryable<Nivel> GetAll()
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
        public IActionResult Create([FromBody] Nivel entity)
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
        public IActionResult Update(int id, [FromBody] Nivel entity)
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
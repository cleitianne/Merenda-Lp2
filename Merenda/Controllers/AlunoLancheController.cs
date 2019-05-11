using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Merenda.DataContext;
using Merenda.Filters;
using Merenda.Models;
using Merenda.Repositories;
using Merenda.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Merenda.Controllers
{
     [Produces("application/json")]
    [Route("api/AlunoLanche")]
    public class AlunoLancheController : Controller
    {
        private IMapper _mapper;
        public AlunoLancheRepository _repository;
        public EstoqueRepository _estoqueRepository;
        public AlunoLancheController(Context context, IMapper mapper)
        {
            this._mapper = mapper;
            _repository = new AlunoLancheRepository(context);
            _estoqueRepository = new EstoqueRepository(context);
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
        [HttpGet("Relatorio")]
        public IActionResult GetRelatorio (AlunoLancheFilter filter) {
            Console.WriteLine(filter.Dia);
            var alunoLache = _repository.GetForRelatorio(filter);

            var result = _mapper.Map<IEnumerable<RelatorioViewModel>>(alunoLache);
            return Ok(result);
        }

        [HttpGet("Valor")]
        public IActionResult GetValorGasto (AlunoLancheFilter filter) {
            Console.WriteLine(filter.Dia);
            var valorFinal = 0.0;
            var alunoLache = _repository.GetForRelatorio(filter);
            foreach(var al in alunoLache){
                var  estoque = _estoqueRepository.GetByCOD(al.Lanche.COD_Estoque);
                valorFinal += estoque.Valor;
            }
            
            return Ok(valorFinal);
        }
    }
    
}
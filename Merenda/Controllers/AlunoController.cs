using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Merenda.DataContext;
using Merenda.Models;
using Merenda.Repositories;
using Merenda.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Merenda.Controllers
{
    [Produces("application/json")]
    [Route("api/Aluno")]
    public class AlunoController : Controller
    {   //teste
    
        public AlunoRepository _repository;
        public AlunoController(Context context)
        {
            _repository = new AlunoRepository(context);
        }


        [HttpGet]
        public IQueryable<Aluno> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _repository.GetById(id);
            if(entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Aluno entity)
        {
           if(entity.Curso.Equals("Bacharelado em Ciência da Computação" ) 
              || entity.Curso.Equals("Bacharelado em Engenharia de Aquicultura")
              || entity.Curso.Equals("Licenciatura em Química")
              || entity.Curso.Equals("Tecnologia em Hotelaria")) {
               entity.Nivel = "Superior";
           }
           else if(entity.Curso.Equals("Técnico em Aquicultura" )
              || entity.Curso.Equals("Técnico em Eventos")
              || entity.Curso.Equals("Técnico em Guia de Turismo")
              || entity.Curso.Equals("Técnico em Informática")
              || entity.Curso.Equals("Técnico em Petroquímica")) {
                entity.Nivel = "Tecnico";
            }


            //Console.WriteLine("teste", entity.Nome);
            if(entity == null)
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
        public IActionResult Update(int id, [FromBody] Aluno entity)
        {
            if(entity == null)
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


        [HttpPost]
        [Route("import")]
        public IActionResult Import([FromBody]List<AlunoImport> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                List<AlunoImport> data = value;
                // Console.WriteLine("------------------------");
                // Console.WriteLine(data[0].Nome);
                // Console.WriteLine(data[0].Curso);
                // Console.WriteLine(data[0].Matricula);
                // Console.WriteLine("------------------------");
                foreach(var d in data){
                    var aluno = new Aluno(){
                        Curso = d.Curso,
                        Matricula = d.Matricula,
                        Nome = d.Nome
                    };
                    Create(aluno);
                }
                return Ok();
            }
        }

    }
}
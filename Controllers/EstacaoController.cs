using System;
using System.Collections;
using System.Collections.Generic;
using apiAgenda.models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apiAgenda.Controllers
{
    [Route("api/[controller]")]
    public class EstacaoController: Controller
    {
        private readonly Estacao _estacao;
        
        public EstacaoController(Estacao estacao)
        {
            _estacao = estacao;
        }

        // GET api/estacao
        [HttpGet]
        public IEnumerable<Estacao> ListaEstacoes(){
            return _estacao.GetAll();
        }

        // GET api/estacao/5
        [HttpGet("{id}", Name="getUsuario")]
        public IActionResult GetById(int id){
            var estacao = _estacao.Find(id);
            if(estacao == null){
                return NotFound();
            }else{
                return new ObjectResult(estacao);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Estacao estacao){
            if(estacao == null){
                return BadRequest();
            }else{
                _estacao.addEstacao(estacao);
                return CreatedAtRoute("getUsuario", new{id = estacao.estacaoId}, estacao);
            }
        }

        // GET api/estacao/5
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var estacao = _estacao.Find(id);
            if(estacao == null){
                return NotFound();
            }else{
                _estacao.Remover(id);
                return new ContentResult();
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Estacao UpEstacao){
            if(UpEstacao == null || UpEstacao.estacaoId != id){
                return BadRequest();
            }else{
                var estacao = _estacao.Find(id);
                if(estacao == null){
                    return NotFound();
                }else{
                    estacao.Nome = UpEstacao.Nome;
                    estacao.Tipo = UpEstacao.Tipo;
                    estacao.dadosEnel = UpEstacao.dadosEnel;
                    estacao.operadores = UpEstacao.operadores;
                    estacao.supervisor = UpEstacao.supervisor;

                    _estacao.Update(estacao);
                    return new ContentResult();
                }
            }
        }
    }
}
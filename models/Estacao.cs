using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiAgenda.models
{
    public class Estacao
    {
        private readonly EstacaoDbContext _context;
        //injeção de dependência contexto do banco de dados
        public Estacao(EstacaoDbContext context)
        {
            _context = context;
            //inicialização da lista de operadores
            operadores = new List<Operador>();
        }

        //propriedades da estação
        public int estacaoId { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public List<Operador> operadores { get; set; }
        public Supervisor supervisor { get; set; }
        public DadosEnel dadosEnel { get; set; }


        // metodo que retorna uma lista com todas as estações
        public IEnumerable<Estacao> GetAll()
        {
            var estacoes = _context.Estacao.Include(x => x.operadores)
                                                .ThenInclude(o => o.telefones)
                                            .Include(s => s.supervisor)
                                                .ThenInclude(b => b.telefones)
                                            .Include(d => d.dadosEnel).ToList();

            return estacoes;
        }

        // metodo que retorna a estações pelo id
        public Estacao Find(int id)
        {
            return _context.Estacao.Include(x => x.operadores)
                                       .ThenInclude(o => o.telefones)
                                    .Include(s => s.supervisor)
                                        .ThenInclude(b => b.telefones)
                                    .Include(d => d.dadosEnel)
                                    .FirstOrDefault(Estacao => Estacao.estacaoId == id);
        }

        // metodo que adiciona uma estação
        public void addEstacao(Estacao estacao)
        {
            _context.Estacao.Add(estacao);
            _context.SaveChanges();
        }

        // metodo remove uma estação
        public void Remover(int id)
        {
            var estacao = _context.Estacao.First(e => e.estacaoId == id);
            _context.Remove(estacao);
            _context.SaveChanges();
        }

        // metodo faz alteração na estação
        public void Update(Estacao estacao)
        {
            _context.Estacao.Update(estacao);
            _context.SaveChanges();
        }
    }
}
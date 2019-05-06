using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiAgenda.models
{
    public class Operador
    {
        public Operador()
        {
            telefones = new List<Telefone>();
        }
        public  int OperadorId { get; set; }

        public string  Nome { get; set; }

        public List<Telefone> telefones { get; set; }

        public Estacao Estacao { get; set; }
    }
}
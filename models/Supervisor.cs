using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiAgenda.models
{
    public class Supervisor
    {
        public Supervisor()
        {
            telefones = new List<Telefone>();
        }
        public int SupervisorId { get; set; }
        public string area { get; set; }
        public string nome { get; set; }

        public List<Telefone> telefones {get; set;}
        public int estacaoId { get; set; }
        public Estacao Estacao { get; set; }

    }
}
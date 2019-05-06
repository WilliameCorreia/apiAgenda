using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiAgenda.models
{
    public class DadosEnel
    {
        public int DadosEnelId { get; set; }
        public string nome_cliente { get; set; }
        public string endereco { get; set; }
        public string classe { get; set; }
        public int uc { get; set; }

        public int estacaoId { get; set; }
        public Estacao estacao { get; set; }

    }
}
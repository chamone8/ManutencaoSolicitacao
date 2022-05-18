using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManutencaoSolicitacao.Domain.SolicitacoesDeManutencao
{
    public class Solicitante
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        private Solicitante() { }

        public Solicitante(int identificador, string nome)
        {
            DomainException.LancarQuadro(string.IsNullOrEmpty(nome), "Nome do Solicitante é invalido");

            Identificador = identificador;
            Nome = nome;
        }
    }
}

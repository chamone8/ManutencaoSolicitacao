namespace ManutencaoSolicitacao.Domain.SubsidiarioAggregate
{
    public class Subsidiaria : Entity
    {
        public string Nome { get; private set; }

        public Subsidiaria(string nome)
        {
            DomainException.LancarQuadro(string.IsNullOrEmpty(nome), "Nome do subsidiario esta invalido");

            Nome = nome;
        }
    }
}
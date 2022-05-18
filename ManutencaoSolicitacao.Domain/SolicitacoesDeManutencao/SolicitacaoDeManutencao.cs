using ManutencaoSolicitacao.Domain.SubsidiarioAggregate;

namespace ManutencaoSolicitacao.Domain.SolicitacoesDeManutencao
{
    public class SolicitacaoDeManutencao : Entity
    {
        public Solicitante Solicitante { get; private set; }
        public Subsidiaria Subsidiaria { get; private set; }
        public TipoDeSolicitacaoDeManutencao TipoDeSolicitacaoDeManutencao { get; private set; }
        public string Justificativa { get; private set; }
        public Contrato Contrato { get; private set; }
        public DateTime InicioDesejadoParaManutencao { get; private set; }
        public DateTime DataDaSolicitacao { get; private set; }
        public StatusDaSolicitacao StatusDaSolicitacao { get; private set; }

        private SolicitacaoDeManutencao() { }
        public SolicitacaoDeManutencao(Subsidiaria subsidiaria, int identificadorDoSolicitante, string nomeSolicitante, 
            TipoDeSolicitacaoDeManutencao tipoDeSolicitacaoDeManutencao, string numeroContrato, string nomeDaTerceirizada, 
            string cnpjDaTerceirizada, string gestorDoContrato, DateTime dataFinalDaVigencia, DateTime inicioDesejadoParaManutencao, string justificativa)
        {


            Solicitante = new Solicitante(identificadorDoSolicitante, nomeSolicitante);
            Subsidiaria = subsidiaria;
            TipoDeSolicitacaoDeManutencao = tipoDeSolicitacaoDeManutencao;
            Justificativa = justificativa;
            Contrato = new Contrato(numeroContrato, nomeDaTerceirizada, cnpjDaTerceirizada, gestorDoContrato, dataFinalDaVigencia);
            InicioDesejadoParaManutencao = inicioDesejadoParaManutencao;
            DataDaSolicitacao = DateTime.Now;
            StatusDaSolicitacao = StatusDaSolicitacao.Pendente;

            DomainException.LancarQuadro(Solicitante == null, "Solicitacao Invalida");
            DomainException.LancarQuadro(string.IsNullOrEmpty(Justificativa), "Justificativa Invalida");
            DomainException.LancarQuadro(inicioDesejadoParaManutencao.Date < DateTime.UtcNow, "Solicitacao Invalida");

        }
        public void CancelarSolicitacao()
        {
            StatusDaSolicitacao = StatusDaSolicitacao.Cancelada;
        }
    }
}

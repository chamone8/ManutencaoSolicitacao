using ExpectedObjects;
using ManutencaoSolicitacao.Domain.SolicitacoesDeManutencao;
using ManutencaoSolicitacao.Domain.SubsidiarioAggregate;
using ManutencaoSolicitacao.Test._Util;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace ManutencaoSolicitacao.Test.Domain.SolicitacoesDeManutencao
{
    public class SolicitacoesDeManutencao
    {
        private const int IdentificadorDoSolicitante = 5;
        private const string NomeDoSolicitante = "Felipe";
        private const string NumeroDoContrato = "2547555";
        private const string NomeDaTerceirizadaDoContrato = "Empresa Chamone";
        private const string CnpjDaTerceirizadaDoContrato = "14172257000191";
        private const string GestorDoContrato = "Kleber";
        private readonly DateTime _dataFinalDaVigernciaDoContrato = DateTime.Now.AddDays(2);
        private readonly TipoDeSolicitacaoDeManutencao TipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao.Jardinagem;
        private string _Justificativa = "Grama muito alta";
        private DateTime _InicioDesejadoParaManutecao = DateTime.Now.AddDays(20);


        private Subsidiaria _Subsidiaria = new Subsidiaria(NomeDoSolicitante);

        private SolicitacaoDeManutencao CriarNovaSolicitacao()
        {
            return new SolicitacaoDeManutencao(_Subsidiaria,
                IdentificadorDoSolicitante,
                NomeDoSolicitante,
                TipoDeSolicitacaoDeManutencao,
                NumeroDoContrato,
                NomeDaTerceirizadaDoContrato,
                CnpjDaTerceirizadaDoContrato,
                GestorDoContrato,
                _dataFinalDaVigernciaDoContrato,
                _InicioDesejadoParaManutecao,
                _Justificativa);
        }

        [Fact]
        public void Should_criado_Solicitacao_Manutencao()
        {
            var request = new
            {
                Subsidiaria = _Subsidiaria,
                Solicitante = new Solicitante(IdentificadorDoSolicitante, NomeDoSolicitante),
                TipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao,
                Justificativa = _Justificativa,
                Contrato = new Contrato(NumeroDoContrato, NomeDaTerceirizadaDoContrato, CnpjDaTerceirizadaDoContrato, GestorDoContrato, _dataFinalDaVigernciaDoContrato),
                InicioDesejadoParaManutencao = _InicioDesejadoParaManutecao
            };
            var solicitacaoDeManutencao = CriarNovaSolicitacao();
            request.ToExpectedObject().ShouldMatch(solicitacaoDeManutencao);
        }

        [Fact]
        public void Should_criado_Solicitacao_Manutencao_Ter_Data_Solicitacao_Hoje()
        {
            var dataSolicitacaoEspera = DateTime.Now;
            var solicitacaoDeManutencao = CriarNovaSolicitacao();
            Assert.Equal(dataSolicitacaoEspera.Date, solicitacaoDeManutencao.DataDaSolicitacao.Date);
        }

        [Fact]
        public void Should_criado_Solicitacao_Manutencao_Iniciar_Status_Pendente()
        {
            var statusSolicitacao = StatusDaSolicitacao.Pendente;
            var solicitacaoDeManutencao = CriarNovaSolicitacao();

            Assert.Equal(statusSolicitacao, solicitacaoDeManutencao.StatusDaSolicitacao);
        }

        public void Should_Cancelar_Solicitacao_Manutencao()
        {
            var solicitacaoDeManutencao = CriarNovaSolicitacao();
            solicitacaoDeManutencao.CancelarSolicitacao();
            Assert.Equal(solicitacaoDeManutencao.StatusDaSolicitacao, StatusDaSolicitacao.Cancelada);
        }

        public void Should_Validar_Data_Incio_Manutencao()
        {
            const string mensagemEsperada = "Data inicio da manutencao invalida";
            var dataInvalida = DateTime.Now.AddDays(-1);
            _InicioDesejadoParaManutecao = dataInvalida;

            AssertExtensions.ThrowsWithMessage(() => CriarNovaSolicitacao(), mensagemEsperada);
        }

        public void Should_Validar_Subsidiaria()
        {
            const string mensagemEsperada = "Subdiciaria Invalida";
            _Subsidiaria = null;

            AssertExtensions.ThrowsWithMessage(() => CriarNovaSolicitacao(), mensagemEsperada);
        }
    }
}
using Xunit;
using ManutencaoSolicitacao.Domain.SubsidiarioAggregate;
using ExpectedObjects;
using ManutencaoSolicitacao.Test._Util;

namespace ManutencaoSolicitacao.Test.Domain.SubsidiariaTest
{
    
    public class SubsidiariaTest
    {
        [Fact]
        public void Should_Create_Subsidiaria()
        {
            var expectedSubdiaria = new
            {
                Nome = "Campo Grande"
            };

            var subdiaria = new Subsidiaria(expectedSubdiaria.Nome);
            expectedSubdiaria.ToExpectedObject().ShouldMatch(subdiaria);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Validate_Nome(string nomeInvalido)
        {
            const string MessageExpected = "Nome do subsidiario esta invalido";

            AssertExtensions.ThrowsWithMessage(() => new Subsidiaria(nomeInvalido), MessageExpected);


        }
    }
}
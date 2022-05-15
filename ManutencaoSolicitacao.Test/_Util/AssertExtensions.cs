using ManutencaoSolicitacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ManutencaoSolicitacao.Test._Util
{
    public static class AssertExtensions
    {
        public static void ThrowsWithMessage(Action testCode, string messageExpected)
        {
            var message = Assert.Throws<DomainException>(testCode).Message;
            Assert.Equal(messageExpected, message);
        }
    }
}
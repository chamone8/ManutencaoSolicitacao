namespace ManutencaoSolicitacao.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string mensagem) : base(mensagem) { }

        public static void LancarQuadro(bool regraInvalida, string mensagem)
        {
            if (regraInvalida)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}
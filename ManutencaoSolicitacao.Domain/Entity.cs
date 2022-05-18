namespace ManutencaoSolicitacao.Domain
{
    public class Entity
    {
        public Guid Id { get; }

        public Entity() 
        {
            Id = Guid.NewGuid();    
        }
    }
}
namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        
        public void InformeId(Guid id)
        {
            Id = id;
        }
    }
}

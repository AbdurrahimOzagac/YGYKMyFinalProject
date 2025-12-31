namespace Core.Entities
{
    public interface IEntity
    {
        
    }

    
    public interface IIDEntity : IEntity
    {
        public int Id { get; set; }
    }
}
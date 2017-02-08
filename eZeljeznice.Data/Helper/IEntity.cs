namespace eZeljeznice.Data.Helper
{
    public interface IEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }

    }
}

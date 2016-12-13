namespace EpamTask.PrivateLibrary.Entity.User
{
    public class UserEntity : BaseEntity
    {
        // Review IP: Why new property here? You already have same in base class
        public new int ID { get; set; }
    }
}

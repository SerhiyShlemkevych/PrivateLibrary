namespace EpamTask.PrivateLibrary.Entity
{
    public abstract class BaseEntity
    {
        public int ID { get; set; } // sometime causes crashes in WPF, no idea why.
    }
}

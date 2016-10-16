namespace EpamTask.PrivateLibrary.Entity.Book
{
    public class BookLocationEntity : BaseEntity
    {
        public new int ID { get; set; }
        public int Floor { get; set; }
        public string Shelf { get; set; }
    }
}

namespace EpamTask.PrivateLibrary.Entity.Book
{
    public class BookEntity : BaseEntity
    {
        // Review IP: propery name should be Id (PascalCase)
        public new int ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        // Review IP: Maybe Genre? 
        public string Gendre { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Amount { get; set; }
        public int Floor { get; set; }
        public string Shelf { get; set; }
    }
}

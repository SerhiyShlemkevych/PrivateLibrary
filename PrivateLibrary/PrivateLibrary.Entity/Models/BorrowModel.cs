namespace EpamTask.PrivateLibrary.Entity.Models
{
    public class BorrowModel 
    {
        public int MemberID { get; set; }
        public string Member { get; set; }
        public int BookID { get; set; }   
        public string Title { get; set; }
        public string LendDate { get; set; }
        public string LendedBy { get; set; }
    }
}

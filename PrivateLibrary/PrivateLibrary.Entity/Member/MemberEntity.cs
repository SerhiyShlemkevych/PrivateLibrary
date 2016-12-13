namespace EpamTask.PrivateLibrary.Entity.Member
{
    public class MemberEntity : BaseEntity
    {
        public new int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        // Review IP: i would use DateTime here
        public string JoinDate { get; set; }
        public string SubscriptionStartDate { get; set; }
        public int CurrentBooks { get; set; }
        public string MembershipName { get; set; }
    }
}

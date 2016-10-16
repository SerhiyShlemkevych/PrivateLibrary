namespace EpamTask.PrivateLibrary.Entity.Member
{
    public class MembershipEntity : BaseEntity
    {
        public new int ID { get; set; }
        public string Name { get; set; }
        public int MaxbookAmount { get; set; }
        public int MonthPlan { get; set; }
        public decimal PricePerMonth { get; set; }
        public int OverdueDayLimit { get; set; }
        public decimal OverdueFees { get; set; }
    }
}

namespace GP_DigitalPropertyManegmentApi.Data.Context


{
    public class UserPropertyPayment
    {
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}

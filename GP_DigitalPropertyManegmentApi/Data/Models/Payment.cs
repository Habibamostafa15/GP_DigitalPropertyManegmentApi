namespace GP_DigitalPropertyManegmentApi.Data.Context
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }
    }
}

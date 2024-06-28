namespace SuvenirShop.Models
{
    public class PaymentInfo
    {
        public required string CardNumber { get; set; }
        public required int CardCVV { get; set;}
        public required string CardExpDate { get; set;}
    }
}
namespace Cakeful.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int CakeId { get; set; }
        public Cake Cake { get; set; } = default!;
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}

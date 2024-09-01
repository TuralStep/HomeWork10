namespace HomeWork10.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateOnly OrderDate { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int CustomerId { get; set; }
    }
}

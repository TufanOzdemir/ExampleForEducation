namespace ProductService.Api.Models
{
    public class AddToBasketRequest  
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}

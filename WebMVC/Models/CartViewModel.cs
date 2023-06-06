namespace WebMVC.Models
{
    public class CartViewModel
    {
     
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public int TotalPrice { get; set; }
      
        //public int TotalPrice => Quantity * Price;
       

        //public string Email { get; set; }
        //public IEnumerable<CartViewModel>? CartItems { get; internal set; }
    }
}

       
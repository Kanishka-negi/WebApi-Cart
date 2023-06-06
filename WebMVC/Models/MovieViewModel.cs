namespace WebMVC.Models
{

    public class MovieViewModel
    {

        public int MovieId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public string Logo { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MovieCategory { get; set; } = null!;

       
        public int Quantity { get; set; }
        //public int TotalPrice { get; set; }
        public int TotalPrice => Quantity * Price;
    }
}
    
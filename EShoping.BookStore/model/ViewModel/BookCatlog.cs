namespace EShoping.BookStore.model.ViewModel
{
    public class BookCatlog
    {
        public int BookId { get; set; }
        public string?  BookName { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
        public string? SellerName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EShoping.BookStore.model
{
    public class BookDetails
    {
        [Key]
        public int BooKId { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public string? Auther { get; set; }
        public decimal BookPrice { get; set; }
        public int BookCategory { get; set; }
        public int SellerId { get; set; }

    }
}

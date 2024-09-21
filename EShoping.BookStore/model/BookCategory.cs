using System.ComponentModel.DataAnnotations;

namespace EShoping.BookStore.model
{
    public class BookCategory
    {
        [Key]
        public int BookCategoryId { get; set; }
        public string? BookCategory_Name { get; set; }
    }
}

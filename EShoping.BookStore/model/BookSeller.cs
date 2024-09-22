using System.ComponentModel.DataAnnotations;

namespace EShoping.BookStore.model
{
    public class BookSeller
    {
        [Key]
        public int BookSelletr_Id { get; set; }
        public string BookSeller_Name { get; set; }
       
    }
}

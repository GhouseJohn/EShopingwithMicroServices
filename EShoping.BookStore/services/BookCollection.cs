using EShoping.BookStore.model;
using EShoping.BookStore.model.ViewModel;
using EShoping.BookStore.services.IServices;
using EShoping.BookStore.utility;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EShoping.BookStore.services
{
    public class BookCollection : IBookCollection
    {
        private readonly ApplicationDbContext _context;
        public BookCollection(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookCatlog>> BookCatlog()
        {
            var _bookcatlog = await (from n in _context.BookDetails
                                     join _seller in _context.BookSeller on n.BookCategory equals _seller.BookSelletr_Id
                                     join _cat in _context.BookCategory on n.BookCategory equals _cat.BookCategoryId
                                     select new BookCatlog
                                     {
                                         BookId = n.BooKId,
                                         BookName = n.BookName,
                                         Description = n.BookDescription,
                                         Author = n.Auther,
                                         Price = n.BookPrice,
                                         SellerName = _seller.BookSeller_Name
                                     }).ToListAsync();
            return _bookcatlog;

        }
    }
}

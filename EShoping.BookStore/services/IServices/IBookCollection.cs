using EShoping.BookStore.model.ViewModel;

namespace EShoping.BookStore.services.IServices
{
    public interface IBookCollection
    {
        Task<IEnumerable<BookCatlog>> BookCatlog();
    }
}

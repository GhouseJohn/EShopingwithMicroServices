using Eshoping.GateWay.model.dto;
using EShoping.BookStore.model.ViewModel;
using EShoping.BookStore.services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShoping.BookStore.Controllers
{
    //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookCollectionController : ControllerBase
    {
        private readonly IBookCollection _bookCollection;
        private ResponseDto _response;
        public BookCollectionController(IBookCollection bookCollection)
        {
            _bookCollection = bookCollection;
            _response = new ResponseDto();
        }
        [HttpGet]
        public async Task<ResponseDto> GetBookList()
        {
            try
            {
                IEnumerable<BookCatlog>? _booklist = await _bookCollection.BookCatlog();
                _response.Result = _booklist;
                _response.IsSuccess = true;
                return _response;
            }
            catch (Exception ex)
            {
                _response.ErrorMessages = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;

        }
    }
}

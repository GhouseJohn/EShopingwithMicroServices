using Eshoping.Registration.model.UserRegistartion;
using MediatR;
using System.Collections;

namespace Eshoping.Registration.userRegistrationServices.Query
{
    public class testmethodeCQRS : IRequest<IEnumerable<Test>>
    {
    }

    public class GetRecordById:IRequest<Test> {
        public int Id { get; set; }
        public GetRecordById(int id)
        {
            Id = id;
        }
    }

    public class DeleteRecordById: IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteRecordById(int id)
        {
            Id = id;
        }
    }



}

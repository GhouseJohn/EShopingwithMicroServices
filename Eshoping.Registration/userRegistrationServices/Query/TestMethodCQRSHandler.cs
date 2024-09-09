using Eshoping.Registration.model.UserRegistartion;
using MediatR;


namespace Eshoping.Registration.userRegistrationServices.Query
{
    public class TestMethodCQRSHandler : IRequestHandler<testmethodeCQRS, IEnumerable<Test>>
    {
        private readonly ITestSegrigation IUserregistration;
        public TestMethodCQRSHandler(ITestSegrigation iUserregistration)
        {
            IUserregistration = iUserregistration;
        }

        public async Task<IEnumerable<Test>> Handle(testmethodeCQRS request, CancellationToken cancellationToken)
        {
            var result = await IUserregistration.getName();
            return result ?? Enumerable.Empty<Test>();
        }
    }

    public class GetListByIdHandler : IRequestHandler<GetRecordById, Test>
    {
        private readonly ITestSegrigation IUserregistration;
        public GetListByIdHandler(ITestSegrigation iUserregistration)
        {
                IUserregistration = iUserregistration;
        }
        public async Task<Test> Handle(GetRecordById request, CancellationToken cancellationToken)
        {
            var _result=await IUserregistration.getName(request.Id);
            return _result is not null ? _result : throw new KeyNotFoundException($"No record found with ID {request.Id}");
        }
    }


    public class DeleteRecordByIdHandler : IRequestHandler<DeleteRecordById, bool>
    {
        private readonly ITestSegrigation IUserregistration;
        public DeleteRecordByIdHandler(ITestSegrigation iUserregistration)
        {
            IUserregistration = iUserregistration;
        }
        public async Task<bool> Handle(DeleteRecordById request, CancellationToken cancellationToken)
        {
            bool isRecordDeletes=false;
            var _result = await IUserregistration.getName(request.Id);
            if (_result is not null)
            {
                isRecordDeletes = await IUserregistration.DelteRecordById(request.Id);
            }
            return isRecordDeletes;
        }
    }
}

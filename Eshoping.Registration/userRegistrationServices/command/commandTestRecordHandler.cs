using Eshoping.Registration.model.UserRegistartion;
using MediatR;

namespace Eshoping.Registration.userRegistrationServices.command
{
    public class commandTestRecordHandler : IRequestHandler<commandTestRecordInsertion, bool>
    {
        private readonly ItestSegrigation IUserregistration;
        public commandTestRecordHandler(ItestSegrigation userRegistration)
        {
            this.IUserregistration = userRegistration;
        }
        public async Task<bool> Handle(commandTestRecordInsertion request, CancellationToken cancellationToken)
        {
            bool _result = false;
            var objTest = new Test
            {
                Name = request.Name,
            };
            _result = await IUserregistration.AddRecord(objTest);
            return _result ? true : false;
        }
    }

    public class commandTestRecordUpdationHandler: IRequestHandler<commandTestRecordUpdation, bool>
    {
        private readonly ItestSegrigation IUserregistration;
        public commandTestRecordUpdationHandler(ItestSegrigation userRegistration)
        {
            this.IUserregistration = userRegistration;
        }

        public async Task<bool> Handle(commandTestRecordUpdation request, CancellationToken cancellationToken)
        {
            bool _result=false;
            var objresult = new Test
            {
                ID=request.Id,
                Name = request.Name,
            };
            _result = await IUserregistration.updateTestResult(objresult);
            return _result ? true : false;
        }
    }
}

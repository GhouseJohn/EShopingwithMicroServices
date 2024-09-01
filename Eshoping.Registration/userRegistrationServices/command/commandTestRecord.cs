using Eshoping.Registration.model.UserRegistartion;
using MediatR;

namespace Eshoping.Registration.userRegistrationServices.command
{
    public class commandTestRecordInsertion : IRequest<bool>
    {
        public string Name { get; set; }
        public commandTestRecordInsertion(Test objTest)
        {
            Name = objTest.Name;
        }
    }


    public class commandTestRecordUpdation : IRequest<bool>
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public commandTestRecordUpdation(Test objTest)
        {
            Name = objTest.Name;
            Id = objTest.ID;
        }
    }
}

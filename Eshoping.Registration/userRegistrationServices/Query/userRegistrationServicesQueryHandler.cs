using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.IuserRegistrationServices;
using MediatR;

namespace Eshoping.Registration.userRegistrationServices.Query
{

    public class userRegistrationServicesDistrictQueryHandler : IRequestHandler<DistrictData, IEnumerable<DistrictDetais>>
    {
        private readonly IUserDependencyService IUserDependencyService;
        public userRegistrationServicesDistrictQueryHandler(IUserDependencyService userDependencyService)
        {
            IUserDependencyService = userDependencyService;
        }
        public async Task<IEnumerable<DistrictDetais>> Handle(DistrictData request, CancellationToken cancellationToken)
        {
            IEnumerable<DistrictDetais>? _result = await IUserDependencyService.GetDistrictDetaisAsync();
           return _result;
        }
    }

    public class UserRegistrationServiceCityQueryHandler : IRequestHandler<CountryListData, IEnumerable<CityDetails>>
    {
        private readonly IUserDependencyService IUserDependencyService;
        public UserRegistrationServiceCityQueryHandler(IUserDependencyService userDependencyService)
        {
            IUserDependencyService = userDependencyService;
        }

        public async Task<IEnumerable<CityDetails>> Handle(CountryListData request, CancellationToken cancellationToken)
        {
            IEnumerable<CityDetails>? _result = await IUserDependencyService.GetCityDetailsAsync(request.DistricId);
            return _result;

        }
    }
}

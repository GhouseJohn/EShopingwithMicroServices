using Eshoping.Registration.model.UserRegistartion;
using MediatR;

namespace Eshoping.Registration.userRegistrationServices.Query
{
    public class GenderList : IRequest<IEnumerable<Gender>>
    {
    }

    public class DistrictData : IRequest<IEnumerable<DistrictDetais>> { }

    public class CountryListData : IRequest<IEnumerable<CityDetails>>
    {
        public int DistricId { get; set; }
        public CountryListData(int districId)
        {
            DistricId = districId;
        }
    }
}

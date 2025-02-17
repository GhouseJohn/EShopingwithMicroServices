﻿using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;

namespace Eshoping.Registration.userRegistrationServices.IuserRegistrationServices
{
    public interface IUserRegistartionDependencyService
    {
        Task<IEnumerable<DistrictDetais>> GetDistrictDetaisAsync();
        Task<IEnumerable<CityDetails>> GetCityDetailsAsync(int DistId);
        Task<bool> SaveUserData(UserRegistration userInfo);


    }
}

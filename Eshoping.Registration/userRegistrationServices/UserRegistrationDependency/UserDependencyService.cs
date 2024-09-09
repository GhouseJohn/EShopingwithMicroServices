using AutoMapper;
using Eshoping.Registration.DataBase;
using Eshoping.Registration.model;
using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.IuserRegistrationServices;
using Microsoft.EntityFrameworkCore;

namespace Eshoping.Registration.userRegistrationServices.UserRegistrationDependency
{
    public class UserDependencyService : IUserDependencyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper autoMapper;
        public UserDependencyService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            autoMapper = mapper;
        }
        public async Task<IEnumerable<DistrictDetais>> GetDistrictDetaisAsync()
        {
            var _result = await (from n in _dbContext.DistrictDetais
                                 select n).ToListAsync();
            return _result;
        }
        public async Task<IEnumerable<CityDetails>> GetCityDetailsAsync(int DistId)
        {
            List<CityDetails>? _result = await (from n in _dbContext.CityDetails
                                                where n.DistId == DistId
                                                select n).ToListAsync();
            return _result is not null ? _result : throw new KeyNotFoundException($"No record found with ID {DistId}");
        }


        private async Task<bool> SaveTemporaryAddress( List<TemporaryAddress> temporaryAddress)
        {
            bool isSucess = false;
          await  _dbContext.TemporaryAddress.AddRangeAsync(temporaryAddress);
            int _result = _dbContext.SaveChanges();
            return _result > 0 ? isSucess = true : isSucess;
        }

        private async Task<bool> InsertUserData(UserInfo userInfo)
        {
            bool IsSuccess = false;
           await _dbContext.UserInfo.AddAsync(userInfo);
            int result= await _dbContext.SaveChangesAsync();
            return result > 0? IsSuccess = true: IsSuccess;
        }

        public async Task<bool> SaveUserData(UserRegistration userInfo)
        {
            bool IsSuccess = false;

            return IsSuccess;

        }


    }
}

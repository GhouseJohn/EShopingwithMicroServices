using AutoMapper;
using Eshoping.Registration.DataBase;
using Eshoping.Registration.model;
using Eshoping.Registration.model.JWTAccess;
using Eshoping.Registration.model.UserRegistartion;
using Eshoping.Registration.userRegistrationServices.IuserRegistrationServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Eshoping.Registration.userRegistrationServices.UserRegistrationDependency
{
    public class UserRegistartionDependencyService : IUserRegistartionDependencyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly JwtApplicationDbContext _jwtApplicationDbContext;
        private readonly IMapper autoMapper;
        private readonly IConfiguration configuration;
        public UserRegistartionDependencyService(ApplicationDbContext dbContext, IMapper mapper, IConfiguration configuration, JwtApplicationDbContext jwtApplicationDbContext)
        {
            _dbContext = dbContext;
            autoMapper = mapper;
            this.configuration = configuration;
            _jwtApplicationDbContext = jwtApplicationDbContext;
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


        private async Task<bool> SaveTemporaryAddress(List<TemporaryAddress> temporaryAddress)
        {
            try
            {
                bool isSucess = false;
                await _dbContext.TemporaryAddress.AddRangeAsync(temporaryAddress);
                int _result = await _dbContext.SaveChangesAsync();
                return _result > 0 ? isSucess = true : isSucess;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private async Task<int> InsertUserData(UserInfo userInfo)
        {
            try
            {
                await _dbContext.UserInfo.AddAsync(userInfo);
                await _dbContext.SaveChangesAsync();
                return userInfo.UserId;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<bool> SaveUserData(UserRegistration userInfo)
        {
            bool IsSuccess = false;
            List<TemporaryAddress> tempAddress = autoMapper.Map<List<TemporaryAddress>>(userInfo.TemporaryAddress_model);
            UserInfo _UserInfo = autoMapper.Map<UserInfo>(userInfo);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            // Ensure that you're using a valid connection string
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        int _userId = await this.InsertUserData(_UserInfo);
                        if (_userId > 0)
                        {
                            foreach (var temp in tempAddress)
                            {
                                temp.userId = _userId;
                            }
                        }
                        var _final = tempAddress;
                        bool isinserted = await SaveTemporaryAddress(tempAddress);
                        var _asp = await AspNetUserInsertion(userInfo);
                        transaction.Commit();
                        IsSuccess = true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    return IsSuccess;

                }
            }
        }


        public async Task<bool> AspNetUserInsertion(UserRegistration userRegi)
        {
            try
            {
                bool isSuccess = false;
                AspNetUSer aspNetUSer = new AspNetUSer();
                aspNetUSer.UserName = userRegi.firstName + userRegi.middleName + userRegi.lastName;
                aspNetUSer.Name = userRegi.firstName + userRegi.lastName;
                aspNetUSer.Email = userRegi.email;
                aspNetUSer.PhoneNumber = userRegi.phonenumber;
                aspNetUSer.PasswordHash = "123";
                aspNetUSer.AccessFailedCount = 0;
                aspNetUSer.Id = 1;
                //JWT Connection
                var optionsBuilderJWT = new DbContextOptionsBuilder<JwtApplicationDbContext>();
                string? connectionString_JWT = configuration.GetConnectionString("JwtConnection");
                optionsBuilderJWT.UseSqlServer(connectionString_JWT);

                using (var context = new JwtApplicationDbContext(optionsBuilderJWT.Options))
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        _jwtApplicationDbContext.AspNetUsers.Add(aspNetUSer);
                        await _jwtApplicationDbContext.SaveChangesAsync();
                        transaction.Commit();

                    }
                }

                return isSuccess;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}


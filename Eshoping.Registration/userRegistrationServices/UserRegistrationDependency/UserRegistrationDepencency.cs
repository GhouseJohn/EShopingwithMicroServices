using Eshoping.Registration.userRegistrationServices.IuserRegistrationServices;

namespace Eshoping.Registration.userRegistrationServices.UserRegistrationDependency
{
    public static class UserRegistrationDepencency
    {
        public static IServiceCollection AdduserRegistrationServices(this IServiceCollection services)
        {
            services.AddScoped<ITestSegrigation, TestSegrigation>();
            services.AddScoped<IUserRegistartionDependencyService, UserRegistartionDependencyService>();

            return services;
        }
    }
}

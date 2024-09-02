namespace Eshoping.Registration.userRegistrationServices.UserRegistrationDependency
{
    public static class UserRegistrationDepencency
    {
        public static IServiceCollection AdduserRegistrationServices(this IServiceCollection services)
        {
            services.AddScoped<ITestSegrigation, TestSegrigation>();
            return services;
        }
    }
}

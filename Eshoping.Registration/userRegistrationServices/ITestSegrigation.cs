using Eshoping.Registration.model.UserRegistartion;
using System.Collections;

namespace Eshoping.Registration.userRegistrationServices
{
    public interface ITestSegrigation
    {
        Task<IEnumerable<Test>> getName();
        Task<Test> getName(int id);
        Task<bool> DelteRecordById(int id);
        Task<bool> AddRecord(Test test);
        Task<bool> updateTestResult(Test test);
    }
}

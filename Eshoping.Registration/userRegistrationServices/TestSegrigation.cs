using Eshoping.Registration.DataBase;
using Eshoping.Registration.model.UserRegistartion;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Eshoping.Registration.userRegistrationServices
{
    public class TestSegrigation : ITestSegrigation
    {
        private readonly ApplicationDbContext _dbContext;
        public TestSegrigation(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Test>> getName()
        {
            var x = await (from n in _dbContext.test
                           select n).ToListAsync();
            return x;
        }

        public async Task<Test> getName(int id)
        {
            var _result = await (from n in _dbContext.test
                                 where n.ID == id
                                 select n).FirstOrDefaultAsync();
            return _result is not null ? _result : throw new KeyNotFoundException($"No record found with ID {id}");
        }

        public async Task<bool> DelteRecordById(int id)
        {
            bool IsDeleted = false;
            var _result = await getName(id);
            if (_result is not null)
            {
                _dbContext.test.Remove(_result);
                _ = _dbContext.SaveChangesAsync();
                IsDeleted = true;
            }
            return IsDeleted;
        }

        public async Task<bool> updateTestResult(Test test)
        {
            bool IsDeleted = false;
           // var _testresult = await getName(test.ID);
            var _testresult = await _dbContext.test.FindAsync(test.ID);
            if (_testresult is not null)
            {
                _testresult.Name = test.Name;
                int result = await _dbContext.SaveChangesAsync();
                IsDeleted = result > 0;
            }
            return IsDeleted;
        }

        public async Task<bool> AddRecord(Test test)
        {
            bool isRecordAdded = false;
            _dbContext.Add(test);
            int result = await _dbContext.SaveChangesAsync();
            return result > 0 ? isRecordAdded = true : isRecordAdded;

        }
    }
}

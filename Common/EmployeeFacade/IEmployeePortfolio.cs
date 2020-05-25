using Code.Model.Abstract;
using System.Collections.Generic;

namespace EmployeePortfolio
{
    public interface IEmployeePortfolio
    {
        IEnumerable<IEmployee> Employees { get; }
        IEmployee CrateEmptyEmployee();
        IEmployee Add(IEmployee employee);
        void Update(IEmployee employee);
        bool Delete(IEmployee employee);
    }
}

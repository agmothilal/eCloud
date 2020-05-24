using Code.Model.Abstract;
using System.Collections.Generic;

namespace EmployeePortfolio
{
    public interface IEmployeePortfolio
    {
        IEnumerable<IEmployee> Employees { get; }
        void Add(int id, string firstname, string lastname, string address, string emailId, string mobileNumber);
        void Update(IEmployee employee);
        bool Delete(IEmployee employee);
    }
}

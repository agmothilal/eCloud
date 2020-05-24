using Code.Model.Abstract;

namespace Core.Model
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee Create(int id, string firstname, string lastname, string address, string emailId, string mobileNumber)
        {
            return new Employee { Id = id, Firstname = firstname, Lastname = lastname, Address = address, EMailId = emailId, MobileNumber = mobileNumber };
        }
    }
}

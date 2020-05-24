namespace Code.Model.Abstract
{
    public interface IEmployeeFactory
    {
        IEmployee Create(int id, string firstname, string lastname, string address, string emailId, string mobileNumber);
    }
}

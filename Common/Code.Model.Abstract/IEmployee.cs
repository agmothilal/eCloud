namespace Code.Model.Abstract
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Address { get; set; }
        string EMailId { get; set; }
        string MobileNumber { get; set; }
    }
}

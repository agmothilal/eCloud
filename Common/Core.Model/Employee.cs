using Code.Model.Abstract;

namespace Core.Model
{
    internal class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string EMailId { get; set; }
        public string MobileNumber { get; set; }
    }
}

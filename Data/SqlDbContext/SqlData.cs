using Code.Model.Abstract;
using System.Collections.Generic;

namespace SqlDbContext
{
    public class SqlData : ISqlData
    {
        private readonly IEmployeeFactory _employeeFactory;

        public List<IEmployee> Employees { get; private set; }

        public SqlData(IEmployeeFactory employeeFactory)
        {
            _employeeFactory = employeeFactory;

            Initiate();
        }

        public void Initiate()
        {
            Employees = new List<IEmployee>
            {
                _employeeFactory.Create( 1,  "John", "Premkumar", "123 North Street,IL", "john@gmail.com", "312-776-6676"),
                _employeeFactory.Create( 2,  "Soundar", "Rajan", "39 South Street,WS", "soundar@gmail.com", "458-776-6676"),
                _employeeFactory.Create( 3,  "Muth", "Kumar", "899 North Block,IL", "muthu@gmail.com", "900-776-6676"),
                _employeeFactory.Create( 4,  "Light", "Man", "50 North Street,TX", "ligh@gmail.com", "987-776-6676"),
                _employeeFactory.Create( 5,  "No", "Name", "78 No Street,TX", "naname@gmail.com", "312-776-1988")
            };
        }
    }
}

using Code.Model.Abstract;
using System.Collections.Generic;

namespace SqlDbContext
{
    public interface ISqlData
    {
        List<IEmployee> Employees { get; }
        void Initiate();
    }
}

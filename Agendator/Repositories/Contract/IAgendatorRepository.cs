using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendator.Repositories.Contract
{
    public interface IAgendatorRepository<T>
    {
        IEnumerable<T> GetAllRoles();
    }
}

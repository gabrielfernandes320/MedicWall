using Agendator.Models;
using Agendator.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendator.Repositories.Implementation
{
    public class AgendatorRepository : IAgendatorRepository<Role>
    {

            readonly agendatorContext _agendatorContext;

            public AgendatorRepository(agendatorContext context)
            {
                _agendatorContext = context;
            }

        public IEnumerable<Role> GetAllRoles()
            {
                return _agendatorContext.Role.ToList();
            }
        
    }
}

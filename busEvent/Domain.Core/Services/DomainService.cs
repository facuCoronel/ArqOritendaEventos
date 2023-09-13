using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Services
{
    public abstract class DomainService : DisposableObject, IDomain
    {

        protected DomainService() { }
    }
}

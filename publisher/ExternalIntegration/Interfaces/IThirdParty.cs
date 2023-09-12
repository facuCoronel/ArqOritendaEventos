using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalIntegration.Interfaces
{
    public interface IThirdParty
    {
        Task<bool> SendEvent(Message message);
    }
}

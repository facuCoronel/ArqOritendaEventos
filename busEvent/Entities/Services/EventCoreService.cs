using Domain.Core.Services;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class RedirectToService : DomainService, IRedirectTo
    {
        private readonly IRedirectToepository _EventsCoreRepository;
        public int MyProperty { get; set; }


        public RedirectToService(IRedirectToepository EventsCoreRepository)
        {
            _EventsCoreRepository = EventsCoreRepository;
        }
        public List<EventCore> redirecToSubscribe()
        {
            var result = _EventsCoreRepository.GetAll().ToList();

            return result;
        }




    }
}

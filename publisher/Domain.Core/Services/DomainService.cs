using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Services
{
    public abstract class DomainService : DisposableObject, IDomainService
    {
        protected string? _topicId;
        protected string? _projectId;
        protected Guid _key;
        private readonly IConfiguration _configuration;
        public DomainService(IConfiguration configuration) {
            _configuration = configuration;
            _topicId = _configuration.GetSection("topicId").Value;
            _projectId = _configuration.GetSection("projectId").Value;
            _key = Guid.Parse(_configuration.GetSection("key").Value);
        }
    }
}

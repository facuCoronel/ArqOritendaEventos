using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Domain.Entities
{
    public class Mail
    {
        public string EMail { get; set; }
        public string Message { get; set; }
    }
}

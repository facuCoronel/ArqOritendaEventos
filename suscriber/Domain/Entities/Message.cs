using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        public byte[] Data { get; set; }
        public string TopicId { get; set; }
        public string ProjectId { get; set; }
        public Guid Key { get; set; }

        public Message(byte[] data, string topicId, string projectId, Guid key)
        {
            Data = data;
            TopicId = topicId;
            ProjectId = projectId;
            Key = key;
        }
    }
}

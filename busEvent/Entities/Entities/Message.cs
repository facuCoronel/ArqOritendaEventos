using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Message
    {
        public byte[] Data { get; set; }
        public string TopicId { get; set; }
        public string ProjectId { get; set; }

        public Message(byte[] data, string topicId, string projectId)
        {
            Data = data;
            TopicId = topicId;
            ProjectId = projectId;
        }
    }
}

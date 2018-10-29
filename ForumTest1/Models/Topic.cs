using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ForumTest1.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string topicName { get; set; }
        public string topicText { get; set; }
    }
}

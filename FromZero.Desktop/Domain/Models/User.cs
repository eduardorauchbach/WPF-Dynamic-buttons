using System;

namespace FromZero.Desktop.Domain.Models
{
    public class User
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
        public string Document { get; set; }
        public string Post { get; set; }
        public string PostLocation { get; set; }

        public User(string name, string document, string post, string postLocation)
        {
            Name = name;
            Document = document;
            Post = post;
            PostLocation = postLocation;
        }
    }
}

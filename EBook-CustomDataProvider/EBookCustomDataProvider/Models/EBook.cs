using System;

namespace EBookCustomDataProvider.Models
{
    public class EBook
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string isbn { get; set; }
    }
}

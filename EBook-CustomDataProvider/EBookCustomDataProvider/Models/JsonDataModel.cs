namespace EBookCustomDataProvider.Models
{
    public class JsonDataModel
    {
        public string Error { get; set; }
        public float Time { get; set; }
        public string Total { get; set; }
        public int Page { get; set; }
        public Book[] Books { get; set; }
    }

    public class Book
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string isbn { get; set; }
    }
}

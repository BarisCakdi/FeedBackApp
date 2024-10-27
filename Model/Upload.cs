namespace FeedBackApp.Model
{
    public class Upload
    {
        public string Id { get; set; }
        public int FeedBackId { get; set; }
        public int UserId { get; set; }

        public FeedBack FeedBack { get; set; }

        public User User { get; set; }
    }
}

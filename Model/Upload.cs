namespace FeedBackApp.Model
{
    public class Upload
    {
        public string Id { get; set; }
        public int FeedBackId { get; set; }
        public string? UserId { get; set; }

        public FeedBack FeedBack { get; set; }
       
    }
}

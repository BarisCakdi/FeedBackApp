namespace FeedBackApp.Model
{
    public class Commit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int FeedBackId { get; set; }
        public int? CommitId { get; set; }
        public DateTime Created { get; set; }

    }
}

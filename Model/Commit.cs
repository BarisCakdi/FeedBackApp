namespace FeedBackApp.Model
{
    public class Commit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int FeedBackId { get; set; }
        public int CommitId { get; set; }
        public DateTime Created { get; set; }
        
        
        public User User { get; set; }

        public FeedBack FeedBack { get; set; }
    }
}

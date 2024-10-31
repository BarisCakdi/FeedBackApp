

// dtoCommit.cs

using FeedBackApp.Model;

namespace FeedBackApp.DTOs
{
    public class dtoCommit
    {
        public string Description { get; set; }
        public DateTime Created{ get; set; } // Ek olarak Creation Time
        public string UserId { get; set; } // UserId eklenmeli
        public string UserName { get; set; }
        public int CommitId { get; set; }
        public int FeedBackId { get; set; }
    }
}
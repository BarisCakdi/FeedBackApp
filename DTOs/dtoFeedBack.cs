using System.Data;

namespace FeedBackApp.DTOs
{
    public class dtoFeedBack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public UpdateStatus UpdateStatus { get; set; }


    }
}

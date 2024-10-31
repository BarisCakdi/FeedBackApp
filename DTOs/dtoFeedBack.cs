using FeedBackApp.Model;
using UpdateStatus = System.Data.UpdateStatus;

namespace FeedBackApp.DTOs
{
    public class dtoFeedBack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public string  CategoryName { get; set; }
        public UpdateStatus UpdateStatus { get; set; }
        
    }
}

namespace FeedBackApp.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FeedBack> FeedBacks { get; set; }
        
        //denene
    }
}

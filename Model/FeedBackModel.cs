﻿using System.Text.Json.Serialization;

namespace FeedBackApp.Model
{
    public enum UpdateStatus
    {
        Planed = 1,
        InProgress = 2,
        Live = 3,
        Suggestion = 4
    } 

    public class FeedBack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        
        public int UploadsCount { get; set; }
        
        
        public UpdateStatus UpdateStatus { get; set; }
        public ICollection<Commit> Commits { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public string UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser User { get; set; }
    }
}

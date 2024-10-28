using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace FeedBackApp.Model;


    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public string Nickname { get; set; }
    
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";
        
        
        [NotMapped]
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
    
        [JsonIgnore]
        public ICollection<Commit> Comments { get; set; } = new List<Commit>();
    
        [JsonIgnore]
        public ICollection<Upload> Votes { get; set; } = new List<Upload>();
    }

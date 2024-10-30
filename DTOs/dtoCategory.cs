using FeedBackApp.Model;
using System.Text.Json.Serialization;

namespace FeedBackApp.DTOs;

public class dtoCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    
}
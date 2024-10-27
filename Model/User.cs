﻿namespace FeedBackApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
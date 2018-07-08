using System;

namespace WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebApp.Interfaces;

    public class PostModel : IPostModel
    {
        public PostModel() { }

        public PostModel(IPostModel postModel)
        {
            Id = postModel.Id;
            CreatedAt = postModel.CreatedAt;
            Body = postModel.Body;
            Likes = postModel.Likes;
            Title = postModel.Title;
            UserId = postModel.UserId;
        }

        public int Id { get; set; }

        [Display(Name = "Published at")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm tt}")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Content")]
        public string Body { get; set; }

        public int Likes { get; set; }

        public string Title { get; set; }

        [Display(Name = "Author id")]
        public int UserId { get; set; }
    }
}

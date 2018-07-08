using System;

namespace WebApp.Interfaces
{
    using WebApp.Entities;

    public interface ICommentModel
    {
        string Body { get; set; }
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        int Likes { get; set; }
        int PostId { get; set; }
        Post Post { get; set; }

        int UserId { get; set; }
        User User { get; set; }
        string ToString();
    }
}
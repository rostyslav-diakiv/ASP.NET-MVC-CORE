using System;

namespace WebApp.Interfaces
{
    public interface ICommentModel
    {
        string Body { get; set; }
        DateTime CreatedAt { get; set; }
        int Id { get; set; }
        int Likes { get; set; }
        int PostId { get; set; }
        int UserId { get; set; }

        IPost Post { get; set; }

        string ToString();
    }
}
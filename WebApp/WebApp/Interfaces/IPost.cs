namespace WebApp.Interfaces
{
    using System.Collections.Generic;

    using WebApp.Entities;
    using WebApp.Models;

    public interface IPost : IPostModel
    {
        List<CommentModel> Comments { get; set; }

        User User { get; set; }
    }
}
namespace WebApp.Interfaces
{
    using System.Collections.Generic;

    using WebApp.Entities;
    using WebApp.Models;

    public interface IUser : IUserModel
    {
        List<Post> Posts { get; set; }

        List<TodoModel> TodoModels { get; set; }

        List<CommentModel> CommentsModels { get; set; }
    }
}
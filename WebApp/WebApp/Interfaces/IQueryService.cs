namespace WebApp.Interfaces
{
    using System;
    using System.Collections.Generic;

    using WebApp.Dtos;
    using WebApp.Entities;
    using WebApp.Models;

    public interface IQueryService
    {
        IEnumerable<Tuple<int, string>> GetUserCompletedTodos(int userId);
        IEnumerable<CommentModel> GetUserPostsComments(int userId);
        IEnumerable<Tuple<Post, int>> GetUserPostsCommentsNumber(int userId);
        IEnumerable<User> Query4();
        Query5Model Query5(int userId);
        Query6Model Query6(int postId);
        Post GetPostById(int? id);

        TodoModel GetTodoById(int? id);

        User GetUserById(int? id);

        List<Post> GetUserPosts(int userid);

        List<TodoModel> GetUserTodos(int userid);
    }
}
using System.Collections.Generic;

namespace WebApp.Interfaces
{
    using WebApp.Dtos;
    using WebApp.Entities;
    using WebApp.Models;

    public interface IQueryService
    {
        (IEnumerable<(int id, string name)> todos, int userId) GetUserCompletedTodos(int userId);
        (IEnumerable<CommentModel> comments, int userId) GetUserPostsComments(int userId);
        UserPostComments GetUserPostsCommentsNumber(int userId);
        IEnumerable<User> Query4();
        (User user, Post lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, Post popPost, Post popPostLikes) Query5(int userId);
        (Post post, CommentModel longestComment, CommentModel mostPopComment, int commentsAmount) Query6(int postId);
        void ShowQuery4(IEnumerable<User> users, int skip = 0, int take = 15);
        void ShowQuery5(
            (User user, Post lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, Post popPost, Post
                popPostLikes) complexTuple);
        void ShowQuery6(
            (Post post, CommentModel longestComment, CommentModel mostPopComment, int commentsAmount) complexTuple);
        void ShowUserCompletedTodos(IEnumerable<(int id, string name)> completedTodos, int userId);
        void ShowUserPostsComments(IEnumerable<CommentModel> comments, int userId);
        void ShowUserPostsCommentsNumber(IEnumerable<(Post post, int commentsAmount)> posts, int userId);

        Post GetPostById(int? id);

        TodoModel GetTodoById(int? id);

        User GetUserById(int? id);
    }
}
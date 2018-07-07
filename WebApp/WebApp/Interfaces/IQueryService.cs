using System.Collections.Generic;

namespace WebApp.Interfaces
{
    public interface IQueryService
    {
        (IEnumerable<(int id, string name)> todos, int userId) GetUserCompletedTodos(int userId);
        (IEnumerable<ICommentModel> comments, int userId) GetUserPostsComments(int userId);
        (IEnumerable<(IPost post, int commentsAmount)> posts, int userId) GetUserPostsCommentsNumber(int userId);
        IEnumerable<IUser> Query4();
        (IUser user, IPost lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, IPost popPost, IPost popPostLikes) Query5(int userId);
        (IPost post, ICommentModel longestComment, ICommentModel mostPopComment, int commentsAmount) Query6(int postId);
        void ShowQuery4(IEnumerable<IUser> users, int skip = 0, int take = 15);
        void ShowQuery5((IUser user, IPost lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, IPost popPost, IPost popPostLikes) complexTuple);
        void ShowQuery6((IPost post, ICommentModel longestComment, ICommentModel mostPopComment, int commentsAmount) complexTuple);
        void ShowUserCompletedTodos(IEnumerable<(int id, string name)> completedTodos, int userId);
        void ShowUserPostsComments(IEnumerable<ICommentModel> comments, int userId);
        void ShowUserPostsCommentsNumber(IEnumerable<(IPost post, int commentsAmount)> posts, int userId);
    }
}
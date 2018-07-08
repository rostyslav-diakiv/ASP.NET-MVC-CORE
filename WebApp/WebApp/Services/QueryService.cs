using System;
using System.Collections.Generic;

namespace WebApp.Services
{
    using System.Linq;

    using WebApp.Dtos;
    using WebApp.Entities;
    using WebApp.Interfaces;
    using WebApp.Models;

    public class QueryService : IQueryService
    {
        private readonly IDataManager _dataManager;

        public QueryService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        #region Query #1 +
        public UserPostComments GetUserPostsCommentsNumber(int userId)
        {
            var postWithNumberOfItsCommetns = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                                    ?.Posts.Select(p => (p, p.Comments.Count));

            return new UserPostComments(userId, postWithNumberOfItsCommetns); // (postWithNumberOfItsCommetns, userId);
        }

        public void ShowUserPostsCommentsNumber(IEnumerable<(IPost post, int commentsAmount)> posts, int userId)
        {
            Console.WriteLine("Query #1");
            Console.WriteLine($"Number of comments under User's posts for user with id: {userId}");
            if (posts == null)
            {
                Console.WriteLine($"User with id: {userId} not found"); return;
            }

            foreach (var p in posts)
            {
                Console.WriteLine($"{p}, comments amount: {p.commentsAmount}");
            }
        }

        public Post GetPostById(int? id)
        {
            var post = _dataManager.Users.SelectMany(u => u.Posts.Where(p => p.Id == id)).FirstOrDefault();

            return post as Post;
        }

        public TodoModel GetTodoById(int? id)
        {
            var todo = _dataManager.Users.SelectMany(u => u.TodoModels.Where(p => p.Id == id)).FirstOrDefault();

            return todo as TodoModel;
        }
        
        public User GetUserById(int? id)
        {
            var user = _dataManager.Users.FirstOrDefault(u => u.Id == id);

            return user as User;
        }

        #endregion

        #region Query #2 +
        public (IEnumerable<ICommentModel> comments, int userId) GetUserPostsComments(int userId)
        {
            var comments = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                 ?.Posts.SelectMany(p => p.Comments.Where(c => c.Body.Length < 50));

            return (comments, userId);
        }

        public void ShowUserPostsComments(IEnumerable<ICommentModel> comments, int userId)
        {
            Console.WriteLine("Query #2");
            Console.WriteLine($"Comments below User's posts for user with id: {userId}");
            if (comments == null)
            {
                Console.WriteLine($"User with id: {userId} not found"); return;
            }

            foreach (var c in comments)
            {
                Console.WriteLine(c);
            }
        }
        #endregion

        #region Query #3 +
        public (IEnumerable<(int id, string name)> todos, int userId) GetUserCompletedTodos(int userId)
        {
            var doneTodosForUserById = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                             ?.TodoModels.Where(t => t.IsComplete)
                                                         .Select(t => (Id: t.Id, Name: t.Name));
            return (doneTodosForUserById, userId);
        }

        public void ShowUserCompletedTodos(IEnumerable<(int id, string name)> completedTodos, int userId)
        {
            Console.WriteLine("Query #3");
            Console.WriteLine($"Completed Todos for user with id: {userId}");
            if (completedTodos == null)
            {
                Console.WriteLine($"User with id: {userId} not found"); return;
            }

            foreach (var t in completedTodos)
            {
                Console.WriteLine($"Todo id:{t.id}, name: {t.name}");
            }
        }
        #endregion

        #region Query #4 + 
        // Get Users with Todos
        public IEnumerable<IUser> Query4()
        {
            var sortedUsers = _dataManager.Users.OrderBy(u => u.Name)
                                    .Select(u => new User(u, u.TodoModels.OrderByDescending(t => t.Name.Length)));
            return sortedUsers;
        }

        public void ShowQuery4(IEnumerable<IUser> users, int skip = 0, int take = 15)
        {
            Console.WriteLine("Query #4");
            Console.WriteLine("Users sorted by Name ascending with Todos sorted by Name Lenght by descending:");
            if (users == null)
            {
                Console.WriteLine("Users not found"); return;
            }

            foreach (var u in users.Skip(skip).Take(take))
            {
                Console.WriteLine($"User id: {u.Id}, name: {u.Name}, Todos: ");
                foreach (var t in u.TodoModels)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Query #5 +
        public (IUser user, IPost lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, IPost popPost, IPost popPostLikes) Query5(int userId)
        {
            var tuple = (from u in _dataManager.Users
                         where u.Id == userId
                         select (u, // User 
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Comments.Count,
                                 u.TodoModels.Count(t => !t.IsComplete),
                                 u.Posts.OrderByDescending(p => p.Comments.Count(c => c.Body.Length > 80)).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.Likes).FirstOrDefault())).FirstOrDefault();

            return tuple;
        }

        public void ShowQuery5((IUser user, IPost lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, IPost popPost, IPost popPostLikes) complexTuple)
        {
            Console.WriteLine("Query #5");
            //if (complexTuple == null)
            //{

            //}
            Console.WriteLine(complexTuple.user);
            Console.WriteLine($"Last user's post: {complexTuple.lastPost}");
            Console.WriteLine($"Number of Comments under last user's post: {complexTuple.lastPostCommentsAmount}");
            Console.WriteLine($"Amount of UnCompleted Todos: {complexTuple.uncompletedTasksAmount}");
            const string text = "The most popular user's post (based on amount of";
            Console.WriteLine($"{text} comments that have body lenght more that 80 chars): {complexTuple.popPost}");
            Console.WriteLine($"{text} likes: {complexTuple.popPostLikes}");
        }
        #endregion

        #region Query #6 +
        public (IPost post, ICommentModel longestComment, ICommentModel mostPopComment, int commentsAmount) Query6(int postId)
        {
            var postData = _dataManager.Users.SelectMany(u => u.Posts.Where(p => p.Id == postId)).Select(po => (po,
                                                                                                       po.Comments.OrderByDescending(c => c.Body.Length).FirstOrDefault(),
                                                                                                       po.Comments.OrderByDescending(c => c.Likes).FirstOrDefault(),
                                                                                                       po.Comments.Count(cm => cm.Likes == 0 || cm.Body.Length < 80))).FirstOrDefault();

            return postData;
        }

        public void ShowQuery6((IPost post, ICommentModel longestComment, ICommentModel mostPopComment, int commentsAmount) complexTuple)
        {
            Console.WriteLine("Query #6");
            Console.WriteLine(complexTuple.post);
            Console.WriteLine($"The longest post's comment: {complexTuple.longestComment}");
            Console.WriteLine($"The most liked post's comment: {complexTuple.mostPopComment}");
            Console.WriteLine($"Number of post's comments with 0 likes or with body length less than 80 chars: {complexTuple.commentsAmount}");
        }
        #endregion
    }
}

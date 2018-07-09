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

        #region Get Entities By Id

        public Post GetPostById(int? id)
        {
            var post = _dataManager.Users.SelectMany(u => u.Posts.Where(p => p.Id == id)).FirstOrDefault();

            return post;
        }

        public TodoModel GetTodoById(int? id)
        {
            var todo = _dataManager.Users.SelectMany(u => u.TodoModels.Where(p => p.Id == id)).FirstOrDefault();

            return todo;
        }

        public User GetUserById(int? id)
        {
            var user = _dataManager.Users.FirstOrDefault(u => u.Id == id);

            return user;
        }

        public List<Post> GetUserPosts(int userid)
        {
            var posts = _dataManager.Users.FirstOrDefault(u => u.Id == userid)?.Posts;

            return posts;
        }

        public List<TodoModel> GetUserTodos(int userid)
        {
            var todos = _dataManager.Users.FirstOrDefault(u => u.Id == userid)?.TodoModels;

            return todos;
        }

        #endregion

        #region Query #1 +
        public IEnumerable<Tuple<Post, int>> GetUserPostsCommentsNumber(int userId)
        {
            var postWithNumberOfItsCommetns = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                                    ?.Posts.Select(p => new Tuple<Post, int>(p, p.Comments.Count));

            return postWithNumberOfItsCommetns;
        }
        #endregion

        #region Query #2 +
        public IEnumerable<CommentModel> GetUserPostsComments(int userId)
        {
            var comments = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                 ?.Posts.SelectMany(p => p.Comments.Where(c => c.Body.Length < 50));

            return comments;
        }
        #endregion

        #region Query #3 +
        public IEnumerable<Tuple<int, string>> GetUserCompletedTodos(int userId)
        {
            var doneTodosForUserById = _dataManager.Users.FirstOrDefault(u => u.Id == userId)
                                             ?.TodoModels.Where(t => t.IsComplete)
                                                         .Select(t => new Tuple<int, string>(t.Id, t.Name));
            return doneTodosForUserById;
        }
        #endregion

        #region Query #4 + 
        public IEnumerable<User> Query4()
        {
            var sortedUsers = _dataManager.Users.OrderBy(u => u.Name)
                                    .Select(u => new User(u, u.TodoModels.OrderByDescending(t => t.Name.Length)));
            return sortedUsers;
        }
        #endregion

        #region Query #5 +
        public Query5Model Query5(int userId)
        {
            var tuple = (from u in _dataManager.Users
                         where u.Id == userId
                         select (u, // User 
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.CreatedAt).FirstOrDefault()?.Comments.Count,
                                 u.TodoModels.Count(t => !t.IsComplete),
                                 u.Posts.OrderByDescending(p => p.Comments.Count(c => c.Body.Length > 80)).FirstOrDefault(),
                                 u.Posts.OrderByDescending(p => p.Likes).FirstOrDefault())).FirstOrDefault();

            var model = new Query5Model(tuple);

            return model;
        }
        #endregion

        #region Query #6 +
        public Query6Model Query6(int postId)
        {
            var postData = _dataManager.Users.SelectMany(u => u.Posts.Where(p => p.Id == postId)).Select(po => (po,
                                                                                                       po.Comments.OrderByDescending(c => c.Body.Length).FirstOrDefault(),
                                                                                                       po.Comments.OrderByDescending(c => c.Likes).FirstOrDefault(),
                                                                                                       po.Comments.Count(cm => cm.Likes == 0 || cm.Body.Length < 80))).FirstOrDefault();

            var model = new Query6Model(postData);

            return model;
        }
        #endregion
    }
}

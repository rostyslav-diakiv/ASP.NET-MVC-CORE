﻿namespace WebApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using WebApp.Entities;
    using WebApp.Interfaces;
    using WebApp.Models;

    public class DataManager : IDataManager
    {
        public List<User> Users { get; }

        public DataManager()
        {
            var data = FetchDataFromApi().Result;
            var users = CombineData(data);
            Users = users.ToList();
        }

        private async Task<(List<UserModel> userModels, List<PostModel> postModels, List<CommentModel> commentModels, List<TodoModel> todoModels)> FetchDataFromApi()
        {
            // Fetch and Join data
            using (var handler = new HttpClientHandler())
            using (var client =
                new HttpClient(handler) { BaseAddress = new Uri("https://5b128555d50a5c0014ef1204.mockapi.io/") })
            {
                var usersTask = client.GetAsync("users");
                var postsTask = client.GetAsync("posts");
                var commentsTask = client.GetAsync("comments");
                var todosTask = client.GetAsync("todos");

                var requestsTasks = new[] { usersTask, postsTask, commentsTask, todosTask };

                await Task.WhenAll(requestsTasks).ConfigureAwait(false);

                var readUsersTask = usersTask.Result.Content.ReadAsStringAsync();
                var readPostsTask = postsTask.Result.Content.ReadAsStringAsync();
                var readCommentsTask = commentsTask.Result.Content.ReadAsStringAsync();
                var readTodosTask = todosTask.Result.Content.ReadAsStringAsync();

                var readTasks = new[] { readUsersTask, readPostsTask, readCommentsTask, readTodosTask };

                await Task.WhenAll(readTasks).ConfigureAwait(false);

                var userModels = JsonConvert.DeserializeObject<List<UserModel>>(readUsersTask.Result);
                var postModels = JsonConvert.DeserializeObject<List<PostModel>>(readPostsTask.Result);
                var commentModels = JsonConvert.DeserializeObject<List<CommentModel>>(readCommentsTask.Result);
                var todoModels = JsonConvert.DeserializeObject<List<TodoModel>>(readTodosTask.Result);

                return (userModels, postModels, commentModels, todoModels);
            }
        }

        private IEnumerable<User> CombineData((List<UserModel> userModels, List<PostModel> postModels, List<CommentModel> commentModels, List<TodoModel> todoModels) dataToCombine)
        {
            var users = from um in dataToCombine.userModels
                        join p in (from pm in dataToCombine.postModels
                                join cm in dataToCombine.commentModels on pm.Id equals cm.PostId into cms
                                select new Post(pm, cms)) on um.Id equals p.UserId into ps
                        join tm in dataToCombine.todoModels on um.Id equals tm.UserId into tms
                        join cm in dataToCombine.commentModels on um.Id equals cm.UserId into cms
                        select new User(um, tms, ps, cms);

            var data = LinkEntities(users);

            return data;
        }

        private List<User> LinkEntities(IEnumerable<User> users)
        {
            var combinedData = users.ToList();
            foreach (var u in combinedData)
            {
                foreach (var p in u.Posts)
                {
                    p.User = u;
                    foreach (var c in p.Comments)
                    {
                        c.Post = p;
                        c.User = combinedData.FirstOrDefault(us => us.Id == c.UserId);
                    }
                }

                foreach (var t in u.TodoModels)
                {
                    t.User = u;
                }
            }

            return combinedData;
        }
    }
}

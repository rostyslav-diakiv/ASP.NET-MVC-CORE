namespace WebApp.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using WebApp.Entities;

    public class Query5Model
    {
        public Query5Model((User user, Post lastPost, int? lastPostCommentsAmount, int uncompletedTasksAmount, Post popPost, Post popPostLikes) tuple)
        {
            User = tuple.user;
            LastPost = tuple.lastPost;
            LastPostCommentsAmount = tuple.lastPostCommentsAmount;
            UncompletedTasksAmount = tuple.uncompletedTasksAmount;
            MostPopularPost = tuple.popPost;
            MostPopularPostLikes = tuple.popPostLikes;
        }

        public User User { get; set; }

        [Display(Name = "Last Post")]
        public Post LastPost { get; set; }

        [Display(Name = "Comments below Last Post")]
        public int? LastPostCommentsAmount { get; set; }

        [Display(Name = "Amount of uncompleted Todos")]
        public int UncompletedTasksAmount { get; set; }

        [Display(Name = "The most popular post")]
        public Post MostPopularPost { get; set; }

        [Display(Name = "The most popular post (Likes)")]
        public Post MostPopularPostLikes { get; set; }
    }
}

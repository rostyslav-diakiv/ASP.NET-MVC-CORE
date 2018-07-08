namespace WebApp.Dtos
{
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
        public Post LastPost { get; set; }
        public int? LastPostCommentsAmount { get; set; }
        public int UncompletedTasksAmount { get; set; }
        public Post MostPopularPost { get; set; }
        public Post MostPopularPostLikes { get; set; }
    }
}

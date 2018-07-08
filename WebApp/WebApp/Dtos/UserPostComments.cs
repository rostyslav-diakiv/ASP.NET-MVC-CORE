using System.Collections.Generic;

namespace WebApp.Dtos
{
    using WebApp.Interfaces;

    public class UserPostComments
    {
        public UserPostComments(int userId, IEnumerable<(IPost post, int comAnount)> postWithComments)
        {
            UserId = userId;
            PostWithComments = new List<(IPost post, int comAnount)>(postWithComments);
        }

        public List<(IPost post, int comAnount)> PostWithComments { get; set; }

        public int UserId { get; set; }
    }
}

namespace WebApp.Interfaces
{
    using System.Collections.Generic;
    
    public interface IPost : IPostModel
    {
        List<ICommentModel> Comments { get; set; }
    }
}
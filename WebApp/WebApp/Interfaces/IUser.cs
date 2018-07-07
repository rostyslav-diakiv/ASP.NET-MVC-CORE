namespace WebApp.Interfaces
{
    using System.Collections.Generic;
    
    public interface IUser : IUserModel
    {
        List<IPost> Posts { get; set; }

        List<ITodoModel> TodoModels { get; set; }
    }
}
using System.Collections.Generic;

namespace WebApp.Interfaces
{
    using WebApp.Entities;

    public interface IDataManager
    {
        List<User> Users { get; }
    }
}
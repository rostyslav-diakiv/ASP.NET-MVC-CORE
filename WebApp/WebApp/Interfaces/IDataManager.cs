using System.Collections.Generic;

namespace WebApp.Interfaces
{
    public interface IDataManager
    {
        List<IUser> Users { get; }
    }
}
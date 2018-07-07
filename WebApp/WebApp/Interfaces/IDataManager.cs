using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Interfaces
{
    public interface IDataManager
    {
        Task<IEnumerable<IUser>> PrepareDataForQuerying();
    }
}
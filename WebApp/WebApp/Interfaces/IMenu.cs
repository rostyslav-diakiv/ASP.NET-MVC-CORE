using System.Threading.Tasks;

namespace WebApp.Interfaces
{
    public interface IMenu
    {
        Task SetUp();
        void Start(bool showMenu);
    }
}
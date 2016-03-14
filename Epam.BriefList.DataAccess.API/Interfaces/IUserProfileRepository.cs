using System.Threading.Tasks;
using Epam.BriefList.DataAccess.API.Models;

namespace Epam.BriefList.DataAccess.API.Interfaces
{
    public interface IUserProfileRepository : IRepository<DalUserProfile>
    {
        Task<DalUserProfile> Get(string name);
        Task<bool> UserNameExist(string name);
        Task<bool> UserEmailExist(string email);
        Task<byte[]> GetImage(int id);
    }
}

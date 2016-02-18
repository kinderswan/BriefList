

using System.Threading.Tasks;
using DAL.Interfaces.DALModels;

namespace DAL.Interfaces.Interfaces
{
    public interface IUserProfileRepository : IRepository<DalUserProfile>
    {
        Task<DalUserProfile> Get(string name);
        Task<bool> UserNameExist(string name);
        Task<bool> UserEmailExist(string email);
    }
}

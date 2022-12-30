using DataAccessLayer.Models;

namespace DataAccessLayer.Data
{
    public interface IUserData
    {
        Task DeleteUser(int id);
        Task<IEnumerable<UserModel>> GetAllUser();
        Task<UserModel?> GetUser(int id);
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
    }
}
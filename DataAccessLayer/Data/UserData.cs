using DataAccessLayer.DbAccess;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }
        public async Task<IEnumerable<UserModel>> GetAllUser() =>
          await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.sp_GetAllUser", new { });

        public async Task<UserModel?> GetUser(int id)
        {
            var result = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.sp_GetUser", new { id = id });
            return result.FirstOrDefault();
        }


        public async Task InsertUser(UserModel user) =>
          await _db.SaveData(storedProcedure: "dbo.sp_InsertUser", new { FirstName = user.FirstName, LastName = user.LastName });
        public async Task UpdateUser(UserModel user) =>
                await _db.SaveData(storedProcedure: "dbo.sp_UpdateUser", new { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName });
        public async Task DeleteUser(int id) =>
                await _db.SaveData(storedProcedure: "dbo.sp_DeleteUser", new { id = id });

    }
}

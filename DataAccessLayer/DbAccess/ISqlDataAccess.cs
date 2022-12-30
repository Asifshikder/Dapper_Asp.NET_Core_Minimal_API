namespace DataAccessLayer.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "constring");
        Task SaveData<T>(string storedProcedure, T parameter, string connectionId = "constring");
    }
}